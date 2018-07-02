using System.Collections.Generic;
using Newtonsoft.Json;

namespace DadataApiClient.Models.Suggests.Data
{
    public class DadataAddressQueryData
    {
        [JsonProperty("postal_code")] public string PostalCode { get; set; }
        
        public string Country { get; set; }

        [JsonProperty("region_fias_id")] public string RegionFiasId { get; set; }
        
        [JsonProperty("region_kladr_id")] public string RegionKladrId { get; set; }
        
        [JsonProperty("region_with_type")] public string RegionWithType { get; set; }
        
        [JsonProperty("region_type")] public string RegionType { get; set; }
        
        [JsonProperty("region_type_full")] public string RegionTypeFull { get; set; }
        
        public string Region { get; set; }
        
        [JsonProperty("area_fias_id")] public string AreaFiasId { get; set; }
        
        [JsonProperty("area_kladr_id")] public string AreaKladrId { get; set; }
        
        [JsonProperty("area_with_type")] public string AreaWithType { get; set; }
        
        [JsonProperty("area_type")] public string AreaType { get; set; }
        
        [JsonProperty("area_type_full")] public string AreaTypeFull { get; set; }
        
        public string Area { get; set; }
        
        [JsonProperty("city_fias_id")] public string CityFiasId { get; set; }
        
        [JsonProperty("city_kladr_id")] public string CityKladrId { get; set; }
        
        [JsonProperty("city_with_type")] public string CityWithType { get; set; }
        
        [JsonProperty("city_type")] public string CityType { get; set; }
        
        [JsonProperty("city_type_full")] public string CityTypeFull { get; set; }
        
        public string City { get; set; }
        
        [JsonProperty("city_area")] public string CityArea { get; set; }
        
        [JsonProperty("city_district_fias_id")] public string CityDistrictAreaFiasId { get; set; }
        
        [JsonProperty("city_district_kladr_id")] public string CityDistrictAreaKladrId { get; set; }
        
        [JsonProperty("city_district_with_type")] public string CityDistrictAreaWithType { get; set; }
        
        [JsonProperty("city_district_type")] public string CityDistrictAreaType { get; set; }
        
        [JsonProperty("city_district_type_full")] public string CityDistrictAreaTypeFull { get; set; }
        
        public string CityDistrictArea { get; set; }
        
        [JsonProperty("settlement_fias_id")] public string SettlementFiasId { get; set; }
        
        [JsonProperty("settlement_kladr_id")] public string SettlementKladrId { get; set; }
        
        [JsonProperty("settlement_with_type")] public string SettlementWithType { get; set; }
        
        [JsonProperty("settlement_type")] public string SettlementType { get; set; }
        
        [JsonProperty("settlement_type_full")] public string SettlementTypeFull { get; set; }
        
        public string Settlement { get; set; }
        
        [JsonProperty("street_fias_id")] public string StreetFiasId { get; set; }
        
        [JsonProperty("street_kladr_id")] public string StreetKladrId { get; set; }
        
        [JsonProperty("street_with_type")] public string StreetWithType { get; set; }
        
        [JsonProperty("street_type")] public string StreetType { get; set; }
        
        [JsonProperty("street_type_full")] public string StreetTypeFull { get; set; }
        
        public string Street { get; set; }
        
        [JsonProperty("house_fias_id")] public string HouseFiasId { get; set; }
        
        [JsonProperty("house_kladr_id")] public string HouseKladrId { get; set; }     
        
        [JsonProperty("house_type")] public string HouseType { get; set; }
        
        [JsonProperty("house_type_full")] public string HouseTypeFull { get; set; }
        
        public string House { get; set; }
        
        [JsonProperty("block_type")] public string BlockType { get; set; }
        
        [JsonProperty("block_type_full")] public string BlockTypeFull { get; set; }
        
        public string Block { get; set; }
        
        [JsonProperty("flat_type")] public string FlatType { get; set; }
        
        [JsonProperty("flat_type_full")] public string FlatTypeFull { get; set; }
        
        public string Flat { get; set; }
        
        [JsonProperty("flat_area")] public string FlatArea { get; set; }
        
        [JsonProperty("square_meter_price")] public string SquareMeterPrice { get; set; }
        
        [JsonProperty("flat_price")] public string FlatPrice { get; set; }
        
        [JsonProperty("postal_box")] public string PostalBox { get; set; }
        
        [JsonProperty("fias_id")] public string FiasId { get; set; }
        
        [JsonProperty("fias_code")] public string FiasCode { get; set; }
        
        [JsonProperty("fias_level")] public string FiasLevel { get; set; }
        
        [JsonProperty("fias_actuality_state")] public string FiasActualityState { get; set; }
        
        [JsonProperty("kladr_id")] public string KladrId { get; set; }
        
        [JsonProperty("capital_marker")] public string CapitalMarker { get; set; }

        public string Okato { get; set; }
        
        public string Oktmo { get; set; }
        
        [JsonProperty("tax_office")] public string TaxOffice { get; set; }
        
        [JsonProperty("tax_office_legal")] public string TaxOfficeLegal { get; set; }

        public string Timezone { get; set; }
        
        [JsonProperty("geo_lat")] public string GeoLat { get; set; }
        
        [JsonProperty("geo_lon")] public string GeoLon { get; set; }
        
        [JsonProperty("beltway_hit")] public string BeltwayHit { get; set; }
        
        [JsonProperty("beltway_distance")] public string BeltwayDistance { get; set; }

        public string Metro { get; set; }
        
        [JsonProperty("qc_geo")] public string QcGeo { get; set; }
        
        [JsonProperty("qc_complete")] public string QcComplete { get; set; }
        
        [JsonProperty("qc_house")] public string QcHouse { get; set; }
        
        [JsonProperty("history_values")] public List<string> HistoryValues { get; set; }
        
        [JsonProperty("unparsed_parts")] public string UnparsedParts { get; set; }

        public string Source { get; set; }

        public string Qc { get; set; }
    }
}