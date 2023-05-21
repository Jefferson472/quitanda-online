using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using quitanda_online.Data;
using quitanda_online.Models;

namespace quitanda_online.Pages.ClienteCRUD
{
    public class AlterarModel : PageModel
    {
        private readonly ApplicationDBContext _context;

        [BindProperty] // faz o vínculo entre os campos do formulári o o objeto 
        public Cliente Cliente { get; set; }

        public AlterarModel(ApplicationDBContext context)
        {
            _context = context;
        }
 
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cliente = await _context.Clientes.FirstOrDefaultAsync(m => m.Id == id);
            if (Cliente == null) 
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(Cliente.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Listar");
        }
        private bool ClienteExists(int id)
        {
            return (_context.Clientes?.Any(m => m.Id == id)).GetValueOrDefault();
        }
    }
}
