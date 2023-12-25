using SocietyBuilder.Models.Population;
using SocietyBuilder.Models.Population.Interfaces;
using SocietyBuilder.Models.Spaces;
using SocietyBuilder.Models.Spaces.Interfaces;

namespace SocietyBuilder.Services.Tenancy
{
    public class TenancyService<T>
        where T : IPopulation, IPhysicalSpace
    {
        public T[] FirstContact(Population population, Area area)
        {
            Parcel center = area.CenterNorth.South;
            var dwelling = Inhabit(population, center);
        }

        private object Inhabit(Population population, Parcel center)
        {
            throw new NotImplementedException();
        }
    }
}
