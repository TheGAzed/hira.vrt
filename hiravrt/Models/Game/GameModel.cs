using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace hiravrt.Models.Game
{
	public readonly struct LookUp
	{
		private readonly Dictionary<char, int> SyllablePoints = new(){
		//         a                i                u                e                o
			{ '\u3042', 1 }, { '\u3044', 1 }, { '\u3046', 1 }, { '\u3048', 1 }, { '\u304a', 1 },
			{ '\u304b', 2 }, { '\u304d', 2 }, { '\u304f', 2 }, { '\u3051', 2 }, { '\u3053', 2 }, // k
			{ '\u3055', 2 }, { '\u3057', 2 }, { '\u3059', 2 }, { '\u305b', 2 }, { '\u305d', 2 }, // s
			{ '\u305f', 2 }, { '\u3061', 2 }, { '\u3064', 2 }, { '\u3066', 2 }, { '\u3068', 2 }, // t
			{ '\u306a', 2 }, { '\u306b', 2 }, { '\u306c', 2 }, { '\u306d', 2 }, { '\u306e', 2 }, // n
			{ '\u306f', 2 }, { '\u3072', 2 }, { '\u3075', 2 }, { '\u3078', 2 }, { '\u307b', 2 }, // h
			{ '\u307e', 2 }, { '\u307f', 2 }, { '\u3080', 2 }, { '\u3081', 2 }, { '\u3082', 2 }, // m
			{ '\u3084', 2 },                  { '\u3086', 2 },                  { '\u3088', 2 }, // y
			{ '\u3089', 2 }, { '\u308a', 2 }, { '\u308b', 2 }, { '\u308c', 2 }, { '\u308d', 2 }, // r
			{ '\u308f', 2 },                                                    { '\u3092', 2 }, // w
		//        n
			{ '\u3093', 1 },
		};

		private readonly Dictionary<char, string> SyllableLatin = new(){
		//      a                   i                   u                   e                   o
		{ '\u3042',  "A" }, { '\u3044',  "I" }, { '\u3046',  "U" }, { '\u3048',  "E" }, { '\u304a',  "O" },
		{ '\u304b', "KA" }, { '\u304d', "KI" }, { '\u304f', "KU" }, { '\u3051', "KE" }, { '\u3053', "KO" }, // k
		{ '\u3055', "SA" }, { '\u3057', "SI" }, { '\u3059', "SU" }, { '\u305b', "SE" }, { '\u305d', "SO" }, // s
		{ '\u305f', "TA" }, { '\u3061', "TI" }, { '\u3064', "TU" }, { '\u3066', "TE" }, { '\u3068', "TO" }, // t
		{ '\u306a', "NA" }, { '\u306b', "NI" }, { '\u306c', "NU" }, { '\u306d', "NE" }, { '\u306e', "NO" }, // n
		{ '\u306f', "HA" }, { '\u3072', "HI" }, { '\u3075', "HU" }, { '\u3078', "HE" }, { '\u307b', "HO" }, // h
		{ '\u307e', "MA" }, { '\u307f', "MI" }, { '\u3080', "MU" }, { '\u3081', "ME" }, { '\u3082', "MO" }, // m
		{ '\u3084', "YA" },                     { '\u3086', "YU" },                     { '\u3088', "YO" }, // y
		{ '\u3089', "RA" }, { '\u308a', "RI" }, { '\u308b', "RU" }, { '\u308c', "RE" }, { '\u308d', "RO" }, // r
		{ '\u308f', "WA" },                                                             { '\u3092', "WO" }, // w
		//      n
		{ '\u3093', "N" },
		};

		private readonly Dictionary<string, char> LatinSyllable = new(){
		//      a                   i                   u                   e                   o
		{  "A", '\u3042' }, {  "I", '\u3044' }, {  "U", '\u3046' }, {  "E", '\u3048' }, {  "O", '\u304a' },
		{ "KA", '\u304b' }, { "KI", '\u304d' }, { "KU", '\u304f' }, { "KE", '\u3051' }, { "KO", '\u3053' }, // k
		{ "SA", '\u3055' }, { "SI", '\u3057' }, { "SU", '\u3059' }, { "SE", '\u305b' }, { "SO", '\u305d' }, // s
		{ "TA", '\u305f' }, { "TI", '\u3061' }, { "TU", '\u3064' }, { "TE", '\u3066' }, { "TO", '\u3068' }, // t
		{ "NA", '\u306a' }, { "NI", '\u306b' }, { "NU", '\u306c' }, { "NE", '\u306d' }, { "NO", '\u306e' }, // n
		{ "HA", '\u306f' }, { "HI", '\u3072' }, { "HU", '\u3075' }, { "HE", '\u3078' }, { "HO", '\u307b' }, // h
		{ "MA", '\u307e' }, { "MI", '\u307f' }, { "MU", '\u3080' }, { "ME", '\u3081' }, { "MO", '\u3082' }, // m
		{ "YA", '\u3084' },                     { "YU", '\u3086' },                     { "YO", '\u3088' }, // y
		{ "RA", '\u3089' }, { "RI", '\u308a' }, { "RU", '\u308b' }, { "RE", '\u308c' }, { "RO", '\u308d' }, // r
		{ "WA", '\u308f' },                                                             { "WO", '\u3092' }, // w
		//      n
		{ "N" , '\u3093'},
		};

		private readonly Dictionary<char, (int, int)> LatinColor = new(){
		//                    a                                  i                                  u                                  e
		//                    o
		{ '\u3042', (0xFF5733, 0xFF5733)}, { '\u3044', (0x4CAF50, 0x4CAF50)}, { '\u3046', (0x2196F3, 0x2196F3)}, { '\u3048', (0xFFC107, 0xFFC107)}, 
			{ '\u304a', (0xE91E63, 0xE91E63)},

		{ '\u304b', (0xFF5733, 0x795548)}, { '\u304d', (0x4CAF50, 0x795548)}, { '\u304f', (0x2196F3, 0x795548)}, { '\u3051', (0xFFC107, 0x795548)}, 
			{ '\u3053', (0xE91E63, 0x795548)}, // k

		{ '\u3055', (0xFF5733, 0x00BCD4)}, { '\u3057', (0x4CAF50, 0x00BCD4)}, { '\u3059', (0x2196F3, 0x00BCD4)}, { '\u305b', (0xFFC107, 0x00BCD4)}, 
			{ '\u305d', (0xE91E63, 0x00BCD4)}, // s

		{ '\u305f', (0xFF5733, 0xFF9800)}, { '\u3061', (0x4CAF50, 0xFF9800)}, { '\u3064', (0x2196F3, 0xFF9800)}, { '\u3066', (0xFFC107, 0xFF9800)}, 
			{ '\u3068', (0xE91E63, 0xFF9800)}, // t

		{ '\u306a', (0xFF5733, 0x673AB7)}, { '\u306b', (0x4CAF50, 0x673AB7)}, { '\u306c', (0x2196F3, 0x673AB7)}, { '\u306d', (0xFFC107, 0x673AB7)}, 
			{ '\u306e', (0xE91E63, 0x673AB7)}, // n

		{ '\u306f', (0xFF5733, 0x8BC34A)}, { '\u3072', (0x4CAF50, 0x8BC34A)}, { '\u3075', (0x2196F3, 0x8BC34A)}, { '\u3078', (0xFFC107, 0x8BC34A)}, 
			{ '\u307b', (0xE91E63, 0x8BC34A)}, // h

		{ '\u307e', (0xFF5733, 0xFF5252)}, { '\u307f', (0x4CAF50, 0xFF5252)}, { '\u3080', (0x2196F3, 0xFF5252)}, { '\u3081', (0xFFC107, 0xFF5252)}, 
			{ '\u3082', (0xE91E63, 0xFF5252)}, // m

		{ '\u3084', (0xFF5733, 0x9C27B0)},                                    { '\u3086', (0x2196F3, 0x9C27B0)},                                    
			{ '\u3088', (0xE91E63, 0x9C27B0)}, // y

		{ '\u3089', (0xFF5733, 0x607D8B)}, { '\u308a', (0x4CAF50, 0x607D8B)}, { '\u308b', (0x2196F3, 0x607D8B)}, { '\u308c', (0xFFC107, 0x607D8B)}, 
			{ '\u308d', (0xE91E63, 0x607D8B)}, // r

		{ '\u308f', (0xFF5733, 0x3F51B5)},                                                                                                          
			{ '\u3092', (0xE91E63, 0x3F51B5)}, // w
		//               n
		{ '\u3093' ,(0x673AB7, 0x673AB7)},
		};

		public LookUp() {}

		public readonly int Points(char syllable) {
			if (SyllablePoints.ContainsKey(syllable)) {
				return SyllablePoints[syllable];
			} else {
				return 0;
			}
		}

		public readonly string Latin(char syllable) {
			if (SyllableLatin.TryGetValue(syllable, out string? value)) {
				return value;
			} else {
				return "";
			}
		}

		public readonly char Syllable(string latin) {
			if (LatinSyllable.TryGetValue(latin, out char value)) {
				return value;
			} else {
				return '\0';
			}
		}

		public readonly (int, int) Color(char syllable) {
			if (LatinColor.TryGetValue(syllable, out (int, int) value)) {
				return value;
			} else {
				return (0, 0);
			}
		}
	}
	public abstract class GameModel {
		public int MinGuessCount { get; set; } = default(int);
		protected LookUp LookUp { get; }
		public int Score { get; set; } = default;
		public char CurrentGuess { get; set; } = default;
		public List<char> RemainingGuesses { get; set; }
		public List<char> CorrectGuesses { get; set; } = new List<char>();
		public List<char> WrongGuesses { get; set; } = new List<char>();

		public GameModel(LookUp lookUp) {
			this.RemainingGuesses = [
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
			this.LookUp = lookUp;
			
			FirstGuess();
			SetMinGuessCount();
		}


		protected abstract void FirstGuess();
		protected abstract void SetMinGuessCount();
		protected abstract void NextGuess();
		public abstract void NextMove(char syllable);
		public abstract bool IsCorrect(char syllable);
		public virtual void Reset() {
			Score = default;
			CurrentGuess = default;
			CorrectGuesses.Clear();
			WrongGuesses.Clear();

			FirstGuess();
		}
	}
}
