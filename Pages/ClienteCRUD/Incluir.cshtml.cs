using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using quitanda_online.Data;
using quitanda_online.Models;


namespace quitanda_online.Pages.ClienteCRUD
{
    public class IncluirModel : PageModel
    {
        private ApplicationDBContext _context;

        [BindProperty] // faz o vínculo entre os campos do formulári o o objeto 
        public Cliente Cliente { get; set; }

        public IncluirModel(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var cliente = new Cliente();
            if (await TryUpdateModelAsync<Cliente>(cliente, "cliente",
                obj => obj.Name, obj => obj.DataNascimento, obj => obj.Email, obj => obj.CPF ))
            {
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Listar");
            }
            return Page();
        }
    }
}
