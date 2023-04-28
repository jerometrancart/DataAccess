using System;
using Microsoft.EntityFrameworkCore;
 
namespace DataAccess
{
    ///CREE NOTRE PROPRE DBCONTEXT QUI HERITE D EF CORE
    public class MyDbContext: DbContext
    {
        ///INDIQUE QUE L OBJET PERSONNE NE SERA PAS NULL
        public DbSet<Personne> Personnes { get; set; } = default!;

        ///NECESSAIRE D'OVERRIDE ONCONFIGURING
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ///PASSE LA CHAINE DE CONNECTION A OPTIONSBUILDER
            optionsBuilder.UseSqlServer("Server=localhost;Database=ApprendreCsharp;User Id=sa;Password=Passw0rd*;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
