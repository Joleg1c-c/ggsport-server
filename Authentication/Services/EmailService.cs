using MailKit;
using MailKit.Net.Smtp;
using MimeKit;

namespace ggsport.Authentication.Services;

public class EmailService : IMailService
{
    private static readonly string FromEmail = "damir.schaymuhametow2015@yandex.ru";
    private static readonly string Password = "Alber_Kamus_19AL";

    public async Task SendEmailAsync(string email, string subject, string message)
    {
        using var emailMessage = new MimeMessage();

        emailMessage.From.Add(new MailboxAddress("GGSport", FromEmail));
        emailMessage.To.Add(new MailboxAddress("", email));
        emailMessage.Subject = subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
        {
            Text = message
        };

        using var client = new SmtpClient();
        await client.ConnectAsync("smtp.yandex.ru", 25, false);
        await client.AuthenticateAsync(FromEmail, Password);
        await client.SendAsync(emailMessage);

        await client.DisconnectAsync(true);
    }
}
