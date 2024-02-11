using hiravrt.Controllers;
using hiravrt.Models.Game;
using Microsoft.AspNetCore.Mvc;

namespace hiravrt.Models.Settings.Graphs
{
	public enum ToggleState : int
	{
		ON = 1,
		OFF = -1,
		UNSET = 0,
	}

	public struct Graph(ToggleState toggle, string kana)
	{
		public ToggleState Toggle { get; set; } = toggle;
		public string Kana { get; } = kana;
	}

	public abstract class GraphModel {
		private SettingsController Controller;
		public List<string> Guesses { get; set; }
		public Graph[,] Graphs { get; set; }
		public int Rows { get; }
		public int Columns { get; }
		public ToggleState[] RowToggle { get; set; } = [];
		public ToggleState[] ColToggle { get; set; } = [];

		public GraphModel(int rows, int columns, SettingsController controller)
		{
			Controller = controller;

			Rows = rows;
			Columns = columns;

			RowToggle = SetRowToggle(rows);
			ColToggle = SetColToggle(columns);

			Graphs = SetGraphs(rows, columns);
			Guesses = SetGuesses(rows * columns);
		}

		abstract protected Graph[,] SetGraphs(int rows, int columns);
		abstract protected List<string> SetGuesses(int size);
		abstract protected ToggleState[] SetRowToggle(int rows);
		abstract protected ToggleState[] SetColToggle(int columns);

		public void ToggleRow(int row) {
			if (row < 0 || row >= Rows) return;
			if (RowToggle[row] == 0) return;

			RowToggle[row] = (ToggleState)(-(int)RowToggle[row]);

			ToggleState toggle = RowToggle[row];
			for (int col = 0; col < Columns; col++)
			{
				if (Graphs[row, col].Toggle == 0) continue;
				if (Graphs[row, col].Toggle != toggle)
				{
					Toggle(row, col);
					ColToggleState(col);
				}
			}
			NotifyController();
		}

		public void ToggleColumn(int col) {
			if (col < 0 || col >= Columns) return;
			if (ColToggle[col] == 0) return;

			ColToggle[col] = (ToggleState)(-(int)ColToggle[col]);

			ToggleState toggle = ColToggle[col];
			for (int row = 0; row < Rows; row++)
			{
				if (Graphs[row, col].Toggle == 0) continue;
				if (Graphs[row, col].Toggle != toggle)
				{
					Toggle(row, col);
					RowToggleState(row);
				}
			}
			NotifyController();
		}

		public void ToggleAt(int row, int col)
		{
			if (row < 0 || row >= Rows) return;
			if (col < 0 || col >= Columns) return;
			if (Graphs[row, col].Toggle == 0) return;

			Toggle(row, col);

			RowToggleState(row);
			ColToggleState(col);

			NotifyController();
		}

		private void RowToggleState(int row)
		{
			int Sum = 0, Count = 0;
			for (int c = 0; c < Columns; c++)
			{
				Sum += (int)Graphs[row, c].Toggle;
				Count += Math.Abs((int)Graphs[row, c].Toggle);
			}

			if (Math.Abs(Sum) != Count) return;

			if (Sum < 0) RowToggle[row] = ToggleState.OFF;
			else RowToggle[row] = ToggleState.ON;
		}

		private void ColToggleState(int column) {
			int Sum = 0, Count = 0;
			for (int r = 0; r < Rows; r++) {
				Sum += (int)Graphs[r, column].Toggle;
				Count += Math.Abs((int)Graphs[r, column].Toggle);
			}

			if (Math.Abs(Sum) != Count) return;

			if (Sum < 0) ColToggle[column] = ToggleState.OFF;
			else ColToggle[column] = ToggleState.ON;
		}

		private void Toggle(int row, int col) {
			Graphs[row, col].Toggle = (ToggleState)(-(int)Graphs[row, col].Toggle);

			string temp = Graphs[row, col].Kana;
			if (Graphs[row, col].Toggle == ToggleState.ON) Guesses.Add(temp);
			else Guesses.Remove(temp);
		}

		private void NotifyController()
		{
			Controller.Notify();
		}
	}
}
