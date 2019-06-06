using DaData.Models.Enums;
using System;

namespace DaData.Models.Suggestions.Data
{
    public class DataState
    {
        public OrganizationState Status { get; set; }
        
        public DateTime? ActualityDate { get; set; }
        
        public DateTime? RegistrationDate { get; set; }
        
        public DateTime? LiquidationDate { get; set; }
    }
}