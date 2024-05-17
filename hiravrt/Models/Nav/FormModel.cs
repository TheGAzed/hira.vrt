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

		private Stopwatch LastSubmit = new Stopwatch();

		private bool IsCooldown {
			get { return LastSubmit.IsRunning && LastSubmit.ElapsedMilliseconds <= 60_000; }
		}

		private bool IsBroken = false;

		public bool IsBlocked {
			get { return IsCooldown || IsBroken; }
		}

		public void SendEmail() {
			if (Message.Length == 0) return;
			if (IsBlocked) return;
			LastSubmit.Reset();

			EmailAddressAttribute address = new();
			MailMessage mailMessage = new();
			IConfiguration config;
            try {
				config = new ConfigurationBuilder()
					.AddUserSecrets<FormModel>()
					.Build();
			} catch (InvalidOperationException ioex) {
				IsBroken = true;
				return;
			}

			if (address.IsValid(Email)) {
				mailMessage.From = new MailAddress(Email);
			} else if (config.GetValue<string>("SMTP:Username") is not null) {
				mailMessage.From = new MailAddress(config.GetValue<string>("SMTP:Username")!);
			}

			mailMessage.To.Add(config.GetValue<string>("SMTP:Username")!);
			mailMessage.Subject = (Name == "" ? "Annonym" : Name) + " writes";
			mailMessage.Body = Email == string.Empty ? "Email : " + Email + "\n\n" + Message : Message;

			SmtpClient smtpClient = new("smtp.gmail.com") {
				Port = config.GetValue<int>("SMTP:Port"),
				Credentials = new NetworkCredential(config.GetValue<string>("SMTP:Username"), config.GetValue<string>("SMTP:Password")),
				EnableSsl = true,
			};

			try {
				smtpClient.Send(mailMessage);
				Console.WriteLine("Message Sent");
			} catch {
				IsBroken = true;
				return;
			}

			this.Reset();

			LastSubmit.Start();
		}

		public void Reset()
		{
			this.Name = "";
			this.Email = "";
			this.Message = "";
		}
	}
}
