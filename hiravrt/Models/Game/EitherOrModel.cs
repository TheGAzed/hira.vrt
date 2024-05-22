using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace hiravrt.Models.Game {
	public class EitherOrModel() : GameModel(2) {
		public string[] Guesses { get; set; } = new string[2];
		public int CorrectIndex { get; set; } = default;

		public override bool IsCorrect(string syllable) {
			return CorrectSyllable.Equals(syllable);
		}

		protected override void UpdateGuess() {
			Random random = new();
			RemainingSyllables.Remove(Guesses[1 - CorrectIndex]);

			Guesses[CorrectIndex] = RemainingSyllables[random.Next(RemainingSyllables.Count)];
			RemainingSyllables.Add(Guesses[1 - CorrectIndex]);

			CorrectIndex = random.Next(Guesses.Length);
			CorrectSyllable = Guesses[CorrectIndex];
		}

		public override void NextMove(string syllable) {
			if (IsCorrect(syllable)) {
				CorrectGuesses.Add(syllable);
			} else {
				WrongGuesses.Add(syllable);
			}

			UpdateGuess();
		}

		protected override void InitialMove() {
			if (RemainingSyllables.Count < MinimumGuessesCount) return;

			Random random = new();
			int size = RemainingSyllables.Count;

			int i = random.Next(size);
			Guesses[0] = RemainingSyllables[i];
			RemainingSyllables.RemoveAt(i);

			Guesses[1] = RemainingSyllables[random.Next(--size)];
			RemainingSyllables.Add(Guesses[0]);

			CorrectIndex = random.Next(Guesses.Length);
            CorrectSyllable = Guesses[CorrectIndex];
		}
	}
}
