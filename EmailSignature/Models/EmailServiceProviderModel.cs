using MailKit.Security;

namespace EmailSignature.Models
{

    public class EmailServiceProviderModel
    {
        public string? AuthenticationMethod { get; set; }

        public SecureSocketOptions Encryption { get; set; }

        public int Port { get; set; }

        public string? ServerAddress { get; set; }

    }

}
