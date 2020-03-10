using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Halley.Presentacion.VentasTemp
{
    public partial class FrmListaProductos : Form
    {

        #region Propiedades
        Int32 _ArticuloId;
        string _Codigo;
        string _Articulo;
        string _Simbolo;
        decimal _Cantidad;
        decimal _ValorUnitario;
        decimal _ValorVenta;
        decimal _Igv;
        decimal _PrecioVenta;

        public Int32 ArticuloId
        {
            get { return _ArticuloId; }
            set { _ArticuloId = value; }
        }
        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }
        public string Articulo
        {
            get { return _Articulo; }
            set { _Articulo = value; }
        }
        public string Simbolo
        {
            get { return _Simbolo; }
            set { _Simbolo = value; }
        }
        public decimal Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }
        public decimal ValorUnitario
        {
            get { return _ValorUnitario; }
            set { _ValorUnitario = value; }
        }
        public decimal ValorVenta
        {
            get { return _ValorVenta; }
            set { _ValorVenta = value; }
        }
        public decimal Igv
        {
            get { return _Igv; }
            set { _Igv = value; }
        }
        public decimal PrecioVenta
        {
            get { return _PrecioVenta; }
            set { _PrecioVenta = value; }
        }

        #endregion 
        public FrmListaProductos()
        {
            InitializeComponent();
        }

        private void FrmListaProductos_Load(object sender, EventArgs e)
        {
            TdgListaProductos.SetDataBinding(Ventas8.DtProductos, "", true);
        }

        private void TdgListaProductos_DoubleClick(object sender, EventArgs e)
        {
            ArticuloId = Convert.ToInt32(TdgListaProductos.Columns["ArticuloId"].Value);
            Codigo = Convert.ToString(TdgListaProductos.Columns["Codigo"].Value);
            Articulo = Convert.ToString(TdgListaProductos.Columns["Articulo"].Value);
            Simbolo = Convert.ToString(TdgListaProductos.Columns["Simbolo"].Value);
            Cantidad = 0;
            ValorUnitario = Convert.ToDecimal(TdgListaProductos.Columns["Precio"].Value);
            this.Close();
        }

        private void TdgListaProductos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                TdgListaProductos_DoubleClick(null, null);
            }
        }
    }
}
