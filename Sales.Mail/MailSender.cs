using Sales.Entities.Interfaces;
using System;
using System.Threading.Tasks;

namespace Sales.Mail
{
    public class MailSender : IMailSender
    {
        readonly IApplicationStatusLogger Logger;
        public MailSender(IApplicationStatusLogger logger) => Logger = logger;

        public Task Send(string message)
        {
            Logger.Log("*** Servidor de correo no configurado ***");
            Logger.Log("Imposible enviar correo");
            Logger.Log(message);
            Logger.Log("******************************************");
            return Task.CompletedTask;
        }
    }
}
