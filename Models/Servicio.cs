using System.ComponentModel.DataAnnotations;

namespace TrasladoSeguro.Models
{
	public class Servicio
	{
		[Key]
		public int Idservicio { get; set; }
		public string? Name { get; set; }
		public ICollection<Cliente> Clientes { get; set; }
	}
}
