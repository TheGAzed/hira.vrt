using hiravrt.Models.Game;
using hiravrt.Models.Nav.Graphs;

namespace hiravrt.Controllers.Nav {
	/// <summary>
	/// Graph states in settings razor section.
	/// </summary>
	public enum GraphState : int {
		MONOGRAPH           = 0b00,
		DIGRAPH             = 0b01,
		DIACRITIC_MONOGRAPG = 0b10,
		DIACRITIC_DIGRAPH   = 0b11,
	}

	public class SettingsController {
		/// <summary>
		/// List of all game models that rely on settings' active syllables
		/// </summary>
		public List<GameModel> GameModels = [];
		private readonly Dictionary<GraphState, GraphModel> keyGraphPair;
		public GraphState CurrentGraphState { get; set; } = GraphState.MONOGRAPH;
		public List<string> AvailableSyllables { get; set; } = [];

		public SettingsController() {
			keyGraphPair = new Dictionary<GraphState, GraphModel>() {
				{ GraphState.MONOGRAPH,           new MonographModel(this)          },
				{ GraphState.DIGRAPH,             new DigraphModel(this)            },
				{ GraphState.DIACRITIC_MONOGRAPG, new DiacriticMonographModel(this) },
				{ GraphState.DIACRITIC_DIGRAPH,   new DiacriticDigraphModel(this)   },
			};
			SetGuesses();
		}

		public void AddGame(GameModel model) {
			GameModels.Add(model);
			model.RemainingSyllables = AvailableSyllables;
			model.Reset();
		}

		public GraphModel GetCurrentGraph() {
			return keyGraphPair[CurrentGraphState];
		}

		public void NextGraph() {
			CurrentGraphState = (GraphState)(((int)CurrentGraphState ^ 0b01) & ~0b10);
		}

		public void NextDiacritic() {
			CurrentGraphState = (GraphState)((int)CurrentGraphState ^ 0b10);
		}

		private void SetGuesses() {
			AvailableSyllables.Clear();

			foreach (GraphModel m in keyGraphPair.Values) {
				foreach (string g in m.Guesses) {
					AvailableSyllables.Add(g);
				}
			}
		}

		public void Notify() {
			SetGuesses();
			foreach (GameModel m in GameModels) m.Reset(); 
		}
	}
}
