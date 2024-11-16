namespace SocietyBuilder.Services.UniversalServices
{
    public class UniversalSettings
    {
        public string ExcelFile { get; set; }
    }
    public static class UniversalServiceProvider
    {
        public static IServiceProvider? ServiceProvider { get; set; }
    }
}
