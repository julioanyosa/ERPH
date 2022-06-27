using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halley.Entidad.Ventas
{
    public class E_Comprobante
    {
        public string EmpresaID { get; set; }
        public string SedeID { get; set; }
        public int TipoComprobanteID { get; set; }
        public int ClienteID { get; set; }
        public string Direccion { get; set; }
        public int TipoVentaID { get; set; }
        public int TipoPagoId { get; set; }
        public int? FormaPagoID { get; set; }
        public int NumCaja { get; set; }
        public string NumGuia { get; set; }
        public decimal IGV { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotIgv { get; set; }
        public int Vendedor { get; set; }
        public int CreditoID { get; set; }
        public int Cajero { get; set; }
        public int EstadoID { get; set; }
        public bool Externa { get; set; }
        public bool Vale { get; set; }
        public string Serie { get; set; }
        public int? NumVale { get; set; }
        public string TipoTicket { get; set; }
        public decimal MontoPagado { get; set; }
        public decimal TotalICBPER { get; set; }
        public decimal Descuento { get; set; }
        public decimal MontoTotal { get; set; }
        //public List<cuota> cuotas { get; set; }
    }


    //public class cuota
    //{
    //    public int int_IdCuota { get; set; }
    //    public int int_IdEmpresa { get; set; }
    //    public long bint_IdComprobante { get; set; }
    //    public int int_NroCuota { get; set; }
    //    public decimal dec_MontoCuota { get; set; }
    //    public DateTime? dat_FechaPagar { get; set; }
    //    public int bit_Activo { get; set; }
    //    public int int_IdUsuario { get; set; }
    //    public DateTime? datt_FechaRegistro { get; set; }
    //    public int bit_Pagado { get; set; }
    //    public int int_IdUsuarioPago { get; set; }
    //    public DateTime? dat_FechaPago { get; set; }
    //    public int int_IdCliente { get; set; }
    //}

}
