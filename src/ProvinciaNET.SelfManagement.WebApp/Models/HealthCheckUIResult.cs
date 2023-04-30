using System.Text.Json.Serialization;

namespace ProvinciaNET.SelfManagement.WebApp.Models
{
    public class HealthCheckUIResult
    {
        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;

        [JsonPropertyName("totalDuration")]
        public string TotalDuration { get; set; } = string.Empty;

        [JsonPropertyName("entries")]
        public Entries Entries { get; set; } = new Entries();
    }

    public class Entries
    {
        [JsonPropertyName("sqlserver")]
        public HealthCheckData SqlServer { get; set; } = new HealthCheckData();

        [JsonPropertyName("efcontext")]
        public HealthCheckData EfContext { get; set; } = new HealthCheckData();
    }

    public class Data
    {
    }

    public class HealthCheckData
    {
        [JsonPropertyName("data")]
        public Data Data { get; set; } = new Data();

        [JsonPropertyName("duration")]
        public string Duration { get; set; } = string.Empty;

        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;

        [JsonPropertyName("tags")]
        public object[] Tags { get; set; } = new object[0];
    }
}