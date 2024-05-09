using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace hiravrt.Models.Game {
	public class EitherOrModel(LookUp lookUp) : GameModel(lookUp, 2) {
		public string[] Guesses { get; set; } = new string[2];
		public int CorrectIndex { get; set; } = default;

		public override bool IsCorrect(string syllable) {
			return CurrentGuess.Equals(syllable);
		}

		protected override void NextGuess() {
			Random random = new();
			RemainingGuesses.Remove(Guesses[1 - CorrectIndex]);

			Guesses[CorrectIndex] = RemainingGuesses[random.Next(RemainingGuesses.Count)];
			RemainingGuesses.Add(Guesses[1 - CorrectIndex]);

			CorrectIndex = random.Next(Guesses.Length);
			CurrentGuess = Guesses[CorrectIndex];
		}

		public override void NextMove(string syllable) {
			if (IsCorrect(syllable)) {
				CorrectGuesses.Add(syllable);
				Score += LookUp.Points(syllable);
			} else {
				WrongGuesses.Add(syllable);
			}

			NextGuess();
		}

		protected override void FirstGuess() {
			if (RemainingGuesses.Count < MinGuessCount) return;

			Random random = new();
			int size = RemainingGuesses.Count;

			int i = random.Next(size);
			Guesses[0] = RemainingGuesses[i];
			RemainingGuesses.RemoveAt(i);

			Guesses[1] = RemainingGuesses[random.Next(--size)];
			RemainingGuesses.Add(Guesses[0]);

			CorrectIndex = random.Next(Guesses.Length);
            CurrentGuess = Guesses[CorrectIndex];
		}
	}
}
