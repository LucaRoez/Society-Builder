namespace SocietyBuilder.Services.UniversalServices
{
    public interface IExcelManager
    {
        (int, float) GetProductData(string product);
        int GetActivityId(string activity);
    }
}
