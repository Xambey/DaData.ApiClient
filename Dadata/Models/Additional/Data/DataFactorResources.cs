using Newtonsoft.Json;

namespace DaData.Models.Additional.Data
{
    public class DataFactorResources
    {
        [JsonProperty("ФИАС")] public string Fias { get; set; }
        
        [JsonProperty("Индексы Почты")] public string IndexesPost{ get; set; }
        
        [JsonProperty("Цены квартир")] public string CostAppartments { get; set; }
        
        [JsonProperty("Площади квартир")] public string AreasAppartments { get; set; }
        
        [JsonProperty("Геокоординаты")] public string GeoCoordinates { get; set; }
        
        [JsonProperty("Недейств. паспорта")] public string InvalidPassports { get; set; }
        
        [JsonProperty("Телефоны")] public string Phones { get; set; }
        
        [JsonProperty("Перенесённые номера")] public string TransferedPhones { get; set; }
    }
}