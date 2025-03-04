using EmailSignature.Models;
using EmailSignature.Services;
using System.Diagnostics;

namespace EmailSignature.ViewModels
{

    class EditSignatureViewModel
    {

        #region - - - - - - Fields - - - - - -

        private readonly EditSignatureModel m_EditSignatureModel;
        private readonly PersistenceContext m_PersistenceContext = new();

        #endregion Fields

        public EditSignatureViewModel(EditSignatureModel editSignatureModel)
        {
            this.m_EditSignatureModel = editSignatureModel;
            if (this.m_PersistenceContext.Database.EnsureCreated())
                Trace.WriteLine("Database created");
        }

        #region - - - - - - Methods - - - - - -

        public string GetSignature()
        {
            var _Signature = this.m_PersistenceContext.Find<EditSignatureModel>(this.m_EditSignatureModel.UserID);
            if (_Signature != null)
                return _Signature.Signature;
            return "No signature found with id: " + this.m_EditSignatureModel.UserID;
        }

        public void UpdateSignature()
        {
            var _Signature = this.m_PersistenceContext.Find<EditSignatureModel>(this.m_EditSignatureModel.UserID);
            if (_Signature == null)
                this.m_PersistenceContext.Signatures.Add(this.m_EditSignatureModel);
            this.m_PersistenceContext.SaveChanges();
        }

        public void UpdateSignatureString(string rtfSignatureString)
            => this.m_EditSignatureModel.Signature = rtfSignatureString;

        #endregion Methods

    }

}
