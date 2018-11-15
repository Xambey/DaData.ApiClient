namespace DaData.Models.Additional.Requests
{
    public class OrganizationRequest : BaseRequest
    {
        public string Query { get; set; }
        
        public string Type { get; set; }
        
        public string BranchType { get; set; }
    }
}