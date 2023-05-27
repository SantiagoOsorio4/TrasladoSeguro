using System.ComponentModel.DataAnnotations;

namespace TrasladoSeguro.Models
{
    public class Login
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
