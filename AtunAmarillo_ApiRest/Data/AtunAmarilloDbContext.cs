using AtunAmarillo_ApiRest.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace AtunAmarillo_ApiRest.Data
{
    public class AtunAmarilloDbContext:DbContext
    {
        public AtunAmarilloDbContext(DbContextOptions<AtunAmarilloDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetallePedido> DetallePedidos { get; set; }
        public DbSet<Menu> Menus { get; set; }

    }
}
