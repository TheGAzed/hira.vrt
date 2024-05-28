using Microsoft.AspNetCore.Mvc;

namespace hiravrt.Controllers.Nav {
	public class HomeController {
		/// <summary>
		/// String address to homepage.
		/// </summary>
		/// <returns>Index string address.</returns>
		public string Home() => "/";
		/// <summary>
		/// String address to about page.
		/// </summary>
		/// <returns>Index string address.</returns>
		public string About() => "/about";
		/// <summary>
		/// String address to game settings page.
		/// </summary>
		/// <returns>Index string address.</returns>
		public string Settings() => "/settings";
		/// <summary>
		/// String address to contact page.
		/// </summary>
		/// <returns>Index string address.</returns>
		public string Contact() => "/contact";

		/// <summary>
		/// String address to GitHub project page.
		/// </summary>
		/// <returns>Index string address.</returns>
		public string Github() => "https://github.com/TheGAzed/hira.vrt";
		/// <summary>
		/// String address to PayPal donation page.
		/// </summary>
		/// <returns>Index string address.</returns>
		public string Donation() => "https://www.paypal.com/donate/?hosted_button_id=8XHXLQXUN9Y56";

		/// <summary>
		/// String address to GitHub profile page.
		/// </summary>
		/// <returns>Index string address.</returns>
		public string GithubAccount() => "https://github.com/TheGAzed";
		/// <summary>
		/// String address to Twitter profile page.
		/// </summary>
		/// <returns>Index string address.</returns>
		public string TwitterAccount() => "https://twitter.com/pipiklover";
		/// <summary>
		/// String address to LinkedIn profile page.
		/// </summary>
		/// <returns>Index string address.</returns>
		public string LinkedinAccount() => "https://www.linkedin.com/in/thegazed/";
		/// <summary>
		/// String address to YouTube channel page.
		/// </summary>
		/// <returns>Index string address.</returns>
		public string YouTubeAccount() => "https://www.youtube.com/channel/UC-bwyBNxVdLfz8ZXATKAnbA";
	}
}
