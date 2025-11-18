using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_Construsys.Models;

namespace api_Construsys.DataContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Proprietario> Proprietarios { get; set; }
    }
}
