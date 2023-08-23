using System.Text.RegularExpressions;

namespace Lexacom
{
    public class PlainTextPatientDataExtractor : IPatientDataExtractor
    {
        public bool TryExtract(string? input, out IReadOnlyCollection<Patient>? result)
        {
            List<Patient> patients = new();
            result = patients;

            if (input is { Length: > 0 } )
            {
                foreach (Match match in Regex.Matches(input, @"(?:Name:(?<Name>\w+\s?\w+)\s*NHS Number:(?<NHSNumber>\w+))", RegexOptions.IgnoreCase | RegexOptions.Multiline).Cast<Match>())
                {
                    if (int.TryParse(Regex.Replace(match.Groups["NHSNumber"].Value, "[^0-9]", ""), out int nhsNumber))
                    {
                        patients.Add(new Patient(match.Groups["Name"].Value, nhsNumber));
                    }
                }

                if (patients.Any())
                {
                    return true;
                }
            }

            return false;
        }
    }
}