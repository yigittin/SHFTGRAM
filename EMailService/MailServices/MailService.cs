using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Org.BouncyCastle.Asn1.Pkcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMailService.MailServices
{
    public class MailService:IMailService
    {
        private readonly IConfiguration _configs;

        public MailService(IConfiguration configs)
        {
            _configs = configs;
        }

        public async Task<bool> SendAsync(Message mailData, CancellationToken ct = default)
        {
            var displayName= _configs.GetSection("EmailConfiguration:DisplayName").Value;
            var from= _configs.GetSection("EmailConfiguration:From").Value;
            var useSsl= _configs.GetSection("EmailConfiguration:UseSSL").Value;
            var smptServer= _configs.GetSection("EmailConfiguration:SmtpServer").Value;
            var useStartTls = _configs.GetSection("EmailConfiguration:UseStartTls").Value;
            var port= Convert.ToInt32(_configs.GetSection("EmailConfiguration:Port").Value);
            var tlsPort= Convert.ToInt32(_configs.GetSection("EmailConfiguration:TlsPort").Value);
            var username= _configs.GetSection("EmailConfiguration:Username").Value;
            var password= _configs.GetSection("EmailConfiguration:Password").Value;
            try
            {
                // Initialize a new instance of the MimeKit.MimeMessage class
                var mail = new MimeMessage();

                #region Sender / Receiver
                // Sender
                mail.From.Add(new MailboxAddress(displayName, mailData.From ?? from));
                mail.Sender = new MailboxAddress(mailData.DisplayName ?? displayName, mailData.From ?? from);

                // Receiver
                foreach (string mailAddress in mailData.To)
                    mail.To.Add(MailboxAddress.Parse(mailAddress));

                // Set Reply to if specified in mail data
                if (!string.IsNullOrEmpty(mailData.ReplyTo))
                    mail.ReplyTo.Add(new MailboxAddress(mailData.ReplyToName, mailData.ReplyTo));

                // BCC
                // Check if a BCC was supplied in the request
                if (mailData.Bcc != null)
                {
                    // Get only addresses where value is not null or with whitespace. x = value of address
                    foreach (string mailAddress in mailData.Bcc.Where(x => !string.IsNullOrWhiteSpace(x)))
                        mail.Bcc.Add(MailboxAddress.Parse(mailAddress.Trim()));
                }

                // CC
                // Check if a CC address was supplied in the request
                if (mailData.Cc != null)
                {
                    foreach (string mailAddress in mailData.Cc.Where(x => !string.IsNullOrWhiteSpace(x)))
                        mail.Cc.Add(MailboxAddress.Parse(mailAddress.Trim()));
                }
                #endregion

                #region Content

                // Add Content to Mime Message
                var body = new BodyBuilder();
                mail.Subject = mailData.Subject;
                body.HtmlBody = mailData.Body;
                mail.Body = body.ToMessageBody();

                #endregion

                #region Send Mail

                using var smtp = new SmtpClient();

                if (Convert.ToBoolean(useSsl))
                {
                    await smtp.ConnectAsync(smptServer, port, SecureSocketOptions.SslOnConnect, ct);
                }
                else if (Convert.ToBoolean(useStartTls))
                {
                    await smtp.ConnectAsync(smptServer, tlsPort, SecureSocketOptions.StartTls, ct);
                }
                await smtp.AuthenticateAsync(username, password, ct);
                await smtp.SendAsync(mail, ct);
                await smtp.DisconnectAsync(true, ct);

                #endregion

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

