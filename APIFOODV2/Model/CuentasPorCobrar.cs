namespace APIFOODV2.Model
{
    public class CuentasPorCobrar
    {
        public int NumFactura { get; set; }
        public string CodCliente { get; set; }
        public DateTime FechaFactura { get; set; }
        public DateTime FechaRegistro { get; set; }
        public double MontoFactura { get; set; }
        public string Usuario { get; set; }
        public char? Estado { get; set; }
    }
}
