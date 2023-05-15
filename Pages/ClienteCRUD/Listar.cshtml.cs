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
    }
}
