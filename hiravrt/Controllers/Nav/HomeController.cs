using Microsoft.AspNetCore.Mvc;

namespace hiravrt.Controllers.Nav
{
	public class HomeController {
		public string Home() => "/";
		public string About() => "/about";
		public string Contact() => "/contact";
		public string Privacy() => "/privacy";
		public string Terms() => "/terms";

		public string Github() => "https://github.com/TheGAzed/hira.vrt";
		public string GithubAccount() => "https://github.com/TheGAzed";
		public string TwitterAccount() => "https://twitter.com/pipiklover";
		public string LinkedinAccount() => "https://www.linkedin.com/in/thegazed/";
		public string YouTubeAccount() => "https://www.youtube.com/channel/UC-bwyBNxVdLfz8ZXATKAnbA";
	}
}
