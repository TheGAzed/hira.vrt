using hiravrt.Models.Game;
using hiravrt.Models.Nav.Graphs;

namespace hiravrt.Controllers.Nav {
	/// <summary>
	/// Graph states in settings razor section.
	/// </summary>
	public enum GraphState : int {
		MONOGRAPH           = 0b00, // MONOGRAPHIC SYLLABLES ENUM
		DIGRAPH             = 0b01, // DIGRAPHIC SYLLABLES ENUM
		DIACRITIC_MONOGRAPG = 0b10, // MONOGRAPHIC SYLLABLES WITH DIACRITICS ENUM
		DIACRITIC_DIGRAPH   = 0b11, // DIGRAPHIC SYLLABLES WITH DIACRITICS ENUM
	}

	public class SettingsController {
		/// <summary>
		/// List of all game models that rely on settings' active syllables
		/// </summary>
		public List<GameModel> GameModels = [];
		/// <summary>
		/// Lookup dictionary that returns concrete GraphModel based on GraphState
		/// </summary>
		private readonly Dictionary<GraphState, GraphModel> StateGraphPair;
		/// <summary>
		/// Returns current set graph in sesttings.
		/// </summary>
		public GraphState CurrentGraphState { get; set; } = GraphState.MONOGRAPH;
		/// <summary>
		/// List of all available/active syllables.
		/// </summary>
		private List<string> AvailableSyllables = [];
		/// <summary>
		/// Default syllables used by every gamemodel.
		/// </summary>
		public static readonly List<string> DefaultSyllables = [
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

		public int AvailableSyllablesCount { get { return AvailableSyllables.Count; } }

		public SettingsController() {
			StateGraphPair = new Dictionary<GraphState, GraphModel>() {
				{ GraphState.MONOGRAPH,           new MonographModel(this)          },
				{ GraphState.DIGRAPH,             new DigraphModel(this)            },
				{ GraphState.DIACRITIC_MONOGRAPG, new DiacriticMonographModel(this) },
				{ GraphState.DIACRITIC_DIGRAPH,   new DiacriticDigraphModel(this)   },
			};
			SetGuesses();
		}

		/// <summary>
		/// Adds gamemodel to notify if list of available syllables has changed.
		/// </summary>
		/// <param name="model">Concrete gamemodel to notify.</param>
		public void AddGame(GameModel model) {
			GameModels.Add(model);
			model.RemainingSyllables = new(AvailableSyllables);
			model.Reset();
		}

		/// <summary>
		/// Gets current concrete graph model set.
		/// </summary>
		/// <returns>Current graph model.</returns>
		public GraphModel GetCurrentGraph() {
			return StateGraphPair[CurrentGraphState];
		}

		/// <summary>
		/// Sets next current graph based on syllable count (MONOGRAPH to DIGRAPH and vice versa)
		/// </summary>
		public void NextGraph() {
			CurrentGraphState = (GraphState)(((int)CurrentGraphState ^ 0b01) & ~0b10);
		}

		/// <summary>
		/// Sets next current graph based on diacritic (NON-DIACRITIC MONO/DIGRAPH to DIACRITIC and vice versa)
		/// </summary>
		public void NextDiacritic() {
			CurrentGraphState = (GraphState)((int)CurrentGraphState ^ 0b10);
		}

		/// <summary>
		/// Clears AvailableSyllables and adds new active guesses.
		/// </summary>
		private void SetGuesses() {
			AvailableSyllables.Clear();

			foreach (GraphModel model in StateGraphPair.Values) {
				foreach (string kana in model.Guesses) {
					AvailableSyllables.Add(kana);
				}
			}
		}

		/// <summary>
		/// Resets AvailableSyllables and notifies all subscribed gamemodels that AvailableSyllables have changed by resetting them.
		/// </summary>
		public void Notify() {
			SetGuesses();
			foreach (GameModel m in GameModels) {
				m.RemainingSyllables = new(AvailableSyllables);
				m.Reset();
			}
		}
	}
}
