namespace Lexacom
{
    public interface IPatientDataExtractor
    {
        bool TryExtract(string? input, out IReadOnlyCollection<Patient>? result);
    }
}