using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace hiravrt.Models.Game {
	public class EitherOrModel() : GameModel(2) {
		/// <summary>
		/// Current guesses pair where one random is the correct and the other a wrong guess.
		/// </summary>
		public string[] GuessesPair { get; set; } = new string[2];
		/// <summary>
		/// Index of correct guess in GuessesPair
		/// </summary>
		public int CorrectIndex { get; set; } = default;

		public override bool IsCorrect(string syllable) {
			return CorrectSyllable.Equals(syllable);
		}

		protected override void UpdateGuess() {
			Random random = new();
			RemainingSyllables.Remove(GuessesPair[1 - CorrectIndex]);

			if (RemainingSyllables.Count > MinimumGuessesCount && RemainingSyllables.Contains(CorrectSyllable)) {
				RemainingSyllables.Remove(CorrectSyllable);
				GuessesPair[CorrectIndex] = RemainingSyllables[random.Next(RemainingSyllables.Count)];
				RemainingSyllables.Add(CorrectSyllable);
			} else {
				GuessesPair[CorrectIndex] = RemainingSyllables[random.Next(RemainingSyllables.Count)];
			}

			RemainingSyllables.Add(GuessesPair[1 - CorrectIndex]);

			CorrectIndex = random.Next(GuessesPair.Length);
			CorrectSyllable = GuessesPair[CorrectIndex];
		}

		public override void NextMove(string syllable) {
			if (IsCorrect(syllable)) {
				CorrectGuessesCount++;
			} else {
				WrongGuessesCount++;
			}

			UpdateGuess();
		}

		protected override void InitialMove() {
			if (RemainingSyllables.Count < MinimumGuessesCount) return;

			Random random = new();
			int size = RemainingSyllables.Count;

			int i = random.Next(size);
			GuessesPair[0] = RemainingSyllables[i];
			RemainingSyllables.RemoveAt(i);

			GuessesPair[1] = RemainingSyllables[random.Next(--size)];
			RemainingSyllables.Add(GuessesPair[0]);

			CorrectIndex = random.Next(GuessesPair.Length);
            CorrectSyllable = GuessesPair[CorrectIndex];
		}
	}
}
