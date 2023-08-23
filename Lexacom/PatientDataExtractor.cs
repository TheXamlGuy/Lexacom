namespace Lexacom
{
    public class PatientDataExtractor : IPatientDataExtractor
    {
        private readonly PatientDataExtractorProvider patientDataExtractors;

        public PatientDataExtractor(PatientDataExtractorProvider patientDataExtractors)
        {
            this.patientDataExtractors = patientDataExtractors;
        }

        public bool TryExtract(string? input, out IReadOnlyCollection<Patient>? result)
        {
            foreach (IPatientDataExtractor patientDataExtractor in patientDataExtractors)
            {
                if (patientDataExtractor.TryExtract(input, out result))
                {
                    return true;
                }
            }

            result = null;
            return false;
        }
    }
}