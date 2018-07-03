using DadataApiClient.Models.Suggests.Data;

namespace DadataApiClient.Models.Standartization.Data
{
    public class DadataPasportQueryResult
    {
        public string Source { get; set; }

        public string Series { get; set; }

        public string Number { get; set; }

        public int Qc { get; set; }
    }
}