using System;
using System.Text.Json.Serialization;

namespace RepairAPI
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        // Ignorer la sérialisation de cette propriété
        [JsonIgnore]
        public int TemperatureK { get; set; }

        // Renommer la propriété dans la sérialisation JSON
        [JsonPropertyName("Summary")]
        public string SummaryText { get; set; }
    }
}
