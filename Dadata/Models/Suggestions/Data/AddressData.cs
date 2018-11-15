using System.Collections.Generic;
using DaData.Models.Additional.Data;

namespace DaData.Models.Suggestions.Data
{
    public class AddressData 
    {
		 public string PostalCode { get; set; }
        
         public string Country { get; set; }

		 public string RegionFiasId { get; set; }
        
		 public string RegionKladrId { get; set; }
        
		 public string RegionWithType { get; set; }
        
		 public string RegionType { get; set; }
        
		 public string RegionTypeFull { get; set; }
        
         public string Region { get; set; }
        
		 public string AreaFiasId { get; set; }
        
		 public string AreaKladrId { get; set; }
        
		 public string AreaWithType { get; set; }
        
		 public string AreaType { get; set; }
        
		 public string AreaTypeFull { get; set; }
        
         public string Area { get; set; }
        
		 public string CityFiasId { get; set; }
        
		 public string CityKladrId { get; set; }
        
		 public string CityWithType { get; set; }
        
		 public string CityType { get; set; }
        
		 public string CityTypeFull { get; set; }
        
         public string City { get; set; }
        
		 public string CityArea { get; set; }
        
		 public string CityDistrictFiasId { get; set; }
        
		 public string CityDistrictKladrId { get; set; }
        
		 public string CityDistrictWithType { get; set; }
        
		 public string CityDistrictType { get; set; }
        
		 public string CityDistrictTypeFull { get; set; }
        
         public string CityDistrictArea { get; set; }
        
		 public string SettlementFiasId { get; set; }
        
		 public string SettlementKladrId { get; set; }
        
		 public string SettlementWithType { get; set; }
        
		 public string SettlementType { get; set; }
        
		 public string SettlementTypeFull { get; set; }
        
         public string Settlement { get; set; }
        
		 public string StreetFiasId { get; set; }
        
		 public string StreetKladrId { get; set; }
        
		 public string StreetWithType { get; set; }
        
		 public string StreetType { get; set; }
        
		 public string StreetTypeFull { get; set; }
        
         public string Street { get; set; }
        
		 public string HouseFiasId { get; set; }
        
		 public string HouseKladrId { get; set; }     
        
		 public string HouseType { get; set; }
        
		 public string HouseTypeFull { get; set; }
        
         public string House { get; set; }
        
		 public string BlockType { get; set; }
        
		 public string BlockTypeFull { get; set; }
        
         public string Block { get; set; }
        
		 public string FlatType { get; set; }
        
		 public string FlatTypeFull { get; set; }
        
         public string Flat { get; set; }
        
		 public string FlatArea { get; set; }
        
		 public string SquareMeterPrice { get; set; }
        
		 public string FlatPrice { get; set; }
        
		 public string PostalBox { get; set; }
        
		 public string FiasId { get; set; }
        
		 public string FiasCode { get; set; }
        
		 public string FiasLevel { get; set; }
        
		 public string FiasActualityState { get; set; }
        
		 public string KladrId { get; set; }
        
		 public string CapitalMarker { get; set; }

         public string Okato { get; set; }
        
         public string Oktmo { get; set; }
        
		 public string TaxOffice { get; set; }
        
		 public string TaxOfficeLegal { get; set; }

         public string Timezone { get; set; }
        
		 public string GeoLat { get; set; }
        
		 public string GeoLon { get; set; }
        
		 public string BeltwayHit { get; set; }
        
		 public string BeltwayDistance { get; set; }

         public List<DataMetro> Metro { get; set; }
        
		 public string QcGeo { get; set; }
        
		 public string QcComplete { get; set; }
        
		 public string QcHouse { get; set; }
        
		 public List<string> HistoryValues { get; set; }
        
		 public string UnparsedParts { get; set; }

         public string Source { get; set; }

         public string Qc { get; set; }
    }
}