namespace APIFOODV2.Model
{
    public class DetFactura
    { 
    public int NumFactura { get; set; }
    public string CodInterno { get; set; }
    public int Cantidad { get; set; }
    public double PrecioUnitario { get; set; }
    public double Subtotal { get; set; }
    public double PorImp { get; set; }
    public double PorDescuento { get; set; }
    }
}
