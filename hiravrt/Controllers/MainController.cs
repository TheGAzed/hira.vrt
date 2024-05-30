using hiravrt.Controllers.Game;
using hiravrt.Controllers.Nav;

namespace hiravrt.Controllers
{
    public class MainController {
		/// <summary>
		/// Game controller that contains all available games for views.
		/// </summary>
		public GameController GameC { get; } = new();
		/// <summary>
		/// Home controller with mainly addresses used by views.
		/// </summary>
		public HomeController HomeC { get; } = new();
		/// <summary>
		/// Settings controller used to control settings specidied by user.
		/// </summary>
		public SettingsController SettingsC { get; } = new();

		public MainController() {
			SettingsC.AddGame(GameC.EitherOrModel);
		}
	}
}
