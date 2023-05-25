using System.ComponentModel.DataAnnotations;

namespace TrasladoSeguro.Models
{
	public class Cliente
	{
		public int Id { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? Address { get; set; }
		public string? PhoneNumber { get; set; }
		[EmailAddress]
		public string? Email { get; set; }
		public int? Idservicio { get; set; }
		public virtual Servicio? Servicio { get; set; }
    }
}
