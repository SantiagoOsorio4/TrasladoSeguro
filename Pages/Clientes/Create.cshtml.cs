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

        [BindProperty]
        public Cliente Clientes { get; set; }

        public SelectList ConductoresSelectList { get; set; }
        public SelectList ServiciosSelectList { get; set; }

        public CreateModel(TrasladoSeguroContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ConductoresSelectList = new SelectList(await _context.Conductor.ToListAsync(), "Id", "Nombre");
            ServiciosSelectList = new SelectList(await _context.Servicios.ToListAsync(), "Idservicio", "Name");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ConductoresSelectList = new SelectList(await _context.Conductor.ToListAsync(), "Id", "Nombre");
                ServiciosSelectList = new SelectList(await _context.Servicios.ToListAsync(), "Idservicio", "Name");

                return Page();
            }

            var servicioSeleccionado = await _context.Servicios.FindAsync(Clientes.Idservicio);
            Clientes.Servicio = servicioSeleccionado;

            var conductorSeleccionado = await _context.Conductor.FindAsync(Clientes.ConductorId);
            Clientes.Conductor = conductorSeleccionado;

            _context.Clientes.Add(Clientes);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }

}

