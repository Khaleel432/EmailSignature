namespace EmailSignature.Models
{

    public class EmailModel
    {

        #region - - - - - - Fields - - - - - -

        public string Address { get; set; }

        public string Body { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string Signature { get; set; }

        public string Subject { get; set; }

        public RecipientModel[] ToRecipients { get; set; }

        public Guid UserID { get; set; }

        #endregion Fields

    }

}
