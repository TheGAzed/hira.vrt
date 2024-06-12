using System.Linq;
using System.Text;
using static System.Formats.Asn1.AsnWriter;

namespace hiravrt.Models.Game {
	public class KeyboardModel(LookUp lookUp) : GameModel(1) {
		private StringBuilder GuessLatin = new StringBuilder();
		private string CorrectSyllableGrid = "";

		public override bool IsCorrect(string syllable) {
			return CorrectSyllableGrid.CompareTo(GuessLatin.ToString() + syllable) == 0;
		}

		public bool IsValid(string syllable) {
			return CorrectSyllableGrid.StartsWith(GuessLatin.ToString() + syllable);
		}

		public override void NextMove(string syllable) {
			if (!IsValid(syllable)) {
				WrongGuessesCount++;
			} else if (IsCorrect(syllable)) {
				CorrectGuessesCount++;
			} else {
				GuessLatin.Append(syllable);
				return;
			}

			GuessLatin.Clear();
			UpdateGuess();
		}

		protected override void InitialMove() {
			if (RemainingSyllables.Count < MinimumGuessesCount) { return; }

			int i = new Random().Next(RemainingSyllables.Count);
			CorrectSyllable = RemainingSyllables[i];
			CorrectSyllableGrid = lookUp.Grid(CorrectSyllable);
		}

		protected override void UpdateGuess() {
			int i = new Random().Next(RemainingSyllables.Count);
			CorrectSyllable = RemainingSyllables[i];
			CorrectSyllableGrid = lookUp.Grid(CorrectSyllable);
		}

		public override void Reset() {
			GuessLatin.Clear();
			CorrectSyllableGrid = "";
			base.Reset();
		}
	}
}