using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrasladoSeguro.Data;
using TrasladoSeguro.Models;

namespace TrasladoSeguro.Pages.Clientes
{
    public class DeleteModel : PageModel
    {
        private readonly TrasladoSeguroContext _context;

        public DeleteModel(TrasladoSeguroContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cliente Clientes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }
            var customer = await _context.Clientes.FirstOrDefaultAsync(m => m.Id == id);

            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                Clientes = customer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var customer = await _context.Clientes.FindAsync(id);

            if (customer != null)
            {
                Clientes = customer;
                _context.Clientes.Remove(Clientes);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
