using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using quitanda_online.Data;
using quitanda_online.Models;

namespace quitanda_online.Pages.ClienteCRUD
{
    public class ListarModel : PageModel
    {
        private readonly ApplicationDBContext _context;

        public IList<Cliente> Clientes { get; set; }

        public ListarModel(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Clientes = await _context.Clientes.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Listar");
        }
    }
}
