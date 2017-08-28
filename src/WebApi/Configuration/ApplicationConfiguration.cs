namespace WebApi.Configuration
{
    public class ApplicationConfiguration
    {
        public string ConnectionString { get; set; }
        public string GetProductsQuery { get; set; }
        public string SearchProductsQuery { get; set; }
        public string GetProductBundlesQuery { get; set; }
    }
}