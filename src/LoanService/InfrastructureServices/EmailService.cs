using System;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;

namespace LoanService.InfrastructureServices
{
    public class EmailService
    {
        public static void SendEmail(Tuple<int,int,float,double> loaninfo)
        {

            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("sarvesh", "sarvesh189@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("sarveshT", "sarvesh189@gmail.com"));
            emailMessage.Subject = "Amazon SES test (SMTP interface accessed using C#)";
            emailMessage.Body = new TextPart("plain") { Text = $"Principle Amount {loaninfo.Item1} Tenure {loaninfo.Item2} InterestRate {loaninfo.Item3} EMI {loaninfo.Item4}" };

            using (var client = new SmtpClient())
            {
                //  

               // client.LocalDomain = "ses-smtp-user.20170406-173508";
                
                client.Connect("email-smtp.us-west-2.amazonaws.com", 587, SecureSocketOptions.StartTls);

              //  client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate("aws_access_key_id", "aws_secret_access_key");
                client.Send(emailMessage);

                client.Disconnect(true);
            }



          

     //       Console.Write("Press any key to continue...");
       //     Console.ReadKey();
        }
    }
    }

