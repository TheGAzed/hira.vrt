using hiravrt.Controllers.Nav;

namespace hiravrt.Models.Nav.Graphs
{
    public class MonographModel(SettingsController controller) : GraphModel(11, 6, controller) {
		protected override void ConsonantsToggleState() {
			IEnumerable<ToggleState> distinct = RowToggle.Skip(1).Distinct();

			if (distinct.Count() == 1) {
				ConsonantsToggle = distinct.First();
			}
		}

		protected override ToggleState[] SetColToggle(int columns) {
			return Enumerable.Repeat(ToggleState.ON, columns).ToArray();
		}

		protected override Graph[,] SetGraphs(int rows, int columns) {
			return new Graph[,] {
				{ new(ToggleState.UNSET, ""),    new(ToggleState.ON, "\u3042"), new(ToggleState.ON, "\u3044"), new(ToggleState.ON, "\u3046"), new(ToggleState.ON, "\u3048"), new(ToggleState.ON, "\u304a"), },
				{ new(ToggleState.UNSET, ""),    new(ToggleState.ON, "\u304b"), new(ToggleState.ON, "\u304d"), new(ToggleState.ON, "\u304f"), new(ToggleState.ON, "\u3051"), new(ToggleState.ON, "\u3053"), },
				{ new(ToggleState.UNSET, ""),    new(ToggleState.ON, "\u3055"), new(ToggleState.ON, "\u3057"), new(ToggleState.ON, "\u3059"), new(ToggleState.ON, "\u305b"), new(ToggleState.ON, "\u305d"), },
				{ new(ToggleState.UNSET, ""),    new(ToggleState.ON, "\u305f"), new(ToggleState.ON, "\u3061"), new(ToggleState.ON, "\u3064"), new(ToggleState.ON, "\u3066"), new(ToggleState.ON, "\u3068"), },
				{ new(ToggleState.UNSET, ""),    new(ToggleState.ON, "\u306a"), new(ToggleState.ON, "\u306b"), new(ToggleState.ON, "\u306c"), new(ToggleState.ON, "\u306d"), new(ToggleState.ON, "\u306e"), },
				{ new(ToggleState.UNSET, ""),    new(ToggleState.ON, "\u306f"), new(ToggleState.ON, "\u3072"), new(ToggleState.ON, "\u3075"), new(ToggleState.ON, "\u3078"), new(ToggleState.ON, "\u307b"), },
				{ new(ToggleState.UNSET, ""),    new(ToggleState.ON, "\u307e"), new(ToggleState.ON, "\u307f"), new(ToggleState.ON, "\u3080"), new(ToggleState.ON, "\u3081"), new(ToggleState.ON, "\u3082"), },
				{ new(ToggleState.UNSET, ""),    new(ToggleState.ON, "\u3084"), new(ToggleState.UNSET, ""),    new(ToggleState.ON, "\u3086"), new(ToggleState.UNSET, ""),    new(ToggleState.ON, "\u3088"), },
				{ new(ToggleState.UNSET, ""),    new(ToggleState.ON, "\u3089"), new(ToggleState.ON, "\u308a"), new(ToggleState.ON, "\u308b"), new(ToggleState.ON, "\u308c"), new(ToggleState.ON, "\u308d"), },
				{ new(ToggleState.UNSET, ""),    new(ToggleState.ON, "\u308f"), new(ToggleState.OFF,"\u3090"), new(ToggleState.UNSET, ""),    new(ToggleState.OFF,"\u3091"), new(ToggleState.ON, "\u3092"), },
				{ new(ToggleState.ON, "\u3093"), new(ToggleState.UNSET, ""),    new(ToggleState.UNSET, ""),    new(ToggleState.UNSET, ""),    new(ToggleState.UNSET, ""),   new(ToggleState.UNSET, ""),    },
			};
		}

		protected override List<string> SetInitialGuesses(int size) {
			return new List<string>(size) {
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
			};
		}

		protected override ToggleState[] SetRowToggle(int rows) {
			return Enumerable.Repeat(ToggleState.ON, rows).ToArray();
		}
	}
}
