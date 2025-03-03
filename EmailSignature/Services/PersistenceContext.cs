using EmailSignature.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailSignature.Services
{

    class PersistenceContext : DbContext
    {

        #region - - - - - - Fields - - - - - -

        public DbSet<EditSignatureModel> Signatures { get; set; }

        #endregion Fields

    }

}
