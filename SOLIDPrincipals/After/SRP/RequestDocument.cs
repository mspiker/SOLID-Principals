using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDPrincipals.After.SRP
{
    public class RequestDocument
    {
        private ILogger logger;
        private MailSender emailSender;

        public RequestDocument()
        {
            logger = new Logger();
            emailSender = new MailSender();
        }
        public void AddDocument()
        {
            // Add document to the repository
            int newId = 99;

            logger.Info("Added document to repository.");
            emailSender.EMailFrom = "emailfrom@xyz.com";
            emailSender.EMailTo = "emailto@xyz.com";
            emailSender.EMailSubject = "Single Responsibility Principle";
            emailSender.EMailBody = "A class should have only one reason to change";
            emailSender.SendEmail();
        }

        public void DeleteDocument(int id)
        {
            // Remove the document from the repository
            logger.Info(String.Format("Document {0} has been removed.", id));
        }
    }
}
