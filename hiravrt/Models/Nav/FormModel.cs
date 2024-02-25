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
			} else {
				mailMessage.From = new MailAddress(config.GetSection("Smtp")["Username"]);
			}

			mailMessage.To.Add("ask.hira.vrt@gmail.com");
			mailMessage.Subject = (Name == "" ? "Annonym" : Name) + "writes";
			mailMessage.Body = Message;

			SmtpClient smtpClient = new("smtp.gmail.com") {
				Port = 587,
				Credentials = new NetworkCredential(config.GetSection("Smtp")["Username"], config.GetSection("Smtp")["Password"]),
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
