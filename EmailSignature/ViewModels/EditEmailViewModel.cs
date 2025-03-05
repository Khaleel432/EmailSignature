using EmailSignature.Models;

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
            this.m_Email.Signature = new(this.m_Email.UserID.ToString());
        }

        #endregion Constructors

    }

}
