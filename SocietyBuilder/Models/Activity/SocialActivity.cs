using SocietyBuilder.Models.Activity.Interfaces;
using SocietyBuilder.Models.Population.Interfaces.IDemography;
using SocietyBuilder.Models.Production;
using SocietyBuilder.Services.RealEconomy;
using SocietyBuilder.Services.UniversalServices;

namespace SocietyBuilder.Models.Activity
{
    public abstract class SocialActivity : IActivity
    {
        public int Id { get; }
        private readonly IExcelManager _excelManager;

        public SocialActivity(string name, IExcelManager excelManager)
        {
            Id = GetId(name);
            _excelManager = excelManager;
        }

        internal int GetId(string name) => _excelManager.GetActivityId(name);
        public INiche GetNiche(Product product) => ActivityUtilities.FindJob(product, this);
    }
}
