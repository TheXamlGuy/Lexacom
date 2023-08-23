using System.Text.Json;

namespace Lexacom
{
    public class JsonTextPatientDataExtractor : IPatientDataExtractor
    {
        public bool TryExtract(string? input, out IReadOnlyCollection<Patient>? result)
        {
            if (input is { Length: > 0 })
            {
                result = JsonSerializer.Deserialize<IReadOnlyCollection<Patient>>(input);
                return true;
            }

            // Never return null
            result = new List<Patient>();
            return false;
        }
    }
}