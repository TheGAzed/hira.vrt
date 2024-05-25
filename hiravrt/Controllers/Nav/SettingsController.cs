using hiravrt.Models.Game;
using hiravrt.Models.Nav.Graphs;

namespace hiravrt.Controllers.Nav {
	public enum GraphState {
		MONOGRAPH = 0b00,
		DIGRAPH = 0b01,
		DIACRITIC_MONOGRAPG = 0b10,
		DIACRITIC_DIGRAPH = 0b11,
	}

	public class SettingsController {
		public string Settings() => "/settings";
		public List<GameModel> GameModels = [];
		private Dictionary<GraphState, GraphModel> keyGraphPair;
		public GraphState CurrGraphState { get; set; } = GraphState.MONOGRAPH;
		public List<string> Guesses { get; set; } = [];

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
			model.RemainingSyllables = Guesses;
			model.Reset();
		}

		public GraphModel GetCurrentGraph() {
			return keyGraphPair[CurrGraphState];
		}

		public void NextGraph() {
			CurrGraphState = (GraphState)(((int)CurrGraphState ^ 0b01) & ~0b10);
		}

		public void NextDiacritic() {
			CurrGraphState = (GraphState)((int)CurrGraphState ^ 0b10);
		}

		private void SetGuesses() {
			Guesses.Clear();

			foreach (GraphModel m in keyGraphPair.Values) {
				foreach (string g in m.Guesses) {
					Guesses.Add(g);
				}
			}
		}

		public void Notify() {
			SetGuesses();
			foreach (GameModel m in GameModels) m.Reset(); 
		}
	}
}
