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
			model = new();
		}

		[Test]
		public void EitherGuessIsCorrect_Test() {
            Assert.That(model.GuessesPair[0].Equals(model.CorrectSyllable) || model.GuessesPair[1].Equals(model.CorrectSyllable));
		}

		[Test]
		public void CorrectIndex_Test() {
			Assert.That(model.GuessesPair[model.CorrectIndex], Is.EqualTo(model.CorrectSyllable));
		}

		[Test]
		public void IsCorrect_CurrentGuessTrue_Test() {
			Assert.That(model.IsCorrect(model.CorrectSyllable));
		}

		[Test]
		public void IsCorrect_CorrectIndexTrue_Test() {
            Assert.That(model.IsCorrect(model.GuessesPair[model.CorrectIndex]), Is.True);
		}

		[Test]
		public void IsCorrect_WrongIndexFalse_Test() {
			Assert.That(model.IsCorrect(model.GuessesPair[1 - model.CorrectIndex]), Is.False);
		}

		[Test]
		public void NextMove_CorrectGuessesListSizeIncreaseOnCorrect_Test() {
			int list_length = model.CorrectGuessesCount;
			model.NextMove(model.GuessesPair[model.CorrectIndex]);

			Assert.That(list_length + 1, Is.EqualTo(model.CorrectGuessesCount));
		}

		[Test]
		public void NextMove_WrongGuessesListSizeIncreaseOnIncorrect_Test() {
			int list_length = model.WrongGuessesCount;
			model.NextMove(model.GuessesPair[1 - model.CorrectIndex]);

            Assert.That(list_length + 1, Is.EqualTo(model.WrongGuessesCount));
        }
    }
}
