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
## Open-closed principal
Software entities such as modules, classes, functions, etc. should be open for extension, but closed for modification.

The Open for extension means we need to design the software modules/classes in such a way that the new responsibilities or functionalities should be added easily when new requirements come. On the other hand, Closed for modification means, we should not modify the class/module until we find some bugs.

### Why is this important? 
We have already developed a class/module and it has gone through the unit testing phase. So we should not have to change this as it affects the existing functionalities. In simple words, we can say that we should develop an entity in such a way that it should allow its behavior to be extended without altering its source code.

### Potential Impact by not following this principal
* Adding new logic to an existing class or function requires testing all functionality, both old and new of the application.  
* Potential to break the SRP as it may perform multiple responsibilities.
* Implementing all the functionality in a single class adds difficulty to the maintenance.

### The demonstration
In our project we will take a document which requests time off, we will call this object the RequestDocument.  This document will need to figure out who the approvers are based upon the position in the workflow.

![alt text](https://github.com/mspiker/SOLID-Principals/blob/[branch]/image.jpg?raw=true)
