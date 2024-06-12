namespace hiravrt.Models.Game {
	public readonly struct LookUp {
		/// <summary>
		/// Lookup syllable unicode to latin dictionary.
		/// </summary>
		private readonly Dictionary<string, string> SyllableLatin;
		/// <summary>
		/// Lookup latin to syllable unicode dictionary.
		/// </summary>
		private readonly Dictionary<string, string> LatinSyllable;
		/// <summary>
		/// Lookup syllable unicode to double gradiant color code dictionary.
		/// </summary>
		private readonly Dictionary<string, (int, int)> SyllableColor;
		/// <summary>
		/// Lookup syllable unicode to pronunciation
		/// </summary>
		private readonly Dictionary<string, string> SyllablePronunciation;
		private readonly Dictionary<string, string> SyllableGrid;

		public LookUp() { 
			this.SyllablePronunciation = new() {
			// HIRAGANA MONOGRAPHS TO PRONUNCIATION
			//    a                     i                      u                      e                     o
			{ "\u3042",  "[a]" }, { "\u3044",   "[i]" }, { "\u3046",   "[ɯ]" }, { "\u3048",  "[e]" }, { "\u304a",  "[o]" },
			{ "\u304b", "[ka]" }, { "\u304d",  "[ki]" }, { "\u304f",  "[kɯ]" }, { "\u3051", "[ke]" }, { "\u3053", "[ko]" }, // k
			{ "\u3055", "[sa]" }, { "\u3057",  "[ɕi]" }, { "\u3059",  "[sɯ]" }, { "\u305b", "[se]" }, { "\u305d", "[so]" }, // s
			{ "\u305f", "[ta]" }, { "\u3061", "[tɕi]" }, { "\u3064", "[tsɯ]" }, { "\u3066", "[te]" }, { "\u3068", "[to]" }, // t
			{ "\u306a", "[na]" }, { "\u306b",  "[ɲi]" }, { "\u306c",  "[nɯ]" }, { "\u306d", "[ne]" }, { "\u306e", "[no]" }, // n
			{ "\u306f", "[ha]" }, { "\u3072",  "[çi]" }, { "\u3075",  "[ɸɯ]" }, { "\u3078", "[he]" }, { "\u307b", "[ho]" }, // h
			{ "\u307e", "[ma]" }, { "\u307f",  "[mi]" }, { "\u3080",  "[mɯ]" }, { "\u3081", "[me]" }, { "\u3082", "[mo]" }, // m
			{ "\u3084", "[ja]" },                        { "\u3086",  "[jɯ]" },                       { "\u3088", "[jo]" }, // y
			{ "\u3089", "[ɾa]" }, { "\u308a",  "[ɾi]" }, { "\u308b",  "[ɾɯ]" }, { "\u308c", "[ɾe]" }, { "\u308d", "[ɾo]" }, // r
			{ "\u308f", "[wa]" }, { "\u3090",   "[i]" },                        { "\u3091",  "[e]" }, { "\u3092",  "[o]" }, // w
			//    n
			{ "\u3093", "[m n ɲ ŋ ɴ ɰ̃]" },

			// HIRAGANA DIGRAPHS TO PRONUNCIATION
			//      ya                          yu                          yo
			{ "\u304D\u3083", "[kʲa]" }, {"\u304D\u3085", "[kʲɯ]" }, {"\u304D\u3087", "[kʲo]" }, // k
			{ "\u3057\u3083",  "[ɕa]" }, {"\u3057\u3085",  "[ɕɯ]" }, {"\u3057\u3087",  "[ɕo]" }, // s
			{ "\u3061\u3083", "[tɕa]" }, {"\u3061\u3085", "[tɕɯ]" }, {"\u3061\u3087", "[tɕo]" }, // t
			{ "\u306B\u3083",  "[ɲa]" }, {"\u306B\u3085",  "[ɲɯ]" }, {"\u306B\u3087",  "[ɲo]" }, // n
			{ "\u3072\u3083",  "[ça]" }, {"\u3072\u3085",  "[çɯ]" }, {"\u3072\u3087",  "[ço]" }, // m
			{ "\u307F\u3083", "[mʲa]" }, {"\u307F\u3085", "[mʲɯ]" }, {"\u307F\u3087", "[mʲo]" }, // h
			{ "\u308A\u3083", "[ɾʲa]" }, {"\u308A\u3085", "[ɾʲɯ]" }, {"\u308A\u3087", "[ɾʲo]" }, // r

			// HIRAGANA DIACRITIC MONOGRAPHS TO PRONUNCIATION
			//    a                        i                        u                        e                        o
			{ "\u304C",    "[ɡa]" }, { "\u304E",    "[ɡi]" }, { "\u3050",    "[ɡɯ]" }, { "\u3052",    "[ɡe]" }, { "\u3054",    "[ɡo]" }, // g
			{ "\u3056", "[(d)za]" }, { "\u3058", "[(d)ʑi]" }, { "\u305A", "[(d)zɯ]" }, { "\u305C", "[(d)ze]" }, { "\u305E", "[(d)zo]" }, // z
			{ "\u3060",    "[da]" }, { "\u3062", "[(d)ʑi]" }, { "\u3065", "[(d)zɯ]" }, { "\u3067",    "[de]" }, { "\u3069",    "[do]" }, // d
			{ "\u3070",    "[ba]" }, { "\u3073",    "[bi]" }, { "\u3076",    "[bɯ]" }, { "\u3079",    "[be]" }, { "\u307C",    "[bo]" }, // b
			{ "\u3071",    "[pa]" }, { "\u3074",    "[pi]" }, { "\u3077",    "[pɯ]" }, { "\u307A",    "[pe]" }, { "\u307D",    "[po]" }, // p

			// HIRAGANA DIACRITIC DIGRAPHS TO PRONUNCIATION
			//      ya                             yu                             yo
			{ "\u304E\u3083",   "[ɡʲa]" }, { "\u304E\u3085",   "[ɡʲɯ]" }, { "\u304E\u3087",   "[ɡʲo]" }, // g
			{ "\u3058\u3083", "[(d)ʑa]" }, { "\u3058\u3085", "[(d)ʑɯ]" }, { "\u3058\u3087", "[(d)ʑo]" }, // z
			{ "\u3062\u3083", "[(d)ʑa]" }, { "\u3062\u3085", "[(d)ʑɯ]" }, { "\u3062\u3087", "[(d)ʑo]" }, // d
			{ "\u3073\u3083",   "[bʲa]" }, { "\u3073\u3085",   "[bʲɯ]" }, { "\u3073\u3087",   "[bʲo]" }, // b
			{ "\u3074\u3083",   "[pʲa]" }, { "\u3074\u3085",   "[pʲɯ]" }, { "\u3074\u3087",   "[pʲo]" }, // p
		};
			this.SyllableColor         = new() {
			// HIRAGANA NON DIACRITIC
			//    a                                   i                                   u                                   e                                   o
			{ "\u3042", (0xFF5733, 0xFF5733) }, { "\u3044", (0x4CAF50, 0x4CAF50) }, { "\u3046", (0x2196F3, 0x2196F3) }, { "\u3048", (0xFFC107, 0xFFC107) }, { "\u304a", (0xE91E63, 0xE91E63) },
			{ "\u304b", (0xFF5733, 0x795548) }, { "\u304d", (0x4CAF50, 0x795548) }, { "\u304f", (0x2196F3, 0x795548) }, { "\u3051", (0xFFC107, 0x795548) }, { "\u3053", (0xE91E63, 0x795548) }, // k
			{ "\u3055", (0xFF5733, 0x00BCD4) }, { "\u3057", (0x4CAF50, 0x00BCD4) }, { "\u3059", (0x2196F3, 0x00BCD4) }, { "\u305b", (0xFFC107, 0x00BCD4) }, { "\u305d", (0xE91E63, 0x00BCD4) }, // s
			{ "\u305f", (0xFF5733, 0xFF9800) }, { "\u3061", (0x4CAF50, 0xFF9800) }, { "\u3064", (0x2196F3, 0xFF9800) }, { "\u3066", (0xFFC107, 0xFF9800) }, { "\u3068", (0xE91E63, 0xFF9800) }, // t
			{ "\u306a", (0xFF5733, 0x673AB7) }, { "\u306b", (0x4CAF50, 0x673AB7) }, { "\u306c", (0x2196F3, 0x673AB7) }, { "\u306d", (0xFFC107, 0x673AB7) }, { "\u306e", (0xE91E63, 0x673AB7) }, // n
			{ "\u306f", (0xFF5733, 0x8BC34A) }, { "\u3072", (0x4CAF50, 0x8BC34A) }, { "\u3075", (0x2196F3, 0x8BC34A) }, { "\u3078", (0xFFC107, 0x8BC34A) }, { "\u307b", (0xE91E63, 0x8BC34A) }, // h
			{ "\u307e", (0xFF5733, 0xFF5252) }, { "\u307f", (0x4CAF50, 0xFF5252) }, { "\u3080", (0x2196F3, 0xFF5252) }, { "\u3081", (0xFFC107, 0xFF5252) }, { "\u3082", (0xE91E63, 0xFF5252) }, // m
			{ "\u3084", (0xFF5733, 0x9C27B0) },                                     { "\u3086", (0x2196F3, 0x9C27B0) },                                     { "\u3088", (0xE91E63, 0x9C27B0) }, // y
			{ "\u3089", (0xFF5733, 0x607D8B) }, { "\u308a", (0x4CAF50, 0x607D8B) }, { "\u308b", (0x2196F3, 0x607D8B) }, { "\u308c", (0xFFC107, 0x607D8B) }, { "\u308d", (0xE91E63, 0x607D8B) }, // r
			{ "\u308f", (0xFF5733, 0x3F51B5) }, { "\u3090", (0x4CAF50, 0x3F51B5) },                                     { "\u3091", (0xFFC107, 0x3F51B5) }, { "\u3092", (0xE91E63, 0x3F51B5) }, // w
			//    n
			{ "\u3093" ,(0x673AB7, 0x673AB7) },
			
			// HIRAGANA DIACRITIC
			//    a                                   i                                   u                                   e                                   o
			{ "\u304C", (0xFF5733, 0x9B59B6) }, { "\u304E", (0x4CAF50, 0x9B59B6) }, { "\u3050", (0x2196F3, 0x9B59B6) }, { "\u3052", (0xFFC107, 0x9B59B6) }, { "\u3054", (0xE91E63, 0x9B59B6) }, // g
			{ "\u3056", (0xFF5733, 0x3498DB) }, { "\u3058", (0x4CAF50, 0x3498DB) }, { "\u305A", (0x2196F3, 0x3498DB) }, { "\u305C", (0xFFC107, 0x3498DB) }, { "\u305E", (0xE91E63, 0x3498DB) }, // z
			{ "\u3060", (0xFF5733, 0xF1C40F) }, { "\u3062", (0x4CAF50, 0xF1C40F) }, { "\u3065", (0x2196F3, 0xF1C40F) }, { "\u3067", (0xFFC107, 0xF1C40F) }, { "\u3069", (0xE91E63, 0xF1C40F) }, // d
			{ "\u3070", (0xFF5733, 0xE67E22) }, { "\u3073", (0x4CAF50, 0xE67E22) }, { "\u3076", (0x2196F3, 0xE67E22) }, { "\u3079", (0xFFC107, 0xE67E22) }, { "\u307C", (0xE91E63, 0xE67E22) }, // b
			{ "\u3071", (0xFF5733, 0x1ABC9C) }, { "\u3074", (0x4CAF50, 0x1ABC9C) }, { "\u3077", (0x2196F3, 0x1ABC9C) }, { "\u307A", (0xFFC107, 0x1ABC9C) }, { "\u307D", (0xE91E63, 0x1ABC9C) }, // p

			// HIRAGANA SPECIAL NON DIACRITIC
			//    ya                                                                      yu                                                                      yo
			{ "\u3083", (0xFF5733, 0x9C27B0) },                                     { "\u3085", (0x2196F3, 0x9C27B0) },                                     { "\u3087", (0xE91E63, 0x9C27B0) }, // y
		};
			this.LatinSyllable         = new() {
			// HIRAGANA MONOGRAPHS TO SYLLABLE
			//          a                     i                    u                     e                     o
			{  "A", "\u3042" }, {    "I", "\u3044" }, {   "U", "\u3046" }, {    "E", "\u3048" }, {    "O", "\u304a" },
			{ "KA", "\u304b" }, {   "KI", "\u304d" }, {  "KU", "\u304f" }, {   "KE", "\u3051" }, {   "KO", "\u3053" }, // k
			{ "SA", "\u3055" }, {  "SHI", "\u3057" }, {  "SU", "\u3059" }, {   "SE", "\u305b" }, {   "SO", "\u305d" }, // s
			{ "TA", "\u305f" }, {  "CHI", "\u3061" }, { "TSU", "\u3064" }, {   "TE", "\u3066" }, {   "TO", "\u3068" }, // t
			{ "NA", "\u306a" }, {   "NI", "\u306b" }, {  "NU", "\u306c" }, {   "NE", "\u306d" }, {   "NO", "\u306e" }, // n
			{ "HA", "\u306f" }, {   "HI", "\u3072" }, {  "FU", "\u3075" }, {   "HE", "\u3078" }, {   "HO", "\u307b" }, // h
			{ "MA", "\u307e" }, {   "MI", "\u307f" }, {  "MU", "\u3080" }, {   "ME", "\u3081" }, {   "MO", "\u3082" }, // m
			{ "YA", "\u3084" },                       {  "YU", "\u3086" },                       {   "YO", "\u3088" }, // y
			{ "RA", "\u3089" }, {   "RI", "\u308a" }, {  "RU", "\u308b" }, {   "RE", "\u308c" }, {   "RO", "\u308d" }, // r
			{ "WA", "\u308f" }, { "(W)I", "\u3090" },                      { "(W)E", "\u3091" }, { "(W)O", "\u3092" }, // w
			//      n
			{  "N", "\u3093" },

			// HIRAGANA DIGRAPHS TO SYLLABLE
			//             ya                        yu                        yo
			{ "KYA", "\u304D\u3083" }, {"KYU", "\u304D\u3085" }, {"KYO", "\u304D\u3087" }, // k
			{ "SHA", "\u3057\u3083" }, {"SHU", "\u3057\u3085" }, {"SHO", "\u3057\u3087" }, // s
			{ "CHA", "\u3061\u3083" }, {"CHU", "\u3061\u3085" }, {"CHO", "\u3061\u3087" }, // t
			{ "NYA", "\u306B\u3083" }, {"NYU", "\u306B\u3085" }, {"NYO", "\u306B\u3087" }, // n
			{ "HYA", "\u3072\u3083" }, {"HYU", "\u3072\u3085" }, {"HYO", "\u3072\u3087" }, // m
			{ "MYA", "\u307F\u3083" }, {"MYU", "\u307F\u3085" }, {"MYO", "\u307F\u3087" }, // h
			{ "RYA", "\u308A\u3083" }, {"RYU", "\u308A\u3085" }, {"RYO", "\u308A\u3087" }, // r

			// HIRAGANA DIACRITIC MONOGRAPHS TO SYLLABLE
			//          a                      i                      u                   e                   o
			{ "GA", "\u304C" }, { "GI",    "\u304E" }, { "GU",    "\u3050" }, { "GE", "\u3052" }, { "GO", "\u3054" }, // g
			{ "ZA", "\u3056" }, { "(Z)JI", "\u3058" }, { "ZU",    "\u305A" }, { "ZE", "\u305C" }, { "ZO", "\u305E" }, // z
			{ "DA", "\u3060" }, { "(D)JI", "\u3062" }, { "(D)ZU", "\u3065" }, { "DE", "\u3067" }, { "DO", "\u3069" }, // d
			{ "BA", "\u3070" }, { "BI",    "\u3073" }, { "BU",    "\u3076" }, { "BE", "\u3079" }, { "BO", "\u307C" }, // b
			{ "PA", "\u3071" }, { "PI",    "\u3074" }, { "PU",    "\u3077" }, { "PE", "\u307A" }, { "PO", "\u307D" }, // p

			// HIRAGANA DIACRITIC DIGRAPHS TO SYLLABLE
			//               ya                           yu                           yo
			{ "GYA"  , "\u304E\u3083" }, { "GYU"  , "\u304E\u3085" }, { "GYO"  , "\u304E\u3087" }, // g
			{ "(Z)JA", "\u3058\u3083" }, { "(Z)JU", "\u3058\u3085" }, { "(Z)JO", "\u3058\u3087" }, // z
			{ "(D)JA", "\u3062\u3083" }, { "(D)JU", "\u3062\u3085" }, { "(D)JO", "\u3062\u3087" }, // d
			{ "BYA"  , "\u3073\u3083" }, { "BYU"  , "\u3073\u3085" }, { "BYO"  , "\u3073\u3087" }, // b
			{ "PYA"  , "\u3074\u3083" }, { "PYU"  , "\u3074\u3085" }, { "PYO"  , "\u3074\u3087" }, // p
		};
			this.SyllableLatin         = new() {
				// HIRAGANA MONOGRAPHS TO LATIN
				//    a                   i                     u                    e                     o
				{ "\u3042",  "A" }, { "\u3044",  "I"   }, { "\u3046",  "U"  }, { "\u3048",  "E"   }, { "\u304a",  "O"   },
				{ "\u304b", "KA" }, { "\u304d", "KI"   }, { "\u304f", "KU"  }, { "\u3051", "KE"   }, { "\u3053", "KO"   }, // k
				{ "\u3055", "SA" }, { "\u3057", "SHI"  }, { "\u3059", "SU"  }, { "\u305b", "SE"   }, { "\u305d", "SO"   }, // s
				{ "\u305f", "TA" }, { "\u3061", "CHI"  }, { "\u3064", "TSU" }, { "\u3066", "TE"   }, { "\u3068", "TO"   }, // t
				{ "\u306a", "NA" }, { "\u306b", "NI"   }, { "\u306c", "NU"  }, { "\u306d", "NE"   }, { "\u306e", "NO"   }, // n
				{ "\u306f", "HA" }, { "\u3072", "HI"   }, { "\u3075", "FU"  }, { "\u3078", "HE"   }, { "\u307b", "HO"   }, // h
				{ "\u307e", "MA" }, { "\u307f", "MI"   }, { "\u3080", "MU"  }, { "\u3081", "ME"   }, { "\u3082", "MO"   }, // m
				{ "\u3084", "YA" },                       { "\u3086", "YU"  },                       { "\u3088", "YO"   }, // y
				{ "\u3089", "RA" }, { "\u308a", "RI"   }, { "\u308b", "RU"  }, { "\u308c", "RE"   }, { "\u308d", "RO"   }, // r
				{ "\u308f", "WA" }, { "\u3090", "(W)I" },                      { "\u3091", "(W)E" }, { "\u3092", "(W)O" }, // w
				//      n
				{ "\u3093", "N" },

				// HIRAGANA DIGRAPHS TO LATIN
				//      ya                        yu                        yo
				{ "\u304D\u3083", "KYA" }, {"\u304D\u3085", "KYU" }, {"\u304D\u3087", "KYO" }, // k
				{ "\u3057\u3083", "SHA" }, {"\u3057\u3085", "SHU" }, {"\u3057\u3087", "SHO" }, // s
				{ "\u3061\u3083", "CHA" }, {"\u3061\u3085", "CHU" }, {"\u3061\u3087", "CHO" }, // t
				{ "\u306B\u3083", "NYA" }, {"\u306B\u3085", "NYU" }, {"\u306B\u3087", "NYO" }, // n
				{ "\u3072\u3083", "HYA" }, {"\u3072\u3085", "HYU" }, {"\u3072\u3087", "HYO" }, // m
				{ "\u307F\u3083", "MYA" }, {"\u307F\u3085", "MYU" }, {"\u307F\u3087", "MYO" }, // h
				{ "\u308A\u3083", "RYA" }, {"\u308A\u3085", "RYU" }, {"\u308A\u3087", "RYO" }, // r

				// HIRAGANA DIACRITIC MONOGRAPHS TO LATIN
				//    a                   i                      u                      e                   o
				{ "\u304C", "GA" }, { "\u304E", "GI"    }, { "\u3050", "GU"    }, { "\u3052", "GE" }, { "\u3054", "GO" }, // g
				{ "\u3056", "ZA" }, { "\u3058", "(Z)JI" }, { "\u305A", "ZU"    }, { "\u305C", "ZE" }, { "\u305E", "ZO" }, // z
				{ "\u3060", "DA" }, { "\u3062", "(D)JI" }, { "\u3065", "(D)ZU" }, { "\u3067", "DE" }, { "\u3069", "DO" }, // d
				{ "\u3070", "BA" }, { "\u3073", "BI"    }, { "\u3076", "BU"    }, { "\u3079", "BE" }, { "\u307C", "BO" }, // b
				{ "\u3071", "PA" }, { "\u3074", "PI"    }, { "\u3077", "PU"    }, { "\u307A", "PE" }, { "\u307D", "PO" }, // p

				// HIRAGANA DIACRITIC DIGRAPHS TO LATIN
				//      ya                           yu                           yo
				{ "\u304E\u3083", "GYA"   }, { "\u304E\u3085", "GYU"   }, { "\u304E\u3087", "GYO"   }, // g
				{ "\u3058\u3083", "(Z)JA" }, { "\u3058\u3085", "(Z)JU" }, { "\u3058\u3087", "(Z)JO" }, // z
				{ "\u3062\u3083", "(D)JA" }, { "\u3062\u3085", "(D)JU" }, { "\u3062\u3087", "(D)JO" }, // d
				{ "\u3073\u3083", "BYA"   }, { "\u3073\u3085", "BYU"   }, { "\u3073\u3087", "BYO"   }, // b
				{ "\u3074\u3083", "PYA"   }, { "\u3074\u3085", "PYU"   }, { "\u3074\u3087", "PYO"   }, // p
			};
			this.SyllableGrid          = new() {
				// HIRAGANA MONOGRAPHS TO LATIN
				//    a                   i                   u                   e                   o
				{ "\u3042",  "A" }, { "\u3044",  "I" }, { "\u3046",  "U" }, { "\u3048",  "E" }, { "\u304a",  "O" },
				{ "\u304b", "KA" }, { "\u304d", "KI" }, { "\u304f", "KU" }, { "\u3051", "KE" }, { "\u3053", "KO" }, // k
				{ "\u3055", "SA" }, { "\u3057", "SI" }, { "\u3059", "SU" }, { "\u305b", "SE" }, { "\u305d", "SO" }, // s
				{ "\u305f", "TA" }, { "\u3061", "TI" }, { "\u3064", "TU" }, { "\u3066", "TE" }, { "\u3068", "TO" }, // t
				{ "\u306a", "NA" }, { "\u306b", "NI" }, { "\u306c", "NU" }, { "\u306d", "NE" }, { "\u306e", "NO" }, // n
				{ "\u306f", "HA" }, { "\u3072", "HI" }, { "\u3075", "HU" }, { "\u3078", "HE" }, { "\u307b", "HO" }, // h
				{ "\u307e", "MA" }, { "\u307f", "MI" }, { "\u3080", "MU" }, { "\u3081", "ME" }, { "\u3082", "MO" }, // m
				{ "\u3084", "YA" },                     { "\u3086", "YU" },                     { "\u3088", "YO" }, // y
				{ "\u3089", "RA" }, { "\u308a", "RI" }, { "\u308b", "RU" }, { "\u308c", "RE" }, { "\u308d", "RO" }, // r
				{ "\u308f", "WA" }, { "\u3090", "WI" },                     { "\u3091", "WE" }, { "\u3092", "WO" }, // w
				//      n
				{ "\u3093", "N" },

				// HIRAGANA DIGRAPHS TO LATIN
				//      ya                        yu                        yo
				{ "\u304D\u3083", "KYA" }, {"\u304D\u3085", "KYU" }, {"\u304D\u3087", "KYO" }, // k
				{ "\u3057\u3083", "SYA" }, {"\u3057\u3085", "SYU" }, {"\u3057\u3087", "SYO" }, // s
				{ "\u3061\u3083", "TYA" }, {"\u3061\u3085", "TYU" }, {"\u3061\u3087", "TYO" }, // t
				{ "\u306B\u3083", "NYA" }, {"\u306B\u3085", "NYU" }, {"\u306B\u3087", "NYO" }, // n
				{ "\u307F\u3083", "MYA" }, {"\u307F\u3085", "MYU" }, {"\u307F\u3087", "MYO" }, // m
				{ "\u3072\u3083", "HYA" }, {"\u3072\u3085", "HYU" }, {"\u3072\u3087", "HYO" }, // h
				{ "\u308A\u3083", "RYA" }, {"\u308A\u3085", "RYU" }, {"\u308A\u3087", "RYO" }, // r

				// HIRAGANA DIACRITIC MONOGRAPHS TO LATIN
				//    a                   i                      u                      e                   o
				{ "\u304C", "GA" }, { "\u304E", "GI" }, { "\u3050", "GU" }, { "\u3052", "GE" }, { "\u3054", "GO" }, // g
				{ "\u3056", "ZA" }, { "\u3058", "ZI" }, { "\u305A", "ZU" }, { "\u305C", "ZE" }, { "\u305E", "ZO" }, // z
				{ "\u3060", "DA" }, { "\u3062", "DI" }, { "\u3065", "DU" }, { "\u3067", "DE" }, { "\u3069", "DO" }, // d
				{ "\u3070", "BA" }, { "\u3073", "BI" }, { "\u3076", "BU" }, { "\u3079", "BE" }, { "\u307C", "BO" }, // b
				{ "\u3071", "PA" }, { "\u3074", "PI" }, { "\u3077", "PU" }, { "\u307A", "PE" }, { "\u307D", "PO" }, // p

				// HIRAGANA DIACRITIC DIGRAPHS TO LATIN
				//      ya                           yu                           yo
				{ "\u304E\u3083", "GYA" }, { "\u304E\u3085", "GYU" }, { "\u304E\u3087", "GYO" }, // g
				{ "\u3058\u3083", "ZYA" }, { "\u3058\u3085", "ZYU" }, { "\u3058\u3087", "ZYO" }, // z
				{ "\u3062\u3083", "DYA" }, { "\u3062\u3085", "DYU" }, { "\u3062\u3087", "DYO" }, // d
				{ "\u3073\u3083", "BYA" }, { "\u3073\u3085", "BYU" }, { "\u3073\u3087", "BYO" }, // b
				{ "\u3074\u3083", "PYA" }, { "\u3074\u3085", "PYU" }, { "\u3074\u3087", "PYO" }, // p
			};
		}

		/// <summary>
		/// Get latin string form of syllable.
		/// </summary>
		/// <param name="syllable">Japanese unicode syllable as string.</param>
		/// <returns>Latin string of Japanese unicode syllable.</returns>
		/// <exception cref="ArgumentException">When input is not valid syllable string.</exception>
		public readonly string Latin(string syllable) {
			if (!SyllableLatin.TryGetValue(syllable, out string? latin)) throw new ArgumentException(latin + " is not a valid japanese syllable");
			return latin;
		}
		/// <summary>
		/// Get syllable string form of latin.
		/// </summary>
		/// <param name="latin">Latin form from Latin(string syllable) lookup.</param>
		/// <returns>Syllable unicode string of latin form.</returns>
		/// <exception cref="ArgumentException">When input is not valid latin string.</exception>
		public readonly string Syllable(string latin) {
			if (!LatinSyllable.TryGetValue(latin, out string? syllable)) throw new ArgumentException(latin + " is not a valid latinized syllable");
			return syllable;
		}
		/// <summary>
		/// Get base or mixed color from syllable string.
		/// </summary>
		/// <param name="syllable">Japanese unicode syllable as string.</param>
		/// <returns>Base (Monographs) or mixed color (Digraphs).</returns>
		/// <exception cref="ArgumentException">>When input is not valid syllable string.</exception>
		public readonly (int, int) Color(string syllable) {
			if (!SyllableLatin.ContainsKey(syllable)) throw new ArgumentException(syllable + " is not a valid japanese syllable");

			switch (syllable.Length) {
				case 1: return SyllableColor[syllable];
				case 2: {
					(int, int) first = SyllableColor[syllable[0].ToString()];
					(int, int) second = SyllableColor[syllable[1].ToString()];

					return (ColorMixer(first.Item1, second.Item1), ColorMixer(first.Item2, second.Item2));
				}
			}

			return (0, 0);
		}
		/// <summary>
		/// Get pronunciation from syllable.
		/// </summary>
		/// <param name="syllable">Japanese unicode syllable as string.</param>
		/// <returns>Pronunciation string of syllable.</returns>
		/// <exception cref="ArgumentException">When input is not valid syllable string.</exception>
		public readonly string Pronunciation(string syllable) {
			if (!SyllablePronunciation.TryGetValue(syllable, out string? latin)) throw new ArgumentException(latin + " is not a valid japanese syllable");
			return latin;
		}
		public readonly string Grid(string syllable) {
			if (!SyllableGrid.TryGetValue(syllable, out string? grid)) throw new ArgumentException(grid + " is not a valid japanese syllable");
			return grid;
		}
		/// <summary>
		/// Mixes two colors and returns new color.
		/// </summary>
		/// <param name="RGB_ONE">First RGB color.</param>
		/// <param name="RGB_TWO">Second RGB color.</param>
		/// <returns></returns>
		private static int ColorMixer(int RGB_ONE, int RGB_TWO) {
			int CMY_ONE, CMY_TWO;

			CMY_ONE = 0xFFFFFF - RGB_ONE;
			CMY_TWO = 0xFFFFFF - RGB_TWO;

			return Math.Abs(CMY_ONE - CMY_TWO);
		}
	}
}
