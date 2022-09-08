using Microsoft.EntityFrameworkCore;
using RazorCrud.Data.Entities;

namespace RazorCrud.Data
{
    public class MyWorldDbContext : DbContext
    {
        public MyWorldDbContext(DbContextOptions<MyWorldDbContext> options) : base(options)
        {

        }
        public DbSet<Cake> Cake { get; set; }
    }
}
