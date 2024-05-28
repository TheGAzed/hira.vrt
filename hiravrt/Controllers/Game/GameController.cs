using hiravrt.Models.Game;
using System.Diagnostics;

namespace hiravrt.Controllers.Game
{
	public class GameController {
		/// <summary>
		/// Lookup variable of dictionaries with Japanese syllables.
		/// </summary>
		public LookUp LookUp { get; } = new LookUp();
		/// <summary>
		/// EitherOr gamemode model class.
		/// </summary>
		public EitherOrModel EitherOrModel { get; }

		/// <summary>
		/// Controller constructor for game dependant code.
		/// </summary>
		public GameController() {
			EitherOrModel = new EitherOrModel();
		}

		/// <summary>
		/// String address for EitherOr gamemode.
		/// </summary>
		/// <returns>EitherOr string address.</returns>
		public string EitherOr() => "/eitheror";
	}
}
