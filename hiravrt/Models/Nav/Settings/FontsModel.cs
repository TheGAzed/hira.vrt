using System.Runtime.CompilerServices;

namespace hiravrt.Models.Nav.Settings {
	public enum FontGroup {
		BASIC,
		STYLE,
	}

	public enum FontID {
		// BASIC
		INITIAL = 0,
		GLNOVANTIQUAMINAMOTO = 1,
		YUJIBOKU = 2,

		// STYLE
		REGGAEONE = 3,
		HACHIMARUPOP = 4,
		NIKKYOUSANS = 5,
	}

	public class FontsModel {
		public FontID CurrentFont { get; set; } = FontID.INITIAL;
		public readonly Dictionary<FontID, string> FontIDFontName;
		public FontsModel() {
			FontIDFontName = new() {
				{ FontID.INITIAL, "initial"}, { FontID.GLNOVANTIQUAMINAMOTO, "GL-NovantiquaMinamoto"},
				{ FontID.YUJIBOKU, "YujiBoku-Regular"}, { FontID.NIKKYOUSANS, "NikkyouSans"},
				{ FontID.REGGAEONE, "ReggaeOne-Regular"}, { FontID.HACHIMARUPOP, "HachiMaruPop-Regular"},
			};
		}
	}
}
