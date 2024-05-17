using hiravrt.Controllers.Game;
using hiravrt.Controllers.Nav;

namespace hiravrt.Controllers
{
    public class MainController {
		public GameController GameC { get; } = new();
		public HomeController HomeC { get; } = new();
		public SettingsController SettingsC { get; } = new();

		public MainController() {
			SettingsC.AddGame(GameC.EitherOrModel);
		}
	}
}
