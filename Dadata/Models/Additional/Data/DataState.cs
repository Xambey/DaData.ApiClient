using System;
using DaData.Models.Enums;

namespace DaData.Models.Additional.Data
{
    public class DataState
    {
        public OrganizationState Status { get; set; }

        public DateTime? ActualityDate { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public DateTime? LiquidationDate { get; set; }
    }
}