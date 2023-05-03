using System.Text.Json.Serialization;

namespace ProvinciaNET.SelfManagement.WebApp.Models
{
    /// <summary>
    /// Health Check UI Result Class
    /// </summary>
    public class HealthCheckUIResult
    {
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the total duration.
        /// </summary>
        /// <value>
        /// The total duration.
        /// </value>
        [JsonPropertyName("totalDuration")]
        public string TotalDuration { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the entries.
        /// </summary>
        /// <value>
        /// The entries.
        /// </value>
        [JsonPropertyName("entries")]
        public Entries Entries { get; set; } = new Entries();
    }

    /// <summary>
    /// Entries Class
    /// </summary>
    public class Entries
    {
        /// <summary>
        /// Gets or sets the SQL server.
        /// </summary>
        /// <value>
        /// The SQL server.
        /// </value>
        [JsonPropertyName("sqlserver")]
        public HealthCheckData SqlServer { get; set; } = new HealthCheckData();

        /// <summary>
        /// Gets or sets the ef context.
        /// </summary>
        /// <value>
        /// The ef context.
        /// </value>
        [JsonPropertyName("efcontext")]
        public HealthCheckData EfContext { get; set; } = new HealthCheckData();
    }

    /// <summary>
    /// Data Class
    /// </summary>
    public class Data
    {
    }

    /// <summary>
    /// Health Check Data Class
    /// </summary>
    public class HealthCheckData
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        [JsonPropertyName("data")]
        public Data Data { get; set; } = new Data();

        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        [JsonPropertyName("duration")]
        public string Duration { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>
        /// The tags.
        /// </value>
        [JsonPropertyName("tags")]
        public object[] Tags { get; set; } = new object[0];
    }
}