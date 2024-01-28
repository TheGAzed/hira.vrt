using System.Linq;
using System.Text;

namespace hiravrt.Models.Game {
	public class KeyboardModel : GameModel {
		private StringBuilder GuessLatin = new StringBuilder();
		private string CurrentGuessLatin = "";

		public KeyboardModel(LookUp lookUp) : base(lookUp) {}

		public override bool IsCorrect(char syllable) {
			return CurrentGuessLatin.CompareTo(GuessLatin.ToString() + syllable) == 0;
		}

		public bool IsValid(char syllable) {
			return CurrentGuessLatin.StartsWith(GuessLatin.ToString() + syllable);
		}

		public override void NextMove(char syllable) {
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
			char temp = CurrentGuess;
			FirstGuess();
		}

		public override void Reset() {
			GuessLatin.Clear();
			CurrentGuessLatin = "";
			base.Reset();
		}

		protected override void SetMinGuessCount() {
			MinGuessCount = 1;
		}
	}
}
