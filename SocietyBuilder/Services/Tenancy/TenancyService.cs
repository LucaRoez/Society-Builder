using SocietyBuilder.Models.Population;
using SocietyBuilder.Models.Population.Interfaces;
using SocietyBuilder.Models.Spaces;
using SocietyBuilder.Models.Spaces.Interfaces;

namespace SocietyBuilder.Services.Tenancy
{
    public class TenancyService<T>
        where T : IPopulation, IPhysicalSpace
    {
        public T[] Inhabit(Population population, Area area)
        {
            MicroParcel center = area.NorthCenter.South.MicroParcels[new Random().Next(0,10)];
            T[] start = Inhabit(population, center);

            return start;
        }

        //private T[] Inhabit(Population population, MicroParcel microParcel)
        //{
        //    var states = population.States = new();
        //    var capabilities = population.Capabilities = new();
        //    var endurances = population.Endurances = new();
        //    var incomes = population.Incomes = new();

        //    capabilities.Add(microParcel, microParcel.Inhabitants * microParcel.ProductionPower);
        //    if (microParcel.BuildingKind == "Residency")
        //    {
        //        states.Add(microParcel, microParcel.States);
        //        endurances.Add(microParcel, microParcel.Endurances);
        //        incomes.Add(microParcel, microParcel.Incomes);
        //    }
        //}
    }
}
