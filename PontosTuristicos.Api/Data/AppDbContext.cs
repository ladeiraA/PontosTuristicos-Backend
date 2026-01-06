using Microsoft.EntityFrameworkCore;
using PontosTuristicos.Api.Models;

namespace PontosTuristicos.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<PontoTuristico> PontosTuristicos { get; set; } = null!;
    }
}