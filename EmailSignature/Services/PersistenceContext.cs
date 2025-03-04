using EmailSignature.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailSignature.Services
{

    class PersistenceContext : DbContext
    {

        #region - - - - - - Fields - - - - - -

        public DbSet<EditSignatureModel> Signatures { get; set; }

        #endregion Fields

        #region - - - - - - Methods - - - - - -

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var _DBConn = "Server=.;Database=EmailSignature;Trusted_Connection=True;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(_DBConn);
        }

        #endregion Methods

    }

}
