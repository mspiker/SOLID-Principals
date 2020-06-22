using System;

namespace SOLIDPrincipals
{
    class Program
    {
        static void Main(string[] args)
        {
            // SINGLE RESPONSIBILITY PRINCIPAL
            // -------------------------------

            // Demonstrates Single Responsibility Principle - The wrong way
            // The RequestDocument class wears many hats, it added and deletes documents
            // from the repository.  But, it also has the detailed code to send an e-mail
            // and log various informational events when they happen.  
            Before.SRP.RequestDocument WrongSRP = new Before.SRP.RequestDocument();
            WrongSRP.AddDocument();
            WrongSRP.DeleteDocument(1);

            // Demonstrates Single Responsibility Principle - The recommended way
            // The RequestDocument class focuses on what it knows best, details of how to
            // manage the request document; like addind and deleting.  It does not need to
            // know the details behind logging informational messages nor sending e-mail.
            After.SRP.RequestDocument CorrectSRP = new After.SRP.RequestDocument();
            CorrectSRP.AddDocument();
            CorrectSRP.DeleteDocument(1);
        }
    }
}
