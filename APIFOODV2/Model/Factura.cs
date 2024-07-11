using System.ComponentModel.DataAnnotations;

namespace APIFOODV2.Model
{
    public class Factura
    {
        [Key]
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
        public string CodCliente { get; set; }
        public double Subtotal { get; set; }
        public double MontoDescuento { get; set; }
        public double MontoImpuesto { get; set; }
        public double Total { get; set; }
        public char Estado { get; set; }
        public string Usuario { get; set; }
        public string TipoPago { get; set; }
    }
}
