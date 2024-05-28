using hiravrt.Models.Nav.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hiravrt.tests.Models.Nav.Graphs {
	class MonographModelTests {
		[Test]
		public void ToggleAtUNSETToggleStateUnchanged_Test() {
			MonographModel graph = new(new());
			graph.ToggleAt(0, 0);

			Assert.That(graph.Graphs[0, 0].Toggle, Is.EqualTo(ToggleState.UNSET));
		}

		[Test]
		public void DoubleToggleAtWholeGraphAllUnchanged_Test() {
			MonographModel graph = new(new());

			for (int r = 0; r < graph.Rows; r++) {
				for (int c = 0; c < graph.Columns; c++) {
					ToggleState state = graph.Graphs[r, c].Toggle;

					graph.ToggleAt(r, c);
					graph.ToggleAt(r, c);

					Assert.That(graph.Graphs[r, c].Toggle, Is.EqualTo(state));
				}
			}
		}

		[Test]
		public void CurrentVowelStateIsNotToggleStateUNSET_Test() {
			MonographModel graph = new(new());
			Assert.That(graph.VowelToggle, Is.Not.EqualTo(ToggleState.UNSET));
		}

		[Test]
		public void CurrentVowelStateChangeOnVowelToggle_Test() {
			MonographModel graph = new(new());

			ToggleState vowelState = graph.VowelToggle;
			graph.ToggleVowels();

			Assert.That(vowelState, Is.Not.EqualTo(graph.VowelToggle));
		}

		[Test]
		public void ToggleVowelFirstRowToggleElementEqualsVowelState_Test() {
			MonographModel graph = new(new());
			graph.ToggleVowels();

			Assert.That(graph.RowToggle[0], Is.EqualTo(graph.VowelToggle));
		}

		[Test]
		public void ToggleVowelFirstRowToggleElementChange_Test() {
			MonographModel graph = new(new());
			ToggleState firstRowState = graph.RowToggle[0];

			graph.ToggleVowels();
			Assert.That(firstRowState, Is.Not.EqualTo(graph.VowelToggle));
		}

		[Test]
		public void ToggleConsonantsAllButFirstRowEqualConsonantsState_Test() {
			MonographModel graph = new(new());

			graph.ToggleConsonants();

			Assert.That(graph.RowToggle.Skip(1).All(t => t == graph.ConsonantsToggle));
		}

		[Test]
		public void DobuleToggleConsonantsAllButFirstRowEqualConsonantsState_Test() {
			MonographModel graph = new(new());

			graph.ToggleConsonants();
			graph.ToggleConsonants();

			Assert.That(graph.RowToggle.Skip(1).All(t => t == graph.ConsonantsToggle));
		}

		[Test]
		public void DoubleConsonantsToggleAfterOneConsonatnToggledGuessesListCountUnchanged_Test() {
			MonographModel graph = new(new());

			graph.ToggleConsonants();
			graph.ToggleConsonants();

			int guessesCount = graph.Guesses.Count;

			graph.ToggleAt(1, 1);

			graph.ToggleConsonants();
			graph.ToggleConsonants();

			Assert.That(guessesCount, Is.EqualTo(graph.Guesses.Count));
		}

		[Test]
		public void DoubleConsonantsToggleAfterOneConsonatnToggledGuessesListCountUnchangedOpposite_Test() {
			MonographModel graph = new(new());

			graph.ToggleConsonants();

			int guessesCount = graph.Guesses.Count;

			graph.ToggleAt(1, 1);

			graph.ToggleConsonants();
			graph.ToggleConsonants();

			Assert.That(guessesCount, Is.EqualTo(graph.Guesses.Count));
		}

		[Test]
		public void ToggleColumnWholeColumnOneToggleState_Test() {
			MonographModel graph = new(new());

			for (int c = 0; c < graph.Columns; c++) {
				graph.ToggleColumn(c);

				for (int r = 0; r < graph.Rows; r++) {
					if (graph.Graphs[r, c].Toggle == ToggleState.UNSET) continue;

					Assert.That(graph.ColToggle[c], Is.EqualTo(graph.Graphs[r, c].Toggle));
				}
			}
		}

		[Test]
		public void DoubleToggleColumnWholeColumnOneToggleState_Test() {
			MonographModel graph = new(new());

			for (int c = 0; c < graph.Columns; c++) {
				graph.ToggleColumn(c);
				graph.ToggleColumn(c);

				for (int r = 0; r < graph.Rows; r++) {
					if (graph.Graphs[r, c].Toggle == ToggleState.UNSET) continue;

					Assert.That(graph.ColToggle[c], Is.EqualTo(graph.Graphs[r, c].Toggle));
				}
			}
		}

		[Test]
		public void ToggleRowWholeRowOneToggleState_Test() {
			MonographModel graph = new(new());

			for (int r = 0; r < graph.Rows; r++) {
				graph.ToggleRow(r);

				for (int c = 0; c < graph.Columns; c++) {
					if (graph.Graphs[r, c].Toggle == ToggleState.UNSET) continue;

					Assert.That(graph.RowToggle[r], Is.EqualTo(graph.Graphs[r, c].Toggle));
				}
			}
		}

		[Test]
		public void DoubleToggleRowWholeRowOneToggleState_Test() {
			MonographModel graph = new(new());

			for (int r = 0; r < graph.Rows; r++) {
				graph.ToggleRow(r);
				graph.ToggleRow(r);

				for (int c = 0; c < graph.Columns; c++) {
					if (graph.Graphs[r, c].Toggle == ToggleState.UNSET) continue;

					Assert.That(graph.RowToggle[r], Is.EqualTo(graph.Graphs[r, c].Toggle));
				}
			}
		}
	}
}
