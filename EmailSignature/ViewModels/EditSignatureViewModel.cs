using EmailSignature.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailSignature.ViewModels
{

    class EditSignatureViewModel
    {

        #region - - - - - - Fields - - - - - -

        public DbSet<EditSignatureModel> Signatures { get; set; }

        #endregion Fields

        #region - - - - - - Methods - - - - - -

        public void AddSignature(EditSignatureModel newSignature)
        {
            this.Signatures.Add(newSignature);
        }

        #endregion Methods

    }

}
