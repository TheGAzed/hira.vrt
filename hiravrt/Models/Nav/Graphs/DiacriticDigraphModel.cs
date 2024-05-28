using hiravrt.Controllers.Nav;

namespace hiravrt.Models.Nav.Graphs
{
    public class DiacriticDigraphModel(SettingsController controller) : GraphModel(5, 3, controller) {
		protected override Graph[,] SetGraphs() {
			return new Graph[,] {
				{ new(ToggleState.OFF,   "\u304E\u3083"), new(ToggleState.OFF,   "\u304E\u3085"), new(ToggleState.OFF,   "\u304E\u3087") },
				{ new(ToggleState.OFF,   "\u3058\u3083"), new(ToggleState.OFF,   "\u3058\u3085"), new(ToggleState.OFF,   "\u3058\u3087") },
				{ new(ToggleState.OFF,   "\u3062\u3083"), new(ToggleState.OFF,   "\u3062\u3085"), new(ToggleState.OFF,   "\u3062\u3087") },
				{ new(ToggleState.OFF,   "\u3073\u3083"), new(ToggleState.OFF,   "\u3073\u3085"), new(ToggleState.OFF,   "\u3073\u3087") },
				{ new(ToggleState.OFF,   "\u3074\u3083"), new(ToggleState.OFF,   "\u3074\u3085"), new(ToggleState.OFF,   "\u3074\u3087") },
			};
		}
	}
}
