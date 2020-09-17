using System;
using DiscordTokenRetriever;

namespace DiscordTokenRetrieverLibrary
{
    class Example
    {
        void exampleFunction()
        {
            foreach (string token in TokenRetriever.RetrieveDiscordTokens())
            {
                Console.WriteLine($"Found a token! {token}");
            }
        }

    }
}
