using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.VentasTemp;
using Halley.Configuracion;
using Halley.Utilitario;
using Halley.Presentacion.Mantenimiento;
using System.Configuration;

namespace Halley.Presentacion.VentasTemp
{
    public partial class Ventas8 : UITemplateAccess
    {
        /*#region propiedades
        DataTable _DtProductos;
        public DataTable DtProductos
        {
            get { return _DtProductos; }
            set { _DtProductos = value; }
        }
        #endregion*/
        TextFunctions ObjTextFunctions = new TextFunctions();
        #region Variables
        CL_VentasTemp ObjCL_VentasTemp = new CL_VentasTemp();
        public static DataTable DtClientes = new DataTable();
        public static DataTable DtProductos = new DataTable();
        DataTable DtComprobante = new DataTable();
        DataTable DtTipoDocumento = new DataTable();
        DataTable DtserieGuias = new DataTable();
        DataTable DtCajas = new DataTable();
        string ImpresoraBoletaGranja = AppSettings.ImpresoraBoletaGranja;
        string ImpresoraFacturaGranja = AppSettings.ImpresoraFacturaGranja;
        string NumComprobante = "";

        #endregion
        

        public Ventas8()
        {
            InitializeComponent();
        }

        private void BtnNuevoCliente_Click(object sender, EventArgs e)
        {
            FrmCliente ObjFrmCliente = new FrmCliente();
            ObjFrmCliente.ShowDialog();

        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            //traer los clientes y los productos
            DtClientes = ObjCL_VentasTemp.GetClientes();
            CboClientesCodigo.HoldFields();
            CboClientesCodigo.DataSource = DtClientes;
            CboClientesCodigo.DisplayMember = "Codigo";
            CboClientesCodigo.ValueMember = "ClienteId";

            CboClientesNombre.HoldFields();
            CboClientesNombre.DataSource = DtClientes;
            CboClientesNombre.DisplayMember = "Cliente";
            CboClientesNombre.ValueMember = "ClienteId";

            CboClientesCodigo.Text = "99999999";

            DtProductos = ObjCL_VentasTemp.GetProductos();

            //traer los tipo de documento y las serie de las guias
            DtTipoDocumento = ObjCL_VentasTemp.GetTipoDocumento();

            CboTipoComprobante.HoldFields();
            CboTipoComprobante.DataSource = DtTipoDocumento;
            CboTipoComprobante.DisplayMember = "NomDocumento";
            CboTipoComprobante.ValueMember = "TipoDocumento";

            DtserieGuias = ObjCL_VentasTemp.GetSerieGuias(AppSettings.EmpresaID + AppSettings.SedeID);//las series

            //traer las cajas de la sede
            DtCajas = ObjCL_VentasTemp.GetCajasSede(AppSettings.EmpresaID + AppSettings.SedeID);

            CboCaja.HoldFields();
            CboCaja.DataSource = DtCajas;
            CboCaja.DisplayMember = "Descripcion";
            CboCaja.ValueMember = "Numcaja";

            //crear tabla para enlazar a la grilla
            DtComprobante.Columns.Add("ArticuloId", typeof(Int32));
            DtComprobante.Columns.Add("Codigo",typeof(string));
            DtComprobante.Columns.Add("Articulo",typeof(string));
            DtComprobante.Columns.Add("Simbolo",typeof(string));
            DtComprobante.Columns.Add("Cantidad",typeof(decimal)).DefaultValue = 0;
            DtComprobante.Columns.Add("ValorUnitario", typeof(decimal));
            DtComprobante.Columns.Add("ValorVenta", typeof(decimal)).DefaultValue = 0;
            DtComprobante.Columns.Add("Igv", typeof(decimal)).DefaultValue = 0;
            DtComprobante.Columns.Add("PrecioVenta", typeof(decimal)).DefaultValue = 0;

            TdgDocumento.SetDataBinding(DtComprobante, "", true);


            this.TdgDocumento.Columns[3].Editor = this.c1NELith;// enlazar con control para que acepte solo numeros

            //mostrar cajero
            LblUsuario.Text = AppSettings.Usuario;
            ocultarToolStrip();
        }

        private void CboClientesCodigo_SelectedValueChanged(object sender, EventArgs e)
        {
            TxtDireccion.Value = CboClientesCodigo.Columns["Direccion"].Value;
        }

        private void TdgDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter) | e.KeyChar == (char)(Keys.Left) | e.KeyChar == (char)(Keys.Right))
            {
                decimal Cantidad;
                if (TdgDocumento.Columns["Cantidad"].Value + "" == "")
                    Cantidad = 0;
                else
                    Cantidad = Convert.ToDecimal(TdgDocumento.Columns["Cantidad"].Value);

                BuscarProducto(TdgDocumento.Columns["Codigo"].Value.ToString(), TdgDocumento.Columns["Articulo"].Value.ToString(), Cantidad);
            }
            CalcularTotales();
        }


        private void BuscarProducto(string Codigo, string Articulo, decimal Cantidad)
        {

            DataView Dv = new DataView(DtProductos);
            if (Codigo + "" != "" && Articulo + "" == "")
                Dv.RowFilter = "Codigo = '" + Codigo + "'";
            if (Articulo + "" != "" && Codigo + "" == "")
                Dv.RowFilter = "Articulo like '" + Articulo + "%'";
            if (Codigo + "" != "" && Articulo + "" != "")
                Dv.RowFilter = "Codigo = '" + Codigo + "'";

            if (Dv.Count == 1)
            {
                TdgDocumento.Columns["ArticuloId"].Value = Dv[0]["ArticuloId"];
                TdgDocumento.Columns["Codigo"].Value = Dv[0]["Codigo"];
                TdgDocumento.Columns["Articulo"].Value = Dv[0]["Articulo"];
                TdgDocumento.Columns["ValorUnitario"].Value = Dv[0]["Precio"];
                TdgDocumento.Columns["Simbolo"].Value = Dv[0]["Simbolo"];
                TdgDocumento.Columns["Cantidad"].Value = Cantidad;
            }
            else if (Dv.Count > 1 || Dv.Count == 0)
            {
                FrmListaProductos ObjFrmListaProductos = new FrmListaProductos();
                ObjFrmListaProductos.ShowDialog();
                if (ObjFrmListaProductos.Codigo != null)//validar que no sea vacio para que no lo agregue
                {
                    TdgDocumento.Columns["ArticuloId"].Value = ObjFrmListaProductos.ArticuloId;
                    TdgDocumento.Columns["Codigo"].Value = ObjFrmListaProductos.Codigo;
                    TdgDocumento.Columns["Articulo"].Value = ObjFrmListaProductos.Articulo;
                    TdgDocumento.Columns["ValorUnitario"].Value = ObjFrmListaProductos.ValorUnitario;
                    TdgDocumento.Columns["Simbolo"].Value = ObjFrmListaProductos.Simbolo;
                    TdgDocumento.Columns["Cantidad"].Value = Cantidad;
                }
                ObjFrmListaProductos.Dispose();
            }

        }

        private void CboTipoDocumentos_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CboTipoComprobante.SelectedIndex != -1 & CboTipoComprobante.SelectedValue != null)
            {
                DataView Dv = new DataView(DtserieGuias);
                Dv.RowFilter = "TipoDocumento = '" + CboTipoComprobante.SelectedValue + "'";
                CboSerieGuias.HoldFields();
                CboSerieGuias.DataSource = Dv;
                CboSerieGuias.DisplayMember = "Serie";
                CboSerieGuias.ValueMember = "Serie";

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
                    printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Facturalley", 810, 550);
                    printDocument1.DefaultPageSettings.Margins.Left = 0;
                    printDocument1.DefaultPageSettings.Margins.Right = 0;
                    printDocument1.DefaultPageSettings.Margins.Top = 0;
                    printDocument1.DefaultPageSettings.Margins.Bottom = 0;
                    printDocument1.OriginAtMargins = true;
                    //printDocument1.DefaultPageSettings.Landscape = false;
                }

            }
        }

        /*private void CboSerieGuias_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CboSerieGuias.SelectedIndex != -1)
                TxtNumero.Text = CboSerieGuias.SelectedText + Convert.ToInt64(CboSerieGuias.Columns["Numero"].Value).ToString("0000000");
        }*/

        private void TdgDocumento_BeforeColUpdate(object sender, C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs e)
        {
            if (TdgDocumento.Columns["Cantidad"].Value + "" != "" & TdgDocumento.Columns["ValorUnitario"].Value + "" != "")
            {
                TdgDocumento.Columns["ValorVenta"].Value =  decimal.Round(Convert.ToDecimal(TdgDocumento.Columns["Cantidad"].Value) * Convert.ToDecimal(TdgDocumento.Columns["ValorUnitario"].Value),1);
            }

            if (TdgDocumento.Columns["ValorVenta"].Value + "" != "")
            {
                TdgDocumento.Columns["Igv"].Value = Convert.ToDecimal(TdgDocumento.Columns["ValorVenta"].Value) * 0;
            }

            if (TdgDocumento.Columns["Igv"].Value + "" != "" & TdgDocumento.Columns["ValorUnitario"].Value + "" != "")
            {
                TdgDocumento.Columns["PrecioVenta"].Value = Convert.ToDecimal(TdgDocumento.Columns["Igv"].Value) + Convert.ToDecimal(TdgDocumento.Columns["ValorVenta"].Value);
            }

            CalcularTotales();
        }

        private void CalcularTotales()
        {
            //calcular el total

            decimal TotalIGV = 0;
            decimal TotalValorVenta = 0;
            decimal TotalVentaNeta = 0;
            foreach (DataRow Dr in DtComprobante.Rows) //sumar las cantidades por producto
            {
                TotalIGV += Convert.ToDecimal(Dr["Igv"]);
                TotalValorVenta += Convert.ToDecimal(Dr["ValorVenta"]);
                TotalVentaNeta += Convert.ToDecimal(Dr["PrecioVenta"]);
            }

            TxtIGV.Value = TotalIGV.ToString("N2");
            TxtValorVenta.Value = TotalValorVenta.ToString("N2");
            TxtVentaNeta.Value = TotalVentaNeta.ToString("N2");
        }


        private void TdgDocumento_BeforeUpdate(object sender, C1.Win.C1TrueDBGrid.CancelEventArgs e)
        {
            CalcularTotales();
        }

        private void TdgDocumento_BeforeInsert(object sender, C1.Win.C1TrueDBGrid.CancelEventArgs e)
        {
            //validar el maximo de productos por boleta
            if (TdgDocumento.RowCount > 9)
            {
                MessageBox.Show("Solo se admite 10 productos por Comprobante. Para los proximos productos debera crear otra Comprobante", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
            CalcularTotales();
        }

        private void TdgDocumento_AfterInsert(object sender, EventArgs e)
        {

            CalcularTotales();
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                bool haycero = false;
                string Producto = "";
                foreach (DataRow DrC in DtComprobante.Rows)
                {
                    if (Convert.ToDecimal(DrC["PrecioVenta"]) == 0)
                    {
                        haycero = true;
                        Producto = DrC["Articulo"].ToString();
                    }

                }
                ErrProvider.Clear();
                if (CboTipoComprobante.SelectedValue != null & CboSerieGuias.SelectedValue != null & DtComprobante.Rows.Count > 0 & CboCaja.SelectedValue != null & haycero==false)
                {
                    //crear tabla para poder insertarlo
                    DataTable DtDetalleComprobante = new DataTable();
                    DtDetalleComprobante.TableName = "DetalleComprobante";
                    DtDetalleComprobante.Columns.Add("ArticuloId", typeof(Int16));
                    DtDetalleComprobante.Columns.Add("PrecioUnitario", typeof(decimal));
                    DtDetalleComprobante.Columns.Add("Cantidad", typeof(decimal));

                    foreach (DataRow Dr in DtComprobante.Rows)
                    {
                        DataRow Dr2 = DtDetalleComprobante.NewRow();
                        Dr2["ArticuloId"] = Dr["ArticuloId"];
                        Dr2["PrecioUnitario"] = Dr["ValorUnitario"];
                        Dr2["Cantidad"] = Dr["Cantidad"];
                        DtDetalleComprobante.Rows.Add(Dr2);

                    }
                    //guardar el comprobante
                    if (DtComprobante.Rows.Count > 0)
                    {
                        string xml = new BaseFunctions().GetXML(DtDetalleComprobante).Replace("NewDataSet", "DocumentElement");
                        NumComprobante = ObjCL_VentasTemp.InsertComprobante(AppSettings.EmpresaID + AppSettings.SedeID, Convert.ToInt32(CboCaja.SelectedValue), Convert.ToInt32(CboTipoComprobante.SelectedValue), Convert.ToInt32(CboClientesCodigo.Columns["ClienteId"].Value), CboClientesNombre.Text, TxtDireccion.Text, CboClientesCodigo.Text, null, Convert.ToDecimal(TxtValorVenta.Value), Convert.ToDecimal(TxtIGV.Value), AppSettings.UserID, CboSerieGuias.Text, xml);
                        LblComprobante.Text = "Ultimo Comprobante Agregado: " + NumComprobante.Substring(2);

                        //imprimir la boleta
                        if (Convert.ToInt16(CboTipoComprobante.SelectedValue) ==1)//boleta
                            printDocument1.PrinterSettings.PrinterName = ImpresoraBoletaGranja;
                        else if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 2)//factura
                            printDocument1.PrinterSettings.PrinterName = ImpresoraFacturaGranja;

                        printDocument1.Print();
                        
                        //mostrar formulario para calcular el vuelto
                        FrmPago ObjFrmPago = new FrmPago();
                        ObjFrmPago.TotalPagar = Convert.ToDecimal(TxtVentaNeta.Value);
                        ObjFrmPago.ShowDialog();

                        MessageBox.Show("Se guardo correctamente el comprobante de pago", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DtComprobante.Clear();
                        CboClientesNombre.Text = "CLIENTES VARIOS";
                        TxtValorVenta.Value = 0;
                        TxtIGV.Value = 0;
                        TxtVentaNeta.Value = 0;
                        TxtCanasta.Text = "";
                        TxtDireccion.Text = "";
                    }
                }
                else
                {
                    if (CboTipoComprobante.SelectedValue == null) { ErrProvider.SetError(CboTipoComprobante, "Seleccione primero el tipo de comprobante."); }
                    if (CboSerieGuias.SelectedValue == null) { ErrProvider.SetError(CboSerieGuias, "Seleccione la serie de la guia."); }
                    if (TdgDocumento.RowCount == 0) { ErrProvider.SetError(TdgDocumento, "No hay Registros que procesar."); }
                    if (CboCaja.SelectedValue == null) { ErrProvider.SetError(CboCaja, "No ha seleccionado una caja."); }
                    if (haycero == true) { MessageBox.Show("Hay cero en el precio de venta del producto: " + Producto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ".\t\nmetodo Imprimir()", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }

        private void TdgDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            String CodigoBarra = TdgDocumento.Columns["Codigo"].Value.ToString();
            if (CodigoBarra.Length == 13)
            {
                //descomponer el codigo
                string Codigo = "";
                string Articulo = "";
                decimal Cantidad = 0;
                CodigoBarra = TdgDocumento.Columns["Codigo"].Value.ToString();
                Codigo = CodigoBarra.Substring(3, 4);
                Cantidad = Convert.ToDecimal(CodigoBarra.Substring(7, 5)) / 1000;
                BuscarProducto(Codigo, Articulo, Cantidad);
                TdgDocumento_BeforeColUpdate(null, null);
                CalcularTotales();
                SendKeys.Send("{DOWN}");
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            //formato para alinear los nuimeros a la derecha
            StringFormat formato = new StringFormat();
            formato.Alignment = StringAlignment.Far;
            //formato.LineAlignment = StringAlignment.Far;

            //obtener la cadena del total a pagar
            string TotalPagarLetras = ObjTextFunctions.enletras(TxtVentaNeta.Text);

            //validar boleta o factura
            #region Boleta
            if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 1)//es boleta
            {
                int sum = 0;
                sum += 12;
                e.Graphics.DrawString(CboClientesNombre.Columns["Cliente"].Value.ToString(), TxtValorVenta.Font, Brushes.Black, 70 + AppSettings.BoletaEjeX, 156 + AppSettings.BoletaEjeY); //cliente
                if (TxtDireccion.Text.Length >= 30)
                    e.Graphics.DrawString(TxtDireccion.Text.Substring(0, 29), TxtValorVenta.Font, Brushes.Black, 80 + AppSettings.BoletaEjeX, 186 + AppSettings.BoletaEjeY); //direccion larga
                else
                    e.Graphics.DrawString(TxtDireccion.Text, TxtValorVenta.Font, Brushes.Black, 80 + AppSettings.BoletaEjeX, 186 + AppSettings.BoletaEjeY); //direccion corta

                e.Graphics.DrawString(TxtCanasta.Text, TxtValorVenta.Font, Brushes.Black, 40 + AppSettings.BoletaEjeX, 166 + AppSettings.BoletaEjeY); //canasta
                e.Graphics.DrawString(CboClientesNombre.Columns["Codigo"].Value.ToString(), TxtValorVenta.Font, Brushes.Black, 326 + AppSettings.BoletaEjeX, 186 + AppSettings.BoletaEjeY); //ruc o DNI
                e.Graphics.DrawString(DateTime.Now.Date.ToString().Substring(0, 10), TxtValorVenta.Font, Brushes.Black, 240 + AppSettings.BoletaEjeX, 136 + AppSettings.BoletaEjeY); //dia
                e.Graphics.DrawString(NumComprobante.Substring(2), TxtValorVenta.Font, Brushes.Black, 260 + AppSettings.BoletaEjeX, 117 + AppSettings.BoletaEjeY); //numero de comprobante

                int Suma = 238;
                foreach (DataRow Dr in DtComprobante.Rows)
                {
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["Cantidad"]).ToString("#,##0.00") + " " + Dr["Simbolo"].ToString(), TxtValorVenta.Font, Brushes.Black, 65 + AppSettings.BoletaEjeX, Suma + AppSettings.BoletaEjeY, formato); //cantidad + UM
                    e.Graphics.DrawString(Dr["Articulo"].ToString(), TxtValorVenta.Font, Brushes.Black, 75 + AppSettings.BoletaEjeX, Suma + AppSettings.BoletaEjeY); //descripcion o producto
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["ValorUnitario"]).ToString("#,##0.00"), TxtValorVenta.Font, Brushes.Black, 320 + AppSettings.BoletaEjeX, Suma + AppSettings.BoletaEjeY, formato); //precio unitario
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["ValorVenta"]).ToString("#,##0.00"), TxtValorVenta.Font, Brushes.Black, 380 + AppSettings.BoletaEjeX, Suma + AppSettings.BoletaEjeY, formato); //valor de venta
                    Suma += 14;
                }

                e.Graphics.DrawString(TxtVentaNeta.Text, TxtValorVenta.Font, Brushes.Black, 370 + AppSettings.BoletaEjeX, 450 + AppSettings.BoletaEjeY, formato); //total
                e.Graphics.DrawString(TotalPagarLetras, TxtValorVenta.Font, Brushes.Black, 45 + AppSettings.BoletaEjeX, 424 + AppSettings.BoletaEjeY); //tatal pagar en letras

            }
            #endregion
            #region Factura
            else if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 2)//es factura
            {
                int sum = 0;
                sum += 12;
                e.Graphics.DrawString(CboClientesNombre.Columns["Cliente"].Value.ToString(), TxtValorVenta.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 117 + AppSettings.FacturaEjeY); //cliente
                //e.Graphics.DrawString(TxtDireccion.Text, TxtValorVenta.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 157 + AppSettings.FacturaEjeY); //direccion
                if (TxtDireccion.Text.Length >= 95)
                    e.Graphics.DrawString(TxtDireccion.Text.Substring(0, 94), TxtValorVenta.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 157 + AppSettings.FacturaEjeY); //direccion
                else
                    e.Graphics.DrawString(TxtDireccion.Text, TxtValorVenta.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 157 + AppSettings.FacturaEjeY); //direccion

                e.Graphics.DrawString(CboClientesNombre.Columns["Codigo"].Value.ToString(), TxtValorVenta.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 182 + AppSettings.FacturaEjeY); //ruc o DNI
                e.Graphics.DrawString(DateTime.Now.Day.ToString(), TxtValorVenta.Font, Brushes.Black, 570 + AppSettings.FacturaEjeX, 182 + AppSettings.FacturaEjeY); //dia
                e.Graphics.DrawString(DateTime.Now.ToString("MMMM"), TxtValorVenta.Font, Brushes.Black, 650 + AppSettings.FacturaEjeX, 182 + AppSettings.FacturaEjeY); //mes
                e.Graphics.DrawString(DateTime.Now.Year.ToString().Substring(2), TxtValorVenta.Font, Brushes.Black, 805 + AppSettings.FacturaEjeX, 182 + AppSettings.FacturaEjeY); //año
                e.Graphics.DrawString(NumComprobante.Substring(2), TxtValorVenta.Font, Brushes.Black, 690 + AppSettings.FacturaEjeX, 147 + AppSettings.FacturaEjeY); //numero de comprobante

                int Suma = 230;
                foreach (DataRow Dr in DtComprobante.Rows)
                {
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["Cantidad"]).ToString("#,##0.00") + " " + Dr["Simbolo"].ToString(), TxtValorVenta.Font, Brushes.Black, 80 + AppSettings.FacturaEjeX, Suma + AppSettings.FacturaEjeY, formato); //cantidad + UM
                    e.Graphics.DrawString(Dr["Articulo"].ToString(), TxtValorVenta.Font, Brushes.Black, 110 + AppSettings.FacturaEjeX, Suma + AppSettings.FacturaEjeY); //descripcion o producto
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["ValorUnitario"]).ToString("#,##0.00"), TxtValorVenta.Font, Brushes.Black, 665 + AppSettings.FacturaEjeX, Suma + AppSettings.FacturaEjeY, formato); //precio unitario
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["ValorVenta"]).ToString("#,##0.00"), TxtValorVenta.Font, Brushes.Black, 790 + AppSettings.FacturaEjeX, Suma + AppSettings.FacturaEjeY, formato); //valor de venta
                    Suma += 14;
                }

                e.Graphics.DrawString(TxtValorVenta.Text, TxtValorVenta.Font, Brushes.Black, 790 + AppSettings.FacturaEjeX, 427 + AppSettings.FacturaEjeY, formato); //subtotal
                e.Graphics.DrawString(TxtIGV.Text, TxtValorVenta.Font, Brushes.Black, 790 + AppSettings.FacturaEjeX, 447 + AppSettings.FacturaEjeY, formato); //igv
                e.Graphics.DrawString(TxtVentaNeta.Text, TxtValorVenta.Font, Brushes.Black, 790 + AppSettings.FacturaEjeX, 477 + AppSettings.FacturaEjeY, formato); //total

                e.Graphics.DrawString(DateTime.Now.Day.ToString(), TxtValorVenta.Font, Brushes.Black, 405 + AppSettings.FacturaEjeX, 457 + AppSettings.FacturaEjeY); //dia pie
                e.Graphics.DrawString(DateTime.Now.ToString("MMMM"), TxtValorVenta.Font, Brushes.Black, 465 + AppSettings.FacturaEjeX, 457 + AppSettings.FacturaEjeY); //mes pie
                e.Graphics.DrawString(DateTime.Now.Year.ToString().Substring(2), TxtValorVenta.Font, Brushes.Black, 545 + AppSettings.FacturaEjeX, 457 + AppSettings.FacturaEjeY); //año pie

                e.Graphics.DrawString(TotalPagarLetras, TxtValorVenta.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 407 + AppSettings.FacturaEjeY); //total pagar en letras
            }
            #endregion
            //tamaño del papel
            //printDocument1.PrinterSettings.PaperSizes = 

            /*//haber
            StringBuilder Str = new StringBuilder();
            Str.Append("margen izquierdo: " + printDocument1.DefaultPageSettings.Margins.Left.ToString() + "");
            Str.Append("margen derecho: " + printDocument1.DefaultPageSettings.Margins.Right.ToString() + ", ");
            Str.Append("margen superior: " + printDocument1.DefaultPageSettings.Margins.Top.ToString() + ", ");
            Str.Append("margen Inferior: " + printDocument1.DefaultPageSettings.Margins.Bottom.ToString() + ", ");
            Str.Append("Ancho : " + printDocument1.DefaultPageSettings.PaperSize.Width.ToString() + ", ");
            Str.Append("Alto : " + printDocument1.DefaultPageSettings.PaperSize.Height.ToString() + ", ");
            MessageBox.Show(Str.ToString());*/
        }

        private void BtnVistaPrevia_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            //printDialog1.AllowSelection = true;
            //printDialog1.AllowSomePages = true;

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                
                if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 1)//es boleta
                {
                    ImpresoraBoletaGranja = printDialog1.PrinterSettings.PrinterName;
                    //*****************guardar la configuracion de la impresora en el appconfig**************
                    if (ImpresoraBoletaGranja != AppSettings.ImpresoraBoletaGranja & ImpresoraBoletaGranja != "")
                    {
                        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        AppSettingsSection appSettings = config.AppSettings;

                        KeyValueConfigurationElement setting = appSettings.Settings["ImpresoraBoletaGranja"];
                        setting.Value = ImpresoraBoletaGranja;
                        config.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("appSettings");
                    }
                    //************************ fin guardar configuracion ***************************************
                }
                else if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 2)// es factura
                {
                    ImpresoraFacturaGranja = printDialog1.PrinterSettings.PrinterName;
                    //*****************guardar la configuracion de la impresora en el appconfig**************
                    if (ImpresoraFacturaGranja != AppSettings.ImpresoraFacturaGranja & ImpresoraFacturaGranja != "")
                    {
                        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        AppSettingsSection appSettings = config.AppSettings;

                        KeyValueConfigurationElement setting = appSettings.Settings["ImpresoraFacturaGranja"];
                        setting.Value = ImpresoraFacturaGranja;
                        config.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("appSettings");
                    }
                    //************************ fin guardar configuracion ***************************************
                }
            }

        }

        private void BtnImprimir2_Click(object sender, EventArgs e)
        {
            BtnImprimir_Click(null, null);
        }

        private void BtnNuevoComprobante2_Click(object sender, EventArgs e)
        {
            BtnNuevoComprobante_Click(null, null);
        }

        private void BtnNuevoComprobante_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("¿Esta seguro que desea cancelar la venta?", "Nueva venta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            //{
                CboClientesCodigo.Text = "99999999999";
                DtComprobante.Clear();
                TxtIGV.Value = 0;
                TxtValorVenta.Value = 0;
                TxtVentaNeta.Value = 0;
            //}
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            BuscarProducto("", "", 0);
        }

        private void CboCaja_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CboCaja.SelectedIndex != -1)
                CboCaja.ReadOnly = true;
        }

        private void TdgDocumento_AfterDelete(object sender, EventArgs e)
        {
            CalcularTotales();
        }
    }
}
