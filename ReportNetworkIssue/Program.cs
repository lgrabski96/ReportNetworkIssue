using Microsoft.Office.Interop.Outlook;
using System;
using System.Threading;
using System.Windows.Forms;

namespace ReportNetworkIssue
{
    public class Program
    {
        public static void Main()
        {
            var outlook = new Application();

            string message = "Message Send";

            try
            {
                MailItem mail = outlook.CreateItem(OlItemType.olMailItem) as MailItem;
                mail.Subject = "Netwotk Issue";
                mail.Body = "A problem has been detected";
                mail.To = "lukasz.grabski@capgemini.com";
                // mail.Display();
                mail.Send();

                MessageBox.Show(message);

                Console.WriteLine("Email was send to ithelpdeskglobal ");
                Thread.Sleep(5000);


                /*
                // TODO: Optionally we can resolve addresses from Exchange Server if that one is used
                AddressEntry currentUser = outlook.Session.CurrentUser.AddressEntry;
                
                // EX should mean Exchange but I don't remember :)
                if (currentUser.Type == "EX")
                {
                    mail.Recipients.Add("Some User Name, email, or whatever");
                    mail.Recipients.ResolveAll();
                    mail.Body = "A problem has been detected";
                    mail.To = "test@some.test.com";
                    mail.Send();
                }
                */

            }
            finally
            {
                // TODO: Check if we want to really exit!
                // outlook.Quit();
            }

            
        }
    }
}
