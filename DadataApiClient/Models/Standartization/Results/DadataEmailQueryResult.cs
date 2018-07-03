using DadataApiClient.Models.Suggests.Data;

namespace DadataApiClient.Models.Standartization.Data
{
    public class DadataEmailQueryResult
    {
        public string Source { get; set; }

        public string Email { get; set; }

        public int Qc { get; set; }
    }
}