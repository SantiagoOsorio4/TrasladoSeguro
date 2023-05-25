using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrasladoSeguro.Models;
using TrasladoSeguro.Data;


namespace TrasladoSeguro.Pages.Clientes
{
    public class CreateModel : PageModel
    {
        private readonly TrasladoSeguroContext _context;

            public CreateModel(TrasladoSeguroContext context)
            {
                _context = context;
            }

        public List<Servicio> Servicios { get; set; }

        [BindProperty]
        public Cliente Clientes { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Servicios = await _context.Servicios.ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Servicios = await _context.Servicios.ToListAsync();
                return Page();
            }

            var servicioSeleccionado = await _context.Servicios.FindAsync(Clientes.Idservicio);
            Clientes.Servicio = servicioSeleccionado;

            _context.Clientes.Add(Clientes);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

