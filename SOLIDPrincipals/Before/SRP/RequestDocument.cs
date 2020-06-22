using System;
using System.Collections.Generic;
using System.Text;

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
