using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.Utilitario;
using Halley.Configuracion;
using Halley.CapaLogica.Ventas;
using Halley.CapaDatos.Ventas;
using Halley.Entidad.Ventas;
using Halley.CapaLogica.Users;
using System.Net;
using Halley.CapaLogica.Empresa;

namespace Halley.Presentacion.Ventas.VentasPavo
{
    public partial class ListComprobante : UITemplateAccess
    {
        #region variables globales

        DataTable dtSerie;
        DataSet dsPedido = new DataSet();
        int NumPedido;
        int ClienteID;
        int VendedorID;
        int IGV;
        int estadoID;
        int? NumVale = null;
        int? formaPago;
        decimal subTotal, TotalIGV, Total;
        string NumComprobante;
        bool validarCheck = false, vale;
        string NomCaja = "";
        DataTable DtCajas = new DataTable();
        CL_Comprobante ObjComprobante = new CL_Comprobante();
        int NumCaja;
        DataTable DtValesConsumo = new DataTable("ValesConsumo");
        DataTable DtBoucher = new DataTable("Boucher");

        string ImpresoraBoletaGranja = AppSettings.ImpresoraBoletaGranja;
        string ImpresoraFacturaGranja = AppSettings.ImpresoraFacturaGranja;
        string ImpresoraTicketGranja = AppSettings.ImpresoraTicketGranja;


        #endregion

        #region constructor
        public ListComprobante()
        {
            InitializeComponent();
        }
        #endregion

        DataTable Dtempresas = new DataTable();
        DataTable DtserieGuias = new DataTable();
        CL_Venta ObjCL_Venta = new CL_Venta();
        DateTime FECHA_IMPRESION;
        #region eventos de los controles

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Limpiar();
                Cursor = Cursors.WaitCursor;

                dsPedido = new DataSet();
                NumPedido = int.Parse(txtNumPedido.Text);
                dsPedido = new CL_OrdenPedido().getOrdenPedido(AppSettings.EmpresaID, AppSettings.SedeID, NumPedido);

                foreach (DataRow fila in dsPedido.Tables["Pedido"].Rows)
                {
                    ClienteID = (int)fila["ClienteID"];
                    lblCliente.Text = fila["RazonSocial"].ToString();
                    lblDocumento.Text = fila["NroDocumento"].ToString();
                    lblDireccion.Text = fila["Direccion"].ToString();
                    label11.Text = fila["TipoDocumento"].ToString();

                    VendedorID = (int)fila["UsuarioID"];
                    lblVendedor.Text = fila["Descripcion"].ToString();
                    lblComentario.Text = fila["Comentario"].ToString();

                    chkExterno.Checked = Convert.ToBoolean(fila["Externa"]);
                    vale = Convert.ToBoolean(fila["Vale"]);

                    if (fila["NumVale"] != DBNull.Value)
                        NumVale = Convert.ToInt32(fila["NumVale"]);

                    if (chkExterno.Checked == true)
                    {
                        CboTipoComprobante.SelectedValue = fila["TipoComprobanteID"];
                        cbTipoPago.SelectedValue = fila["TipoPagoID"];
                        cbFormaPago.SelectedValue = fila["FormaPagoID"];

                        CboTipoComprobante.Enabled = false;
                        cbTipoPago.Enabled = false;
                        cbFormaPago.Enabled = false;
                    }
                    else
                    {
                        //CboTipoComprobante.Text = "[Seleccionar]";
                        //cbTipoPago.Text = "[Seleccionar]";
                        //cbFormaPago.Text = "[Seleccionar]";

                        CboTipoComprobante.Enabled = true;
                        cbTipoPago.Enabled = true;
                        cbFormaPago.Enabled = true;
                    }

                    IGV = (int)fila["IGV"];
                    subTotal = Convert.ToDecimal(fila["SubTotal"]);
                    TotalIGV = Convert.ToDecimal(fila["TotalIGV"]);
                    Total = subTotal + TotalIGV;

                    lblSubTotal.Text = subTotal.ToString("C");
                    lblIGV.Text = TotalIGV.ToString("C");
                    lblTotPagar.Text = Total.ToString("C");

                    tdbgPedidos.SetDataBinding(dsPedido.Tables["detallePedido"], "", true);
                    btnRegistrar.Enabled = true;
                    btnCancelar.Enabled = true;
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListComprobante_Load(object sender, EventArgs e)
        {

            //tarer empresas
            Dtempresas = new CL_Empresas().GetEmpresas();
            DtserieGuias = ObjComprobante.GetSerieGuiasT(AppSettings.SedeID);//las series
            ocultarToolStrip();
            Cargar();
        }

        private void cbComprobante_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CboTipoComprobante.SelectedValue != null)
            {
                DataView dv = new DataView(dtSerie);
                dv.RowFilter = "TipoDocumento='" + CboTipoComprobante.SelectedValue + "'";
                c1Combo.FillC1Combo1(cbSerie, dv.ToTable(), "Serie", "Serie");

                if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 1)//es boleta
                {
                    //tamaño de la boleta
                    printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("BoletaHalley", 510, 550);
                    printDocument1.DefaultPageSettings.Margins.Left = 0;
                    printDocument1.DefaultPageSettings.Margins.Right = 0;
                    printDocument1.DefaultPageSettings.Margins.Top = 0;
                    printDocument1.DefaultPageSettings.Margins.Bottom = 0;
                    printDocument1.OriginAtMargins = true;
                    //printDocument1.DefaultPageSettings.Landscape = false;
                }
                else if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 2)//es factura
                {
                    //tamaño de la Factura
                    printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Facturalley", 845, 550);
                    printDocument1.DefaultPageSettings.Margins.Left = 0;
                    printDocument1.DefaultPageSettings.Margins.Right = 0;
                    printDocument1.DefaultPageSettings.Margins.Top = 0;
                    printDocument1.DefaultPageSettings.Margins.Bottom = 0;
                    printDocument1.OriginAtMargins = true;
                    //printDocument1.DefaultPageSettings.Landscape = false;
                }
                else if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 3)//es ticket
                {
                    printDocument1.DefaultPageSettings.PaperSize.RawKind = (int)System.Drawing.Printing.PaperKind.USStandardFanfold;
                    //MessageBox.Show(printDocument1.DefaultPageSettings.PaperSize.RawKind.ToString());
                }
            }
        }

        private void txtNumPedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter) & Convert.ToDecimal(txtNumPedido.Text.Length) > 0)
            {
                btnBuscar_Click(null, null);
            }
            else
                new TextFunctions().SoloNumero(sender, e, txtNumPedido);
        }

        private void txtNumPedido_TextChanged(object sender, EventArgs e)
        {
            if (txtNumPedido.TextLength != 0)
                btnBuscar.Enabled = true;
            else
                btnBuscar.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void cbTipoPago_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbTipoPago.SelectedValue != null)
            {
                if (cbTipoPago.SelectedValue.ToString() == "1")
                {
                    cbFormaPago.Text = "";
                    cbFormaPago.Enabled = false;
                }
                else
                {
                    cbFormaPago.Text = "[Seleccionar]";
                    cbFormaPago.Enabled = true;
                }
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                errValidar.Clear();

                if (CboTipoComprobante.SelectedValue == null)
                {
                    errValidar.SetError(CboTipoComprobante, "Seleccione el Comprobante");
                    validarCheck = true;
                }
                else
                {
                    //if (CboTipoComprobante.SelectedValue.ToString().Equals("1"))
                    //    printDocument1.PrinterSettings.PrinterName = ImpresoraBoletaGranja;
                    //else if (CboTipoComprobante.SelectedValue.ToString().Equals("1"))
                    //    printDocument1.PrinterSettings.PrinterName = ImpresoraFacturaGranja;
                    //else if (CboTipoComprobante.SelectedValue.ToString().Equals("3"))
                    //    printDocument1.PrinterSettings.PrinterName = ImpresoraTicketGranja;

                    string EMPRESA_ID = "GH";
                    string TIPO_COMPROBANTE = "";
                    if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 1)
                    {
                        TIPO_COMPROBANTE = "BO";
                    }
                    else if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 2)
                    {
                        TIPO_COMPROBANTE = "FA";
                    }
                    else if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 3)
                    {
                        TIPO_COMPROBANTE = "TI";
                    }
                    //ahora se gauradara en una tabla Configuracion.Configuracion

                    DataView DV = new DataView(UTI_Datatables.Dt_Configuracion, "Codigo ='" + "IMP_" + EMPRESA_ID + "_" + TIPO_COMPROBANTE + "'", "", DataViewRowState.CurrentRows);

                    if (DV.Count > 0)
                    {
                        printDocument1.PrinterSettings.PrinterName = DV[0]["Data"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No existe una impresora configurada, por favor agregela", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }


                    if (printDocument1.PrinterSettings.PrinterName == "")
                    {
                        MessageBox.Show("Al parecer no se ha seleccionado la impresora. no se imprimira el comprobante.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Cursor = Cursors.Default;
                        return;
                    }
                }


                if (cbSerie.SelectedValue == null)
                {
                    errValidar.SetError(cbSerie, "Seleccione la serie"); validarCheck = true;
                }
                if (NumCaja == 0)
                {
                    errValidar.SetError(LblCaja, "Seleccione la caja");
                    validarCheck = true;
                }
                if (cbTipoPago.SelectedValue == null)
                {
                    errValidar.SetError(cbTipoPago, "Seleccione el tipo de pago");
                    validarCheck = true;
                }
                else if (cbFormaPago.SelectedValue == null && cbTipoPago.SelectedValue.ToString() != "1")
                {
                    errValidar.SetError(cbFormaPago, "Seleccione la forma de pago");
                    validarCheck = true;
                }

                if (validarCheck == true)
                {
                    Cursor = Cursors.Default;
                    validarCheck = false;
                    return;
                }


                if (cbTipoPago.SelectedValue.ToString().Equals("1"))
                    estadoID = (int)Enums.Comprobante.Pendiente;
                else
                    estadoID = (int)Enums.Comprobante.Pagado;

                if (cbFormaPago.SelectedValue == null)
                    formaPago = null;
                else
                    formaPago = Convert.ToInt32(cbFormaPago.SelectedValue);

                E_Comprobante ObjComprobante = new E_Comprobante();
                E_Pago ObjPago = new E_Pago();

                ObjComprobante.EmpresaID = AppSettings.EmpresaID;
                ObjComprobante.SedeID = AppSettings.SedeID;
                ObjComprobante.TipoComprobanteID = Convert.ToInt32(CboTipoComprobante.SelectedValue);
                ObjComprobante.ClienteID = ClienteID;
                ObjComprobante.Direccion = lblDireccion.Text;
                ObjComprobante.TipoVentaID = 1;
                ObjComprobante.TipoPagoId = Convert.ToInt32(cbTipoPago.SelectedValue);
                ObjComprobante.FormaPagoID = formaPago;
                ObjComprobante.NumCaja = NumCaja;
                ObjComprobante.IGV = IGV;
                ObjComprobante.SubTotal = subTotal;
                ObjComprobante.TotIgv = TotalIGV;
                ObjComprobante.Vendedor = VendedorID;
                ObjComprobante.Cajero = AppSettings.UserID;
                ObjComprobante.Serie = cbSerie.Text;
                ObjComprobante.EstadoID = estadoID;
                ObjComprobante.Externa = chkExterno.Checked;
                ObjComprobante.Vale = vale;
                ObjComprobante.NumVale = NumVale;


                //es provisional
                DataTable dt = new DataTable();
                DataTable DtCuotas = new DataTable();
                dt = new CL_Comprobante().InsertComprobante(ObjComprobante, dsPedido.Tables["detallePedido"], NumPedido, "N", DtValesConsumo, DtBoucher, dt, DtCuotas);
                NumComprobante = dt.Rows[0]["NumComprobante"].ToString();
                FECHA_IMPRESION = Convert.ToDateTime(dt.Rows[0]["FECHA_ACTUAL"].ToString());
                DtValesConsumo.Rows.Clear();// limpiar los vales
                DtBoucher.Rows.Clear();// limpiar los boucher

                printDocument1.Print();

                /*if (ObjComprobante.TipoPagoId == 2)
                {

                    ObjPago.NumComprobante = NumComprobante;
                    ObjPago.TipoComprobanteID = ObjComprobante.TipoComprobanteID;
                    ObjPago.Importe = Total;
                    ObjPago.FormaPagoID = ObjComprobante.FormaPagoID;
                    ObjPago.UsuarioID = ObjComprobante.Cajero;

                    new CL_Pago().InsertPago(ObjPago);

                    FrmPago ObjFrmPago = new FrmPago();
                    ObjFrmPago.TotalPagar = Convert.ToDecimal(Total);
                    ObjFrmPago.ShowDialog();
                }*/

                if (AppSettings.SedeID != "001VU")
                {
                    new CL_Helper().SendMail("VALES DE NAVIDAD", string.Concat("IMPRIMIR LOS VALES ESTE COMPROBANTE : ", NumComprobante), "aaliagame@haller.com.pe");
                }

                MessageBox.Show("El comprobante se generó correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                validarCheck = false;

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Cursor = Cursors.Default;
            }

        }

        #endregion

        #region metodos definidos

        private void Limpiar()
        {
            if (dsPedido.Tables.Count > 0)
                dsPedido.Clear();
            //txtNumPedido.Text = "";
            lblCliente.Text = "";
            lblDocumento.Text = "";
            lblDireccion.Text = "";
            lblVendedor.Text = "";
            lblComentario.Text = "";
            //cbComprobante.Text = "[Seleccionar]";
            //cbSerie.Text = "";
            //cbCaja.Text = "[Seleccionar]";
            //cbTipoPago.Text = "[Seleccionar]";
            // cbFormaPago.Text = "[Seleccionar]";
            lblSubTotal.Text = "0";
            lblTotPagar.Text = "0";
            lblIGV.Text = "0";
            btnRegistrar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void Cargar()
        {
            c1Combo.FillC1Combo1(CboTipoComprobante, new CL_Comprobante().getTipoComprobante(), "NomTipoComprobante", "TipoComprobanteID");
            c1Combo.FillC1Combo1(cbTipoPago, new CL_Comprobante().getTipoPago(), "NomTipoPago", "TipoPagoID");
            c1Combo.FillC1Combo1(cbFormaPago, new CL_Comprobante().getFormaPago(), "NomFormaPago", "FormaPagoID");
            #region optener Nro IP
            String NombreHost;
            String DireccionIP;
            NombreHost = Dns.GetHostName();
            DireccionIP = System.Net.Dns.GetHostByName(NombreHost).AddressList[0] + "";
            //MessageBox.Show(DireccionIP);
            //dar formato a la direccion IP
            string ACU = "";
            string NuevaIP = "";
            for (int X = 0; X < DireccionIP.Length; X++)
            {
                string Valor = DireccionIP.Substring(X, 1);
                if (Valor != ".")
                    ACU += Valor;
                else
                {
                    NuevaIP += ACU.PadLeft(3, '0') + ".";
                    ACU = "";
                }
            }
            NuevaIP += ACU.PadLeft(3, '0');



            //traer impresoras
            CapaLogica.Users.CL_Usuario ObjUsuario = new CapaLogica.Users.CL_Usuario();
            UTI_Datatables.Dt_Configuracion = ObjUsuario.USP_M_CONFIGURACION(2, 0, "", "", "", "", AppSettings.UserID, NuevaIP);

            //traer las cajas de la sede
            DtCajas = ObjComprobante.GetCajasSedeT(NuevaIP);
            if (DtCajas.Rows.Count == 0)
            {
                NumCaja = 0;
                NomCaja = "No existe.";
                MessageBox.Show("Esta direccion IP: #" + DireccionIP + "# no esta asociada a ninguna caja", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                NumCaja = Convert.ToInt32(DtCajas.Rows[0]["Numcaja"]);
                NomCaja = DtCajas.Rows[0]["Descripcion"].ToString();
            }
            #endregion
            LblCaja.Text = NomCaja;
            //c1Combo.FillC1Combo1(cbCaja,new CL_Comprobante().GetCajasSede(AppSettings.EmpresaID + AppSettings.SedeID),"Descripcion","Numcaja");
            dtSerie = new CL_Comprobante().GetSerieComprobantes(AppSettings.EmpresaID + AppSettings.SedeID);
            cbTipoPago.SelectedIndex = 1;
            cbFormaPago.SelectedIndex = 0;
        }

        #endregion

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //formato para alinear los nuimeros a la derecha
            StringFormat formato = new StringFormat();
            formato.Alignment = StringAlignment.Far;
            //formato.LineAlignment = StringAlignment.Far;

            //obtener la cadena del total a pagar
            string TotalPagarLetras = new TextFunctions().enletras(Total.ToString());

            //validar boleta o factura
            #region Boleta
            if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 1)//es boleta
            {
                int sum = 0;
                sum += 12;
                e.Graphics.DrawString(lblCliente.Text, txtNumPedido.Font, Brushes.Black, 70 + AppSettings.BoletaEjeX, 156 + AppSettings.BoletaEjeY); //cliente
                if (lblDireccion.Text.Length >= 30)
                    e.Graphics.DrawString(lblDireccion.Text.Substring(0, 29), txtNumPedido.Font, Brushes.Black, 80 + AppSettings.BoletaEjeX, 186 + AppSettings.BoletaEjeY); //direccion larga
                else
                    e.Graphics.DrawString(lblDireccion.Text, txtNumPedido.Font, Brushes.Black, 80 + AppSettings.BoletaEjeX, 186 + AppSettings.BoletaEjeY); //direccion corta

                //e.Graphics.DrawString(null, txtNumPedido.Font, Brushes.Black, 40 + AppSettings.BoletaEjeX, 166 + AppSettings.BoletaEjeY); //canasta
                e.Graphics.DrawString(lblDocumento.Text, txtNumPedido.Font, Brushes.Black, 326 + AppSettings.BoletaEjeX, 186 + AppSettings.BoletaEjeY); //ruc o DNI
                e.Graphics.DrawString(DateTime.Now.Date.ToString().Substring(0, 10), txtNumPedido.Font, Brushes.Black, 240 + AppSettings.BoletaEjeX, 136 + AppSettings.BoletaEjeY); //dia
                e.Graphics.DrawString(NumComprobante.Substring(2), txtNumPedido.Font, Brushes.Black, 260 + AppSettings.BoletaEjeX, 117 + AppSettings.BoletaEjeY); //numero de comprobante

                int Suma = 238;
                foreach (DataRow Dr in dsPedido.Tables["detallePedido"].Rows)
                {
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["Cantidad"]).ToString("#,##0.00") + " " + "KG", txtNumPedido.Font, Brushes.Black, 65 + AppSettings.BoletaEjeX, Suma + AppSettings.BoletaEjeY, formato); //cantidad + UM
                    e.Graphics.DrawString(Dr["NomProducto"].ToString(), txtNumPedido.Font, Brushes.Black, 75 + AppSettings.BoletaEjeX, Suma + AppSettings.BoletaEjeY); //descripcion o producto
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["PrecioUnitario"]).ToString("#,##0.00"), txtNumPedido.Font, Brushes.Black, 320 + AppSettings.BoletaEjeX, Suma + AppSettings.BoletaEjeY, formato); //precio unitario
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["Importe"]).ToString("#,##0.00"), txtNumPedido.Font, Brushes.Black, 380 + AppSettings.BoletaEjeX, Suma + AppSettings.BoletaEjeY, formato); //valor de venta
                    Suma += 14;
                }

                e.Graphics.DrawString(lblTotPagar.Text, txtNumPedido.Font, Brushes.Black, 370 + AppSettings.BoletaEjeX, 450 + AppSettings.BoletaEjeY, formato); //total
                e.Graphics.DrawString(TotalPagarLetras, txtNumPedido.Font, Brushes.Black, 45 + AppSettings.BoletaEjeX, 424 + AppSettings.BoletaEjeY); //tatal pagar en letras

            }
            #endregion
            #region Factura
            else if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 2)//es factura
            {
                int sum = 0;
                sum += 12;
                e.Graphics.DrawString(lblCliente.Text, txtNumPedido.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 117 + AppSettings.FacturaEjeY); //cliente
                //e.Graphics.DrawString(useCliente2.txtDireccion.Text, TxtPrecio.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 157 + AppSettings.FacturaEjeY); //direccion
                if (lblDireccion.Text.Length >= 95)
                    e.Graphics.DrawString(lblDireccion.Text.Substring(0, 94), txtNumPedido.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 157 + AppSettings.FacturaEjeY); //direccion
                else
                    e.Graphics.DrawString(lblDireccion.Text, txtNumPedido.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 157 + AppSettings.FacturaEjeY); //direccion

                e.Graphics.DrawString(lblDocumento.Text, txtNumPedido.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 182 + AppSettings.FacturaEjeY); //ruc o DNI
                e.Graphics.DrawString(DateTime.Now.Day.ToString(), txtNumPedido.Font, Brushes.Black, 570 + AppSettings.FacturaEjeX, 182 + AppSettings.FacturaEjeY); //dia
                e.Graphics.DrawString(DateTime.Now.ToString("MMMM"), txtNumPedido.Font, Brushes.Black, 650 + AppSettings.FacturaEjeX, 182 + AppSettings.FacturaEjeY); //mes
                e.Graphics.DrawString(DateTime.Now.Year.ToString().Substring(2), txtNumPedido.Font, Brushes.Black, 805 + AppSettings.FacturaEjeX, 182 + AppSettings.FacturaEjeY); //año
                e.Graphics.DrawString(NumComprobante.Substring(2), txtNumPedido.Font, Brushes.Black, 690 + AppSettings.FacturaEjeX, 147 + AppSettings.FacturaEjeY); //numero de comprobante

                int Suma = 230;
                foreach (DataRow Dr in dsPedido.Tables["detallePedido"].Rows)
                {
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["Cantidad"]).ToString("#,##0.00") + " " + "KG", txtNumPedido.Font, Brushes.Black, 80 + AppSettings.FacturaEjeX, Suma + AppSettings.FacturaEjeY, formato); //cantidad + UM
                    e.Graphics.DrawString(Dr["NomProducto"].ToString(), txtNumPedido.Font, Brushes.Black, 110 + AppSettings.FacturaEjeX, Suma + AppSettings.FacturaEjeY); //descripcion o producto
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["PrecioUnitario"]).ToString("#,##0.00"), txtNumPedido.Font, Brushes.Black, 665 + AppSettings.FacturaEjeX, Suma + AppSettings.FacturaEjeY, formato); //precio unitario
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["Importe"]).ToString("#,##0.00"), txtNumPedido.Font, Brushes.Black, 790 + AppSettings.FacturaEjeX, Suma + AppSettings.FacturaEjeY, formato); //valor de venta
                    Suma += 14;
                }
                e.Graphics.DrawString(lblSubTotal.Text, txtNumPedido.Font, Brushes.Black, 790 + AppSettings.FacturaEjeX, 427 + AppSettings.FacturaEjeY, formato); //subtotal
                e.Graphics.DrawString(lblIGV.Text, txtNumPedido.Font, Brushes.Black, 790 + AppSettings.FacturaEjeX, 447 + AppSettings.FacturaEjeY, formato); //igv
                e.Graphics.DrawString(lblTotPagar.Text, txtNumPedido.Font, Brushes.Black, 790 + AppSettings.FacturaEjeX, 477 + AppSettings.FacturaEjeY, formato); //total

                e.Graphics.DrawString(DateTime.Now.Day.ToString(), txtNumPedido.Font, Brushes.Black, 405 + AppSettings.FacturaEjeX, 457 + AppSettings.FacturaEjeY); //dia pie
                e.Graphics.DrawString(DateTime.Now.ToString("MMMM"), txtNumPedido.Font, Brushes.Black, 465 + AppSettings.FacturaEjeX, 457 + AppSettings.FacturaEjeY); //mes pie
                e.Graphics.DrawString(DateTime.Now.Year.ToString().Substring(2), txtNumPedido.Font, Brushes.Black, 545 + AppSettings.FacturaEjeX, 457 + AppSettings.FacturaEjeY); //año pie

                e.Graphics.DrawString(TotalPagarLetras, txtNumPedido.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 407 + AppSettings.FacturaEjeY); //total pagar en letras
            }
            #endregion
            #region ticketera
            if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 3)//es ticket
            {
                //obtener datos de la empresa
                DataView DV = new DataView(Dtempresas);
                //string EmpresaID = "IH";
                DV.RowFilter = "EmpresaID = '" + "GH" + "'";
                string NomEmpresa = DV[0]["NomEmpresa"].ToString();
                string RUC = DV[0]["RUC"].ToString();

                string SerieEticketera;
                string NroAutorizacion;

                //SerieEticketera = CboSerieGuia.Columns["SerieEticketera"].Value.ToString();
                //NroAutorizacion = CboSerieGuia.Columns["NroAutorizacion"].Value.ToString();
                DataView dv1 = new DataView(DtserieGuias, "EmpresaID = '" + "GH" + "' and TipoDocumento = " + CboTipoComprobante.SelectedValue.ToString() + " and Serie = '" + cbSerie.SelectedValue.ToString() + "'", "", DataViewRowState.CurrentRows);
                SerieEticketera = dv1[0]["SerieEticketera"].ToString();
                NroAutorizacion = dv1[0]["NroAutorizacion"].ToString();

                //cambiar el nombre de las columnas
                dsPedido.Tables["detallePedido"].Columns["NomProducto"].ColumnName = "Alias";

                string Formatoticket = ObjCL_Venta.FormatoTicketBoleta(NomEmpresa, AppSettings.NomSede, NumComprobante.Substring(2),
                "Ticket Nro: ", dsPedido.Tables["detallePedido"], RUC, AppSettings.Usuario, Total, NomCaja, SerieEticketera,
                NroAutorizacion, TotalPagarLetras, lblCliente.Text, lblDocumento.Text, lblDireccion.Text, "", true, FECHA_IMPRESION, Total, 0, null, Total);
                e.Graphics.DrawString(Formatoticket, txtNumPedido.Font, Brushes.Black, 0, 0); //total pagar en letras

            }
            #endregion
        }

        private void cbFormaPago_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbFormaPago.SelectedIndex != -1 && cbFormaPago.SelectedValue.ToString() == "5")//es vale
            {
                //aca aparece la ventana de los vales
                FrmValesConsumo ObjFrmValesConsumo = new FrmValesConsumo();
                ObjFrmValesConsumo.ShowDialog();
                if (ObjFrmValesConsumo.DtValesConsumo != null && ObjFrmValesConsumo.DtValesConsumo.Rows.Count > 0)
                    DtValesConsumo = ObjFrmValesConsumo.DtValesConsumo.Copy();
            }
            else if (cbFormaPago.SelectedIndex != -1 && cbFormaPago.SelectedValue.ToString() == "3")//es boucher
            {
                //aca aparece la ventana de los vales
                FrmBoucher ObjFrmBoucher = new FrmBoucher();
                ObjFrmBoucher.ShowDialog();
                if (ObjFrmBoucher.DtBoucher != null && ObjFrmBoucher.DtBoucher.Rows.Count > 0)
                    DtBoucher = ObjFrmBoucher.DtBoucher.Copy();
            }
            else
            {
                if (DtValesConsumo.Rows.Count > 0)
                {
                    MessageBox.Show("Se elimino los vales ingresados, en caso de que decida\npagar con vales vuelva a ingresarlos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (DtBoucher.Rows.Count > 0)
                {
                    MessageBox.Show("Se elimino los boucher, en caso de que decida\npagar con boucher vuelva a ingresarlos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                DtValesConsumo.Rows.Clear();
                DtBoucher.Rows.Clear();
            }
        }
    }
}
