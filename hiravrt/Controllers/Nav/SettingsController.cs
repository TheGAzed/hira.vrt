using hiravrt.Models.Game;
using hiravrt.Models.Nav.Settings;
using hiravrt.Models.Nav.Settings.Grid;
using hiravrt.Models.Nav.Settings.Grid.Graphs;

namespace hiravrt.Controllers.Nav {
	public enum SettingsSection {
		GRID,
		FONTS,
	}

	public class SettingsController {
		public FontsModel fontsModel;
		public GridModel  gridModel;
		/// <summary>
		/// List of all game models that rely on settings' active syllables
		/// </summary>
		public List<GameModel> GameModels = [];
		public SettingsSection CurrentSettingsSection { get; set; } = SettingsSection.GRID;

		public SettingsController() {
			fontsModel = new FontsModel();
			gridModel  = new GridModel(this);
		}

		/// <summary>
		/// Adds gamemodel to notify if list of available syllables has changed.
		/// </summary>
		/// <param name="model">Concrete gamemodel to notify.</param>
		public void AddGame(GameModel model) {
			GameModels.Add(model);
			model.RemainingSyllables = new(gridModel.AvailableSyllables);
			model.Reset();
		}

		/// <summary>
		/// Resets AvailableSyllables and notifies all subscribed gamemodels that AvailableSyllables have changed by resetting them.
		/// </summary>
		public void Notify() {
			gridModel.ResetGuesses();
			foreach (GameModel m in GameModels) {
				m.RemainingSyllables = new(gridModel.AvailableSyllables);
				m.Reset();
			}
		}
	}
}
