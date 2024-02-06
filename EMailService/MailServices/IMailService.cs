using Org.BouncyCastle.Asn1.Pkcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMailService.MailServices
{
    public interface IMailService
    {
        Task<bool> SendAsync(Message mailData, CancellationToken ct);
    }
}
