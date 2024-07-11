using System.ComponentModel.DataAnnotations;

namespace APIFOODV2.Model
{
    public class Cliente
    {

        [Key]
        public string cedulaLegal { get; set; }
        public string tipoCedula { get; set; }
        public string nombreCompleto { get; set; }
        public string email { get; set; }
        public DateTime fechaRegistro { get; set; }
        public char estado { get; set; }
        public string usuario { get; set; }
    }
}
