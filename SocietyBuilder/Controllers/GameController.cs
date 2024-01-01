using Microsoft.AspNetCore.Mvc;
using SocietyBuilder.Models.Population;
using SocietyBuilder.Models.Population.Interfaces;
using SocietyBuilder.Models.Spaces;
using SocietyBuilder.Models.Spaces.Interfaces;
using SocietyBuilder.Services.RealEconomy;
using SocietyBuilder.Services.PhysicSpace;
using SocietyBuilder.Services.PopulationGenerator;
using SocietyBuilder.Services.Tenancy;
using System.Text.Json.Serialization;

namespace SocietyBuilder.Controllers
{
    [ApiController]
    public class GameController<T> : Controller
        where T : IPopulation, IPhysicalSpace
    {
        private readonly IPhysicConstructor _space;
        private readonly IPopulationGenerator _pop;
        private readonly ITenancyService _tenancy;
        private readonly IEconomicActivityService _activity;
        public GameController(IPhysicConstructor space, IPopulationGenerator pop, ITenancyService tenancy, IEconomicActivityService activity)
        {
            _space = space;
            _pop = pop;
            _tenancy = tenancy;
            _activity = activity;
        }
        [HttpGet]
        public OkResult NewGame(string difficult)
        {
            Area space = _pop.NewGame(difficult, _space.CreateNewArea());
            Area area = _tenancy.Inhabit(space);
            //_activity.SwitchTurn();

            return Ok();
        }
    }
}
