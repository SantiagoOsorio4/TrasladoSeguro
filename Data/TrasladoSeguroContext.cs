using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Data
{
	public class TrasladoSeguroContext : DbContext
	{
		public TrasladoSeguroContext(DbContextOptions options) : base(options)
		{ 
		}
		public DbSet<Cliente> Clientes { get; set; }
		public DbSet<Servicio> Servicios { get; set; }
	}
}


