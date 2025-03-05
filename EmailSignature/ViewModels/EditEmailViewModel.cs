using EmailSignature.Models;
using System.IO;

namespace EmailSignature.ViewModels
{

    public class EditEmailViewModel
    {

        #region - - - - - - Fields - - - - - -

        public readonly EmailModel m_Email;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public EditEmailViewModel()
        {
            this.m_Email = new EmailModel()
            {
                UserID = Guid.NewGuid()
            };
            this.m_Email.Signature = new("Signatures/" + this.m_Email.UserID.ToString());
        }

        #endregion Constructors

        #region - - - - - - Methods - - - - - -

        public string GetSignature()
        {
            if (this.m_Email.Signature.Exists)
            {
                var _SignatureString = "";
                using (StreamReader _SR = this.m_Email.Signature.OpenText())
                {
                    string _NextFileLine = "";
                    while ((_NextFileLine = _SR.ReadLine()) != null)
                    {
                        _SignatureString = _SignatureString + _NextFileLine + "\n";
                    }
                    return _SignatureString;
                }
            }
            return "";
        }

        #endregion Methods

    }

}
