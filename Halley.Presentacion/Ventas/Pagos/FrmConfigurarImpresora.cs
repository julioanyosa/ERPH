using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Empresa;
using Halley.Utilitario;
using Halley.Configuracion;
using Halley.CapaLogica.Ventas;
using System.Configuration;
using System.Net;

namespace Halley.Presentacion.Ventas.Pagos
{
    public partial class FrmConfigurarImpresora : Form
    {

        string ImpresoraBoletaGranja = "";
        string ImpresoraBoletaComercio = "";
        string ImpresoraBoletaIndustria = "";
        string ImpresoraBoletaAvicola = "";
        string ImpresoraFacturaGranja = "";
        string ImpresoraFacturaIndustria = "";
        string ImpresoraFacturaComercio = "";
        string ImpresoraFacturaAvicola = "";
        string ImpresoraTicketGranja = "";
        string ImpresoraTicketComercio = "";
        string ImpresoraTicketIndustria = "";
        string ImpresoraTicketAvicola= "";
        string ImpresoraPago = "";
        CapaLogica.Users.CL_Usuario ObjUsuario = new CapaLogica.Users.CL_Usuario();

        string NuevaIP = "";

        public FrmConfigurarImpresora()
        {
            InitializeComponent();
        }

        private void FrmConfigurarImpresora_Load(object sender, EventArgs e)
        {
            //agregar empresa
            c1Combo.FillC1Combo(this.c1cboCia, new CL_Empresas().GetEmpresas(), "NomEmpresa", "EmpresaID");
            c1Combo.FillC1Combo1(CboTipoComprobante, new CL_Comprobante().getTipoComprobante(), "NomTipoComprobante", "TipoComprobanteID");

           

            #region nueva ip
            String NombreHost;
            String DireccionIP;
            NombreHost = Dns.GetHostName();
            DireccionIP = System.Net.Dns.GetHostByName(NombreHost).AddressList[0] + "";
            //MessageBox.Show(DireccionIP);
            //dar formato a la direccion IP
            string ACU = "";
            NuevaIP = "";
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
            #endregion

            //ahora se gauradara en una tabla Configuracion.Configuracion
            
            UTI_Datatables.Dt_Configuracion = ObjUsuario.USP_M_CONFIGURACION(2, 0, "", "", "", "", 0, NuevaIP);

            DataView dv = new DataView();

            dv = new DataView(UTI_Datatables.Dt_Configuracion, "Codigo='IMP_GH_BO'", "", DataViewRowState.CurrentRows);
            if (dv.Count > 0)
            {
                LblBoletaGranja.Text = dv[0]["Data"].ToString();
            }

            dv = new DataView(UTI_Datatables.Dt_Configuracion, "Codigo='IMP_GH_FA'", "", DataViewRowState.CurrentRows);
            if (dv.Count > 0)
            {
                LblFacturaGranja.Text = dv[0]["Data"].ToString();
            }

            dv = new DataView(UTI_Datatables.Dt_Configuracion, "Codigo='IMP_GH_TI'", "", DataViewRowState.CurrentRows);
            if (dv.Count > 0)
            {
                LblTicketGranja.Text = dv[0]["Data"].ToString();
            }

            dv = new DataView(UTI_Datatables.Dt_Configuracion, "Codigo='IMP_IH_BO'", "", DataViewRowState.CurrentRows);
            if (dv.Count > 0)
            {
                LblBoletaIndustria.Text = dv[0]["Data"].ToString();
            }

            dv = new DataView(UTI_Datatables.Dt_Configuracion, "Codigo='IMP_IH_FA'", "", DataViewRowState.CurrentRows);
            if (dv.Count > 0)
            {
                LblFacturaIndustria.Text = dv[0]["Data"].ToString();
            }

            dv = new DataView(UTI_Datatables.Dt_Configuracion, "Codigo='IMP_IH_TI'", "", DataViewRowState.CurrentRows);
            if (dv.Count > 0)
            {
                LblTicketIndustria.Text = dv[0]["Data"].ToString();
            }

            dv = new DataView(UTI_Datatables.Dt_Configuracion, "Codigo='IMP_CH_BO'", "", DataViewRowState.CurrentRows);
            if (dv.Count > 0)
            {
                LblBoletaComercial.Text = dv[0]["Data"].ToString();
            }

            dv = new DataView(UTI_Datatables.Dt_Configuracion, "Codigo='IMP_CH_FA'", "", DataViewRowState.CurrentRows);
            if (dv.Count > 0)
            {
                LblFacturaComercial.Text = dv[0]["Data"].ToString();
            }

            dv = new DataView(UTI_Datatables.Dt_Configuracion, "Codigo='IMP_CH_TI'", "", DataViewRowState.CurrentRows);
            if (dv.Count > 0)
            {
                LblTicketComercial.Text = dv[0]["Data"].ToString();
            }

            dv = new DataView(UTI_Datatables.Dt_Configuracion, "Codigo='IMP_PA'", "", DataViewRowState.CurrentRows);
            if (dv.Count > 0)
            {
                LblTicketPago.Text = dv[0]["Data"].ToString();
            }
          
        }

        private void BtnImpresora_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {

                string EMPRESA_ID = c1cboCia.SelectedValue.ToString() ;
                if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 1 & EMPRESA_ID == "GH")//es boleta
                {
                    ImpresoraBoletaGranja = printDialog1.PrinterSettings.PrinterName;
                    //*****************guardar la configuracion de la impresora en el appconfig**************
                    if (ImpresoraBoletaGranja != AppSettings.ImpresoraBoletaGranja & ImpresoraBoletaGranja != "")
                    {
                        //ahora se gauradara en una tabla Configuracion.Configuracion
                        DataTable DtImpresora = new DataTable();
                        DtImpresora = ObjUsuario.USP_M_CONFIGURACION(1, 0, EMPRESA_ID, "IMP_GH_BO", "IMPRESORA BOLETA DE GRANJA", ImpresoraBoletaGranja, AppSettings.UserID, NuevaIP);
                        LblBoletaGranja.Text = ImpresoraBoletaGranja;
                        ActualizarConfiguracion(EMPRESA_ID, "IMP_GH_BO", ImpresoraBoletaGranja, NuevaIP);
                        MessageBox.Show("Se guardo correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        
                    }
                }
                else if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 2 & EMPRESA_ID == "GH")// es factura
                {
                    ImpresoraFacturaGranja = printDialog1.PrinterSettings.PrinterName;
                    //*****************guardar la configuracion de la impresora en el appconfig**************
                    if (ImpresoraFacturaGranja != AppSettings.ImpresoraFacturaGranja & ImpresoraFacturaGranja != "")
                    {
                        //ahora se gauradara en una tabla Configuracion.Configuracion
                        DataTable DtImpresora = new DataTable();
                        DtImpresora = ObjUsuario.USP_M_CONFIGURACION(1, 0, EMPRESA_ID, "IMP_GH_FA", "IMPRESORA FACTURA DE GRANJA", ImpresoraFacturaGranja, AppSettings.UserID, NuevaIP);
                        LblFacturaGranja.Text = ImpresoraFacturaGranja;
                        ActualizarConfiguracion(EMPRESA_ID, "IMP_GH_FA", ImpresoraFacturaGranja, NuevaIP);
                        MessageBox.Show("Se guardo correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 3 & c1cboCia.SelectedValue.ToString() == "GH")// es ticket
                {
                    ImpresoraTicketGranja = printDialog1.PrinterSettings.PrinterName;
                    //*****************guardar la configuracion de la impresora en el appconfig**************
                    if (ImpresoraTicketGranja != AppSettings.ImpresoraTicketGranja & ImpresoraTicketGranja != "")
                    {

                        //ahora se gauradara en una tabla Configuracion.Configuracion
                        DataTable DtImpresora = new DataTable();
                        DtImpresora = ObjUsuario.USP_M_CONFIGURACION(1, 0, EMPRESA_ID, "IMP_GH_TI", "IMPRESORA TICKET DE GRANJA", ImpresoraTicketGranja, AppSettings.UserID, NuevaIP);
                        LblTicketGranja.Text = ImpresoraTicketGranja;
                        ActualizarConfiguracion(EMPRESA_ID, "IMP_GH_TI", ImpresoraTicketGranja, NuevaIP);
                        MessageBox.Show("Se guardo correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }

                else if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 1 & c1cboCia.SelectedValue.ToString() == "IH")//es boleta
                {
                    ImpresoraBoletaIndustria = printDialog1.PrinterSettings.PrinterName;
                    //*****************guardar la configuracion de la impresora en el appconfig**************
                    if (ImpresoraBoletaIndustria != AppSettings.ImpresoraBoletaIndustria & ImpresoraBoletaIndustria != "")
                    {

                        //ahora se gauradara en una tabla Configuracion.Configuracion
                        DataTable DtImpresora = new DataTable();
                        DtImpresora = ObjUsuario.USP_M_CONFIGURACION(1, 0, EMPRESA_ID, "IMP_IH_BO", "IMPRESORA BOLETA DE INDUSTRIA", ImpresoraBoletaIndustria, AppSettings.UserID, NuevaIP);
                        LblBoletaIndustria.Text = ImpresoraBoletaIndustria;
                        ActualizarConfiguracion(EMPRESA_ID, "IMP_IH_BO", ImpresoraBoletaIndustria, NuevaIP);
                        MessageBox.Show("Se guardo correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        //AppSettingsSection appSettings = config.AppSettings;

                        //KeyValueConfigurationElement setting = appSettings.Settings["ImpresoraBoletaIndustria"];
                        //setting.Value = ImpresoraBoletaIndustria;
                        //config.Save(ConfigurationSaveMode.Modified);
                        //ConfigurationManager.RefreshSection("appSettings");
                        //LblBoletaIndustria.Text = ImpresoraBoletaIndustria;
                        //MessageBox.Show("Se guardo correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 2 & c1cboCia.SelectedValue.ToString() == "IH")// es factura
                {
                    ImpresoraFacturaIndustria = printDialog1.PrinterSettings.PrinterName;
                    //*****************guardar la configuracion de la impresora en el appconfig**************
                    if (ImpresoraFacturaIndustria != AppSettings.ImpresoraFacturaIndustria & ImpresoraFacturaIndustria != "")
                    {

                        //ahora se gauradara en una tabla Configuracion.Configuracion
                        DataTable DtImpresora = new DataTable();
                        DtImpresora = ObjUsuario.USP_M_CONFIGURACION(1, 0, EMPRESA_ID, "IMP_IH_FA", "IMPRESORA FACTURA DE INDUSTRIA", ImpresoraFacturaIndustria, AppSettings.UserID, NuevaIP);
                        LblFacturaIndustria.Text = ImpresoraFacturaIndustria;
                        ActualizarConfiguracion(EMPRESA_ID, "IMP_IH_FA", ImpresoraFacturaIndustria, NuevaIP);
                        MessageBox.Show("Se guardo correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        //AppSettingsSection appSettings = config.AppSettings;

                        //KeyValueConfigurationElement setting = appSettings.Settings["ImpresoraFacturaIndustria"];
                        //setting.Value = ImpresoraFacturaIndustria;
                        //config.Save(ConfigurationSaveMode.Modified);
                        //ConfigurationManager.RefreshSection("appSettings");
                        //LblFacturaIndustria.Text = ImpresoraFacturaIndustria;
                        //MessageBox.Show("Se guardo correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 3 & c1cboCia.SelectedValue.ToString() == "IH")// es ticket
                {
                    ImpresoraTicketIndustria = printDialog1.PrinterSettings.PrinterName;
                    //*****************guardar la configuracion de la impresora en el appconfig**************
                    if (ImpresoraTicketIndustria != AppSettings.ImpresoraTicketIndustria & ImpresoraTicketIndustria != "")
                    {

                        //ahora se gauradara en una tabla Configuracion.Configuracion
                        DataTable DtImpresora = new DataTable();
                        DtImpresora = ObjUsuario.USP_M_CONFIGURACION(1, 0, EMPRESA_ID, "IMP_IH_TI", "IMPRESORA TICKET DE INDUSTRIA", ImpresoraTicketIndustria, AppSettings.UserID, NuevaIP);
                        LblTicketIndustria.Text = ImpresoraTicketIndustria;
                        ActualizarConfiguracion(EMPRESA_ID, "IMP_IH_TI", ImpresoraTicketIndustria, NuevaIP);
                        MessageBox.Show("Se guardo correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        //AppSettingsSection appSettings = config.AppSettings;

                        //KeyValueConfigurationElement setting = appSettings.Settings["ImpresoraTicketIndustria"];
                        //setting.Value = ImpresoraTicketIndustria;
                        //config.Save(ConfigurationSaveMode.Modified);
                        //ConfigurationManager.RefreshSection("appSettings");
                        //LblTicketIndustria.Text = ImpresoraTicketIndustria;
                        //MessageBox.Show("Se guardo correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                else if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 1 & c1cboCia.SelectedValue.ToString() == "CH")//es boleta
                {
                    ImpresoraBoletaComercio = printDialog1.PrinterSettings.PrinterName;
                    //*****************guardar la configuracion de la impresora en el appconfig**************
                    if (ImpresoraBoletaComercio != AppSettings.ImpresoraBoletaComercio & ImpresoraBoletaComercio != "")
                    {

                        //ahora se gauradara en una tabla Configuracion.Configuracion
                        DataTable DtImpresora = new DataTable();
                        DtImpresora = ObjUsuario.USP_M_CONFIGURACION(1, 0, EMPRESA_ID, "IMP_CH_BO", "IMPRESORA BOLETA DE COMERCIO", ImpresoraBoletaComercio, AppSettings.UserID, NuevaIP);
                        LblBoletaComercial.Text = ImpresoraBoletaComercio;
                        ActualizarConfiguracion(EMPRESA_ID, "IMP_CH_BO", ImpresoraBoletaComercio, NuevaIP);
                        MessageBox.Show("Se guardo correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        //AppSettingsSection appSettings = config.AppSettings;

                        //KeyValueConfigurationElement setting = appSettings.Settings["ImpresoraBoletaComercio"];
                        //setting.Value = ImpresoraBoletaComercio;
                        //config.Save(ConfigurationSaveMode.Modified);
                        //ConfigurationManager.RefreshSection("appSettings");
                        //LblBoletaComercial.Text = ImpresoraBoletaComercio;
                        //MessageBox.Show("Se guardo correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 2 & c1cboCia.SelectedValue.ToString() == "CH")// es factura
                {
                    ImpresoraFacturaComercio = printDialog1.PrinterSettings.PrinterName;
                    //*****************guardar la configuracion de la impresora en el appconfig**************
                    if (ImpresoraFacturaComercio != AppSettings.ImpresoraFacturaComercio & ImpresoraFacturaComercio != "")
                    {
                        //ahora se gauradara en una tabla Configuracion.Configuracion
                        DataTable DtImpresora = new DataTable();
                        DtImpresora = ObjUsuario.USP_M_CONFIGURACION(1, 0, EMPRESA_ID, "IMP_CH_FA", "IMPRESORA FACTURA DE COMERCIO", ImpresoraFacturaComercio, AppSettings.UserID, NuevaIP);
                        LblFacturaComercial.Text = ImpresoraFacturaComercio;
                        ActualizarConfiguracion(EMPRESA_ID, "IMP_CH_FA", ImpresoraFacturaComercio, NuevaIP);
                        MessageBox.Show("Se guardo correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        //AppSettingsSection appSettings = config.AppSettings;

                        //KeyValueConfigurationElement setting = appSettings.Settings["ImpresoraFacturaComercio"];
                        //setting.Value = ImpresoraFacturaComercio;
                        //config.Save(ConfigurationSaveMode.Modified);
                        //ConfigurationManager.RefreshSection("appSettings");
                        //LblFacturaComercial.Text = ImpresoraFacturaComercio;
                        //MessageBox.Show("Se guardo correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 3 & c1cboCia.SelectedValue.ToString() == "CH")// es ticket
                {
                    ImpresoraTicketComercio = printDialog1.PrinterSettings.PrinterName;
                    //*****************guardar la configuracion de la impresora en el appconfig**************
                    if (ImpresoraTicketComercio != AppSettings.ImpresoraTicketComercio & ImpresoraTicketComercio != "")
                    {
                        //ahora se gauradara en una tabla Configuracion.Configuracion
                        DataTable DtImpresora = new DataTable();
                        DtImpresora = ObjUsuario.USP_M_CONFIGURACION(1, 0, EMPRESA_ID, "IMP_CH_TI", "IMPRESORA TICKET DE COMERCIO", ImpresoraTicketComercio, AppSettings.UserID, NuevaIP);
                        LblTicketComercial.Text = ImpresoraTicketComercio;
                        ActualizarConfiguracion(EMPRESA_ID, "IMP_CH_TI", ImpresoraTicketComercio, NuevaIP);
                        MessageBox.Show("Se guardo correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        //AppSettingsSection appSettings = config.AppSettings;

                        //KeyValueConfigurationElement setting = appSettings.Settings["ImpresoraTicketComercio"];
                        //setting.Value = ImpresoraTicketComercio;
                        //config.Save(ConfigurationSaveMode.Modified);
                        //ConfigurationManager.RefreshSection("appSettings");
                        //LblTicketComercial.Text = ImpresoraTicketComercio;
                        //MessageBox.Show("Se guardo correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }


                else if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 1 & c1cboCia.SelectedValue.ToString() == "AH")//es boleta
                {
                    ImpresoraBoletaAvicola= printDialog1.PrinterSettings.PrinterName;
                    //*****************guardar la configuracion de la impresora en el appconfig**************
                    if (ImpresoraBoletaAvicola != AppSettings.ImpresoraBoletaAvicola & ImpresoraBoletaAvicola != "")
                    {

                        //ahora se gauradara en una tabla Configuracion.Configuracion
                        DataTable DtImpresora = new DataTable();
                        DtImpresora = ObjUsuario.USP_M_CONFIGURACION(1, 0, EMPRESA_ID, "IMP_AH_BO", "IMPRESORA BOLETA DE AVICOLA", ImpresoraBoletaAvicola, AppSettings.UserID, NuevaIP);
                        LblBoletaAvicola.Text = ImpresoraBoletaAvicola;
                        ActualizarConfiguracion(EMPRESA_ID, "IMP_AH_BO", ImpresoraBoletaAvicola, NuevaIP);
                        MessageBox.Show("Se guardo correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 2 & c1cboCia.SelectedValue.ToString() == "CH")// es factura
                {
                    ImpresoraFacturaAvicola = printDialog1.PrinterSettings.PrinterName;
                    //*****************guardar la configuracion de la impresora en el appconfig**************
                    if (ImpresoraFacturaAvicola != AppSettings.ImpresoraFacturaAvicola & ImpresoraFacturaAvicola != "")
                    {
                        //ahora se gauradara en una tabla Configuracion.Configuracion
                        DataTable DtImpresora = new DataTable();
                        DtImpresora = ObjUsuario.USP_M_CONFIGURACION(1, 0, EMPRESA_ID, "IMP_AH_FA", "IMPRESORA FACTURA DE AVICOLA", ImpresoraFacturaAvicola, AppSettings.UserID, NuevaIP);
                        LblFacturaAvicola.Text = ImpresoraFacturaAvicola;
                        ActualizarConfiguracion(EMPRESA_ID, "IMP_AH_FA", ImpresoraFacturaComercio, NuevaIP);
                        MessageBox.Show("Se guardo correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
              
                else if (Convert.ToInt16(CboTipoComprobante.SelectedValue) == 3 & c1cboCia.SelectedValue.ToString() == "AH")// es ticket
                {
                    ImpresoraTicketAvicola = printDialog1.PrinterSettings.PrinterName;
                    //*****************guardar la configuracion de la impresora en el appconfig**************
                    if (ImpresoraTicketAvicola != AppSettings.ImpresoraTicketAvicola & ImpresoraTicketAvicola != "")
                    {

                        //ahora se gauradara en una tabla Configuracion.Configuracion
                        DataTable DtImpresora = new DataTable();
                        DtImpresora = ObjUsuario.USP_M_CONFIGURACION(1, 0, EMPRESA_ID, "IMP_AH_TI", "IMPRESORA TICKET DE AVICOLA", ImpresoraTicketAvicola, AppSettings.UserID, NuevaIP);
                        LblTicketAvicola.Text = ImpresoraTicketAvicola;
                        ActualizarConfiguracion(EMPRESA_ID, "IMP_AH_TI", ImpresoraTicketAvicola, NuevaIP);
                        MessageBox.Show("Se guardo correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
        }

        private void BtnImpresoraPago_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                //configurar impresora de pago
                ImpresoraPago = printDialog1.PrinterSettings.PrinterName;
                //*****************guardar la configuracion de la impresora en el appconfig**************
                if (ImpresoraPago != AppSettings.ImpresoraPago & ImpresoraPago != "")
                {
                    string EMPRESA_ID = c1cboCia.SelectedValue.ToString();
                    //ahora se gauradara en una tabla Configuracion.Configuracion
                    DataTable DtImpresora = new DataTable();
                    DtImpresora = ObjUsuario.USP_M_CONFIGURACION(1, 0, EMPRESA_ID, "IMP_PA", "IMPRESORA PAGO DE " + EMPRESA_ID, ImpresoraPago, AppSettings.UserID, NuevaIP);

                    ActualizarConfiguracion(EMPRESA_ID, "IMP_PA", ImpresoraPago, NuevaIP);

                    LblTicketPago.Text = ImpresoraPago;
                    MessageBox.Show("Se guardo correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    //AppSettingsSection appSettings = config.AppSettings;

                    //KeyValueConfigurationElement setting = appSettings.Settings["ImpresoraPago"];
                    //setting.Value = ImpresoraPago;
                    //config.Save(ConfigurationSaveMode.Modified);
                    //ConfigurationManager.RefreshSection("appSettings");
                    //LblTicketPago.Text = ImpresoraPago;
                    //MessageBox.Show("Se guardo correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ActualizarConfiguracion(string EMPRESA_ID, string CODIGO, string Impresora, string direccionip)
        {
            //buscamos para actualizar
            DataView DV = new DataView(UTI_Datatables.Dt_Configuracion, "Codigo ='" + CODIGO + "'", "", DataViewRowState.CurrentRows);
            //si encuantr actualiza
            if (DV.Count>0)
            {
                //actualizar
                DataRow[] customerRow = UTI_Datatables.Dt_Configuracion.Select("Codigo ='" + CODIGO + "'");
                customerRow[0]["Data"] = Impresora;
            }
            else
            {
                //sino agrega
                    DataRow Dr = UTI_Datatables.Dt_Configuracion.NewRow();
                    Dr["ConfiguracionID"] = 0;//no interesa
                    Dr["EmpresaID"] = EMPRESA_ID;
                    Dr["Codigo"] = CODIGO;
                    Dr["Descripcion"] = "no interesa";
                    Dr["Data"] = Impresora;
                    Dr["UsuarioID"] = AppSettings.UserID;
                    Dr["DireccionIP"] = direccionip;
                    UTI_Datatables.Dt_Configuracion.Rows.Add(Dr);

            }
            UTI_Datatables.Dt_Configuracion.AcceptChanges();
            
        }

    

    }
}
