using hiravrt.Controllers.Nav;

namespace hiravrt.Models.Nav.Graphs
{
    public class DiacriticMonographModel(SettingsController controller) : GraphModel(5, 5, controller) {
		protected override Graph[,] SetGraphs() {
			return new Graph[,] {
				
				{ new(ToggleState.OFF, "\u304C"), new(ToggleState.OFF, "\u304E"), new(ToggleState.OFF, "\u3050"), new(ToggleState.OFF, "\u3052"), new(ToggleState.OFF, "\u3054"), },
				{ new(ToggleState.OFF, "\u3056"), new(ToggleState.OFF, "\u3058"), new(ToggleState.OFF, "\u305A"), new(ToggleState.OFF, "\u305C"), new(ToggleState.OFF, "\u305E"), },
				{ new(ToggleState.OFF, "\u3060"), new(ToggleState.OFF, "\u3062"), new(ToggleState.OFF, "\u3065"), new(ToggleState.OFF, "\u3067"), new(ToggleState.OFF, "\u3069"), },
				{ new(ToggleState.OFF, "\u3070"), new(ToggleState.OFF, "\u3073"), new(ToggleState.OFF, "\u3076"), new(ToggleState.OFF, "\u3079"), new(ToggleState.OFF, "\u307C"), },
				{ new(ToggleState.OFF, "\u3071"), new(ToggleState.OFF, "\u3074"), new(ToggleState.OFF, "\u3077"), new(ToggleState.OFF, "\u307A"), new(ToggleState.OFF, "\u307D"), },
			};
		}
	}
}
