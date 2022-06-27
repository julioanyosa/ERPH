using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.CapaLogica.Ventas;
using Halley.Utilitario;
using Halley.CapaLogica.Empresa;
using Halley.Entidad.Ventas;
using Halley.Configuracion;
using System.Net;
using Halley.CapaLogica.Ventas;
using ThoughtWorks.QRCode.Codec;

namespace Halley.Presentacion.Ventas.Administracion
{
    public partial class NotaCredito : UITemplateAccess
    {

        CL_Comprobante ObjCL_Comprobante = new CL_Comprobante();
        CL_Venta ObjCL_Venta = new CL_Venta();
         
        int hojaimpresa = 1;
        DataSet DS;
        DataTable dtcabecera;
        DataTable dtdetalle;
        DataTable DtCuotas;
        TextFunctions ObjTextFunctions = new TextFunctions();
        Boolean ConCliente = true;
        DataTable DtDatosSede;

        public NotaCredito()
        {
            InitializeComponent();
        }

        private void NotaCredito_Load(object sender, EventArgs e)
        {
            DataTable Dtempresas = new CL_Empresas().GetEmpresas();
            DataTable DtComprobante = new CL_Comprobante().getTipoComprobante();
            c1Combo.FillC1Combo(this.Cboempresa2, Dtempresas.Copy(), "NomEmpresa", "EmpresaID");
            c1Combo.FillC1Combo(this.c1cboCia, Dtempresas.Copy(), "NomEmpresa", "EmpresaID");
            c1Combo.FillC1Combo(cbComprobante, DtComprobante, "NomTipoComprobante", "TipoComprobanteID");

            DataView DVCO = new DataView(DtComprobante, "TipoComprobanteID in(6,7)", "", DataViewRowState.CurrentRows);
            c1Combo.FillC1Combo(CboTipoComprobanteListado, DVCO.ToTable(), "NomTipoComprobante", "TipoComprobanteID");
            
        }

        private void BtnNotaCredito_Click(object sender, EventArgs e)
        {
            ErrProvider.Clear();
            try
            {
                Cursor = Cursors.WaitCursor;
                if (Cboempresa2.SelectedIndex != -1 & cbComprobante.SelectedValue != null && TxtSerieAnulacion.Text != "" && TxtNumeroAnulacion.Text != ""
                    && TxtMotivoEliminacion.Text != "" && TxtSerieAnulacion.Text.Length == 4)
                {
                    if (MessageBox.Show("¿Seguro que desea generar una nota de crédito para el Comprobante Nro: " + TxtSerieAnulacion.Text + "-" + TxtNumeroAnulacion.Text + "?.", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        string nrocomprobante = Cboempresa2.SelectedValue.ToString() + TxtSerieAnulacion.Text.Substring(1, 3) + "-" + TxtNumeroAnulacion.Text.PadLeft(7, '0');

                        ObjCL_Comprobante.GenerarNotaCredito(nrocomprobante, Convert.ToInt32(cbComprobante.SelectedValue), Cboempresa2.SelectedValue.ToString(), AppSettings.UserID, TxtMotivoEliminacion.Text);
                        MessageBox.Show("Se genero la nota de crédito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cursor = Cursors.Default;
                    }
                }
                else
                {
                    if (cbComprobante.SelectedIndex == -1) ErrProvider.SetError(cbComprobante, "Seleccione un tipo de comprobante.");
                    if (TxtSerieAnulacion.Text == "") ErrProvider.SetError(TxtSerieAnulacion, "Ingrese la serie del comprobante.");
                    if (TxtNumeroAnulacion.Text == "") ErrProvider.SetError(TxtNumeroAnulacion, "Ingrese el número del comprobante.");
                    if (Cboempresa2.SelectedIndex == -1) ErrProvider.SetError(Cboempresa2, "Seleccione una empresa.");
                    if (TxtMotivoEliminacion.Text == "") ErrProvider.SetError(TxtMotivoEliminacion, "Ingrese el motivo de la nota de crédito.");
                    if (TxtSerieAnulacion.Text.Length != 4) ErrProvider.SetError(TxtSerieAnulacion, "Ingrese serie correcta.");
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (TdgComprobantes.RowCount > 0)
                {

                    string NumComprobante = this.TdgComprobantes.Columns["NumComprobante"].Value.ToString();
                    string SERIE = this.TdgComprobantes.Columns["SERIE"].Value.ToString();
                    string NUMERO = this.TdgComprobantes.Columns["NUMERO"].Value.ToString();
                    if (MessageBox.Show("¿Seguro que desea imprimir el comprobante " + SERIE + "-" + NUMERO + "?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        Int64 ComprobanteId = Convert.ToInt64(this.TdgComprobantes.Columns["ComprobanteId"].Value);
                        hojaimpresa = 1;

                        DS = ObjCL_Venta.ObtenerParaImpresionNc(ComprobanteId);
                        dtcabecera = DS.Tables[0];
                        dtdetalle = DS.Tables[1];
                        DtCuotas = DS.Tables[2];


                        //seleccionar impresora

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
                        #endregion

                        //traer impresoras
                        CapaLogica.Users.CL_Usuario ObjUsuario = new CapaLogica.Users.CL_Usuario();
                        UTI_Datatables.Dt_Configuracion = ObjUsuario.USP_M_CONFIGURACION(2, 0, "", "", "", "", AppSettings.UserID, NuevaIP);

                        string EMPRESA_ID = dtcabecera.Rows[0]["EmpresaID"].ToString();
                        string TIPO_COMPROBANTE = "";

                        TIPO_COMPROBANTE = "TI";

                        //ahora se gauradara en una tabla Configuracion.Configuracion

                        DataView DV = new DataView(UTI_Datatables.Dt_Configuracion, "Codigo ='" + "IMP_" + EMPRESA_ID + "_" + TIPO_COMPROBANTE + "'", "", DataViewRowState.CurrentRows);

                        if (DV.Count > 0)
                        {
                            printDocument1.PrinterSettings.PrinterName = DV[0]["Data"].ToString();
                            printDocument1.Print();
                        }
                        else
                        {
                            string impresora = "";
                            if (printDialog1.ShowDialog() == DialogResult.OK)
                                impresora = printDialog1.PrinterSettings.PrinterName;


                            if (impresora != "")
                            {
                                printDocument1.PrinterSettings.PrinterName = impresora;
                                printDocument1.Print();
                            }
                            else
                            {
                                MessageBox.Show("no ha seleccionado la impresora.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                Cursor = Cursors.Default;
                                return;
                            }

                            //MessageBox.Show("No existe una impresora configurada, por favor agregela \n(seleccionar impresora ticket en venta)", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            //return;
                        }


                        if (printDocument1.PrinterSettings.PrinterName == "")
                        {
                            MessageBox.Show("Al parecer no se ha seleccionado la impresora. no se imprimira el comprobante.\n(seleccionar impresora ticket en venta)", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Cursor = Cursors.Default;
                            return;
                        }
                        //fin seleccionar imrepsora
                    }




                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnConsultarListado_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {

                if (CboTipoComprobanteListado.SelectedIndex != -1)
                {

                    DataTable dt = ObjCL_Venta.ListarNotaCredito(Convert.ToDateTime(DtpFechaIniListado.Value.ToShortDateString()), Convert.ToDateTime(DtpFechaFinListado.Value.ToShortDateString()),
                        Convert.ToInt16(CboTipoComprobanteListado.SelectedValue), c1cboCia.SelectedValue.ToString());


                    //cargamos la grilla
             
                    TdgComprobantes.SetDataBinding(dt, "", true);

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.InnerException.Message);
                MessageBox.Show(ex.Message);

            }

            Cursor = Cursors.Default;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //formato para alinear los nuimeros a la derecha
            StringFormat formato = new StringFormat();
            formato.Alignment = StringAlignment.Far;
            //formato.LineAlignment = StringAlignment.Far;



            TextFunctions ObjTextFunctions = new TextFunctions();
            //obtener la cadena del total a pagar
            string TotalPagarLetras = ObjTextFunctions.enletras(dtcabecera.Rows[0]["Monto"].ToString());



            string NomEmpresa = dtcabecera.Rows[0]["NomEmpresa"].ToString();
            string RUC = dtcabecera.Rows[0]["RUC"].ToString();

            string SerieEticketera = "";
            string NroAutorizacion = "";


            string CodigoTipoComprobante = "07", TipoLetra = "B", TipoDocumentoCliente = "DNI";
            int Canticabecera = 31;
            string[] Formatoticket = new string[2];

            if (dtcabecera.Rows[0]["NroDocumentoCliente"].ToString() == "0")
                ConCliente = false;
            else
                ConCliente = true;

            E_NotaCredito obj = new E_NotaCredito();
            obj.str_TipoDocumentoVinculante = dtcabecera.Rows[0]["str_TipoDocumentoVinculante"].ToString();
            obj.str_ID_DocumentoVinculante = dtcabecera.Rows[0]["str_ID_DocumentoVinculante"].ToString();
            obj.str_CodigoTipoNotaCredito = dtcabecera.Rows[0]["str_CodigoTipoNotaCredito"].ToString();
            obj.str_DescripcionTipoNotaCredito = dtcabecera.Rows[0]["str_DescripcionTipoNotaCredito"].ToString();
            obj.str_Motivo = dtcabecera.Rows[0]["str_Motivo"].ToString();

            if (hojaimpresa == 1)
            {

                if (Convert.ToInt16(dtcabecera.Rows[0]["TipoComprobanteID"]) == 6)//es boleta
                {

                  

                    Formatoticket = ObjCL_Venta.FormatoTicketFE(NomEmpresa, AppSettings.NomSede, dtcabecera.Rows[0]["NumComprobante"].ToString(),
                    "NOTA DE CRÉDITO: ", dtdetalle, RUC, AppSettings.Usuario, Convert.ToDecimal(dtcabecera.Rows[0]["MontoPagado"]), dtcabecera.Rows[0]["NomCaja"].ToString(), SerieEticketera,
                    NroAutorizacion, TotalPagarLetras, dtcabecera.Rows[0]["RazonSocialCliente"].ToString(),
                    dtcabecera.Rows[0]["NroDocumentoCliente"].ToString(), dtcabecera.Rows[0]["DireccionCliente"].ToString(),
                    "", ConCliente, Convert.ToDateTime(dtcabecera.Rows[0]["AudCrea"]), Convert.ToDecimal(dtcabecera.Rows[0]["MontoPagado"]),
                    Convert.ToDecimal(dtcabecera.Rows[0]["TotalIGV"]), "B",
                       DtDatosSede.Rows[0]["TelefonoCelular"].ToString(), DtDatosSede.Rows[0]["TelefonoFijo"].ToString(), Convert.ToDecimal(dtcabecera.Rows[0]["Monto"]),
                       Convert.ToDecimal(dtcabecera.Rows[0]["TotalICBPER"]), Convert.ToInt32(dtcabecera.Rows[0]["TipoPagoID"]), DtCuotas, obj);

                    e.Graphics.DrawString(Formatoticket[0], TxtFormato.Font, Brushes.Black, 0, 0); //total pagar en letras


                }
                else if (Convert.ToInt16(dtcabecera.Rows[0]["TipoComprobanteID"]) == 7)//es factura
                {
               
                    TipoLetra = "F";
                    TipoDocumentoCliente = "RUC";
                    Canticabecera = 35;

                    Formatoticket = ObjCL_Venta.FormatoTicketFE(NomEmpresa, AppSettings.NomSede, dtcabecera.Rows[0]["NumComprobante"].ToString(),
                    "NOTA DE CRÉDITO: ", dtdetalle, RUC, AppSettings.Usuario, Convert.ToDecimal(dtcabecera.Rows[0]["MontoPagado"]), dtcabecera.Rows[0]["NomCaja"].ToString(), SerieEticketera,
                    NroAutorizacion, TotalPagarLetras, dtcabecera.Rows[0]["RazonSocialCliente"].ToString(),
                    dtcabecera.Rows[0]["NroDocumentoCliente"].ToString(), dtcabecera.Rows[0]["DireccionCliente"].ToString(),
                    "", ConCliente, Convert.ToDateTime(dtcabecera.Rows[0]["AudCrea"]), Convert.ToDecimal(dtcabecera.Rows[0]["MontoPagado"]), Convert.ToDecimal(dtcabecera.Rows[0]["TotalIGV"]), "F",
                       DtDatosSede.Rows[0]["TelefonoCelular"].ToString(), DtDatosSede.Rows[0]["TelefonoFijo"].ToString(),
                       Convert.ToDecimal(dtcabecera.Rows[0]["Monto"]), Convert.ToDecimal(dtcabecera.Rows[0]["TotalICBPER"]),
                       Convert.ToInt32(dtcabecera.Rows[0]["TipoPagoID"]), DtCuotas, obj);

                    e.Graphics.DrawString(Formatoticket[0], TxtFormato.Font, Brushes.Black, 0, 0); //total pagar en letras
                    //e.Graphics.DrawString(Convert.ToChar(27) + "i", TxtPrecio.Font, Brushes.Black, 0, 0); //total pagar en letras


                }


                /*imprimir el codigo de barras*/

                QRCodeEncoder objqrcode = new QRCodeEncoder();
                Image imgimage;
                Bitmap objbitmap;
                PictureBox Pimage = new PictureBox();
                string s;
                s = RUC + " | " + CodigoTipoComprobante + " | " + TipoLetra + dtcabecera.Rows[0]["NumComprobante"].ToString().Substring(0,3) + " | " + dtcabecera.Rows[0]["NumComprobante"].ToString().Substring(5) + " | " + Convert.ToDecimal(dtcabecera.Rows[0]["TotalIGV"]).ToString("N2") + " | " + Convert.ToDecimal(dtcabecera.Rows[0]["Monto"]).ToString("N2") + " | " +
                    Convert.ToDateTime(dtcabecera.Rows[0]["AudCrea"]).ToShortDateString() + " | " + TipoDocumentoCliente + " | " + dtcabecera.Rows[0]["NroDocumentoCliente"].ToString();
                objqrcode.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                objqrcode.QRCodeScale = 2;
                objqrcode.QRCodeVersion = 6;
                objqrcode.QRCodeErrorCorrect = ThoughtWorks.QRCode.Codec.QRCodeEncoder.ERROR_CORRECTION.L;
                imgimage = objqrcode.Encode(s);
                objbitmap = new Bitmap(imgimage);
                //objbitmap.Save("QRCode.jpg");
                //Pimage.ImageLocation = "QRCode.jpg";
                //CALCULAMOS AL CANTIDAD DE LINEAS
                int CantidadLineas = ((Convert.ToInt32(Formatoticket[1]) + 2) * 13);
                e.Graphics.DrawImage(imgimage, new Point(80, CantidadLineas));


                if (Convert.ToDecimal(dtcabecera.Rows[0]["TotalIGV"]) == 0)
                {
                    string textofinal = "Bienes   transferidos  en   la  Amazonía\nRegión  Selva  para ser  cosumidos en la\nmisma.";
                    e.Graphics.DrawString(textofinal, TxtFormato.Font, Brushes.Black, 0, CantidadLineas + (13 * 7));
                }
                hojaimpresa = 2;
                e.HasMorePages = true;


            }

            else if (hojaimpresa == 2)
            {
                decimal total = Convert.ToDecimal(dtcabecera.Rows[0]["Monto"]);

                if (Convert.ToInt16(dtcabecera.Rows[0]["TipoComprobanteID"]) == 6)//es boleta
                {
                    string[] Formatoticket2 = new string[2];
                    Formatoticket2 = ObjCL_Venta.FormatoTicketFEResumido(NomEmpresa, AppSettings.NomSede, dtcabecera.Rows[0]["NumComprobante"].ToString(),
                    "NOTA DE CRÉDITO: ", dtdetalle, RUC, AppSettings.Usuario, Convert.ToDecimal(dtcabecera.Rows[0]["MontoPagado"]), dtcabecera.Rows[0]["NomCaja"].ToString(), SerieEticketera,
                    NroAutorizacion, TotalPagarLetras, dtcabecera.Rows[0]["RazonSocialCliente"].ToString(),
                    dtcabecera.Rows[0]["NroDocumentoCliente"].ToString(), dtcabecera.Rows[0]["DireccionCliente"].ToString(),
                    "", ConCliente, Convert.ToDateTime(dtcabecera.Rows[0]["AudCrea"]), Convert.ToDecimal(dtcabecera.Rows[0]["MontoPagado"]),
                    Convert.ToDecimal(dtcabecera.Rows[0]["TotalIGV"]), "B", total, Convert.ToDecimal(dtcabecera.Rows[0]["TotalICBPER"]),
                    Convert.ToInt32(dtcabecera.Rows[0]["TipoPagoID"]), DtCuotas, obj);

                    e.Graphics.DrawString(Formatoticket2[0], TxtFormato.Font, Brushes.Black, 0, 0); //total pagar en letras

                }
                else if (Convert.ToInt16(dtcabecera.Rows[0]["TipoComprobanteID"]) == 7)//es factura
                {
                    CodigoTipoComprobante = "07";
                    TipoLetra = "F";
                    TipoDocumentoCliente = "RUC";
                    Canticabecera = 35;

                    string[] Formatoticket2 = new string[2];
                    Formatoticket2 = ObjCL_Venta.FormatoTicketFEResumido(NomEmpresa, AppSettings.NomSede, dtcabecera.Rows[0]["NumComprobante"].ToString(),
                    "NOTA DE CRÉDITO: ", dtdetalle, RUC, AppSettings.Usuario, Convert.ToDecimal(dtcabecera.Rows[0]["Monto"]), dtcabecera.Rows[0]["NomCaja"].ToString(), SerieEticketera,
                    NroAutorizacion, TotalPagarLetras, dtcabecera.Rows[0]["RazonSocialCliente"].ToString(),
                    dtcabecera.Rows[0]["NroDocumentoCliente"].ToString(), dtcabecera.Rows[0]["DireccionCliente"].ToString(),
                    "", ConCliente, Convert.ToDateTime(dtcabecera.Rows[0]["AudCrea"]), Convert.ToDecimal(dtcabecera.Rows[0]["Monto"]),
                    Convert.ToDecimal(dtcabecera.Rows[0]["TotalIGV"]), "F", total, Convert.ToDecimal(dtcabecera.Rows[0]["TotalICBPER"]),
                    Convert.ToInt32(dtcabecera.Rows[0]["TipoPagoID"]), DtCuotas, obj);

                    e.Graphics.DrawString(Formatoticket2[0], TxtFormato.Font, Brushes.Black, 0, 0); //total pagar en letras
                    //e.Graphics.DrawString(Convert.ToChar(27) + "i", TxtPrecio.Font, Brushes.Black, 0, 0); //total pagar en letras


                }


                e.HasMorePages = false;
            }
            
        }

        private void c1cboCia_SelectedValueChanged(object sender, EventArgs e)
        {
            if (c1cboCia.SelectedIndex != -1)
            {
                string EmpresaID = c1cboCia.SelectedValue.ToString();
                DtDatosSede = ObjCL_Venta.ObtenerDatosSucursal(EmpresaID, AppSettings.SedeID);
            }
        }

    }
}

