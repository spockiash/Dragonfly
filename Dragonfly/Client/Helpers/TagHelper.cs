using Dragonfly.Models;

namespace Dragonfly.Client.Helpers
{
    public static class TagHelper
    {
        public static string GetTagName(string[] tagSanitized) => tagSanitized.Length > 1 ? $"{tagSanitized[0]} {tagSanitized[1]}" : tagSanitized[0];
    }
}
