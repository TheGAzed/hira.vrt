using hiravrt.Models.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hiravrt.tests.Models.Game {
	class LookUpModelTests {
		private LookUp Lookup;
		private List<string> Syllable;
		private List<string> Latin;

		[SetUp]
		public void Setup() {
			Lookup = new LookUp();
			Syllable = new(){
				// MONOGRAPHS
				//    a             i             u             e             o
				{ "\u3042" }, { "\u3044" }, { "\u3046" }, { "\u3048" }, { "\u304a" },
				{ "\u304b" }, { "\u304d" }, { "\u304f" }, { "\u3051" }, { "\u3053" }, // k
				{ "\u3055" }, { "\u3057" }, { "\u3059" }, { "\u305b" }, { "\u305d" }, // s
				{ "\u305f" }, { "\u3061" }, { "\u3064" }, { "\u3066" }, { "\u3068" }, // t
				{ "\u306a" }, { "\u306b" }, { "\u306c" }, { "\u306d" }, { "\u306e" }, // n
				{ "\u306f" }, { "\u3072" }, { "\u3075" }, { "\u3078" }, { "\u307b" }, // h
				{ "\u307e" }, { "\u307f" }, { "\u3080" }, { "\u3081" }, { "\u3082" }, // m
				{ "\u3084" },               { "\u3086" },               { "\u3088" }, // y
				{ "\u3089" }, { "\u308a" }, { "\u308b" }, { "\u308c" }, { "\u308d" }, // r
				{ "\u308f" }, { "\u3090" },               { "\u3091" }, { "\u3092" }, // w
				//    n
				{ "\u3093" },

				// DIGRAPHS
				//       ya                 yu                 yo
				{ "\u304D\u3083" }, {"\u304D\u3085" }, {"\u304D\u3087" }, // k
				{ "\u3057\u3083" }, {"\u3057\u3085" }, {"\u3057\u3087" }, // s
				{ "\u3061\u3083" }, {"\u3061\u3085" }, {"\u3061\u3087" }, // t
				{ "\u306B\u3083" }, {"\u306B\u3085" }, {"\u306B\u3087" }, // n
				{ "\u3072\u3083" }, {"\u3072\u3085" }, {"\u3072\u3087" }, // m
				{ "\u307F\u3083" }, {"\u307F\u3085" }, {"\u307F\u3087" }, // h
				{ "\u308A\u3083" }, {"\u308A\u3085" }, {"\u308A\u3087" }, // r

				// DIACRITIC MONOGRAPHS
				//    a             i             u             e             o
				{ "\u304C" }, { "\u304E" }, { "\u3050" }, { "\u3052" }, { "\u3054" }, // g
				{ "\u3056" }, { "\u3058" }, { "\u305A" }, { "\u305C" }, { "\u305E" }, // z
				{ "\u3060" }, { "\u3062" }, { "\u3065" }, { "\u3067" }, { "\u3069" }, // d
				{ "\u3070" }, { "\u3073" }, { "\u3076" }, { "\u3079" }, { "\u307C" }, // b
				{ "\u3071" }, { "\u3074" }, { "\u3077" }, { "\u307A" }, { "\u307D" }, // p

				// DIACRITIC DIGRAPHS
				//       ya                  yu                  yo
				{ "\u304E\u3083" }, { "\u304E\u3085" }, { "\u304E\u3087" }, // g
				{ "\u3058\u3083" }, { "\u3058\u3085" }, { "\u3058\u3087" }, // z
				{ "\u3062\u3083" }, { "\u3062\u3085" }, { "\u3062\u3087" }, // d
				{ "\u3073\u3083" }, { "\u3073\u3085" }, { "\u3073\u3087" }, // b
				{ "\u3074\u3083" }, { "\u3074\u3085" }, { "\u3074\u3087" }, // p
			};
			Latin = new(){
			// MONOGRAPHS
			//  a           i          u           e           o
			{  "A" }, {    "I" }, {   "U" }, {    "E" }, {    "O" },
			{ "KA" }, {   "KI" }, {  "KU" }, {   "KE" }, {   "KO" }, // k
			{ "SA" }, {  "SHI" }, {  "SU" }, {   "SE" }, {   "SO" }, // s
			{ "TA" }, {  "CHI" }, { "TSU" }, {   "TE" }, {   "TO" }, // t
			{ "NA" }, {   "NI" }, {  "NU" }, {   "NE" }, {   "NO" }, // n
			{ "HA" }, {   "HI" }, {  "FU" }, {   "HE" }, {   "HO" }, // h
			{ "MA" }, {   "MI" }, {  "MU" }, {   "ME" }, {   "MO" }, // m
			{ "YA" },             {  "YU" },             {   "YO" }, // y
			{ "RA" }, {   "RI" }, {  "RU" }, {   "RE" }, {   "RO" }, // r
			{ "WA" }, { "(W)I" },            { "(W)E" }, { "(W)O" }, // w
			//  n
			{  "N" },

			// DIGRAPHS
			//  ya        yu        yo
			{ "KYA" }, {"KYU" }, {"KYO" }, // k
			{ "SHA" }, {"SHU" }, {"SHO" }, // s
			{ "CHA" }, {"CHU" }, {"CHO" }, // t
			{ "NYA" }, {"NYU" }, {"NYO" }, // n
			{ "HYA" }, {"HYU" }, {"HYO" }, // m
			{ "MYA" }, {"MYU" }, {"MYO" }, // h
			{ "RYA" }, {"RYU" }, {"RYO" }, // r

			// DIACRITIC MONOGRAPHS
			//  a         i            u            e         o
			{ "GA" }, { "GI"    }, { "GU"    }, { "GE" }, { "GO" }, // g
			{ "ZA" }, { "(Z)JI" }, { "ZU"    }, { "ZE" }, { "ZO" }, // z
			{ "DA" }, { "(D)JI" }, { "(D)ZU" }, { "DE" }, { "DO" }, // d
			{ "BA" }, { "BI"    }, { "BU"    }, { "BE" }, { "BO" }, // b
			{ "PA" }, { "PI"    }, { "PU"    }, { "PE" }, { "PO" }, // p

			// DIACRITIC DIGRAPHS
			//  ya           yu           yo
			{ "GYA"   }, { "GYU"   }, { "GYO"   }, // g
			{ "(Z)JA" }, { "(Z)JU" }, { "(Z)JO" }, // z
			{ "(D)JA" }, { "(D)JU" }, { "(D)JO" }, // d
			{ "BYA"   }, { "BYU"   }, { "BYO"   }, // b
			{ "PYA"   }, { "PYU"   }, { "PYO"   }, // p
		};
		}

		[Test]
		public void SyllableBackwards_Test() {
			Syllable.ForEach(s => {
				Assert.That(s, Is.EqualTo(Lookup.Syllable(Lookup.Latin(s))));
			});
		}
		[Test]
		public void LatinBackwards_Test() {
			Latin.ForEach(l => {
				Assert.That(l, Is.EqualTo(Lookup.Latin(Lookup.Syllable(l))));
			});
		}
		[Test]
		public void PointsReturnZeroIfInvalid_Test() {
			Assert.That(Lookup.Points("zero"), Is.EqualTo(0));
		}
	}
}
