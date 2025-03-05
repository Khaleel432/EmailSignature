using EmailSignature.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Identity.Client;
using MimeKit;

namespace EmailSignature.Services
{
    public interface IEmailProvider
    {

        #region - - - - - - Methods - - - - - -

        public Task<bool> SendEmail(EmailModel email);

        #endregion Methods

    }

    public class EmailProvider : IEmailProvider
    {

        #region - - - - - - Fields - - - - - -

        private readonly EmailServiceProviderModel m_EmailProvider;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public EmailProvider()
        {
            this.m_EmailProvider = new EmailServiceProviderModel()
            {
                AuthenticationMethod = "OAuth2",
                Encryption = SecureSocketOptions.StartTls,
                Port = 587,
                ServerAddress = "smtp-mail.outlook.com"
            };
        }

        #endregion Constructors

        #region - - - - - - Methods - - - - - -

        async Task<bool> IEmailProvider.SendEmail(EmailModel email)
        {
            var _Message = new MimeMessage();

            _Message.From.Add(new MailboxAddress(email.Address, email.Name));
            _Message.Subject = email.Subject;

            _Message.Body = new TextPart("plain")
            {
                Text = email.Body
            };

            foreach (var _Recipient in email.ToRecipients)
            {
                _Message.To.Add(new MailboxAddress(_Recipient.Name, _Recipient.Address));
            }

            var _Result = await GetPublicClientOAuth2CredentialsAsync("SMTP", email.Address);

            var _OAuth2 = new SaslMechanismOAuth2(_Result.Account.Username, _Result.AccessToken);

            using (var _Client = new SmtpClient())
            {
                _Client.Connect(this.m_EmailProvider.ServerAddress, this.m_EmailProvider.Port, this.m_EmailProvider.Encryption);
                //_Client.Authenticate(email.Address, email.Password);
                _Client.Authenticate(_OAuth2);
                _Client.Send(_Message);
                _Client.Disconnect(true);
            }
            //var result = await publicClientApplication.AcquireTokenSilent(scopes, account).ExecuteAsync(cancellationToken);

            return true;
        }

        //Taken from: https://github.com/jstedfast/MailKit/blob/master/ExchangeOAuth2.md
        // Application ID and Directory ID need to be retrieved from outlook to continue OAuth token flow
        static async Task<AuthenticationResult> GetPublicClientOAuth2CredentialsAsync(string protocol, string emailAddress, CancellationToken cancellationToken = default)
        {
            var options = new PublicClientApplicationOptions
            {
                ClientId = "Application (client) ID",
                TenantId = "Directory (tenant) ID",

                // Use "https://login.microsoftonline.com/common/oauth2/nativeclient" for apps using
                // embedded browsers or "http://localhost" for apps that use system browsers.
                RedirectUri = "https://login.microsoftonline.com/common/oauth2/nativeclient"
            };

            var publicClientApplication = PublicClientApplicationBuilder
                .CreateWithApplicationOptions(options)
                .Build();

            string[] scopes;

            if (protocol.Equals("IMAP", StringComparison.OrdinalIgnoreCase))
            {
                scopes = new string[] {
            "email",
            "offline_access",
            "https://outlook.office.com/IMAP.AccessAsUser.All"
        };
            }
            else if (protocol.Equals("POP", StringComparison.OrdinalIgnoreCase))
            {
                scopes = new string[] {
            "email",
            "offline_access",
            "https://outlook.office.com/POP.AccessAsUser.All"
        };
            }
            else
            {
                scopes = new string[] {
            "email",
            "offline_access",
            "https://outlook.office.com/SMTP.Send"
        };
            }

            try
            {
                // First, check the cache for an auth token.
                return await publicClientApplication.AcquireTokenSilent(scopes, emailAddress).ExecuteAsync(cancellationToken);
            }
            catch (MsalUiRequiredException)
            {
                // If that fails, then try getting an auth token interactively.
                return await publicClientApplication.AcquireTokenInteractive(scopes).WithLoginHint(emailAddress).ExecuteAsync(cancellationToken);
            }
        }

        #endregion Methods

    }

}
