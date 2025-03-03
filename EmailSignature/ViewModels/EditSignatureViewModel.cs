using EmailSignature.Models;
using EmailSignature.Services;

namespace EmailSignature.ViewModels
{

    class EditSignatureViewModel
    {

        #region - - - - - - Fields - - - - - -

        private readonly PersistenceContext m_PersistenceContext = new();

        #endregion Fields

        public EditSignatureViewModel()
            => this.m_PersistenceContext.Database.EnsureCreated();

        #region - - - - - - Methods - - - - - -

        public void AddSignature(EditSignatureModel newSignature)
        {
            this.m_PersistenceContext.Signatures.Add(newSignature);
            this.m_PersistenceContext.SaveChanges();
        }

        #endregion Methods

    }

}
