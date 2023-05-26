using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.Clientes
{
    public class IndexModel : PageModel
    {
        private readonly TrasladoSeguroContext _context;

        public IndexModel(TrasladoSeguroContext context)
        {
            _context = context;
        }

        public List<Cliente> Clientes { get; set; }

        public async Task OnGetAsync()
        {
            Clientes = await _context.Clientes
                .Include(c => c.Conductor)
                .Include(c => c.Servicio)
                .ToListAsync();
        }
    }
}

