using SocietyBuilder.Models.Spaces;
using SocietyBuilder.Services.PhysicSpace;
using SocietyBuilder.Services.PopulationGenerator;
using SocietyBuilder.Services.RealEconomy;
using SocietyBuilder.Services.Tenancy;

namespace SocietyBuilder.Services.GameCore
{
    public class GameCore : IGameCore
    {
        private readonly IPhysicConstructor _space;
        private readonly IPopulationGenerator _pop;
        private readonly ITenancyService _tenancy;
        private readonly IEconomicActivityService _activity;
        public GameCore(IPhysicConstructor space, IPopulationGenerator pop, ITenancyService tenancy, IEconomicActivityService activity)
        {
            _space = space;
            _pop = pop;
            _tenancy = tenancy;
            _activity = activity;
        }

        public void NewGame(string difficult)
        {
            Region space = _pop.NewGame(difficult, _space.CreateNewRegion());
            Region region = _tenancy.Inhabit(space);
            _activity.CommandActivity(region);
            //_activity.SwitchTurn();
        }
    }
}
