using Microsoft.Extensions.Configuration.UserSecrets;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
using static hiravrt.Views.Pages.Nav.Contact;

namespace hiravrt.Models.Nav {
	public class FormModel {
		public string Name { get; set; } = "";
		public string Email { get; set; } = "";
		public string Message { get; set; } = "";

		public void SendEmail() {
			if (Message.Length == 0) return;

			EmailAddressAttribute address = new();
			MailMessage mailMessage = new();
			IConfiguration config = new ConfigurationBuilder()
				.AddUserSecrets<FormModel>()
				.Build();

            if (address.IsValid(Email)) {
				mailMessage.From = new MailAddress(Email);
			} else if (config.GetValue<string>("SMTP:Username") is not null) {
				mailMessage.From = new MailAddress(config.GetValue<string>("SMTP:Username")!);
			}

			mailMessage.To.Add(config.GetValue<string>("SMTP:Username")!);
			mailMessage.Subject = (Name == "" ? "Annonym" : Name) + "writes";
			mailMessage.Body = Message;

			SmtpClient smtpClient = new("smtp.gmail.com") {
				Port = config.GetValue<int>("SMTP:Port"),
				Credentials = new NetworkCredential(config.GetValue<string>("SMTP:Username"), config.GetValue<string>("SMTP:Password")),
				EnableSsl = true,
			};

			try {
				smtpClient.Send(mailMessage);
				Console.WriteLine("Message Sent");
			} catch (Exception e) {
				Console.WriteLine(e.ToString());
			}
		}
	}
}
