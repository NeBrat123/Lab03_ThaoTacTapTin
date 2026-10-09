using System;
using System.IO;

namespace ChuDe3.StudentManager
{
    internal static class SettingsStore
    {
        private static readonly string SettingsDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ChuDe3.StudentManager");
        private static readonly string LastFileSetting = Path.Combine(SettingsDirectory, "last-file.txt");

        public static string LoadLastPath()
        {
            try { return File.Exists(LastFileSetting) ? File.ReadAllText(LastFileSetting).Trim() : null; }
            catch { return null; }
        }

        public static void SaveLastPath(string path)
        {
            Directory.CreateDirectory(SettingsDirectory);
            File.WriteAllText(LastFileSetting, path ?? string.Empty);
        }
    }
}
