using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Halley.Utilitario;
using Halley.Entidad.Ventas;

namespace Halley.Presentacion.Ventas
{
    public partial class FrmCuotas : Form
    {
        TextFunctions ObjTextFunctions = new TextFunctions();

        public bool paso { get; set; }
        public decimal dec_MontoCuota { get; set; }
        public DataTable dtcuota { get; set; }

        public FrmCuotas()
        {
            InitializeComponent();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            ErrProvider.Clear();
            if (TxtMonto.Text.Trim() != "" & DtpFecha.Value != null)
            {
                paso = true;

                DateTime fecha = new DateTime(DtpFecha.Value.Year, DtpFecha.Value.Month, DtpFecha.Value.Day);

                if (Convert.ToDecimal(TxtMonto.Text) <= 0)
                {
                    ErrProvider.SetError(TxtMonto, "Ingrese un monto  mayor a cero.");
                    paso = false;
                }

                DataView Dv = new DataView(dtcuota, "dat_FechaPagar='" + fecha + "'", "", DataViewRowState.CurrentRows);
                if (Dv.Count > 0)
                {
                    ErrProvider.SetError(DtpFecha, "Debe seleccionar una fecha diferente por cuota.");
                    paso = false;
                }

                if (paso)
                {
                    DataRow DR = dtcuota.NewRow();
                    DR["int_IdCuota"] = 0;
                    DR["int_NroCuota"] = (dtcuota.Rows.Count + 1);
                    DR["dec_MontoCuota"] = Convert.ToDecimal(TxtMonto.Text);
                    DR["dat_FechaPagar"] = fecha;
                    DR["bit_Pagado"] = 0;
                    dtcuota.Rows.Add(DR);
                    TdgCuotas.SetDataBinding(dtcuota, "", true);
                    TdgCuotas.Focus();
                    TxtMonto.Text = "";
                    TxtMonto.Focus();

                    calcular();
                }

            }
            else
            {
                if (TxtMonto.Text.Trim() == "") { ErrProvider.SetError(TxtMonto, "Ingrese un monto válido."); }
                if (DtpFecha.Value == null) { ErrProvider.SetError(DtpFecha, "Seleccione una fecha válida."); }
            }

            paso = false;
        }

        private void TxtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            ObjTextFunctions.ValidaNumero(sender, e, TxtMonto);
        }

        private void FrmCuotas_Load(object sender, EventArgs e)
        {
            LblMontoTotal.Text = dec_MontoCuota.ToString("N2");

            dtcuota = new DataTable();

            dtcuota.Columns.Add("int_IdCuota", typeof(int));
            dtcuota.Columns.Add("int_NroCuota", typeof(int));
            dtcuota.Columns.Add("dec_MontoCuota", typeof(decimal)).DefaultValue = 0.00;
            dtcuota.Columns.Add("dat_FechaPagar", typeof(DateTime));
            dtcuota.Columns.Add("bit_Pagado", typeof(Int16));


            calcular();
            paso = false;
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            ErrProvider.Clear();
            paso = true;
            if (dtcuota.Rows.Count == 0)
            {
                ErrProvider.SetError(TdgCuotas, "Ingrese al menos una cuota.");
                paso = false;
            }


            if (TxtCuotaInicial.Text.Trim() == "")
            {
                ErrProvider.SetError(TxtCuotaInicial, "Ingrese el pago inicial.");
                paso = false;
            }

            if (TxtCuotaInicial.Text.Trim() != "" && dtcuota.Rows.Count > 0)//cumplio las dos anteriores
            {
                decimal total = Convert.ToDecimal(dtcuota.Compute("sum(dec_MontoCuota)", ""));
                if (total + Convert.ToDecimal(TxtCuotaInicial.Text) != dec_MontoCuota)
                {
                    LblTotalCuotas.Text = (total + Convert.ToDecimal(TxtCuotaInicial.Text)).ToString("N2");
                    ErrProvider.SetError(TdgCuotas, "el total de las cuotas mas la cuota inicial deben ser igual al total a pagar.");
                    paso = false;
                }
            }



            if (paso)
            {
                DataRow DR = dtcuota.NewRow();
                DR["int_IdCuota"] = 0;
                DR["int_NroCuota"] = 0;
                DR["dec_MontoCuota"] = Convert.ToDecimal(TxtCuotaInicial.Text);
                DR["dat_FechaPagar"] = DateTime.Now;
                DR["bit_Pagado"] = 1;
                dtcuota.Rows.InsertAt(DR, 0);

                dtcuota.AcceptChanges();
                this.Close();
            }
        }

        private void TdgCuotas_AfterDelete(object sender, EventArgs e)
        {
            dtcuota.AcceptChanges();
            calcular();
        }

        private void TdgCuotas_AfterUpdate(object sender, EventArgs e)
        {
            dtcuota.AcceptChanges();
            calcular();
        }


        private void calcular()
        {
            decimal total = 0;
            decimal montoinicial = TxtCuotaInicial.Text.Trim() == "" ? 0 : Convert.ToDecimal(TxtCuotaInicial.Text);

            if (dtcuota.Rows.Count > 0)
                total = Convert.ToDecimal(dtcuota.Compute("sum(dec_MontoCuota)", ""));

            LblTotalCuotas.Text = (total + montoinicial).ToString("N2");

            TxtMonto.Text = (dec_MontoCuota - total - montoinicial).ToString();
        }

        

    }
}
