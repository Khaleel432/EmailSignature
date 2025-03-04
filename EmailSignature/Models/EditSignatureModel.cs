using System.ComponentModel.DataAnnotations;

namespace EmailSignature.Models
{

    class EditSignatureModel
    {

        #region - - - - - - Fields - - - - - -

        public string Signature { get; set; }

        [Key]
        public Guid UserID { get; set; }

        #endregion Fields

    }

}
