using Microsoft.AspNetCore.Mvc;

namespace hiravrt.Controllers.Nav
{
    public class HomeController
    {
        public string Home() => "/";
        public string Github() => "https://github.com/TheGAzed/hira.vrt";
        public string About() => "/about";
        public string Contact() => "/contact";
        public string Privacy() => "/privacy";
        public string Terms() => "/terms";
        public string GithubAccount() => "https://github.com/TheGAzed";
        public string TwitterAccount() => "https://twitter.com/pipiklover";
    }
}
