using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Ventas;
using Halley.CapaLogica.Almacen;
using Halley.Configuracion;
using Halley.Utilitario;
using System.Configuration;
using Halley.Presentacion.Mantenimiento;
using Halley.Entidad.Ventas;
using Halley.CapaLogica.Empresa;
using System.Net;
using Halley.Presentacion.Almacen.Operaciones;


namespace Halley.Presentacion.Ventas
{
    public partial class UCVentasxPeso : UITemplateAccess
    {
        #region Variables

        CL_Comprobante ObjComprobante = new CL_Comprobante();
        CL_Producto ObjCL_Producto = new CL_Producto();
        CL_Venta ObjCL_Venta = new CL_Venta();
        TextFunctions ObjTextFunctions = new TextFunctions();
        CL_Credito ObjCL_Credito = new CL_Credito();
        CL_Pago ObjCL_Pago = new CL_Pago();

        public static DataTable DtClientes = new DataTable();
        public static DataTable DtProductos = new DataTable();
        DataTable DtDetalleComprobante = new DataTable();
        DataTable DtTipoDocumento = new DataTable();
        DataTable DtserieGuias = new DataTable();
        DataTable DtCajas = new DataTable();
        DataTable DtFormaPago = new DataTable();
        DataTable DtTipoPago = new DataTable();
        DataTable DtVendedor = new DataTable();
        DataTable dtPedido = new DataTable();
        DataTable DtServicios = new DataTable();
        DataTable DtValesConsumo = new DataTable("ValesConsumo");
        DataTable DtBoucher = new DataTable("Boucher");
        DataTable Dtempresas = new DataTable();
        DataTable DtNotaIngreso = new DataTable("NotaIngreso");



        CapaLogica.Users.CL_Usuario ObjUsuario = new CapaLogica.Users.CL_Usuario();

        string NumComprobante = "";
        string EmpresaID;
        int NumCaja;
        string NomCaja = "";
        int NroTerminales = 0;
        int TipoPagoId = 0;
        DateTime FechaReserva;
        string AlmacenID = "";
        decimal descuento = 0;
        decimal DescontarporValesConsumo = 0;
        decimal PesoNeto = 0;

        decimal IGV = 0;

        string Alias, UnidadMedidaID;
        decimal PrecioUnitario, Cantidad, PrecioVenta, StockDisponible, TotalIGV, Subtotal, TotalPagar;
        string ProductoID, ProductoIDVentas, NomVendedor;
        Int32 VendedorID = 0, ClienteID, estadoID = 0, EstadoIDEntrega = 1, TipoVentaID = 0, NumPedido = 0;
        string TipoTicket = null;
        #endregion


        public UCVentasxPeso()
        {
            InitializeComponent();
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            useCliente2.Cargar(new CL_Cliente().GetClientes());

            //crear tabla para enlazar a la grilla
            DtDetalleComprobante.Columns.Add("ProductoIDVentas", typeof(string));
            DtDetalleComprobante.Columns.Add("ProductoID", typeof(string));
            DtDetalleComprobante.Columns.Add("Alias", typeof(string));
            DtDetalleComprobante.Columns.Add("UnidadMedidaID", typeof(string));
            DtDetalleComprobante.Columns.Add("Cantidad", typeof(decimal)).DefaultValue = 0;
            DtDetalleComprobante.Columns.Add("PrecioUnitario", typeof(decimal));
            DtDetalleComprobante.Columns.Add("Importe", typeof(decimal)).DefaultValue = 0;
            DtDetalleComprobante.Columns.Add("FechaReserva", typeof(DateTime));
            DtDetalleComprobante.Columns.Add("EstadoID", typeof(int)).DefaultValue = 1;
            DtDetalleComprobante.Columns.Add("AlmacenID", typeof(string));
            DtDetalleComprobante.Columns.Add("Descuento", typeof(decimal)).DefaultValue = 0; ;
            DtDetalleComprobante.Columns.Add("PesoNeto", typeof(decimal));
            DtDetalleComprobante.Columns.Add("HistoricoPrecioID", typeof(int));



            TdgDocumento.SetDataBinding(DtDetalleComprobante, "", true);

            this.TdgDocumento.Columns[3].Editor = this.c1NELith;// enlazar con control para que acepte solo numeros

            //ocultar grilla de productos
            TdgListaProductos.Visible = false;

            //traer el nro de terminales
            //NroTerminales = ObjCL_Venta.GetNroTerminales(AppSettings.SedeID);
            NroTerminales = 3;//siempre el cajero vaa ser el vendedor eso creo

            #region 1 terminal; 3 terminales (planta?)
            //validar según numero de terminales
            if (NroTerminales == 1 | NroTerminales == 3)
            {
                LblPedido.Visible = false;
                lblNumPedido.Visible = false;

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

                //traer impresoras
                UTI_Datatables.Dt_Configuracion = ObjUsuario.USP_M_CONFIGURACION(2, 0, "", "", "", "", AppSettings.UserID, NuevaIP);

                //traer los tipo de documento y las serie de las guias
                DtTipoDocumento = ObjComprobante.getTipoComprobante();

                CboTipoComprobante.ComboBox.DataSource = DtTipoDocumento;
                CboTipoComprobante.ComboBox.DisplayMember = "NomTipoComprobante";
                CboTipoComprobante.ComboBox.ValueMember = "TipoComprobanteID";

                DtserieGuias = ObjComprobante.GetSerieGuiasT(AppSettings.SedeID);//las series

                DtFormaPago = ObjComprobante.getFormaPago();
                CboFormaPago.ComboBox.DataSource = DtFormaPago;
                CboFormaPago.ComboBox.DisplayMember = "NomFormaPago";
                CboFormaPago.ComboBox.ValueMember = "FormaPagoID";

                DtTipoPago = ObjComprobante.getTipoPago();
                CboTipoPago.ComboBox.DataSource = DtTipoPago;
                CboTipoPago.ComboBox.DisplayMember = "NomTipoPago";
                CboTipoPago.ComboBox.ValueMember = "TipoPagoID";

                //traer vendedores
                DtVendedor = ObjCL_Venta.GetVendedores(AppSettings.SedeID);

                //mostrar cajero
                LblUsuario.Text = AppSettings.Usuario;
                ocultarToolStrip();
                CboTipoComprobante.ComboBox.SelectedIndex = -1;

                CboTipoPago.SelectedIndex = 1;

                LblCaja.Text = NomCaja;

                if (NroTerminales == 3) //venta federico basadre (vendedor y cajero es la msima persona)
                {
                    NomVendedor = AppSettings.Usuario;
                    LblVendedor.Text = NomVendedor;
                    VendedorID = AppSettings.UserID;
                }
                RbNormal.Checked = true;
            }
            #endregion
            #region dos terminales
            else if (NroTerminales == 2)
            {
                BtnGenerarGuias.Visible = false;
                VendedorID = AppSettings.UserID;
                BarraVentas.Visible = false;
                BtnImprimir.Text = "&Pedir";
                BtnImprimir.Image = Properties.Resources.Aceptar_16x16;
                LblVendedor.Visible = false;
                LblBoleta.Visible = false;
                LblFactura.Visible = false;
                LblB.Visible = false;
                LblF.Visible = false;

                RbNormal.Visible = false;
                RbDiferida.Checked = true;
            }
            #endregion

            //agregar empresa
            Dtempresas = new CL_Empresas().GetEmpresas();
            c1Combo.FillC1Combo(this.c1cboCia, Dtempresas, "NomEmpresa", "EmpresaID");

            //ocultar lista de creditos
            LstCreditos.Visible = false;
            ocultarToolStrip();
            useCliente2.cbNombre.Text = "CLIENTES VARIOS";
            c1cboCia.SelectedValue = AppSettings.EmpresaID;
            if (c1cboCia.SelectedIndex != -1)
                EmpresaID = c1cboCia.SelectedValue.ToString();

            //traer servicios otros
            DtServicios = ObjCL_Venta.GetServicios();

            this.TdgDocumento.Splits[0].DisplayColumns["Descuento"].Visible = false;

            //ver pollo vivo por defecto
            BuscarProductoKeyPress();
        }

        #region Eventos Click
        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                bool haycero = false;
                string Producto = "";
                foreach (DataRow DrC in DtDetalleComprobante.Rows)
                {
                    if (Convert.ToDecimal(DrC["Importe"]) == 0)
                    {
                        haycero = true;
                        Producto = DrC["Alias"].ToString();
                    }

                }

                if (Convert.ToInt16(CboTipoComprobante.ComboBox.SelectedValue) == 3)
                {
                    if (ChkEsTicketFactura.Checked == true)
                        TipoTicket = "F";
                    else
                        TipoTicket = "B";
                }
                else
                    TipoTicket = null;


                #region tipo de venta
                if (RbNormal.Checked == true)
                    TipoVentaID = 4;
                else if (RbExterno.Checked == true)
                    TipoVentaID = 5;
                else if (RbReserva.Checked == true)
                    TipoVentaID = 3;
                else if (RbDiferida.Checked == true)
                    TipoVentaID = 6;
                #endregion

                #region Una terminal
                if (NroTerminales == 1 | NroTerminales == 3)//la venta y la caja son la misma
                {

                    if (useCliente2.cbCliente.SelectedIndex != -1 & CboTipoComprobante.ComboBox.SelectedValue != null & CboSerieGuia.ComboBox.SelectedValue != null & DtDetalleComprobante.Rows.Count > 0 & NumCaja != 0 & haycero == false & CboTipoPago.SelectedIndex != -1)
                    {
                        


                        TipoPagoId = Convert.ToInt32(CboTipoPago.ComboBox.SelectedValue);


                        string EMPRESA_ID = c1cboCia.SelectedValue.ToString();
                        string TIPO_COMPROBANTE = "";
                        if (Convert.ToInt16(CboTipoComprobante.ComboBox.SelectedValue) == 1)
                        {
                            TIPO_COMPROBANTE = "BO";
                        }
                        else if (Convert.ToInt16(CboTipoComprobante.ComboBox.SelectedValue) == 2)
                        {
                            TIPO_COMPROBANTE = "FA";
                        }
                        else if (Convert.ToInt16(CboTipoComprobante.ComboBox.SelectedValue) == 3)
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

                        //validar valores para el crédito
                        int CreditoID = 0;
                        decimal CreditoDisponible = 0;
                        if (LstCreditos.SelectedIndex != -1)
                        {
                            CreditoID = Convert.ToInt32(LstCreditos.Columns["CreditoID"].Value);
                            CreditoDisponible = Convert.ToDecimal(LstCreditos.Columns["CreditoDisponible"].Value);
                        }


                        //aca modificar acacacacacacaca
                        DataTable dt = new DataTable();
                        DateTime FECHA_IMPRESION;
                        dt = ObjCL_Venta.GenerarComprobante(DtDetalleComprobante, EmpresaID, AppSettings.SedeID, ClienteID, Convert.ToInt32(CboTipoComprobante.ComboBox.SelectedValue),
                                            useCliente2.txtDireccion.Text, TipoVentaID, TipoPagoId, Convert.ToInt32(CboFormaPago.ComboBox.SelectedValue), NumCaja, IGV, Subtotal, TotalIGV,
                                            TotalPagar, LstCreditos.SelectedIndex, CreditoID, CreditoDisponible, VendedorID, AppSettings.UserID, CboSerieGuia.ComboBox.SelectedValue.ToString(),
                                            TipoTicket, DtValesConsumo, DtBoucher, DtNotaIngreso, 0, 0, TotalPagar);

                        NumComprobante = dt.Rows[0]["NumComprobante"].ToString();
                        FECHA_IMPRESION = Convert.ToDateTime(dt.Rows[0]["FECHA_ACTUAL"].ToString());


                        if (CboTipoComprobante.ComboBox.SelectedValue.ToString() == "1")//Es boleta
                            LblBoleta.Text = NumComprobante;
                        if (CboTipoComprobante.ComboBox.SelectedValue.ToString() == "2")//Es factura
                            LblFactura.Text = NumComprobante;

                        printDocument1.Print();//manda a imprimnir

                        //calcular la suma de los vales
                        if (DtValesConsumo.Rows.Count > 0)
                            DescontarporValesConsumo = Convert.ToDecimal(DtValesConsumo.Compute("sum(Monto)", ""));
                        if (DtBoucher.Rows.Count > 0)
                            DescontarporValesConsumo = Convert.ToDecimal(DtBoucher.Compute("sum(Monto)", ""));
                        if (DtNotaIngreso.Rows.Count > 0)
                            DescontarporValesConsumo = Convert.ToDecimal(DtNotaIngreso.Compute("sum(Importe)", ""));

                        #region mostrar formulario para calcular el vuelto
                        FrmPago ObjFrmPago = new FrmPago();
                        ObjFrmPago.TotalPagar = Convert.ToDecimal(TotalPagar - DescontarporValesConsumo);
                        ObjFrmPago.ShowDialog();
                        #endregion

                        #region validar varios
                        //MessageBox.Show("Se guardo correctamente el comprobante de pago", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DtDetalleComprobante.Clear();
                        useCliente2.cbNombre.Text = "CLIENTES VARIOS";
                        TxtValorVenta.Value = 0;
                        TxtIGV.Value = 0;
                        TxtVentaNeta.Value = 0;
                        useCliente2.txtDireccion.Text = "";
                        DescontarporValesConsumo = 0;
                        DtValesConsumo.Rows.Clear();// limpiar los vales
                        DtBoucher.Rows.Clear();// limpiar los vales
                        DtNotaIngreso.Rows.Clear();//limpia los adelantos
                        CboFormaPago.ComboBox.SelectedValue = 1;//contado por defecto
                        #endregion

                        Cursor = Cursors.Default;
                        if (NroTerminales == 1)
                        {
                            NomVendedor = "";
                            VendedorID = 0;
                        }
                        LblVendedor.Text = NomVendedor;
                        TxtCodigo.Focus();

                    }
                    else
                    {
                        /*if (CboTipoComprobante.ComboBox.SelectedIndex == -1) { MessageBox.Show("Seleccione primero el tipo de comprobante.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
                        if (CboSerieGuia.ComboBox.SelectedIndex == -1) { MessageBox.Show("Seleccione la serie de la guia.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
                        if (TdgDocumento.RowCount == 0) { ErrProvider.SetError(TdgDocumento, "No hay Registros que procesar."); }
                        if (CboCaja.ComboBox.SelectedIndex == -1) { MessageBox.Show("No ha seleccionado una caja.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
                        if (CboTipoPago.SelectedIndex == -1) { MessageBox.Show("No ha seleccionado un tipo de pago.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
                        if (haycero == true) { MessageBox.Show("Hay cero en el precio de venta del producto: " + Producto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                        if (VendedorID == 0) { MessageBox.Show("Al parecer no se ha ingresado el vendedor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); TxtCodigo.Focus(); }*/
                        if (CboTipoComprobante.ComboBox.SelectedIndex == -1) { ErrProvider.SetError(BtnImprimir, "Seleccione el tipo de comprobante."); }
                        if (CboSerieGuia.ComboBox.SelectedIndex == -1) { ErrProvider.SetError(BtnImprimir, "Seleccione la serie de la guía."); }
                        if (TdgDocumento.RowCount == 0) { ErrProvider.SetError(TdgDocumento, "No hay Registros que procesar."); }
                        if (NumCaja == 0) { ErrProvider.SetError(BarraVentas, "Esta terminal no esta asopciada a una caja."); }
                        if (CboTipoPago.SelectedIndex == -1) { ErrProvider.SetError(BtnImprimir, "Seleccione el tipo de pago"); }
                        if (haycero == true) { MessageBox.Show("Hay cero en el precio de venta del producto: " + Producto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                        if (useCliente2.cbCliente.SelectedIndex == -1) { ErrProvider.SetError(useCliente2.cbCliente, "No se ha seleccionado un cliente."); }
                    }
                }
                #endregion

                #region Dos terminales
                else if (NroTerminales == 2)//la venta y la caja son diferentes
                {
                    if (useCliente2.cbCliente.SelectedIndex != -1 & DtDetalleComprobante.Rows.Count > 0 & haycero == false & VendedorID != 0)
                    {
                        #region crearpedido
                        E_OrdenPedido ObjOrdenPedido = new E_OrdenPedido()
                        {
                            ClienteID = Convert.ToInt32(useCliente2.cbCliente.SelectedValue),
                            TipoComprobanteID = null,
                            TipoVentaID = TipoVentaID,
                            TipoPagoID = null,
                            FormaPagoId = null,
                            IGV = IGV,
                            SubTotal = Subtotal,
                            TotalIGV = TotalIGV,
                            UsuarioID = AppSettings.UserID,
                            EmpresaID = EmpresaID,
                            SedeID = AppSettings.SedeID,
                            Comentario = "",
                            Vale = false,
                        };
                        if (RbExterno.Checked == true)
                            ObjOrdenPedido.Externa = true;
                        else
                            ObjOrdenPedido.Externa = false;

                        #region crear tabla y agregarle los pedidos
                        DataTable dtPedido = new DataTable("OrdenPedido");
                        dtPedido.Columns.Add("Codigo", typeof(string));
                        dtPedido.Columns.Add("Producto", typeof(string));
                        dtPedido.Columns.Add("Cantidad", typeof(decimal));
                        dtPedido.Columns.Add("PrecioUnitario", typeof(decimal));
                        dtPedido.Columns.Add("Importe", typeof(decimal), "Cantidad * PrecioUnitario");
                        dtPedido.Columns.Add("FechaReserva", typeof(DateTime));
                        dtPedido.Columns.Add("AlmacenID", typeof(string));
                        foreach (DataRow DR in DtDetalleComprobante.Rows)
                        {
                            DataRow DRP = dtPedido.NewRow();
                            DRP["Codigo"] = DR["ProductoID"];
                            DRP["Producto"] = DR["Alias"];
                            DRP["Cantidad"] = DR["Cantidad"];
                            DRP["PrecioUnitario"] = DR["PrecioUnitario"];
                            DRP["FechaReserva"] = DR["FechaReserva"];
                            DRP["AlmacenID"] = DR["AlmacenID"];
                            dtPedido.Rows.Add(DRP);
                        }
                        #endregion

                        if (TotalPagar >= 700 & (ClienteID == 1 | ClienteID == 204 | ClienteID == 241 | ClienteID == 3032))
                        {
                            MessageBox.Show("si la venta pasa de S/ 700 debe exigir datos que identifiquen al cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        NumPedido = new CL_OrdenPedido().InsertOrdenPedido2(ObjOrdenPedido, dtPedido);
                        lblNumPedido.Text = NumPedido.ToString();

                        //MessageBox.Show("El pedido se genero correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show("El Numero Pedido : " + lblNumPedido.Text, "PEDIDO", MessageBoxButtons.OK);

                        #endregion

                        #region validar varios
                        DtDetalleComprobante.Clear();
                        useCliente2.cbNombre.Text = "CLIENTES VARIOS";
                        TxtValorVenta.Value = 0;
                        TxtIGV.Value = 0;
                        TxtVentaNeta.Value = 0;
                        useCliente2.txtDireccion.Text = "";
                        TxtProducto.Focus();
                        ChkDescuento.Checked = false;
                        ChkFlete.Checked = false;
                        #endregion
                    }
                    else
                    {
                        if (TdgDocumento.RowCount == 0) { ErrProvider.SetError(TdgDocumento, "No hay Registros que procesar."); }
                        if (haycero == true) { MessageBox.Show("Hay cero en el precio de venta del producto: " + Producto, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                        if (VendedorID == 0) { MessageBox.Show("Al parecer no se ha ingresado el vendedor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); TxtCodigo.Focus(); }
                    }
                }
                #endregion

                ErrProvider.Clear();

                //pollo vivo por defecto
                TxtCodigo.Text = "0100";
                BuscarProductoKeyPress();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ".\t\nmetodo Imprimir()", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnVistaPrevia_Click(object sender, EventArgs e)
        {
            #region no vale
            /*printDialog1.Document = printDocument1;
            //printDialog1.AllowSelection = true;
            //printDialog1.AllowSomePages = true;
            
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {

                if (Convert.ToInt16(CboTipoComprobante.ComboBox.SelectedValue) == 1 & c1cboCia.SelectedValue.ToString() == "GH")//es boleta
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
                }
                else if (Convert.ToInt16(CboTipoComprobante.ComboBox.SelectedValue) == 2 & c1cboCia.SelectedValue.ToString() == "GH")// es factura
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
                }

                else if (Convert.ToInt16(CboTipoComprobante.ComboBox.SelectedValue) == 1 & c1cboCia.SelectedValue.ToString() == "IH")//es boleta
                {
                    ImpresoraBoletaIndustria = printDialog1.PrinterSettings.PrinterName;
                    //*****************guardar la configuracion de la impresora en el appconfig**************
                    if (ImpresoraBoletaIndustria != AppSettings.ImpresoraBoletaIndustria & ImpresoraBoletaIndustria != "")
                    {
                        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        AppSettingsSection appSettings = config.AppSettings;

                        KeyValueConfigurationElement setting = appSettings.Settings["ImpresoraBoletaIndustria"];
                        setting.Value = ImpresoraBoletaIndustria;
                        config.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("appSettings");
                    }
                }
                else if (Convert.ToInt16(CboTipoComprobante.ComboBox.SelectedValue) == 2 & c1cboCia.SelectedValue.ToString() == "IH")// es factura
                {
                    ImpresoraFacturaIndustria = printDialog1.PrinterSettings.PrinterName;
                    //*****************guardar la configuracion de la impresora en el appconfig**************
                    if (ImpresoraFacturaIndustria != AppSettings.ImpresoraFacturaIndustria & ImpresoraFacturaIndustria != "")
                    {
                        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        AppSettingsSection appSettings = config.AppSettings;

                        KeyValueConfigurationElement setting = appSettings.Settings["ImpresoraFacturaIndustria"];
                        setting.Value = ImpresoraFacturaIndustria;
                        config.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("appSettings");
                    }
                }

                else if (Convert.ToInt16(CboTipoComprobante.ComboBox.SelectedValue) == 1 & c1cboCia.SelectedValue.ToString() == "CH")//es boleta
                {
                    ImpresoraBoletaComercio = printDialog1.PrinterSettings.PrinterName;
                    //*****************guardar la configuracion de la impresora en el appconfig**************
                    if (ImpresoraBoletaComercio != AppSettings.ImpresoraBoletaComercio & ImpresoraBoletaComercio != "")
                    {
                        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        AppSettingsSection appSettings = config.AppSettings;

                        KeyValueConfigurationElement setting = appSettings.Settings["ImpresoraBoletaComercio"];
                        setting.Value = ImpresoraBoletaComercio;
                        config.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("appSettings");
                    }
                }
                else if (Convert.ToInt16(CboTipoComprobante.ComboBox.SelectedValue) == 2 & c1cboCia.SelectedValue.ToString() == "CH")// es factura
                {
                    ImpresoraFacturaComercio = printDialog1.PrinterSettings.PrinterName;
                    //*****************guardar la configuracion de la impresora en el appconfig**************
                    if (ImpresoraFacturaComercio != AppSettings.ImpresoraFacturaComercio & ImpresoraFacturaComercio != "")
                    {
                        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        AppSettingsSection appSettings = config.AppSettings;

                        KeyValueConfigurationElement setting = appSettings.Settings["ImpresoraFacturaComercio"];
                        setting.Value = ImpresoraFacturaComercio;
                        config.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("appSettings");
                    }
                }
            }*/
            #endregion

            Pagos.FrmConfigurarImpresora ObjFrmConfigurarImpresora = new Pagos.FrmConfigurarImpresora();
            ObjFrmConfigurarImpresora.Show();

        }

        private void BtnNuevoComprobante2_Click(object sender, EventArgs e)
        {
            BtnNuevoComprobante_Click(null, null);
        }

        private void BtnNuevoComprobante_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("¿Esta seguro que desea cancelar la venta?", "Nueva venta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            //{
            useCliente2.cbNombre.Text = "CLIENTES VARIOS";
            DtDetalleComprobante.Clear();
            TxtIGV.Value = 0;
            TxtValorVenta.Value = 0;
            TxtVentaNeta.Value = 0;
            TxtCodigo.Text = "";
            TxtProducto.Text = "";
            TxtPrecio.Text = "";
            Alias = "";
            ProductoID = "";
            if (NroTerminales == 1)
                VendedorID = 0;
            LblVendedor.Text = "";
            StockDisponible = 0;
            LblStock.Text = StockDisponible.ToString();
            ChkDescuento.Checked = false;
            ChkFlete.Checked = false;
            DtValesConsumo.Rows.Clear();// limpiar los vales
            DtBoucher.Rows.Clear();// limpiar los vales
            DtNotaIngreso.Rows.Clear();//limpia los adelantos
            CboFormaPago.ComboBox.SelectedValue = 1;//contado por defecto

            //pollo vivo por defecto
            TxtCodigo.Text = "0100";
            BuscarProductoKeyPress();
            //}
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            BuscarProducto("", "", 0);
        }

        private void BtnNuevoCliente_Click(object sender, EventArgs e)
        {
            FrmCliente ObjFrmCliente = new FrmCliente();
            ObjFrmCliente.ShowDialog();

        }
        #endregion

        #region eventos Combo


        #endregion

        #region Eventos TextBox


        private void AgregarDetalle(decimal CantidadA)
        {
            decimal NuevoPrecio;
            Cantidad = CantidadA;
            PrecioVenta = PrecioUnitario * Cantidad;

            //string cantidadTexto = PrecioVenta.ToString();
            ////se busca el punto
            //int posi = 0;
            //posi = cantidadTexto.IndexOf('.');
            //if (posi > 0)
            //{
            //    //se busca la posicion del punto y se agrega la cantidad correspondiente
            //    string cadenacontar = cantidadTexto.Substring(posi);
            //    if (cadenacontar.Length > 1)
            //    {
            //        int Numerovalidar = Convert.ToInt32(cantidadTexto.Substring(posi+2,1));
            //        if(Numerovalidar > 5)//si es mayor a cero se redondea
            //        {
            //            NuevoPrecio = Convert.ToDecimal(PrecioVenta.ToString()) + Convert.ToDecimal(0.1);
            //            NuevoPrecio = Convert.ToDecimal(NuevoPrecio.ToString().Substring(0, posi + 2));
            //        }
            //        else
            //        {
            //            NuevoPrecio = Convert.ToDecimal(PrecioVenta.ToString()) - Convert.ToDecimal("0.0" + Numerovalidar.ToString());
            //            NuevoPrecio = Convert.ToDecimal(NuevoPrecio.ToString().Substring(0, posi + 2));
            //        }

            //    }
            //    else
            //        NuevoPrecio = PrecioVenta;

            //}
            //else
            NuevoPrecio = Math.Round(PrecioVenta, 1);

            if (RbNormal.Checked == true | RbExterno.Checked == true)
            {
                DataRow Dr = DtDetalleComprobante.NewRow();
                Dr["ProductoIDVentas"] = ProductoIDVentas;
                Dr["ProductoID"] = ProductoID;
                Dr["Alias"] = Alias;
                Dr["UnidadMedidaID"] = UnidadMedidaID;
                Dr["Cantidad"] = Cantidad;
                Dr["PrecioUnitario"] = PrecioUnitario;
                Dr["Importe"] = NuevoPrecio;
                if (RbReserva.Checked == true)
                    Dr["FechaReserva"] = FechaReserva;
                else
                    Dr["FechaReserva"] = DBNull.Value;
                Dr["EstadoID"] = EstadoIDEntrega;
                Dr["AlmacenID"] = AlmacenID;
                DtDetalleComprobante.Rows.Add(Dr);
            }
            else//si es reserva o diferida no deberian repetirse los items de venta
            {
                //buscar que no exista
                DataView Dv = new DataView(DtDetalleComprobante);
                Dv.RowFilter = "ProductoID = '" + ProductoID + "'";
                if (Dv.Count == 0)
                {
                    DataRow Dr = DtDetalleComprobante.NewRow();
                    Dr["ProductoIDVentas"] = ProductoIDVentas;
                    Dr["ProductoID"] = ProductoID;
                    Dr["Alias"] = Alias;
                    Dr["UnidadMedidaID"] = UnidadMedidaID;
                    Dr["Cantidad"] = Cantidad;
                    Dr["PrecioUnitario"] = PrecioUnitario;
                    Dr["Importe"] = NuevoPrecio;
                    if (RbReserva.Checked == true)
                        Dr["FechaReserva"] = FechaReserva;
                    else
                        Dr["FechaReserva"] = DBNull.Value;
                    Dr["EstadoID"] = EstadoIDEntrega;
                    DtDetalleComprobante.Rows.Add(Dr);
                }
                else
                    MessageBox.Show("El producto ya ha sido agregado al detalle. En reserva y diferida solo puede almacenar un item por comprobante", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            TxtProducto.Text = "";
            TxtCodigo.Text = "";
            if (RbReserva.Checked == false)
            {
                PesoNeto = 0;
            }
            TxtPrecio.Text = "";
            if (NroTerminales == 1)
                TxtCodigo.Focus();
            if (NroTerminales == 3 | NroTerminales == 2)
                TxtProducto.Focus();
        }
        private void TxtCodigo_TextChanged(object sender, EventArgs e)
        {
            /*try
            {
                if (TxtCodigo.Text.Length > 0)
                {
                    TdgListaProductos.Visible = true;
                    DataView dv = new DataView(DtProductos);
                    dv.RowFilter = "ProductoIDVentas LIKE '" + TxtCodigo.Text + "%'";
                    this.TdgListaProductos.SetDataBinding(dv, "", true);
                }
                else
                    TdgListaProductos.Visible = false;
            }
            catch (Exception)
            {
                // MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void TxtProducto_TextChanged(object sender, EventArgs e)
        {
            /*try
            {
                if (TxtProducto.Text.Length > 0)
                {
                    TdgListaProductos.Visible = true;
                    DataView dv = new DataView(DtProductos);
                    dv.RowFilter = "Alias LIKE '" + TxtProducto.Text + "%'";
                    this.TdgListaProductos.SetDataBinding(dv, "", true);
                }
                else
                    TdgListaProductos.Visible = false;
            }
            catch (Exception)
            {
                // MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void TxtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter) & TxtCodigo.Text != "")
            {
                BuscarProductoKeyPress();

            }
            else if (e.KeyChar == (char)(Keys.Escape))
            {
                if (TdgListaProductos.Visible == true)
                    TdgListaProductos.Visible = false;
            }
            else
            {
                TdgListaProductos.Visible = true;
                TdgListaProductos.SetDataBinding(DtProductos, "", true);
                TdgListaProductos.Focus();
            }
        }

        private void BuscarProductoKeyPress()
        {
            DtProductos = ObjCL_Producto.GetProductosPrecio(EmpresaID + AppSettings.SedeID, TxtCodigo.Text, "C");

            //si el producto es unico no es necesario mostrar la lista
            if (DtProductos.Rows.Count == 1)
            {

                AlmacenID = EmpresaID + AppSettings.SedeID + DtProductos.Rows[0]["Almacen"].ToString();

                if (EmpresaID == "" | AppSettings.SedeID == "" | DtProductos.Rows[0]["Almacen"].ToString() == "" | AlmacenID.Length != 10)
                    MessageBox.Show("El codigo de almacen es = '" + AlmacenID + "'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                StockDisponible = Convert.ToDecimal(DtProductos.Rows[0]["StockDisponible"]);
                LblStock.Text = StockDisponible.ToString();
                ProductoID = DtProductos.Rows[0]["ProductoID"].ToString();
                ProductoIDVentas = DtProductos.Rows[0]["ProductoIDVentas"].ToString();
                Alias = DtProductos.Rows[0]["Alias"].ToString();
                UnidadMedidaID = DtProductos.Rows[0]["UnidadMedidaID"].ToString();
                PrecioUnitario = Convert.ToDecimal(DtProductos.Rows[0]["PrecioUnitario"].ToString());

                if (StockDisponible > 0 | RbDiferida.Checked == true | RbReserva.Checked == true)
                {
                    TxtCodigo.Text = ProductoIDVentas;
                    TxtProducto.Text = Alias;
                    TxtPrecio.Text = PrecioUnitario.ToString("C");
                    if (RbReserva.Checked == true)
                    {
                        BtnReserva_Click(null, null);
                    }
                    else
                    {
                        btnBalanza.Focus(); //establecer como foco la cantidad
                    }
                    CalcularTotales();
                }

            }

            else if (DtProductos.Rows.Count == 0)
            {
                if (NroTerminales == 1)
                    TxtCodigo.Focus();
                else if (NroTerminales == 2)
                    TxtProducto.Focus();
            }
        }

        private void TxtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter) & TxtProducto.Text != "")
            {
                DtProductos = ObjCL_Producto.GetProductosPrecio(EmpresaID + AppSettings.SedeID, TxtProducto.Text, "A");
                if (DtProductos.Rows.Count == 1)
                {
                    AlmacenID = EmpresaID + AppSettings.SedeID + DtProductos.Rows[0]["Almacen"].ToString();
                    StockDisponible = Convert.ToDecimal(DtProductos.Rows[0]["StockDisponible"]);
                    LblStock.Text = StockDisponible.ToString();
                    ProductoID = DtProductos.Rows[0]["ProductoID"].ToString();
                    ProductoIDVentas = DtProductos.Rows[0]["ProductoIDVentas"].ToString();
                    Alias = DtProductos.Rows[0]["Alias"].ToString();
                    UnidadMedidaID = DtProductos.Rows[0]["UnidadMedidaID"].ToString();
                    PrecioUnitario = Convert.ToDecimal(DtProductos.Rows[0]["PrecioUnitario"].ToString());

                    if (StockDisponible > 0 | RbDiferida.Checked == true | RbReserva.Checked == true)
                    {
                        TxtCodigo.Text = ProductoIDVentas;
                        TxtProducto.Text = Alias;
                        TxtPrecio.Text = PrecioUnitario.ToString("C");
                        if (RbReserva.Checked == true)
                        {
                            BtnReserva_Click(null, null);
                        }
                        else
                        {
                            btnBalanza.Focus(); //establecer como foco la cantidad
                        }
                        CalcularTotales();
                    }

                }
                if (e.KeyChar == (char)(Keys.Escape))
                {
                    if (TdgListaProductos.Visible == true)
                        TdgListaProductos.Visible = false;
                }
                else if (DtProductos.Rows.Count == 0)
                {
                    if (NroTerminales == 1)
                        TxtCodigo.Focus();
                    else if (NroTerminales == 2 | NroTerminales == 3)
                        TxtProducto.Focus();
                }
                else
                {
                    TdgListaProductos.Visible = true;
                    TdgListaProductos.SetDataBinding(DtProductos, "", true);
                    TdgListaProductos.Focus();
                }
            }
        }
        private void TxtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            ValidarCodigoBarra(TxtCodigo.Text);
        }

        private void TxtProducto_KeyUp(object sender, KeyEventArgs e)
        {
            ValidarCodigoBarra(TxtProducto.Text);
        }
        #endregion

        #region Eventos de Grillas

        private void TdgDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)(Keys.Enter) | e.KeyChar == (char)(Keys.Left) | e.KeyChar == (char)(Keys.Right))
            if (e.KeyChar == (char)(Keys.Enter))
            {
                decimal Cantidad;
                if (TdgDocumento.Columns["Cantidad"].Value + "" == "")
                    Cantidad = 0;
                else
                    Cantidad = Convert.ToDecimal(TdgDocumento.Columns["Cantidad"].Value);

                BuscarProducto(TdgDocumento.Columns["ProductoID"].Value.ToString(), TdgDocumento.Columns["Alias"].Value.ToString(), Cantidad);
                SendKeys.Send("{DOWN}");
                if (NroTerminales == 1)
                    TxtCodigo.Focus();
                else
                    TxtProducto.Focus();
            }
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

        private void TdgDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            String CodigoBarra = TdgDocumento.Columns["Codigo"].Value.ToString();
            if (CodigoBarra.Length == 13 && CodigoBarra.Substring(0, 1) == "2")
            {
                //descomponer el codigo
                string Codigo = "";
                string Articulo = "";
                decimal Cantidad = 0;
                CodigoBarra = TdgDocumento.Columns["Codigo"].Value.ToString();
                Codigo = CodigoBarra.Substring(3, 4);
                Cantidad = Convert.ToDecimal(CodigoBarra.Substring(7, 5)) / 1000;
                BuscarProducto(Codigo, Articulo, Cantidad);
                Calcular();
                CalcularTotales();
                SendKeys.Send("{DOWN}");
            }
        }

        private void TdgListaProductos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter) & TdgListaProductos.RowCount > 0)
            {
                AlmacenID = EmpresaID + AppSettings.SedeID + this.TdgListaProductos.Columns["Almacen"].Value.ToString();
                StockDisponible = Convert.ToDecimal(this.TdgListaProductos.Columns["StockDisponible"].Value);
                LblStock.Text = StockDisponible.ToString();
                ProductoID = this.TdgListaProductos.Columns["ProductoID"].Value.ToString();
                ProductoIDVentas = this.TdgListaProductos.Columns["ProductoIDVentas"].Value.ToString();
                Alias = this.TdgListaProductos.Columns["Alias"].Value.ToString();
                UnidadMedidaID = this.TdgListaProductos.Columns["UnidadMedidaID"].Value.ToString();
                PrecioUnitario = Convert.ToDecimal(this.TdgListaProductos.Columns["PrecioUnitario"].Value.ToString());

                if (StockDisponible > 0 | RbDiferida.Checked == true | RbReserva.Checked == true)
                {
                    TxtCodigo.Text = ProductoIDVentas;
                    TxtProducto.Text = Alias;
                    TxtPrecio.Text = PrecioUnitario.ToString("C");
                    TdgListaProductos.Visible = false;
                    if (RbReserva.Checked == true)
                    {
                        BtnReserva_Click(null, null);
                    }
                    else
                    {
                        btnBalanza.Focus(); //establecer como foco la cantidad
                    }
                    CalcularTotales();
                }
            }
            else if (e.KeyChar == (char)(Keys.Escape))
            {

                TdgListaProductos.Visible = false;

                TxtCodigo.Text = "";
                TxtProducto.Text = "";
                TxtPrecio.Text = "";
                TdgListaProductos.Visible = false;

                if (NroTerminales == 1)
                    TxtCodigo.Focus(); //establecer como foco la cantidad
                if (NroTerminales == 2 | NroTerminales == 3)
                    TxtProducto.Focus();
                CalcularTotales();
            }
            //limpiar apra que no aparescan denuevo
        }


        private void TdgDocumento_AfterDelete(object sender, EventArgs e)
        {
            Calcular();
            CalcularTotales();
        }

        #endregion

        #region Metodos

        private void BuscarProducto(string Codigo, string Articulo, decimal Cantidad)
        {

            DataView Dv = new DataView(DtProductos);
            if (Codigo + "" != "" && Articulo + "" == "")
                Dv.RowFilter = "ProductoIDVentas = '" + Codigo + "'";
            if (Articulo + "" != "" && Codigo + "" == "")
                Dv.RowFilter = "Alias like '" + Articulo + "%'";
            if (Codigo + "" != "" && Articulo + "" != "")
                Dv.RowFilter = "ProductoIDVentas = '" + Codigo + "'";

            if (Dv.Count == 1)
            {
                TdgDocumento.Columns["ProductoIDVentas"].Value = Dv[0]["ProductoIDVentas"];
                TdgDocumento.Columns["ProductoID"].Value = Dv[0]["ProductoID"];
                TdgDocumento.Columns["Alias"].Value = Dv[0]["Alias"];
                TdgDocumento.Columns["PrecioUnitario"].Value = Dv[0]["PrecioUnitario"];
                TdgDocumento.Columns["UnidadMedidaID"].Value = Dv[0]["UnidadMedidaID"];
                TdgDocumento.Columns["Cantidad"].Value = Cantidad;
            }
        }

        private void BuscarProducto2(string Codigo, string Articulo, decimal Cantidad2)
        {
            DtProductos = ObjCL_Producto.GetProductosPrecio(EmpresaID + AppSettings.SedeID, Codigo, "C");

            if (DtProductos.Rows.Count == 1)
            {
                ProductoID = DtProductos.Rows[0]["ProductoID"].ToString();
                AlmacenID = EmpresaID + AppSettings.SedeID + DtProductos.Rows[0]["Almacen"].ToString();
                ProductoIDVentas = DtProductos.Rows[0]["ProductoIDVentas"].ToString();
                Alias = DtProductos.Rows[0]["Alias"].ToString();
                UnidadMedidaID = DtProductos.Rows[0]["UnidadMedidaID"].ToString();
                Cantidad = Cantidad2;
                PrecioUnitario = Convert.ToDecimal(DtProductos.Rows[0]["PrecioUnitario"]);
                PrecioVenta = PrecioUnitario * Cantidad;
                StockDisponible = Convert.ToDecimal(DtProductos.Rows[0]["StockDisponible"]);
                LblStock.Text = StockDisponible.ToString();

                if (Cantidad2 <= StockDisponible)
                {
                    AgregarDetalle(Cantidad2);
                    StockDisponible = 0;
                    LblStock.Text = StockDisponible.ToString();
                }
                else
                    MessageBox.Show("Lo solicitado no puede ser mayor al stock disponible.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                TxtProducto.Text = "";
                TxtCodigo.Text = "";
                if (RbReserva.Checked != true)
                {
                    PesoNeto = 0;
                }
                TxtCodigo.Focus();

            }
            else
            {
                MessageBox.Show("No se encontro el producto, verifique su almacen principal, que tenga stock en su almacen principal y que tenga un precio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtCodigo.ReadOnly = false;
                TxtCodigo.Text = "";
                TxtCodigo.Focus();
                return;
            }

        }

        private void CalcularTotales()
        {
            if (DtDetalleComprobante.Rows.Count > 0)
            {
                TotalIGV = Convert.ToDecimal(DtDetalleComprobante.Compute("sum(Importe) *  " + IGV, ""));
                Subtotal = Convert.ToDecimal(DtDetalleComprobante.Compute("sum(Importe)", "").ToString());
                TotalPagar = Convert.ToDecimal(DtDetalleComprobante.Compute("(sum(Importe) *  " + IGV + ") + sum(Importe)", ""));

                if (ChkDescuento.Checked == true)
                {
                    if (TotalPagar - Math.Truncate(TotalPagar) > 0)
                    {
                        Descuentoautomatico();
                        //volver a calcular valores
                        TotalIGV = Convert.ToDecimal(DtDetalleComprobante.Compute("sum(Importe) *  " + IGV, ""));
                        Subtotal = Convert.ToDecimal(DtDetalleComprobante.Compute("sum(Importe)", "").ToString());
                        TotalPagar = Convert.ToDecimal(DtDetalleComprobante.Compute("(sum(Importe) *  " + IGV + ") + sum(Importe)", ""));
                    }
                }



                TxtIGV.Text = TotalIGV.ToString("C");
                TxtValorVenta.Text = Subtotal.ToString("C");
                TxtVentaNeta.Text = TotalPagar.ToString("C");
            }
            else
            {
                TotalIGV = 0;
                Subtotal = 0;
                TotalPagar = 0;
                descuento = 0;

                TxtIGV.Text = TotalIGV.ToString("C");
                TxtValorVenta.Text = Subtotal.ToString("C");
                TxtVentaNeta.Text = TotalPagar.ToString("C");
            }


        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            //formato para alinear los nuimeros a la derecha
            StringFormat formato = new StringFormat();
            formato.Alignment = StringAlignment.Far;
            //formato.LineAlignment = StringAlignment.Far;

            //obtener la cadena del total a pagar
            string TotalPagarLetras = ObjTextFunctions.enletras(TotalPagar.ToString());

            //validar boleta o factura
            #region Boleta
            if (Convert.ToInt16(CboTipoComprobante.ComboBox.SelectedValue) == 1)//es boleta
            {
                int sum = 0;
                sum += 12;
                e.Graphics.DrawString(useCliente2.cbNombre.Columns["RazonSocial"].Value.ToString(), TxtPrecio.Font, Brushes.Black, 70 + AppSettings.BoletaEjeX, 156 + AppSettings.BoletaEjeY); //cliente
                if (useCliente2.txtDireccion.Text.Length >= 30)
                    e.Graphics.DrawString(useCliente2.txtDireccion.Text.Substring(0, 29), TxtPrecio.Font, Brushes.Black, 80 + AppSettings.BoletaEjeX, 186 + AppSettings.BoletaEjeY); //direccion larga
                else
                    e.Graphics.DrawString(useCliente2.txtDireccion.Text, TxtPrecio.Font, Brushes.Black, 80 + AppSettings.BoletaEjeX, 186 + AppSettings.BoletaEjeY); //direccion corta

                //e.Graphics.DrawString(TxtCanasta.Text, TxtPrecio.Font, Brushes.Black, 40 + AppSettings.BoletaEjeX, 166 + AppSettings.BoletaEjeY); //canasta
                e.Graphics.DrawString(useCliente2.cbCliente.Columns["NroDocumento"].Value.ToString(), TxtPrecio.Font, Brushes.Black, 326 + AppSettings.BoletaEjeX, 186 + AppSettings.BoletaEjeY); //ruc o DNI
                e.Graphics.DrawString(DateTime.Now.Date.ToString().Substring(0, 10), TxtPrecio.Font, Brushes.Black, 240 + AppSettings.BoletaEjeX, 136 + AppSettings.BoletaEjeY); //dia
                e.Graphics.DrawString(NumComprobante.Substring(2), TxtPrecio.Font, Brushes.Black, 260 + AppSettings.BoletaEjeX, 117 + AppSettings.BoletaEjeY); //numero de comprobante

                int Suma = 238;
                foreach (DataRow Dr in DtDetalleComprobante.Rows)
                {
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["Cantidad"]).ToString("#,##0.00") + " " + Dr["UnidadMedidaID"].ToString(), TxtPrecio.Font, Brushes.Black, 65 + AppSettings.BoletaEjeX, Suma + AppSettings.BoletaEjeY, formato); //cantidad + UM
                    e.Graphics.DrawString(Dr["Alias"].ToString(), TxtPrecio.Font, Brushes.Black, 75 + AppSettings.BoletaEjeX, Suma + AppSettings.BoletaEjeY); //descripcion o producto
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["PrecioUnitario"]).ToString("#,##0.00"), TxtPrecio.Font, Brushes.Black, 320 + AppSettings.BoletaEjeX, Suma + AppSettings.BoletaEjeY, formato); //precio unitario
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["Importe"]).ToString("#,##0.00"), TxtPrecio.Font, Brushes.Black, 380 + AppSettings.BoletaEjeX, Suma + AppSettings.BoletaEjeY, formato); //valor de venta
                    Suma += 14;
                }

                e.Graphics.DrawString(TxtVentaNeta.Text, TxtPrecio.Font, Brushes.Black, 370 + AppSettings.BoletaEjeX, 450 + AppSettings.BoletaEjeY, formato); //total
                e.Graphics.DrawString(TotalPagarLetras, TxtPrecio.Font, Brushes.Black, 45 + AppSettings.BoletaEjeX, 424 + AppSettings.BoletaEjeY); //tatal pagar en letras

            }
            #endregion
            #region Factura
            else if (Convert.ToInt16(CboTipoComprobante.ComboBox.SelectedValue) == 2)//es factura
            {
                int sum = 0;
                sum += 12;
                e.Graphics.DrawString(useCliente2.cbNombre.Columns["RazonSocial"].Value.ToString(), TxtPrecio.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 117 + AppSettings.FacturaEjeY); //cliente
                //e.Graphics.DrawString(useCliente2.txtDireccion.Text, TxtPrecio.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 157 + AppSettings.FacturaEjeY); //direccion
                if (useCliente2.txtDireccion.Text.Length >= 95)
                    e.Graphics.DrawString(useCliente2.txtDireccion.Text.Substring(0, 94), TxtPrecio.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 157 + AppSettings.FacturaEjeY); //direccion
                else
                    e.Graphics.DrawString(useCliente2.txtDireccion.Text, TxtPrecio.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 157 + AppSettings.FacturaEjeY); //direccion

                e.Graphics.DrawString(useCliente2.cbCliente.Columns["NroDocumento"].Value.ToString(), TxtPrecio.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 182 + AppSettings.FacturaEjeY); //ruc o DNI
                e.Graphics.DrawString(DateTime.Now.Day.ToString(), TxtPrecio.Font, Brushes.Black, 570 + AppSettings.FacturaEjeX, 182 + AppSettings.FacturaEjeY); //dia
                e.Graphics.DrawString(DateTime.Now.ToString("MMMM"), TxtPrecio.Font, Brushes.Black, 650 + AppSettings.FacturaEjeX, 182 + AppSettings.FacturaEjeY); //mes
                e.Graphics.DrawString(DateTime.Now.Year.ToString().Substring(2), TxtPrecio.Font, Brushes.Black, 810 + AppSettings.FacturaEjeX, 182 + AppSettings.FacturaEjeY); //año
                e.Graphics.DrawString(NumComprobante.Substring(2), TxtPrecio.Font, Brushes.Black, 690 + AppSettings.FacturaEjeX, 147 + AppSettings.FacturaEjeY); //numero de comprobante

                int Suma = 230;
                foreach (DataRow Dr in DtDetalleComprobante.Rows)
                {
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["Cantidad"]).ToString("#,##0.00") + " " + Dr["UnidadMedidaID"].ToString(), TxtPrecio.Font, Brushes.Black, 80 + AppSettings.FacturaEjeX, Suma + AppSettings.FacturaEjeY, formato); //cantidad + UM
                    e.Graphics.DrawString(Dr["Alias"].ToString(), TxtPrecio.Font, Brushes.Black, 110 + AppSettings.FacturaEjeX, Suma + AppSettings.FacturaEjeY); //descripcion o producto
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["PrecioUnitario"]).ToString("#,##0.00"), TxtPrecio.Font, Brushes.Black, 665 + AppSettings.FacturaEjeX, Suma + AppSettings.FacturaEjeY, formato); //precio unitario
                    e.Graphics.DrawString(Convert.ToDecimal(Dr["Importe"]).ToString("#,##0.00"), TxtPrecio.Font, Brushes.Black, 790 + AppSettings.FacturaEjeX, Suma + AppSettings.FacturaEjeY, formato); //valor de venta
                    Suma += 14;
                }

                e.Graphics.DrawString(TxtValorVenta.Text, TxtPrecio.Font, Brushes.Black, 790 + AppSettings.FacturaEjeX, 427 + AppSettings.FacturaEjeY, formato); //subtotal
                e.Graphics.DrawString(TxtIGV.Text, TxtPrecio.Font, Brushes.Black, 790 + AppSettings.FacturaEjeX, 447 + AppSettings.FacturaEjeY, formato); //igv
                e.Graphics.DrawString(TxtVentaNeta.Text, TxtPrecio.Font, Brushes.Black, 790 + AppSettings.FacturaEjeX, 477 + AppSettings.FacturaEjeY, formato); //total

                e.Graphics.DrawString(DateTime.Now.Day.ToString(), TxtPrecio.Font, Brushes.Black, 405 + AppSettings.FacturaEjeX, 457 + AppSettings.FacturaEjeY); //dia pie
                e.Graphics.DrawString(DateTime.Now.ToString("MMMM"), TxtPrecio.Font, Brushes.Black, 465 + AppSettings.FacturaEjeX, 457 + AppSettings.FacturaEjeY); //mes pie
                e.Graphics.DrawString(DateTime.Now.Year.ToString().Substring(2), TxtPrecio.Font, Brushes.Black, 545 + AppSettings.FacturaEjeX, 457 + AppSettings.FacturaEjeY); //año pie

                e.Graphics.DrawString(TotalPagarLetras, TxtPrecio.Font, Brushes.Black, 90 + AppSettings.FacturaEjeX, 407 + AppSettings.FacturaEjeY); //total pagar en letras
            }
            #endregion

        }
        private void ValidarCodigoBarra(string CodigoDeBarra)
        {
            if (CodigoDeBarra.Length > 0)
            {
                if (CodigoDeBarra.Length == 13 & CodigoDeBarra.Substring(0, 1) == "2")//es producto
                {
                    //se oculta la grilla
                    TdgListaProductos.Visible = false;
                    //descomponer el codigo
                    string Codigo = "";
                    string Articulo = "";
                    decimal Cantidad = 0;
                    Codigo = CodigoDeBarra.Substring(3, 4);
                    Cantidad = Convert.ToDecimal(CodigoDeBarra.Substring(7, 5)) / 1000;
                    BuscarProducto2(Codigo, Articulo, Cantidad);
                    Calcular();
                    CalcularTotales();
                }
                else if (CodigoDeBarra.Length == 13 & CodigoDeBarra.Substring(0, 1) == "V")//es vendedor
                {
                    if (DtVendedor.Rows.Count > 0)
                    {
                        VendedorID = Convert.ToInt32(CodigoDeBarra.Substring(1));
                        DataView Dv = new DataView(DtVendedor);
                        Dv.RowFilter = "UserID = " + VendedorID.ToString();
                        if (Dv.Count > 0)
                            NomVendedor = Dv[0]["Descripcion"].ToString();
                        else
                        {
                            NomVendedor = "";
                            VendedorID = 0;
                            MessageBox.Show("Este vendedor no existe o no pertenece a esta sede.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        LblVendedor.Text = NomVendedor;
                        TxtCodigo.Text = "";
                        TxtProducto.Text = "";
                        TxtCodigo.Focus();
                    }
                }
            }
        }

        private void Calcular()
        {
            if (TdgDocumento.Columns["Cantidad"].Value + "" != "" & TdgDocumento.Columns["PrecioUnitario"].Value + "" != "")
            {
                TdgDocumento.Columns["Importe"].Value = decimal.Round(Convert.ToDecimal(TdgDocumento.Columns["Cantidad"].Value) * Convert.ToDecimal(TdgDocumento.Columns["PrecioUnitario"].Value), 1);
            }
        }
        #endregion


        private void CboTipoComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChkEsTicketFactura.Visible = false;
            if (DtTipoDocumento.Rows.Count > 0 && CboTipoComprobante.SelectedIndex != -1 & DtserieGuias.Rows.Count > 0 & EmpresaID != "")
            {
                DataView Dv = new DataView(DtserieGuias);
                Dv.RowFilter = "TipoDocumento = '" + Convert.ToInt32(CboTipoComprobante.ComboBox.SelectedValue) + "' and EmpresaID = '" + EmpresaID + "'";
                CboSerieGuia.ComboBox.DataSource = Dv;
                CboSerieGuia.ComboBox.DisplayMember = "Serie";
                CboSerieGuia.ComboBox.ValueMember = "Serie";

                //seleccionar la serie por defecto
                switch (CboTipoComprobante.ComboBox.SelectedValue.ToString())
                {
                    case "1":
                        if (EmpresaID == "GH")
                        {
                            if (AppSettings.GHSerieDefectoBoleta != "")
                                CboSerieGuia.ComboBox.SelectedValue = AppSettings.GHSerieDefectoBoleta;
                        }
                        else if (EmpresaID == "IH")
                        {
                            if (AppSettings.IHSerieDefectoBoleta != "")
                                CboSerieGuia.ComboBox.SelectedValue = AppSettings.IHSerieDefectoBoleta;
                        }
                        else if (EmpresaID == "CH")
                        {
                            if (AppSettings.CHSerieDefectoBoleta != "")
                                CboSerieGuia.ComboBox.SelectedValue = AppSettings.CHSerieDefectoBoleta;
                        }
                        else if (EmpresaID == "AH")
                        {
                            if (AppSettings.AHSerieDefectoBoleta != "")
                                CboSerieGuia.ComboBox.SelectedValue = AppSettings.AHSerieDefectoBoleta;
                        }
                        break;
                    case "2":
                        if (EmpresaID == "GH")
                        {
                            if (AppSettings.GHSerieDefectoFactura != "")
                                CboSerieGuia.ComboBox.SelectedValue = AppSettings.GHSerieDefectoFactura;
                        }
                        else if (EmpresaID == "IH")
                        {
                            if (AppSettings.IHSerieDefectoFactura != "")
                                CboSerieGuia.ComboBox.SelectedValue = AppSettings.IHSerieDefectoFactura;
                        }
                        else if (EmpresaID == "CH")
                        {
                            if (AppSettings.CHSerieDefectoFactura != "")
                                CboSerieGuia.ComboBox.SelectedValue = AppSettings.CHSerieDefectoFactura;
                        }
                        else if (EmpresaID == "AH")
                        {
                            if (AppSettings.AHSerieDefectoFactura != "")
                                CboSerieGuia.ComboBox.SelectedValue = AppSettings.AHSerieDefectoFactura;
                        }
                        break;
                    case "3":
                        if (EmpresaID == "GH")
                        {
                            if (AppSettings.GHSerieDefectoTicket != "")
                                CboSerieGuia.ComboBox.SelectedValue = AppSettings.GHSerieDefectoTicket;
                        }
                        else if (EmpresaID == "IH")
                        {
                            if (AppSettings.IHSerieDefectoTicket != "")
                                CboSerieGuia.ComboBox.SelectedValue = AppSettings.IHSerieDefectoTicket;
                        }
                        else if (EmpresaID == "CH")
                        {
                            if (AppSettings.CHSerieDefectoTicket != "")
                                CboSerieGuia.ComboBox.SelectedValue = AppSettings.CHSerieDefectoTicket;
                        }
                        else if (EmpresaID == "AH")
                        {
                            if (AppSettings.AHSerieDefectoTicket != "")
                                CboSerieGuia.ComboBox.SelectedValue = AppSettings.AHSerieDefectoTicket;
                        }
                        ChkEsTicketFactura.Checked = false;
                        ChkEsTicketFactura.Visible = true;
                        break;
                }

                if (Dv.Count == 0)
                {
                    CboSerieGuia.SelectedIndex = -1;
                    CboSerieGuia.Text = "";
                }

                if (Convert.ToInt16(CboTipoComprobante.ComboBox.SelectedValue) == 1)//es boleta
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
                else if (Convert.ToInt16(CboTipoComprobante.ComboBox.SelectedValue) == 2)//es factura
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

            }
            else
            {
                CboSerieGuia.SelectedIndex = -1;
                CboSerieGuia.Text = "";
            }
        }

        private void RbReserva_CheckedChanged(object sender, EventArgs e)
        {
            if (RbReserva.Checked == true)
            {
                //limpiar el detalle
                DtDetalleComprobante.Rows.Clear();
            }
            else
            {
                DtDetalleComprobante.Rows.Clear();
            }
        }

        private void CboTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable DtCreditos = new DataTable();
            if (CboTipoPago.SelectedIndex != -1 && CboTipoPago.ComboBox.SelectedValue.ToString() == "1")//es credito
            {
                LstCreditos.Visible = true;
                CboFormaPago.Visible = false;
                PnlCreditos.Visible = true;

                //traer créditos
                DtCreditos = ObjCL_Credito.GetCreditosCliente(ClienteID, "A");
                LstCreditos.HoldFields();
                LstCreditos.DataSource = DtCreditos;
            }
            else
            {
                LstCreditos.Visible = false;
                CboFormaPago.Visible = true;
                PnlCreditos.Visible = false;
            }
        }

        private void useCliente2_ComboValueChange()
        {
            ClienteID = Convert.ToInt32(useCliente2.cbCliente.SelectedValue);
            if (CboTipoPago.SelectedIndex != -1 && CboTipoPago.ComboBox.SelectedValue.ToString() == "1")//es credito
            {
                CboTipoPago_SelectedIndexChanged(null, null);
            }
        }

        private void BtnReserva_Click(object sender, EventArgs e)
        {
            Alias = TxtProducto.Text;
            ProductoID = TxtCodigo.Text;
            if (Alias != "" & ProductoID != "")
            {
                FrmReserva ObjFrmReserva = new FrmReserva();
                ObjFrmReserva.Alias = Alias;
                ObjFrmReserva.ProductoID = ProductoID;
                ObjFrmReserva.ShowDialog();

                if (ObjFrmReserva.Aprobado == true)
                {
                    FechaReserva = ObjFrmReserva.FechaReserva;
                    AgregarDetalle(ObjFrmReserva.Cantidad);
                }
                Calcular();
                CalcularTotales();
                TxtProducto.Text = "";
                TxtCodigo.Text = "";
                if (RbReserva.Checked == false)
                    PesoNeto = 0;
                TxtPrecio.Text = "";
                TxtCodigo.Focus();
            }
        }

        private void c1cboCia_SelectedValueChanged(object sender, EventArgs e)
        {
            if (c1cboCia.SelectedIndex != -1)
            {
                EmpresaID = c1cboCia.SelectedValue.ToString();
                if (NroTerminales == 1)
                {
                    if (CboTipoComprobante.SelectedIndex != -1)
                    {
                        CboTipoComprobante_SelectedIndexChanged(null, null);
                        BtnNuevoComprobante_Click(null, null);
                    }
                }
            }
            DtDetalleComprobante.Rows.Clear();
        }

        private void BtnGenerarGuias_Click(object sender, EventArgs e)
        {

            #region Crear tabla para enviar a crear guias
            DataTable DtDetalleGuiaRemisionVenta = new DataTable("DetalleGuiaRemisionVenta");
            DtDetalleGuiaRemisionVenta.Columns.Add("NomProducto", typeof(string));
            DtDetalleGuiaRemisionVenta.Columns.Add("UnidadMedidaID", typeof(string));
            DtDetalleGuiaRemisionVenta.Columns.Add("ProductoID", typeof(string));
            DtDetalleGuiaRemisionVenta.Columns.Add("CantidadEnviada", typeof(decimal));
            DtDetalleGuiaRemisionVenta.Columns.Add("PesoNeto", typeof(decimal));

            //añadir los detalles a una nueva tabla
            foreach (DataRow DR in DtDetalleComprobante.Rows)
            {
                DataRow DrD = DtDetalleGuiaRemisionVenta.NewRow();
                DrD["NomProducto"] = DR["Alias"];
                DrD["UnidadMedidaID"] = DR["UnidadMedidaID"];
                DrD["ProductoID"] = DR["ProductoID"];
                DrD["CantidadEnviada"] = DR["Cantidad"];
                DrD["PesoNeto"] = DR["PesoNeto"];
                DtDetalleGuiaRemisionVenta.Rows.Add(DrD);
            }
            #endregion

            #region validar que no haya "0" en el peso de los productos
            //agregar los que su cantidad se altero (osea mayor a 0)

            foreach (DataRow Dr in DtDetalleGuiaRemisionVenta.Rows)
            {
                bool HayPesoCero = true;
                string NomProducto = "";
                if (Dr["PesoNeto"].ToString() == "" || Dr["PesoNeto"].ToString() == "." | Dr["PesoNeto"] == DBNull.Value | Convert.ToDecimal(Dr["PesoNeto"].ToString()) == 0)
                {
                    HayPesoCero = true;
                    NomProducto = Dr["NomProducto"].ToString();
                    MessageBox.Show("Hay peso '0' en el producto: " + NomProducto + ". el peso no debe ser cero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            #endregion


            FrmGuias ObjFrmGuias = new FrmGuias();
            ObjFrmGuias.DtDetalleGuiaRemisionVenta = DtDetalleGuiaRemisionVenta;
            ObjFrmGuias.DtTipoComprobante = DtTipoDocumento.Copy();
            ObjFrmGuias.Destinatario = useCliente2.cbNombre.Columns["RazonSocial"].ToString();
            ObjFrmGuias.RUCDestinatario = useCliente2.cbCliente.Columns["NroDocumento"].ToString();
            ObjFrmGuias.Remitente = c1cboCia.Columns["NomEmpresa"].ToString();
            ObjFrmGuias.RUCRemitente = c1cboCia.Columns["RUC"].ToString();
            ObjFrmGuias.DtServicios = DtServicios;
            ObjFrmGuias.ShowDialog();
        }

        private void TdgDocumento_BeforeUpdate(object sender, C1.Win.C1TrueDBGrid.CancelEventArgs e)
        {
            Calcular();
            CalcularTotales();
        }

        private void Descuentoautomatico()
        {

            //eliminar descuento
            EliminarDescuento();

            //calcular el descuento automaticamente
            descuento = 0;

            //agrega el producto "descuento"
            DataView Dv = new DataView(DtServicios);
            Dv.RowFilter = "Tipo='-'";

            AlmacenID = EmpresaID + AppSettings.SedeID + "DES";//existe pero no vaa disminuir nada
            StockDisponible = 1;
            LblStock.Text = StockDisponible.ToString();
            ProductoID = Dv[0]["ProductoID"].ToString();
            ProductoIDVentas = Dv[0]["ProductoID"].ToString();
            Alias = Dv[0]["Alias"].ToString();
            UnidadMedidaID = Dv[0]["UnidadMedidaID"].ToString();
            PrecioUnitario = Convert.ToDecimal(Dv[0]["PrecioUnitario"].ToString());
            //calcular el descuento
            TotalPagar = Convert.ToDecimal(DtDetalleComprobante.Compute("(sum(Importe) *  " + IGV + ") + sum(Importe)", ""));
            descuento = TotalPagar - Math.Truncate(TotalPagar);
            //actualizar el descuento
            AgregarDetalle(descuento * -1);
        }

        private void TdgDocumento_AfterUpdate(object sender, EventArgs e)
        {
            //se actualiza la cantidad del descuento
            descuento = 0;
            //calcular el descuento
            foreach (DataRow Dr in DtDetalleComprobante.Rows)
            {
                descuento += Convert.ToDecimal(Dr["Descuento"]) * Convert.ToDecimal(Dr["Cantidad"]);
            }
            //agrega el producto "descuento"
            DataView Dv = new DataView(DtServicios);
            Dv.RowFilter = "Tipo='-'";

            DataView Dv2 = new DataView(DtDetalleComprobante);
            Dv2.RowFilter = "ProductoID = '" + Dv[0]["ProductoID"].ToString() + "'";
            if (Dv2.Count > 0)
            {
                DataRow[] customerRow = DtDetalleComprobante.Select("ProductoID = '" + Dv[0]["ProductoID"].ToString() + "'");
                customerRow[0]["Cantidad"] = descuento * -1;
                customerRow[0]["Importe"] = decimal.Round((descuento * -1) * Convert.ToDecimal(Dv[0]["PrecioUnitario"]));
            }

            Calcular();
            CalcularTotales();
        }

        private void TdgDocumento_FetchCellStyle(object sender, C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs e)
        {

            DataView Dv = new DataView(DtServicios);
            Dv.RowFilter = "Tipo='-'";
            //deshabilitar para que no se modifique el decuento
            switch (e.Column.DataColumn.DataField)
            {
                case "Cantidad":
                    if (this.TdgDocumento[e.Row, "ProductoID"].ToString().Trim() == Dv[0]["ProductoID"].ToString())
                    {
                        e.CellStyle.Locked = true;
                        break;
                    }
                    break;
                case "Descuento":
                    if (this.TdgDocumento[e.Row, "ProductoID"].ToString().Trim() == Dv[0]["ProductoID"].ToString())
                    {
                        e.CellStyle.Locked = true;
                        break;
                    }
                    break;

            }

            DataView Dv2 = new DataView(DtServicios);
            Dv2.RowFilter = "Tipo='+'";
            //deshabilitar para que no se modifique el decuento
            switch (e.Column.DataColumn.DataField)
            {
                case "Descuento":
                    if (this.TdgDocumento[e.Row, "ProductoID"].ToString().Trim() == Dv2[0]["ProductoID"].ToString())
                    {
                        e.CellStyle.Locked = true;
                        break;
                    }
                    break;

            }
        }

        private void TdgDocumento_FetchRowStyle(object sender, C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs e)
        {
            DataView Dv = new DataView(DtServicios);
            Dv.RowFilter = "Tipo='-'";
            //deshabilitar para que no se modifique el decuento

            string S = TdgDocumento.Columns["ProductoID"].CellText(e.Row).ToString();
            if (S == Dv[0]["ProductoID"].ToString())
            {
                e.CellStyle.BackColor = System.Drawing.Color.LightCoral;
            }

            DataView Dv2 = new DataView(DtServicios);
            Dv2.RowFilter = "Tipo='+'";
            //deshabilitar para que no se modifique el decuento

            string S2 = TdgDocumento.Columns["ProductoID"].CellText(e.Row).ToString();
            if (S2 == Dv2[0]["ProductoID"].ToString())
            {
                e.CellStyle.BackColor = System.Drawing.Color.LightSeaGreen;
            }
        }

        private void ChkFlete_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkFlete.Checked == true)
            {
                //agrega el producto "flete"
                DataView Dv = new DataView(DtServicios);
                Dv.RowFilter = "Tipo='+'";

                AlmacenID = EmpresaID + AppSettings.SedeID + "DES"; //existe pero no vaa disminuir nada
                StockDisponible = 1;
                LblStock.Text = StockDisponible.ToString();
                ProductoID = Dv[0]["ProductoID"].ToString();
                ProductoIDVentas = Dv[0]["ProductoID"].ToString();
                Alias = Dv[0]["Alias"].ToString();
                UnidadMedidaID = Dv[0]["UnidadMedidaID"].ToString();
                PrecioUnitario = Convert.ToDecimal(Dv[0]["PrecioUnitario"].ToString());

                //actualizar el descuento
                AgregarDetalle(0);
            }
            else
            {
                //buscar el producto "flete"
                DataView Dv = new DataView(DtServicios);
                Dv.RowFilter = "Tipo='+'";

                //se elimina el registro que contiene el descuento
                DataView Dv2 = new DataView(DtDetalleComprobante);
                Dv2.RowFilter = "ProductoID = '" + Dv[0]["ProductoID"].ToString() + "'";
                if (Dv2.Count > 0)
                {
                    DataRow[] customerRow = DtDetalleComprobante.Select("ProductoID = '" + Dv[0]["ProductoID"].ToString() + "'");
                    customerRow[0].Delete();
                }
                Calcular();
                CalcularTotales();
            }
        }

        private void TdgDocumento_BeforeColUpdate(object sender, C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs e)
        {
            if (TdgDocumento.RowCount > 0)
            {
                if (TdgDocumento.Columns["Descuento"].Value.ToString() == "" | TdgDocumento.Columns["Descuento"].Value.ToString() == ".")
                {
                    e.Cancel = true;
                    TdgDocumento.Columns["Descuento"].Value = 0;
                    e.Cancel = false;
                    return;
                }
                if (TdgDocumento.Columns["Cantidad"].Value.ToString() == "" | TdgDocumento.Columns["Cantidad"].Value.ToString() == ".")
                {
                    e.Cancel = true;
                    TdgDocumento.Columns["Cantidad"].Value = 0;
                    e.Cancel = false;
                    return;
                }

            }
        }

        private void CboFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboFormaPago.SelectedIndex != -1 && CboFormaPago.ComboBox.SelectedValue.ToString() == "5")//es vale
            {
                //aca aparece la ventana de los vales
                FrmValesConsumo ObjFrmValesConsumo = new FrmValesConsumo();
                ObjFrmValesConsumo.ShowDialog();
                if (ObjFrmValesConsumo.DtValesConsumo != null && ObjFrmValesConsumo.DtValesConsumo.Rows.Count > 0)
                    DtValesConsumo = ObjFrmValesConsumo.DtValesConsumo.Copy();
            }
            else if (CboFormaPago.SelectedIndex != -1 && CboFormaPago.ComboBox.SelectedValue.ToString() == "3")//es boucher
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

        private void btnBalanza_Click(object sender, EventArgs e)
        {
            FrmPesos ObjFrmPesos = new FrmPesos();
            ObjFrmPesos.ShowDialog();
            PesoNeto = ObjFrmPesos.PesoNeto;

            if (PesoNeto > 0)
            {
                if (RbDiferida.Checked == true | RbExterno.Checked == true | RbReserva.Checked == true)
                {
                    AgregarDetalle(PesoNeto);
                }
                else if (RbNormal.Checked == true)
                {
                    if (PesoNeto <= StockDisponible)
                    {
                        AgregarDetalle(PesoNeto);
                        StockDisponible = 0;
                        LblStock.Text = StockDisponible.ToString();
                    }
                    else
                        MessageBox.Show("Lo solicitado no puede ser mayor al stock disponible.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            CalcularTotales();
            ObjFrmPesos.Dispose();
        }

        private void BtnInicioCaja_Click(object sender, EventArgs e)
        {
            //aperturar caja con una cantidad inicial de dinero
            FrmAperturaCaja ObjFrmAperturaCaja = new FrmAperturaCaja();
            ObjFrmAperturaCaja.DtEmpresas = Dtempresas;
            ObjFrmAperturaCaja.NumCaja = NumCaja;
            ObjFrmAperturaCaja.EmpresaID = EmpresaID;
            ObjFrmAperturaCaja.NomCaja = NomCaja;
            ObjFrmAperturaCaja.NroDocumento = useCliente2.cbCliente.Columns["NroDocumento"].Value.ToString();
            ObjFrmAperturaCaja.Cliente = useCliente2.cbNombre.Columns["RazonSocial"].Value.ToString();
            ObjFrmAperturaCaja.ClienteID = Convert.ToInt32(useCliente2.cbCliente.SelectedValue);
            ObjFrmAperturaCaja.ShowDialog();
            ObjFrmAperturaCaja.Dispose();

        }

        private void BtnEgreso_Click(object sender, EventArgs e)
        {
            //registrar egresos
            FrmEgreso ObjFrmEgreso = new FrmEgreso();
            ObjFrmEgreso.NomCaja = NomCaja;
            ObjFrmEgreso.EmpresaID = EmpresaID;
            ObjFrmEgreso.NumCaja = NumCaja;
            ObjFrmEgreso.DtEmpresas = Dtempresas;
            ObjFrmEgreso.ShowDialog();
            ObjFrmEgreso.Dispose();
        }

        private void BtnAdelantos_Click(object sender, EventArgs e)
        {
            //aca se vè lso adelantos
            FrmAdelantos ObjFrmAdelantos = new FrmAdelantos();
            ObjFrmAdelantos.ClienteID = Convert.ToInt32(useCliente2.cbCliente.SelectedValue);
            ObjFrmAdelantos.ShowDialog();
            DtNotaIngreso = ObjFrmAdelantos.DtNotaIngreso.Copy();
            //eliminar columnas innecesarias
            if (DtNotaIngreso.Columns.Count > 0)
            {
                DtNotaIngreso.Columns.Remove("NomEmpresa");
                DtNotaIngreso.Columns.Remove("Observacion");
                DtNotaIngreso.Columns.Remove("AudCrea");
            }
            ObjFrmAdelantos.Dispose(); //eliminamos el objeto???
        }

        private void BtnDefault_Click(object sender, EventArgs e)
        {
            if (CboSerieGuia.SelectedIndex != -1)
            {
                UpdateConfiguration ObjUpdateConfiguration = new UpdateConfiguration();
                //seleccionar la serie por defecto
                switch (CboTipoComprobante.ComboBox.SelectedValue.ToString())
                {
                    case "1":
                        if (EmpresaID == "GH")
                            ObjUpdateConfiguration.AppSettingsSectionModify("GHSerieDefectoBoleta", CboSerieGuia.ComboBox.SelectedValue.ToString());
                        else if (EmpresaID == "IH")
                            ObjUpdateConfiguration.AppSettingsSectionModify("IHSerieDefectoBoleta", CboSerieGuia.ComboBox.SelectedValue.ToString());
                        else if (EmpresaID == "CH")
                            ObjUpdateConfiguration.AppSettingsSectionModify("CHSerieDefectoBoleta", CboSerieGuia.ComboBox.SelectedValue.ToString());
                        else if (EmpresaID == "AH")
                            ObjUpdateConfiguration.AppSettingsSectionModify("AHSerieDefectoBoleta", CboSerieGuia.ComboBox.SelectedValue.ToString());
                        break;
                    case "2":
                        if (EmpresaID == "GH")
                            ObjUpdateConfiguration.AppSettingsSectionModify("GHSerieDefectoFactura", CboSerieGuia.ComboBox.SelectedValue.ToString());
                        else if (EmpresaID == "IH")
                            ObjUpdateConfiguration.AppSettingsSectionModify("IHSerieDefectoFactura", CboSerieGuia.ComboBox.SelectedValue.ToString());
                        else if (EmpresaID == "CH")
                            ObjUpdateConfiguration.AppSettingsSectionModify("CHSerieDefectoFactura", CboSerieGuia.ComboBox.SelectedValue.ToString());
                        else if (EmpresaID == "AH")
                            ObjUpdateConfiguration.AppSettingsSectionModify("AHSerieDefectoFactura", CboSerieGuia.ComboBox.SelectedValue.ToString());
                        break;
                    case "3":
                        if (EmpresaID == "GH")
                            ObjUpdateConfiguration.AppSettingsSectionModify("GHSerieDefectoTicket", CboSerieGuia.ComboBox.SelectedValue.ToString());
                        else if (EmpresaID == "IH")
                            ObjUpdateConfiguration.AppSettingsSectionModify("IHSerieDefectoTicket", CboSerieGuia.ComboBox.SelectedValue.ToString());
                        else if (EmpresaID == "CH")
                            ObjUpdateConfiguration.AppSettingsSectionModify("CHSerieDefectoTicket", CboSerieGuia.ComboBox.SelectedValue.ToString());
                        else if (EmpresaID == "AH")
                            ObjUpdateConfiguration.AppSettingsSectionModify("AHSerieDefectoTicket", CboSerieGuia.ComboBox.SelectedValue.ToString());
                        break;
                }
                MessageBox.Show("Se actualizo la serie de la empresa '" + EmpresaID + "', de " + CboTipoComprobante.ComboBox.Text + " con la serie: " + CboSerieGuia.ComboBox.SelectedValue.ToString() + ".", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void EliminarDescuento()
        {
            //buscar el producto "descuento"
            DataView Dv = new DataView(DtServicios);
            Dv.RowFilter = "Tipo='-'";

            DataView Dv2 = new DataView(DtDetalleComprobante);
            Dv2.RowFilter = "ProductoID = '" + Dv[0]["ProductoID"].ToString() + "'";
            if (Dv2.Count > 0)
            {
                //se elimina el registro que contiene el descuento
                DataRow[] customerRow = DtDetalleComprobante.Select("ProductoID = '" + Dv[0]["ProductoID"].ToString() + "'");
                customerRow[0].Delete();
            }
        }

        private void ChkDescuento_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkDescuento.Checked == true)
            {
                if (TotalPagar - Math.Truncate(TotalPagar) > 0)
                {
                    Descuentoautomatico();
                }
            }
            else
            {
                EliminarDescuento();
            }

            //volver a calcular valores
            if (DtDetalleComprobante.Rows.Count != 0)
            {
                TotalIGV = Convert.ToDecimal(DtDetalleComprobante.Compute("sum(Importe) *  " + IGV, ""));
                Subtotal = Convert.ToDecimal(DtDetalleComprobante.Compute("sum(Importe)", "").ToString());
                TotalPagar = Convert.ToDecimal(DtDetalleComprobante.Compute("(sum(Importe) *  " + IGV + ") + sum(Importe)", ""));
            }
            else
            {
                TotalIGV = 0;
                Subtotal = 0;
                TotalPagar = 0;
            }



            TxtIGV.Text = TotalIGV.ToString("C");
            TxtValorVenta.Text = Subtotal.ToString("C");
            TxtVentaNeta.Text = TotalPagar.ToString("C");

            //if (ChkDescuento.Checked == true)
            //{
            //    //eliminar descuento
            //    EliminarDescuento();

            //    descuento = 0;
            //    //muestra el descuento
            //    this.TdgDocumento.Splits[0].DisplayColumns["Descuento"].Visible = true;
            //    //agrega el producto "descuento"
            //    DataView Dv = new DataView(DtServicios);
            //    Dv.RowFilter = "Tipo='-'";

            //    AlmacenID = EmpresaID + AppSettings.SedeID + "DES";//existe pero no vaa disminuir nada
            //    StockDisponible = 1;
            //    LblStock.Text = StockDisponible.ToString();
            //    ProductoID = Dv[0]["ProductoID"].ToString();
            //    ProductoIDVentas = Dv[0]["ProductoID"].ToString();
            //    Alias = Dv[0]["Alias"].ToString();
            //    UnidadMedidaID = Dv[0]["UnidadMedidaID"].ToString();
            //    PrecioUnitario = Convert.ToDecimal(Dv[0]["PrecioUnitario"].ToString());
            //    //calcular el descuento
            //    foreach (DataRow Dr in DtDetalleComprobante.Rows)
            //    {
            //        descuento += Convert.ToDecimal(Dr["Descuento"]) * Convert.ToDecimal(Dr["Cantidad"]);
            //    }

            //    //actualizar el descuento
            //    AgregarDetalle(descuento * -1);
            //}
            //else
            //{

            //    //actualizar descuento a 0
            //    foreach (DataRow Dr in DtDetalleComprobante.Rows)
            //    {
            //        Dr["Descuento"] = 0;
            //    }

            //    //se quita la columna descuento
            //    this.TdgDocumento.Splits[0].DisplayColumns["Descuento"].Visible = false;

            //    //eliminar descuento
            //    EliminarDescuento();
            //}
            //Calcular();
            //CalcularTotales();
        }

    }
}


