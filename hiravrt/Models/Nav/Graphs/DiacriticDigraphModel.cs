using hiravrt.Controllers.Nav;

namespace hiravrt.Models.Nav.Graphs
{
    public class DiacriticDigraphModel(SettingsController controller) : GraphModel(5, 3, controller) {
		protected override void ConsonantsToggleState() {
			IEnumerable<ToggleState> distinct = RowToggle.Distinct();

			if (distinct.Count() == 1) {
				ConsonantsToggle = distinct.First();
			}
		}

		protected override ToggleState[] SetColToggle(int columns) {
			return Enumerable.Repeat(ToggleState.OFF, columns).ToArray();
		}

		protected override Graph[,] SetGraphs(int rows, int columns) {
			return new Graph[,] {
				{ new(ToggleState.OFF,   "\u304E\u3083"), new(ToggleState.OFF,   "\u304E\u3085"), new(ToggleState.OFF,   "\u304E\u3087") },
				{ new(ToggleState.OFF,   "\u3058\u3083"), new(ToggleState.OFF,   "\u3058\u3085"), new(ToggleState.OFF,   "\u3058\u3087") },
				{ new(ToggleState.OFF,   "\u3062\u3083"), new(ToggleState.OFF,   "\u3062\u3085"), new(ToggleState.OFF,   "\u3062\u3087") },
				{ new(ToggleState.OFF,   "\u3073\u3083"), new(ToggleState.OFF,   "\u3073\u3085"), new(ToggleState.OFF,   "\u3073\u3087") },
				{ new(ToggleState.OFF,   "\u3074\u3083"), new(ToggleState.OFF,   "\u3074\u3085"), new(ToggleState.OFF,   "\u3074\u3087") },
			};
		}

		protected override List<string> SetGuesses(int size) {
			return [];
		}

		protected override ToggleState[] SetRowToggle(int rows) {
			return [
				ToggleState.OFF,
				ToggleState.OFF,
				ToggleState.OFF,
				ToggleState.OFF,
				ToggleState.OFF,
			];
		}
	}
}
