using System.ComponentModel.DataAnnotations;

namespace APIFOODV2.Model
{
    public class Bitacora
    {
        public string Tabla { get; set; }
        [Key]
        public string Usuario { get; set; }
        public string Maquina { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoMov { get; set; }
        public string Registro { get; set; }
    }
}
