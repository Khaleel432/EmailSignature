using EmailSignature.Models;
using System.IO;

namespace EmailSignature.ViewModels
{

    public class EditSignatureViewModel
    {

        #region - - - - - - Fields - - - - - -

        public EmailModel m_Email;

        #endregion Fields

        public EditSignatureViewModel() { }

        #region - - - - - - Methods - - - - - -

        public string GetSignature()
        {
            if (this.m_Email.Signature.Exists)
            {
                var _SignatureString = "";
                using (StreamReader _SR = this.m_Email.Signature.OpenText())
                {
                    while ((_SignatureString = _SR.ReadLine()) != null)
                    {
                        return _SignatureString;
                    }
                }
            }
            return "";
        }

        public void SaveSignature(string rtfString)
        {
            var _SignatureString = this.m_Email.Signature;
            if (!_SignatureString.Exists)
            {
                //Create a file to write to.
                using (StreamWriter _SW = _SignatureString.CreateText())
                {
                    _SW.WriteLine(rtfString);
                }
            }
        }

        #endregion Methods

    }

}
