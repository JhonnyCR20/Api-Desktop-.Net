using System.ComponentModel.DataAnnotations;

namespace APIFOODV2.Model
{
    public class Producto
    {
        [Key]
        public string CodigoInterno { get; set; }
        public int CodigoBarra { get; set; }
        public string Descripcion { get; set; }
        public int PrecioVenta { get; set; }
        public double Descuento { get; set; }
        public double Impuesto { get; set; }
        public string UnidadMedida { get; set; }
        public double PrecioCompra { get; set; }
        public string Usuario { get; set; }
        public int Existencia { get; set; }
    }
}
