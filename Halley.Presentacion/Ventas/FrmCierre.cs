using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.Configuracion;
using Halley.CapaLogica.Ventas;
using Halley.Utilitario;

namespace Halley.Presentacion.Ventas
{
    public partial class FrmCierre : Form
    {
        #region variables
        string EmpresaID = "";
        CL_Venta ObjCL_Venta = new CL_Venta();
        string ImpresoraBoletaGranja = AppSettings.ImpresoraBoletaGranja;
        string ImpresoraBoletaComercio = AppSettings.ImpresoraBoletaComercio;
        string ImpresoraBoletaIndustria = AppSettings.ImpresoraBoletaIndustria;
        string ImpresoraFacturaGranja = AppSettings.ImpresoraFacturaGranja;
        string ImpresoraFacturaIndustria = AppSettings.ImpresoraFacturaIndustria;
        string ImpresoraFacturaComercio = AppSettings.ImpresoraFacturaComercio;
        string ImpresoraTicketGranja = AppSettings.ImpresoraTicketGranja;
        string ImpresoraTicketComercio = AppSettings.ImpresoraTicketComercio;
        string ImpresoraTicketIndustria = AppSettings.ImpresoraTicketIndustria;
        #endregion

        #region propiedades
        private DataTable _DtEmpresas;

        public DataTable DtEmpresas
        {
            get { return _DtEmpresas; }
            set { _DtEmpresas = value; }
        }
        private int _NumCaja;

        public int NumCaja
        {
            get { return _NumCaja; }
            set { _NumCaja = value; }
        }
        #endregion

        public FrmCierre()
        {
            InitializeComponent();
        }

        private void BtnCierre_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea imprimir el total de la caja por día?", "Advertencia", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (c1cboCia.SelectedIndex != -1)
                {
                    Cursor = Cursors.WaitCursor;
                    string EMPRESA_ID = c1cboCia.SelectedValue.ToString();
                    EmpresaID = c1cboCia.SelectedValue.ToString();
                    string TIPO_COMPROBANTE = "";
                    TIPO_COMPROBANTE = "TI";

                    //ahora se gauradara en una tabla Configuracion.Configuracion

                    DataView DV = new DataView(UTI_Datatables.Dt_Configuracion, "Codigo ='" + "IMP_" + EMPRESA_ID + "_" + TIPO_COMPROBANTE + "'", "", DataViewRowState.CurrentRows);

                    if (DV.Count > 0)
                    {
                        printDocument1.PrinterSettings.PrinterName = DV[0]["Data"].ToString();

                        printDocument1.Print();//manda a imprimnir
                        Cursor = Cursors.Default;
                    }
                    else
                    {
                        MessageBox.Show("No existe una impresora configurada, por favor agregela", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }


                }
            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                #region Total Eticketera
                //obtener datos de la empresa
                DataView DV = new DataView(DtEmpresas);
                //string EmpresaID = "IH";
                DV.RowFilter = "EmpresaID = '" + EmpresaID + "'";
                string NomEmpresa = DV[0]["NomEmpresa"].ToString();
                string RUC = DV[0]["RUC"].ToString();

                string FormatoTotalesTicket = ObjCL_Venta.FormatoTotalesTicket(NomEmpresa, AppSettings.NomSede, RUC, DtpFechaCierre.Value.Date, DtpFechaCierre.Value.Date.AddDays(1), NumCaja, EmpresaID, AppSettings.SedeID, AppSettings.UserID);
                e.Graphics.DrawString(FormatoTotalesTicket, TxtFormatoticketera.Font, Brushes.Black, 0, 0); //total pagar en letras
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();

        }

        private void FrmCierre_Load(object sender, EventArgs e)
        {
            //agregar empresa
            c1Combo.FillC1Combo(this.c1cboCia, DtEmpresas, "NomEmpresa", "EmpresaID");
            c1cboCia.SelectedValue = AppSettings.EmpresaID;
        }
    }
}
