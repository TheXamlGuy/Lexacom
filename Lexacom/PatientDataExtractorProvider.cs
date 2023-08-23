using System.Collections.ObjectModel;

namespace Lexacom
{
    public class PatientDataExtractorProvider : ReadOnlyCollection<IPatientDataExtractor>
    {
        public PatientDataExtractorProvider(IList<IPatientDataExtractor> list) : base(list)
        {

        }
    }


}