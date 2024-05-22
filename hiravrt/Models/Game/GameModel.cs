using hiravrt.Models.Nav.Graphs;using Microsoft.AspNetCore.Mvc;using System.Text;using System.Text.Json.Nodes;using System.Text.Json.Serialization;namespace hiravrt.Models.Game {	public abstract class GameModel {		/// <summary>
		/// Minimum syllable count required to play the game mode.
		/// </summary>		public int MinimumGuessesCount { get; set; } = default;		public string CorrectSyllable { get; set; } = "";		public List<string> RemainingSyllables { get; set; }		public List<string> CorrectGuesses { get; set; } = [];		public List<string> WrongGuesses { get; set; } = [];		public GameModel(int minGuessCount) {			this.RemainingSyllables = [					"\u3042", "\u3044", "\u3046", "\u3048", "\u304a",					"\u304b", "\u304d", "\u304f", "\u3051", "\u3053",					"\u3055", "\u3057", "\u3059", "\u305b", "\u305d",					"\u305f", "\u3061", "\u3064", "\u3066", "\u3068",					"\u306a", "\u306b", "\u306c", "\u306d", "\u306e",					"\u306f", "\u3072", "\u3075", "\u3078", "\u307b",					"\u307e", "\u307f", "\u3080", "\u3081", "\u3082",					"\u3084",           "\u3086",           "\u3088",					"\u3089", "\u308a", "\u308b", "\u308c", "\u308d",					"\u308f",                               "\u3092",			"\u3093",			];			this.MinimumGuessesCount = minGuessCount;						InitialMove();		}		/// <summary>
		/// Sets the initial state of game mode.
		/// </summary>		protected abstract void InitialMove();		/// <summary>
		/// Updates game mode guesses to next guesses.
		/// </summary>		protected abstract void UpdateGuess();		/// <summary>
		/// Evaluates syllable and initializes next guesses.
		/// </summary>
		/// <param name="syllable">Syllable to evaluate.</param>		public abstract void NextMove(string syllable);
		/// <summary>
		/// Evaluates if syllable parameter is equal to CorrectSyllable.
		/// </summary>
		/// <param name="syllable">Syllable to evaluate.</param>
		/// <returns></returns>		public abstract bool IsCorrect(string syllable);		/// <summary>
		/// Resets game model to initial state.
		/// </summary>		public virtual void Reset() {			CorrectSyllable = "";			CorrectGuesses.Clear();			WrongGuesses.Clear();			InitialMove();		}	}}