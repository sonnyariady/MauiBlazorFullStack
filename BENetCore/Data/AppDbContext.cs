using Microsoft.EntityFrameworkCore;
using KaryawanApi.Models;


namespace KaryawanApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Karyawan> Karyawan { get; set; }
    }
}