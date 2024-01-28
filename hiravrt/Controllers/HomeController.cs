using Microsoft.AspNetCore.Mvc;

namespace hiravrt.Controllers {
	public class HomeController {
		public string Home() => "/";
		public string About() => "/about";
		public string Contact() => "/contact";
		public string Privacy() => "/privacy";
		public string Terms() => "/terms";
	}
}
