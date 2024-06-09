using hiravrt.Controllers.Nav;
using hiravrt.Models.Nav.Settings.Grid.Graphs;

namespace hiravrt.Models.Nav.Settings.Grid {
	/// <summary>
	/// Graph states in settings razor section.
	/// </summary>
	public enum GraphState : int {
		MONOGRAPH = 0b00, // MONOGRAPHIC SYLLABLES ENUM
		DIGRAPH = 0b01, // DIGRAPHIC SYLLABLES ENUM
		DIACRITIC_MONOGRAPG = 0b10, // MONOGRAPHIC SYLLABLES WITH DIACRITICS ENUM
		DIACRITIC_DIGRAPH = 0b11, // DIGRAPHIC SYLLABLES WITH DIACRITICS ENUM
	}

	public class GridModel {
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

		/// <summary>
		/// List of all available/active syllables.
		/// </summary>
		public List<string> AvailableSyllables = [];
		private Queue<string> AvailableSyllablesQueue;
		public int AvailableSyllablesCount { get { return AvailableSyllables.Count; } }

		/// <summary>
		/// Returns current set graph in sesttings.
		/// </summary>
		public GraphState CurrentGraphState { get; set; } = GraphState.MONOGRAPH;
		private readonly Dictionary<GraphState, GraphModel> StateGraphPair;

		public GridModel(SettingsController controller) {
			StateGraphPair = new Dictionary<GraphState, GraphModel>() {
				{ GraphState.MONOGRAPH,           new MonographModel(controller)          },
				{ GraphState.DIGRAPH,             new DigraphModel(controller)            },
				{ GraphState.DIACRITIC_MONOGRAPG, new DiacriticMonographModel(controller) },
				{ GraphState.DIACRITIC_DIGRAPH,   new DiacriticDigraphModel(controller)   },
			};

			AvailableSyllablesQueue = new(AvailableSyllables);
			SetGuesses();
		}
		/// <summary>
		/// Clears AvailableSyllables and adds new active guesses.
		/// </summary>
		private void SetGuesses() {
			foreach (GraphModel model in StateGraphPair.Values) {
				foreach (string kana in model.Guesses) {
					AvailableSyllables.Add(kana);
				}
			}

			AvailableSyllablesQueue = new(AvailableSyllables);
		}

		public void ResetGuesses() {
			AvailableSyllables.Clear();
			SetGuesses();
		}
		public string ShiftGetAvailableSyllable() {
			string temp = AvailableSyllablesQueue.Dequeue();
			AvailableSyllablesQueue.Enqueue(temp);
			return temp;
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
	}
}
