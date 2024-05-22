using Microsoft.Extensions.Configuration.UserSecrets;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using static hiravrt.Views.Pages.Nav.Contact;

namespace hiravrt.Models.Nav {
	public class FormModel {
		public string Name { get; set; } = "";
		public string Email { get; set; } = "";
		public string Message { get; set; } = "";

		private readonly IConfiguration ?config;

		public bool IsBroken = false;

		public bool IsValidForm() {
			return Message.Length > 0;
		}

		public FormModel() {
			try {
				config = new ConfigurationBuilder()
					.AddUserSecrets<FormModel>()
					.Build();
			}
			catch (InvalidOperationException) {
				IsBroken = true;
			}
		}

		public void SendEmail() {
			if (Message.Length == 0 || IsBroken) return;

			try {
				EmailAddressAttribute address = new();
				MailMessage mailMessage = new();

				if (address.IsValid(Email)) {
					mailMessage.From = new MailAddress(Email);
				} else if (config!.GetValue<string>("SMTP:Username") is not null) {
					mailMessage.From = new MailAddress(config!.GetValue<string>("SMTP:Username")!);
				}

				mailMessage.To.Add(config!.GetValue<string>("SMTP:Username")!);
				mailMessage.Subject = (Name == "" ? "Annonym" : Name) + " writes";
				mailMessage.Body = Email.Length != 0 ? "Email : " + Email + "\n\n" + Message : Message;

				SmtpClient smtpClient = new("smtp.gmail.com") {
					Port = config!.GetValue<int>("SMTP:Port"),
					Credentials = new NetworkCredential(config!.GetValue<string>("SMTP:Username"), config!.GetValue<string>("SMTP:Password")),
					EnableSsl = true,
				};

				smtpClient.Send(mailMessage);
			} catch {
				IsBroken = true;
			}

			this.Reset();
		}

		public void Reset() {
			this.Name = "";
			this.Email = "";
			this.Message = "";
		}
	}
}
