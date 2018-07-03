using DadataApiClient.Models.Suggests.Data;

namespace DadataApiClient.Models.Standartization.Data
{
    public class DadataFioQueryResult
    {
        public string Source { get; set; }

        public string Result { get; set; }

        public string ResultGenitive { get; set; }

        public string ResultDative { get; set; }

        public string ResultAblative { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public string Gender { get; set; }

        public int Qc { get; set; }
    }
}