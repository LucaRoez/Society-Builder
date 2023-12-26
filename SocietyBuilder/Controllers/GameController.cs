using Microsoft.AspNetCore.Mvc;
using SocietyBuilder.Models.Population;
using SocietyBuilder.Models.Population.Interfaces;
using SocietyBuilder.Models.Spaces;
using SocietyBuilder.Models.Spaces.Interfaces;
using SocietyBuilder.Services.PhysicSpace;
using SocietyBuilder.Services.Tenancy;
using System.Text.Json.Serialization;

namespace SocietyBuilder.Controllers
{
    [ApiController]
    public class GameController<T> : Controller
        where T : IPopulation, IPhysicalSpace
    {
        private readonly ITenancyService _tenancy;
        private readonly IPhysicConstructor _space;
        public GameController(ITenancyService tenancy, IPhysicConstructor space)
        {
            _tenancy = tenancy;
            _space = space;
        }
        [HttpGet]
        public OkResult NewGame()
        {
            (Area area, Population pop) = _tenancy.Inhabit(new Population(), _space.CreateNewArea());

            return Ok();
        }
    }
}
