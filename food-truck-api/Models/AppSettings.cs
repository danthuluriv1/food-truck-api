namespace food_truck_api.Models
{
    public class AppSettings
    {
        public ConnectionStrings? ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string? AppDbConnectionString { get; set; }
        public string? AppDbDatabaseName { get; set; }
    }
}
