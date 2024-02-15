using System.Linq;
using System.Text;

namespace hiravrt.Models.Game {
	public class KeyboardModel(LookUp lookUp) : GameModel(lookUp, 1) {
		private StringBuilder GuessLatin = new StringBuilder();
		private string CurrentGuessLatin = "";

		public override bool IsCorrect(string syllable) {
			return CurrentGuessLatin.CompareTo(GuessLatin.ToString() + syllable) == 0;
		}

		public bool IsValid(string syllable) {
			return CurrentGuessLatin.StartsWith(GuessLatin.ToString() + syllable);
		}

		public override void NextMove(string syllable) {
			if (!IsValid(syllable)) {
				WrongGuesses.Add(CurrentGuess);
			} else if (IsCorrect(syllable)) {
                CorrectGuesses.Add(CurrentGuess);
				Score += LookUp.Points(CurrentGuess);
			} else {
				GuessLatin.Append(syllable);
				return;
			}

			GuessLatin.Clear();
			NextGuess();
		}

		protected override void FirstGuess() {
			if (RemainingGuesses.Count < MinGuessCount) { return; }
			int i = new Random().Next(RemainingGuesses.Count);
			CurrentGuess = RemainingGuesses[i];
			CurrentGuessLatin = LookUp.Latin(CurrentGuess);
		}

		protected override void NextGuess() {
			string temp = CurrentGuess;
			FirstGuess();
		}

		public override void Reset() {
			GuessLatin.Clear();
			CurrentGuessLatin = "";
			base.Reset();
		}
	}
}
