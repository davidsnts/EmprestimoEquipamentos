using GestorEquipamentos.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GestorEquipamentos.DataBase
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ProdutoModel> Produto { get; set; } = default!;        
        public DbSet<GestorEquipamentos.Models.ReservaModel> ReservaModel { get; set; } = default!;

    }
}
