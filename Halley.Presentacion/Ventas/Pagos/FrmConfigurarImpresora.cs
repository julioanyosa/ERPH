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


            dv = new DataView(UTI_Datatables.Dt_Configuracion, "Codigo='IMP_GH_TI'", "", DataViewRowState.CurrentRows);
            if (dv.Count > 0)
            {
                LblTicketGranja.Text = dv[0]["Data"].ToString();
            }

            dv = new DataView(UTI_Datatables.Dt_Configuracion, "Codigo='IMP_IH_TI'", "", DataViewRowState.CurrentRows);
            if (dv.Count > 0)
            {
                LblTicketIndustria.Text = dv[0]["Data"].ToString();
            }


            dv = new DataView(UTI_Datatables.Dt_Configuracion, "Codigo='IMP_CH_TI'", "", DataViewRowState.CurrentRows);
            if (dv.Count > 0)
            {
                LblTicketComercial.Text = dv[0]["Data"].ToString();
            }

            dv = new DataView(UTI_Datatables.Dt_Configuracion, "Codigo='IMP_AH_TI'", "", DataViewRowState.CurrentRows);
            if (dv.Count > 0)
            {
                LblTicketAvicola.Text = dv[0]["Data"].ToString();
            }

            dv = new DataView(UTI_Datatables.Dt_Configuracion, "Codigo='IMP_CH_SD'", "", DataViewRowState.CurrentRows);
            if (dv.Count > 0)
            {
                LblTicketGanaderiaSantoDomingo.Text = dv[0]["Data"].ToString();
            }

            dv = new DataView(UTI_Datatables.Dt_Configuracion, "Codigo='IMP_CH_GP'", "", DataViewRowState.CurrentRows);
            if (dv.Count > 0)
            {
                LblTicketAgropecuaria.Text = dv[0]["Data"].ToString();
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
                string impresora = printDialog1.PrinterSettings.PrinterName;
                string EMPRESA_ID = c1cboCia.SelectedValue.ToString();
                if (impresora != "")
                {
                    DataTable DtImpresora = new DataTable();
                    DtImpresora = ObjUsuario.USP_M_CONFIGURACION(1, 0, EMPRESA_ID, "IMP_" + EMPRESA_ID + "_TI", "IMPRESORA TICKET DE " + EMPRESA_ID, impresora, AppSettings.UserID, NuevaIP);
                    ActualizarConfiguracion(EMPRESA_ID, "IMP_" + EMPRESA_ID + "_TI", impresora, NuevaIP);

                    if (EMPRESA_ID == "GH")
                        LblTicketGranja.Text = impresora;
                    else if (EMPRESA_ID == "IH")
                        LblTicketIndustria.Text = impresora;
                    else if (EMPRESA_ID == "CH")
                        LblTicketComercial.Text = impresora;
                    else if (EMPRESA_ID == "AH")
                        LblTicketAvicola.Text = impresora;
                    else if (EMPRESA_ID == "SD")
                        LblTicketGanaderiaSantoDomingo.Text = impresora;
                    else if (EMPRESA_ID == "GP")
                        LblTicketAgropecuaria.Text = impresora;

                    MessageBox.Show("Se guardo correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (DV.Count > 0)
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
