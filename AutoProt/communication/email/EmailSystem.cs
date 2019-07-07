using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AutoProt
{
    public class EmailSystem : IDisposable
    {
        public bool Enabled { get; private set; }
        private SmtpClient client;

        private bool disposed = false;

        public EmailSystem(string host, string port, string username, string encryptedpassword)
        {
            this.Enabled = false;
            try
            {
                string password = Crypto.DecryptString(encryptedpassword, "secretMailPass");
                this.client = new SmtpClient
                {
                    Host = host,
                    Port = int.Parse(port),
                    EnableSsl = true,
                    Timeout = 10000,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(username, password)
                };
                this.Enabled = true;
            }
            catch
            {
                this.Enabled = false;
            }
        }
        public bool CheckEmailAdress(string email,string user)
        {
            bool mailworked = false;
            try
            {
                MailAddress newMail = new MailAddress(email,user);
                mailworked = true;
            }
            catch
            {
                mailworked = false;
            }
            return mailworked;
        }
        
        public string SendMail(string email, string user, string fileName, string results,string interpretation,List<string> ccemails = null)
        {
            string mailResult = "";
            if (Enabled)
            {
                try
                {
                    MailAddress recipentAddress = new MailAddress(email, user);
                    MailMessage mail = new MailMessage(new MailAddress("massspecstatistics@gmail.com", "Mass Spec Statistics"), recipentAddress)
                    {
                        IsBodyHtml = true,
                        Subject = fileName
                    };

                    foreach (string ccemail in ccemails)
                    {
                        if (!String.IsNullOrEmpty(ccemail))
                        {
                            try
                            {
                                MailAddress ccmailadress = new MailAddress(ccemail, "CC recipient");
                                mail.CC.Add(ccmailadress);
                            }
                            catch
                            {
                                mailResult += "Problems! CC-email >" + ccemail + "< seems not to be a valid address?";
                            }
                        }
                        
                    }

                    string body = File.ReadAllText(@"emailTemplate.htm", Encoding.UTF8); ;
                    body = body.Replace("#FILE#", fileName);
                    body = body.Replace("#NUMBERS#", results);
                    body = body.Replace("#INTERPRETATION#", interpretation);

                    mail.Body = body;
                    this.client.Send(mail);
                    mailResult += "Mail sent!";
                }
                catch
                {
                    mailResult += "Problems! Is user >" + user + email + "< configured correctly?";
                }
            }
            else 
            {
                mailResult = "Mail settings not initialized properly, can't send mail";
            }
            return mailResult;
        }
        /*
        public string SendMail(RawFileName rawfile, Dictionary<string, ResultItem> results)
        {
            string user = rawfile.user;
            string bodyContent = "<table>";
            foreach (KeyValuePair<string, ResultItem> result in results)
            {
                bodyContent += "<tr><td>";
                bodyContent += result.Key;
                bodyContent += "</td><td>";
                bodyContent += result.Value.GetFormattedValue();
                bodyContent += "</td></tr>";
            }
            bodyContent += "</table>";
            string mailresult = SendMail(rawfile.user, rawfile.baseName, bodyContent);
            return mailresult;
        }
         */
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (client != null)
                    {
                        client.Dispose();
                    }
                }
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
