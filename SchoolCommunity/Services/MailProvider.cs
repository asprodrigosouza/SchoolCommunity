using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace MCBSchedule.Provider
{
    public sealed class MailProvider
    {
        private static MailProvider _intance;
        private SmtpClient Smtp;
        private Thread SendThread;

        private List<string> MailTo;
        private string MailFrom;
        private List<string> MailBCC;
        private List<string> MailCC;
        private string MailSubject;
        private string MailBody;
        private string AttachPath;

        public MailProvider()
        {
            MailTo = new List<string>();
            MailBCC = new List<string>();
            MailCC = new List<string>();
        }

        public void SendEmail(string mailTo, string mailFrom, string mailSubject, string mailBody, string pathFiles)
        {
            this.SendEmail(mailTo, mailFrom, "", "", mailSubject, mailBody, pathFiles);
        }

        public void SendEmail(string _MailTo, string _MailFrom, string _MailBCC, string _MailCC, string _MailSubject, string _MailBody, string _AttachPath)
        {
            this.MailTo.Add(_MailTo);
            this.MailFrom = _MailFrom;
            this.MailBCC.Add(_MailBCC);
            this.MailCC.Add(_MailCC);
            this.MailSubject = _MailSubject;
            this.MailBody = _MailBody;
            this.AttachPath = _AttachPath;
            this.SendThread = new Thread(new ThreadStart(this.ThreadSender));
            this.SendThread.Start();
        }

        public void SendEmail(List<string> _MailTo, string _MailFrom, List<string> _MailBCC, List<string> _MailCC, string _MailSubject, string _MailBody, string _AttachPath)
        {
            this.MailTo = _MailTo;

            this.MailFrom = _MailFrom;
            this.MailBCC = _MailBCC;
            this.MailCC = _MailCC;

            this.MailSubject = _MailSubject;
            this.MailBody = _MailBody;
            this.AttachPath = _AttachPath;
            this.SendThread = new Thread(new ThreadStart(this.ThreadSender));
            this.SendThread.Start();
        }

        public void ThreadSender()
        {
            try
            {
                MailMessage message = (MailMessage)null;
                try
                {
                    //this.Smtp = new SmtpClient(ConfigurationManager.AppSettings["SMTPAddress"].ToString(), int.Parse(ConfigurationManager.AppSettings["SMTPPort"].ToString()));
                    //this.Smtp.Credentials = (ICredentialsByHost)new NetworkCredential(ConfigurationManager.AppSettings["SMTPLogin"], ConfigurationManager.AppSettings["SMTPPassword"]);
                    
                    this.Smtp = new SmtpClient("smtp.gmail.com", 587);
                    this.Smtp.EnableSsl = true;
                    this.Smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    this.Smtp.UseDefaultCredentials = false;
                    this.Smtp.Credentials = (ICredentialsByHost)new NetworkCredential("projetointegradorads18@gmail.com", "projetoads2018");
                    //this.Smtp.Credentials = new NetworkCredential("projetointegradorads18@gmail.com", "projetoads2018");
                    
                    // ******* SMTP GMAIL ******* //
                    //this.Smtp = new SmtpClient("smtp.live.com", 587);
                    //this.Smtp.Credentials = (ICredentialsByHost)new NetworkCredential("joseivis@live.com", "positivo201");
                    //this.Smtp.EnableSsl = true;

                    message = new MailMessage();
                    message.From = new MailAddress(this.MailFrom);

                    this.MailTo.ForEach(delegate (string str)
                    {
                        message.To.Add(str);
                    });

                    message.Subject = this.MailSubject;
                    message.Body = this.MailBody;
                    message.IsBodyHtml = true;

                    this.MailCC.ForEach(delegate (string str)
                    {
                        message.CC.Add(str);
                    });
                    
                    this.MailBCC.ForEach(delegate (string str) {
                        message.Bcc.Add(str);
                    });
                    
                    //foreach (string file in Directory.GetFiles(this.AttachPath, "*.*", SearchOption.TopDirectoryOnly))
                        //message.Attachments.Add(new Attachment(file));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Formatando dados e-Mail \r\n => " + ex.ToString());
                }

                try
                {
                    this.Smtp.Send(message);
                }
                catch (SmtpFailedRecipientsException ex)
                {
                    Console.WriteLine("SmtpFailedRecipientsException \r\n => " + ex.ToString());
                }
                catch (SmtpFailedRecipientException ex)
                {
                    Console.WriteLine("SmtpFailedRecipientException \r\n => " + ex.ToString());
                }
                catch (SmtpException ex)
                {
                    Console.WriteLine("SmtpException \r\n => " + ex.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro Envio e-Mail \r\n => " + ex.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Formatando dados e-Mail \r\n => " + ex.ToString());
            }
        }
    }
}