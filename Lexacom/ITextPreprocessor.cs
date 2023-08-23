namespace Lexacom
{
    public interface ITextPreprocessor
    {
        bool TryProcess(string input, out string? output);
    }
}