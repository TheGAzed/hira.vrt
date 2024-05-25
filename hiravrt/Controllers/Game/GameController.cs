using hiravrt.Models.Game;
using System.Diagnostics;

namespace hiravrt.Controllers.Game
{
	public class GameController {
		/// <summary>
		/// Lookup variable of dictionaries.
		/// </summary>
		public LookUp LookUp { get; } = new LookUp();
		/// <summary>
		/// EitherOr game mode model.
		/// </summary>
		public EitherOrModel EitherOrModel { get; }

		/// <summary>
		/// Initializer for all gamemodes.
		/// </summary>
		public GameController() {
			EitherOrModel = new EitherOrModel();
		}

		public string EitherOr() => "/eitheror";
	}
}
