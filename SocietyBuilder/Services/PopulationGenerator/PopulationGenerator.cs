using SocietyBuilder.Models.Population;
using SocietyBuilder.Models.Population.Features;
using SocietyBuilder.Models.Population.Sociologic.Class;
using SocietyBuilder.Models.Spaces;
using System.Linq;

namespace SocietyBuilder.Services.PopulationGenerator
{
    public class PopulationGenerator : IPopulationGenerator
    {
        public Region NewGame(string difficult, Region area)
        {
            switch (difficult)
            {
                case "For Fools": area = PopulatePop(100, "Wealthies", area); break;
                case "Easy": area = PopulatePop(100, "Richs", area); break;
                case "Normal": area = PopulatePop(100, "Proffessionals", area); break;
                case "Hard": area = PopulatePop(100, "Poor", area); break;
                case "For Thorough People": area = PopulatePop(100, "Pauper", area); break;
                default: area = PopulatePop(100, "Poor", area); break;
            }

            return area;
        }

        private Region PopulatePop(int quantity, string socialStatus, Region area)
        {
            var parcels = area.NorthCenter.South.Parcels;
            int i = 0;
            while (i < quantity)
            {
                foreach (Parcel parcel in parcels)
                {
                    if (parcel != null)
                    {
                        Citizen citizen = new()
                        {
                            KnownPlaces = new() { parcel.Ken() },
                            Satieties = new()
                        };
                        foreach (Necessity necessity in PopulationUtilities.Necessities)
                        {
                            citizen.Satieties.Add(new(necessity, 0));
                        }

                        parcel.Inhabitants += 1; i++;
                        parcel.Population.Append(citizen);
                        continue;
                    }
                }
            }
            return area;
        }
    }
}
