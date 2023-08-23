namespace Lexacom.Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Maybe in some sort of DI framework with auto registrations on ITextPreprocessor
            TextPreprocessorProvider textPreprocessors = new(new List<ITextPreprocessor> 
            { 
                new PlainTextPreprocessor(), 
                new JsonTextPreprocessor()
            });

            TextPreprocessor preprocessor = new(textPreprocessors);

            PatientDataExtractorProvider patientDataExtractors = new(new List<IPatientDataExtractor>
            {          
                new PlainTextPatientDataExtractor(),
                new JsonTextPatientDataExtractor()
            });

            PatientDataExtractor patientDataExtractor = new(patientDataExtractors); 

            while (true)
            {
                Console.WriteLine("Enter your text transcription: ");
                if (Console.ReadLine() is { } transcription)
                {
                    if (preprocessor.TryProcess(transcription, out string? result))
                    {
                        Console.WriteLine($"Preprocessed text transcription result: {Environment.NewLine}");
                        Console.WriteLine($"{result}{Environment.NewLine}");

                        if (patientDataExtractor.TryExtract(result, out IReadOnlyCollection<Patient>? patients) && patients is not null)
                        {
                            Console.WriteLine($"{"Name"}\t\t\t{"NHS Number"}");
                            foreach (Patient patient in patients)
                            {
                                Console.WriteLine($"{patient.Name}\t\t\t{patient.NHSNumber}");
                            }

                            Console.WriteLine();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Failed to determine input of your text transcription.");
                }
            } 
        }
    }
}