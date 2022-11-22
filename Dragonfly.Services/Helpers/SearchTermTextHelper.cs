using Dragonfly.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dragonfly.Services.Helpers
{
    public static class SearchTermTextHelper
    {
        public static string GetSearchSnippet(string text, string searchTerm)
        {
            string[] sentences = Regex.Split(text, @"(?<=[\.!\?])\s+");
            var matchedSentences = sentences.Where(i => i.Contains(searchTerm)).ToList();
            var sb = new StringBuilder();
            int counter = 0;
            foreach (var sentence in matchedSentences.Take(5))
            {
                counter++;
                sb.Append($"{sentence}... ");
            }
            var hitsLeft = matchedSentences.Count - counter;
            if (matchedSentences.Count == 0)
            {
                int i = 0;
                foreach (var sentence in sentences)
                {
                    i++;
                    sb.Append($"{sentence} ");
                    if (i == 4)
                    {
                        break;
                    }
                }

                sb.Append($"...");
            }
            return sb.ToString();
        }
    }
}
