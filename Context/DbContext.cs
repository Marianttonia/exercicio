using exercise.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.Context
{
    public class ContextAPI : DbContext
    {
        public DbSet<Habitante> Habitantes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-KKPJKI1\SQLEXPRESS;Database=ProjectTables;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}