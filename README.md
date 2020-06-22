# SOLID-Principals
Project demonstrates the principals of SOLID, five principals intended to make software designs more understandable, flexible, and maintainable.  It promotes high quality, fast to market agile methods to develop software.  
## Single Responsibility Principal (SRP)
Each software module or class should have only one reason to change. In other words, we can say that each module or class should have only one responsibility to do.

This project demonstrates a quick approach in the Before.SRP namespace which can generally be forund in applications. It then rewrites that code in the After.SRP namespace to adopt the single responsibilty principal.  Both solutions contain a RequestDocument which will represent some document.  Lets look at typically what you will find.

```c#
namespace SOLIDPrincipals.Before.SRP
{
    public class RequestDocument
    {
        public void AddDocument()
        {
            // Add document to the repository
            int newId = 99;

            LogActivity("Added document to repository.");
            EmailDocument(newId);
        }
        public void DeleteDocument(int id)
        {
            // Remove the document from the repository
            LogActivity(String.Format("Document {0} has been removed.", id));
        }
        private void EmailDocument(int id)
        {
            // Email the document to get approvals
        }
        private void LogActivity(string activityToLog)
        {
            // Write the activity to a log file
        }
    }
}
```

After rewriting it we generate an ILogger interface along with two additional classes, one class (Logger) implements the ILogger interface and the other class focuses on sending the e-mail.  

```c#
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
```
