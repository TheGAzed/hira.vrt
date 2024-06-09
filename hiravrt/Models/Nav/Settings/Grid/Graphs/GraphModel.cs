using hiravrt.Controllers.Nav;
using hiravrt.Models.Game;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace hiravrt.Models.Nav.Settings.Grid.Graphs
{
    /// <summary>
    /// Settings toggle states enum for rows, columns and sallables.
    /// </summary>
    public enum ToggleState : int
    {
        ON = 1,
        OFF = -1,
        UNSET = 0,
    }

    public struct Graph(ToggleState toggle, string kana)
    {
        /// <summary>
        /// Toggle state.
        /// </summary>
        public ToggleState Toggle { get; set; } = toggle;
        /// <summary>
        /// Kana syllable string.
        /// </summary>
        public string Kana { get; } = kana;
    }

    public abstract class GraphModel
    {
        /// <summary>
        /// Observer of all graph models.
        /// </summary>
        private readonly SettingsController Controller;
        /// <summary>
        /// List of all currenty active (ToggleState.ON) kana syllables.
        /// </summary>
        public List<string> Guesses { get; set; }
        /// <summary>
        /// Grid of toggle states mapping to kana syllables.
        /// </summary>
        public Graph[,] Graphs { get; set; }
        /// <summary>
        /// Number of rows in this.Graphs grid.
        /// </summary>
        public int Rows { get; }
        /// <summary>
        /// Number of columns in this.Graphs grid.
        /// </summary>
        public int Columns { get; }
        /// <summary>
        /// Row toggle states array of grid.
        /// </summary>
        public ToggleState[] RowToggle { get; set; } = [];
        /// <summary>
        /// Column toggle states array of grid.
        /// </summary>
        public ToggleState[] ColToggle { get; set; } = [];
        /// <summary>
        /// Consonants toggle states variable.
        /// </summary>
        public ToggleState ConsonantsToggle { get; set; }
        /// <summary>
        /// Vowels (only used by MonographModel) toggle states variable.
        /// </summary>
        public ToggleState VowelToggle { get; set; } = ToggleState.UNSET;

        public GraphModel(int rows, int columns, SettingsController controller)
        {
            Controller = controller;

            Rows = rows;
            Columns = columns;

            RowToggle = SetRowToggle();
            ColToggle = SetColToggle();

            Graphs = SetGraphs();
            Guesses = SetInitialGuesses();

            ConsonantsToggleState();
            VowelToggleState();
        }

        /// <summary>
        /// Sets the graph of all kana characters in graphs.
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        abstract protected Graph[,] SetGraphs();
        protected virtual List<string> SetInitialGuesses()
        {
            return [];
        }

        protected virtual ToggleState[] SetRowToggle()
        {
            return Enumerable.Repeat(ToggleState.OFF, Rows).ToArray();
        }

        protected virtual ToggleState[] SetColToggle()
        {
            return Enumerable.Repeat(ToggleState.OFF, Columns).ToArray();
        }

        protected void RowToggleState(int row)
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

        protected void ColToggleState(int column)
        {
            int Sum = 0, Count = 0;
            for (int r = 0; r < Rows; r++)
            {
                Sum += (int)Graphs[r, column].Toggle;
                Count += Math.Abs((int)Graphs[r, column].Toggle);
            }

            if (Math.Abs(Sum) != Count) return;

            if (Sum < 0) ColToggle[column] = ToggleState.OFF;
            else ColToggle[column] = ToggleState.ON;
        }

        protected virtual void ConsonantsToggleState()
        {
            IEnumerable<ToggleState> distinct = RowToggle.Distinct();

            if (distinct.Count() == 1)
            {
                ConsonantsToggle = distinct.First();
            }
        }

        protected virtual void VowelToggleState()
        {

        }

        protected void Toggle(int row, int col)
        {
            if (Graphs[row, col].Toggle == ToggleState.UNSET) return;

            Graphs[row, col].Toggle = (ToggleState)(-(int)Graphs[row, col].Toggle);

            string temp = Graphs[row, col].Kana;
            if (Graphs[row, col].Toggle == ToggleState.ON) Guesses.Add(temp);
            else Guesses.Remove(temp);
        }

        protected void NotifySettingsController()
        {
            Controller.Notify();
        }

        public void ToggleRow(int row)
        {
            if (row < 0 || row >= Rows) throw new ArgumentException("Row value " + row + " is out of bounds");

            if (RowToggle[row] == ToggleState.UNSET) return;

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

            VowelToggleState();
            ConsonantsToggleState();
            NotifySettingsController();
        }

        public void ToggleColumn(int col)
        {
            if (col < 0 || col >= Columns) throw new ArgumentException("Column value " + col + " is out of bounds");

            if (ColToggle[col] == ToggleState.UNSET) return;

            ColToggle[col] = (ToggleState)(-(int)ColToggle[col]);

            ToggleState toggle = ColToggle[col];
            for (int row = 0; row < Rows; row++)
            {
                if (Graphs[row, col].Toggle == ToggleState.UNSET) continue;
                if (Graphs[row, col].Toggle != toggle)
                {
                    Toggle(row, col);
                    RowToggleState(row);
                }
            }

            VowelToggleState();
            ConsonantsToggleState();
            NotifySettingsController();
        }

        public void ToggleAt(int row, int col)
        {
            if (row < 0 || row >= Rows) throw new ArgumentException("Row value " + row + " is out of bounds");
            if (col < 0 || col >= Columns) throw new ArgumentException("Column value " + col + " is out of bounds");

            if (Graphs[row, col].Toggle == ToggleState.UNSET) return;

            Toggle(row, col);

            RowToggleState(row);
            ColToggleState(col);

            VowelToggleState();
            ConsonantsToggleState();

            NotifySettingsController();
        }

        public virtual void ToggleVowels()
        {
            VowelToggleState();
        }

        public virtual void ToggleConsonants()
        {
            ConsonantsToggle = (ToggleState)(-(int)ConsonantsToggle);

            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Columns; c++)
                {
                    if (Graphs[r, c].Toggle != ConsonantsToggle) Toggle(r, c);
                }
            }

            for (int r = 0; r < Rows; r++) RowToggleState(r);
            for (int c = 0; c < Columns; c++) ColToggleState(c);

            VowelToggleState();
            NotifySettingsController();
        }
    }
}
