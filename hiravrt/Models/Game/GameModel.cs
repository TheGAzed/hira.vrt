using hiravrt.Controllers.Nav;
using hiravrt.Models.Nav.Graphs;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace hiravrt.Models.Game {
	public abstract class GameModel {
		/// <summary>
		/// Minimum syllable count required to play the game mode.
		/// </summary>
		public int MinimumGuessesCount { get; set; } = default;
		/// <summary>
		/// Correct syllable in gamemode.
		/// </summary>
		public string CorrectSyllable { get; set; } = "";
		/// <summary>
		/// List of remaining syllables that are randomly picked every turn.
		/// </summary>
		public List<string> RemainingSyllables { get; set; }
		/// <summary>
		/// Count of all wrongly guessed syllables throughout the game.
		/// </summary>
		public int WrongGuessesCount = default;
		/// <summary>
		/// Count of all correctly guessed syllables throughout the game.
		/// </summary>
		public int CorrectGuessesCount = default;

		public GameModel(int MinimumGuessesCount) {
			this.RemainingSyllables  = SettingsController.DefaultSyllables;
			this.MinimumGuessesCount = MinimumGuessesCount;
			
			InitialMove();
		}

		/// <summary>
		/// Sets the initial state of game mode.
		/// </summary>
		protected abstract void InitialMove();
		/// <summary>
		/// Updates game mode guesses to next guesses.
		/// </summary>
		protected abstract void UpdateGuess();
		/// <summary>
		/// Evaluates syllable and initializes next guesses.
		/// </summary>
		/// <param name="syllable">Syllable to evaluate.</param>
		public abstract void NextMove(string syllable);
		/// <summary>
		/// Evaluates if syllable parameter is equal to CorrectSyllable.
		/// </summary>
		/// <param name="syllable">Syllable to evaluate.</param>
		/// <returns></returns>
		public abstract bool IsCorrect(string syllable);
		/// <summary>
		/// Resets game model to initial state.
		/// </summary>
		public virtual void Reset() {
			CorrectSyllable = "";
			CorrectGuessesCount = default;
			WrongGuessesCount = default;

			InitialMove();
		}
	}
}
