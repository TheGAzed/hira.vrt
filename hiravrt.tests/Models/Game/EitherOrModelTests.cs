using hiravrt.Models.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hiravrt.tests.Models.Game {
	class EitherOrModelTests {
		private EitherOrModel model;

		[SetUp]
		public void SetUp() {
			model = new(new());
		}

		[Test]
		public void EitherGuessIsCorrect_Test() {
            Assert.That(model.Guesses[0].Equals(model.CurrentGuess) || model.Guesses[1].Equals(model.CurrentGuess));
		}
		[Test]
		public void CorrectIndex_Test() {
			Assert.That(model.Guesses[model.CorrectIndex], Is.EqualTo(model.CurrentGuess));
		}
		[Test]
		public void IsCorrect_CurrentGuessTrue_Test() {
			Assert.That(model.IsCorrect(model.CurrentGuess));
		}
		[Test]
		public void IsCorrect_CorrectIndexTrue_Test() {
            Assert.That(model.IsCorrect(model.Guesses[model.CorrectIndex]), Is.True);
		}
		[Test]
		public void IsCorrect_WrongIndexFalse_Test() {
			Assert.That(model.IsCorrect(model.Guesses[1 - model.CorrectIndex]), Is.False);
		}
		[Test]
		public void NextMove_CheckChangeOnlyOneNextGuess_Test() {
			string a = model.Guesses[0];
			string b = model.Guesses[1];

			model.NextMove(model.CurrentGuess);

			Assert.That((a == model.Guesses[0]), Is.Not.EqualTo((b == model.Guesses[1])));
		}
		[Test]
		public void NextMove_CorrectGuessesListSizeIncreaseOnCorrect_Test() {
			int list_length = model.CorrectGuesses.Count;
			model.NextMove(model.Guesses[model.CorrectIndex]);

			Assert.That(list_length + 1, Is.EqualTo(model.CorrectGuesses.Count));
		}
		[Test]
		public void NextMove_CorrectGuessesListLastElementIsPreviousCorrectGuess_Test() {
			string last_correct = model.Guesses[model.CorrectIndex];
			
			model.NextMove(model.Guesses[model.CorrectIndex]);

			Assert.That(last_correct, Is.EqualTo(model.CorrectGuesses.Last()));
		}
		[Test]
		public void NextMove_WrongGuessesListSizeIncreaseOnIncorrect_Test() {
			int list_length = model.WrongGuesses.Count;
			model.NextMove(model.Guesses[1 - model.CorrectIndex]);

            Assert.That(list_length + 1, Is.EqualTo(model.WrongGuesses.Count));
        }
        [Test]
        public void NextMove_WrongGuessesListLastElementIsPreviousWrongGuess_Test() {
            string last_wrong = model.Guesses[1 - model.CorrectIndex];

            model.NextMove(model.Guesses[1 - model.CorrectIndex]);

            Assert.That(last_wrong, Is.EqualTo(model.WrongGuesses.Last()));
        }
    }
}
