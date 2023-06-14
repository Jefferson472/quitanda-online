using Microsoft.EntityFrameworkCore;
using quitanda_online.Models;

namespace quitanda_online.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext (DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; } = default!;
        public DbSet<Cliente> Clientes { get; set; } = default!;
        public DbSet<Pedido> Pedidos { get; set; } = default!;
        public DbSet<ItemPedido> ItensPedidos { get; set; } = default!;
        // public DbSet<Favorito> Favoritos { get; set; } = default!;
        // public DbSet<Visitado> Visitados { get; set; } = default!;
    }
}
