using System;
using System.Net;
using System.Net.Mail;

namespace Почтовый_клиент
{
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                Console.WriteLine("Введите Ваш логин: ");
                string userlogin = Console.ReadLine();
                Console.WriteLine("Введите Ваш пароль: ");
                string userpassword = string.Empty;
                ConsoleKeyInfo key;
                do
                {
                    key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter) break;
                    if (key.Key == ConsoleKey.Backspace)
                    {
                        if (userpassword.Length != 0)
                        {
                            userpassword = userpassword.Remove(userpassword.Length - 1);
                            Console.Write("\b \b");
                        }
                    }
                    else
                    {
                        userpassword += key.KeyChar;
                        Console.Write("*");
                    }
                }
                while (true);
                Console.WriteLine();
                smtp.Credentials = new NetworkCredential(userlogin, userpassword);
                MailAddress from = new MailAddress(userlogin, "Harold");
                Console.WriteLine("Введите email-адрес получателя: ");
                string recipientadress = Console.ReadLine();
                MailAddress to = new MailAddress(recipientadress);
                MailMessage message1 = new MailMessage(from, to);
                message1.Subject = "Hide";
                message1.Body = "<h2>People forget about me, it hurts but I'll hide the pain</h2>";
                message1.IsBodyHtml = true;
                smtp.EnableSsl = true;
                smtp.Send(message1);
                Console.WriteLine("Сообщение успешно отправлено.");
            } catch
            {
                Console.WriteLine( "Произошла ошибка.");
            } 
            Console.ReadLine();
        }
    }
}
