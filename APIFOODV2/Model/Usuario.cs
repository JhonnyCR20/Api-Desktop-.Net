using System.ComponentModel.DataAnnotations;

namespace APIFOODV2.Model
{
    public class Usuario
    {
        [Key]
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime FechaRegistro { get; set; }
        public char? Estado { get; set; }
    }
}
