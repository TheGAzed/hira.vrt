using hiravrt.Models.Game;

namespace hiravrt.Controllers {
	public class SettingsController {
		public string Settings() => "/settings";
		public List<GameModel> models = new List<GameModel>();
		public List<char> Guesses { get; }
		public int[,] HiraganaToggle { get; }
		public SettingsController() {
			Guesses = [
					'\u3042', '\u3044', '\u3046', '\u3048', '\u304a',
					'\u304b', '\u304d', '\u304f', '\u3051', '\u3053',
					'\u3055', '\u3057', '\u3059', '\u305b', '\u305d',
					'\u305f', '\u3061', '\u3064', '\u3066', '\u3068',
					'\u306a', '\u306b', '\u306c', '\u306d', '\u306e',
					'\u306f', '\u3072', '\u3075', '\u3078', '\u307b',
					'\u307e', '\u307f', '\u3080', '\u3081', '\u3082',
					'\u3084',           '\u3086',           '\u3088',
					'\u3089', '\u308a', '\u308b', '\u308c', '\u308d',
					'\u308f',                               '\u3092',
				'\u3093',
			];
			HiraganaToggle = new int[11, 6]{
				{      0, 0x3042, 0x3044, 0x3046, 0x3048, 0x304a, },
				{      0, 0x304b, 0x304d, 0x304f, 0x3051, 0x3053, },
				{      0, 0x3055, 0x3057, 0x3059, 0x305b, 0x305d, },
				{      0, 0x305f, 0x3061, 0x3064, 0x3066, 0x3068, },
				{      0, 0x306a, 0x306b, 0x306c, 0x306d, 0x306e, },
				{      0, 0x306f, 0x3072, 0x3075, 0x3078, 0x307b, },
				{      0, 0x307e, 0x307f, 0x3080, 0x3081, 0x3082, },
				{      0, 0x3084,      0, 0x3086,      0, 0x3088, },
				{      0, 0x3089, 0x308a, 0x308b, 0x308c, 0x308d, },
				{      0, 0x308f,      0,      0,      0, 0x3092, },
				{ 0x3093,      0,      0,      0,      0,      0, },
			};
		}

		public void ToggleRowAt(int row) {
			for (int col = 0; col < HiraganaToggle.GetLength(1); col++) {
				Toggle(row, col);
			}
			ResetModels();
		}

		public void ToggleColumnAt(int col) {
			for (int row = 0; row < HiraganaToggle.GetLength(0); row++) {
				Toggle(row, col);
			}
			ResetModels();
		}

		public void ToggleAt(int row, int col) {
			Toggle(row, col);
			ResetModels();
		}

		private void Toggle(int row, int col) {
			if (HiraganaToggle[row, col] == 0) { return; }

			HiraganaToggle[row, col] = ~(HiraganaToggle[row, col]) + 1;

			int temp = HiraganaToggle[row, col];
			if (temp > 0) {
				Guesses.Add((char)temp);
			} else {
				Guesses.Remove((char)-temp);
			}
		}

		public void AddGame(GameModel model) {
			models.Add(model);
			model.RemainingGuesses = Guesses;
			//model.SetRemaining(Guesses);
			model.Reset();
		}

		public void RemoveGame(GameModel model) {
			models.Remove(model);
			model.RemainingGuesses = [
					'\u3042', '\u3044', '\u3046', '\u3048', '\u304a',
					'\u304b', '\u304d', '\u304f', '\u3051', '\u3053',
					'\u3055', '\u3057', '\u3059', '\u305b', '\u305d',
					'\u305f', '\u3061', '\u3064', '\u3066', '\u3068',
					'\u306a', '\u306b', '\u306c', '\u306d', '\u306e',
					'\u306f', '\u3072', '\u3075', '\u3078', '\u307b',
					'\u307e', '\u307f', '\u3080', '\u3081', '\u3082',
					'\u3084',           '\u3086',           '\u3088',
					'\u3089', '\u308a', '\u308b', '\u308c', '\u308d',
					'\u308f',                               '\u3092',
				'\u3093',
			];
			model.Reset();
		}

		private void ResetModels() {
			foreach (GameModel model in models) {
				model.Reset();
			}
		}
	}
}
