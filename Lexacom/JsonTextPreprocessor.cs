using System.Text.Json;

namespace Lexacom
{
    public class JsonTextPreprocessor : ITextPreprocessor
    {
        public bool TryProcess(string input, out string? output)
        {
            // Let's do VERY basic JSON validation here...
            if (input.Trim().StartsWith("{") && input.EndsWith("}"))
            {
                using JsonDocument document = JsonDocument.Parse(input[1..^1]);
                output = JsonSerializer.Serialize(document, new JsonSerializerOptions 
                {
                    WriteIndented = true 
                });
                
                return true;
            }

            output = null;
            return false;
        }
    }
}