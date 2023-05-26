namespace TrasladoSeguro.Models
{
    public class Conductor
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
    }
}
