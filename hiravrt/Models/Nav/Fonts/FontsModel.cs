using System.Runtime.CompilerServices;

namespace hiravrt.Models.Nav.Fonts {
    public enum FontID {
        BASE,
        GLNOVANTIQUAMINAMOTO,
        HACHIMARUPOP,
        NIKKYOUSANS,
        REGGAEONE,
        YUJIBOKU,
    }

    public readonly struct FontsModel(FontID id, string filepath, string name) {
        public FontID Id { get; } = id;
        public string Filepath { get; } = filepath;
        public string Name { get; } = name;
    }
}
