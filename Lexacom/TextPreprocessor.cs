namespace Lexacom
{
    public class TextPreprocessor : ITextPreprocessor
    {
        private readonly TextPreprocessorProvider textPreprocessors;

        public TextPreprocessor(TextPreprocessorProvider textPreprocessors)
        {
            this.textPreprocessors = textPreprocessors;
        }

        public bool TryProcess(string input, out string? output)
        {
            foreach (ITextPreprocessor textPreprocessor in textPreprocessors)
            {
                if (textPreprocessor.TryProcess(input, out output))
                {
                    return true;
                }
            }

            output = null;
            return false;
        }
    }
}