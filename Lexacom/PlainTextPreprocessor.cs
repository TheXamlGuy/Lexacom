using System.Text.RegularExpressions;

namespace Lexacom
{
    public class PlainTextPreprocessor : ITextPreprocessor
    {
        public bool TryProcess(string input, out string? output)
        {
            if (input.Contains("[[new-line]]"))
            {
                output = Regex.Replace(input, @"(\[\[new-line\]\])+", Environment.NewLine, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase);
                return true;
            }

            output = null;
            return false;
        }
    }
}