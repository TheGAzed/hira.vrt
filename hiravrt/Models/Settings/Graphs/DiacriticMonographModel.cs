using hiravrt.Controllers;

namespace hiravrt.Models.Settings.Graphs
{
	public class DiacriticMonographModel(SettingsController controller) : GraphModel(5, 5, controller) {
		protected override ToggleState[] SetColToggle(int columns) {
			return Enumerable
				.Repeat(ToggleState.OFF, columns)
				.ToArray();
		}

		protected override Graph[,] SetGraphs(int rows, int columns) {
			return new Graph[,] {
				
				{ new(ToggleState.OFF, "\u304C"), new(ToggleState.OFF, "\u304E"), new(ToggleState.OFF, "\u3050"), new(ToggleState.OFF, "\u3052"), new(ToggleState.OFF, "\u3054"), },
				{ new(ToggleState.OFF, "\u3056"), new(ToggleState.OFF, "\u3058"), new(ToggleState.OFF, "\u305A"), new(ToggleState.OFF, "\u305C"), new(ToggleState.OFF, "\u305E"), },
				{ new(ToggleState.OFF, "\u3060"), new(ToggleState.OFF, "\u3062"), new(ToggleState.OFF, "\u3065"), new(ToggleState.OFF, "\u3067"), new(ToggleState.OFF, "\u3069"), },
				{ new(ToggleState.OFF, "\u3070"), new(ToggleState.OFF, "\u3073"), new(ToggleState.OFF, "\u3076"), new(ToggleState.OFF, "\u3079"), new(ToggleState.OFF, "\u307C"), },
				{ new(ToggleState.OFF, "\u3071"), new(ToggleState.OFF, "\u3074"), new(ToggleState.OFF, "\u3077"), new(ToggleState.OFF, "\u307A"), new(ToggleState.OFF, "\u307D"), },
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
