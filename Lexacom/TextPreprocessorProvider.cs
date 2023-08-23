using System.Collections.ObjectModel;

namespace Lexacom
{
    public class TextPreprocessorProvider : ReadOnlyCollection<ITextPreprocessor>
    {
        public TextPreprocessorProvider(IList<ITextPreprocessor> list) : base(list)
        {

        }
    }
}