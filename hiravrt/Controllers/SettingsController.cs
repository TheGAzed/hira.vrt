using hiravrt.Models.Game;
using hiravrt.Models.Settings;
using hiravrt.Models.Settings.Graphs;

namespace hiravrt.Controllers
{
	public enum GraphState {
		MONOGRAPH           = 0b00,
		DIGRAPH             = 0b01,
		DIACRITIC_MONOGRAPG = 0b10,
		DIACRITIC_DIGRAPH   = 0b11,
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

		public bool IsDiacritic() {
			return ((int)CurrGraphState & 0b10) != 0;
		}

		public void AddGame(GameModel model) {
			GameModels.Add(model);
			model.RemainingGuesses = Guesses;
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

		public void RemoveGame(GameModel model) {
			GameModels.Remove(model);
			model.RemainingGuesses = [
					"\u3042", "\u3044", "\u3046", "\u3048", "\u304a",
					"\u304b", "\u304d", "\u304f", "\u3051", "\u3053",
					"\u3055", "\u3057", "\u3059", "\u305b", "\u305d",
					"\u305f", "\u3061", "\u3064", "\u3066", "\u3068",
					"\u306a", "\u306b", "\u306c", "\u306d", "\u306e",
					"\u306f", "\u3072", "\u3075", "\u3078", "\u307b",
					"\u307e", "\u307f", "\u3080", "\u3081", "\u3082",
					"\u3084",           "\u3086",           "\u3088",
					"\u3089", "\u308a", "\u308b", "\u308c", "\u308d",
					"\u308f",                               "\u3092",
				"\u3093",
			];
			model.Reset();
		}

		public void Notify() {
			SetGuesses();
			foreach (GameModel m in GameModels) {
				m.Reset();
			}
		}
	}
}
