using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.Registrar
{
    public class CreateModel : PageModel
    {
        private readonly TrasladoSeguroContext _context;

        public CreateModel(TrasladoSeguroContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Servicio NewServicio { get; set; }

        [BindProperty]
        public Conductor NewConductor { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Servicios == null || NewServicio == null)
            {
                return Page();
            }

            _context.Servicios.Add(NewServicio);
            _context.Conductor.Add(NewConductor);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Clientes/Index");
        }
    }
}
