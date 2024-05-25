﻿using hiravrt.Controllers.Nav;

namespace hiravrt.Models.Nav.Graphs
{
    public class DigraphModel(SettingsController controller) : GraphModel(7, 3, controller) {
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
				{ new(ToggleState.OFF, "\u304D\u3083"), new(ToggleState.OFF, "\u304D\u3085"), new(ToggleState.OFF, "\u304D\u3087") },
				{ new(ToggleState.OFF, "\u3057\u3083"), new(ToggleState.OFF, "\u3057\u3085"), new(ToggleState.OFF, "\u3057\u3087") },
				{ new(ToggleState.OFF, "\u3061\u3083"), new(ToggleState.OFF, "\u3061\u3085"), new(ToggleState.OFF, "\u3061\u3087") },
				{ new(ToggleState.OFF, "\u306B\u3083"), new(ToggleState.OFF, "\u306B\u3085"), new(ToggleState.OFF, "\u306B\u3087") },
				{ new(ToggleState.OFF, "\u3072\u3083"), new(ToggleState.OFF, "\u3072\u3085"), new(ToggleState.OFF, "\u3072\u3087") },
				{ new(ToggleState.OFF, "\u307F\u3083"), new(ToggleState.OFF, "\u307F\u3085"), new(ToggleState.OFF, "\u307F\u3087") },
				{ new(ToggleState.OFF, "\u308A\u3083"), new(ToggleState.OFF, "\u308A\u3085"), new(ToggleState.OFF, "\u308A\u3087") },
			};
		}

		protected override List<string> SetInitialGuesses(int size) {
			return [];
		}

		protected override ToggleState[] SetRowToggle(int rows) {
			return [
				ToggleState.OFF,
				ToggleState.OFF,
				ToggleState.OFF,
				ToggleState.OFF,
				ToggleState.OFF,
				ToggleState.OFF,
				ToggleState.OFF,
			];
		}
	}
}
