using Microsoft.EntityFrameworkCore;
using TutoWebAspL3.Models;

namespace TutoWebAspL3.Services
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Etudiant> Etudiant { get; set; }
        public DbSet<Commune> Commune { get; set; }
        public DbSet<Categorie> Categorie { get; set; }
        public DbSet<Quittance> Quittance { get; set; }

    }


}
