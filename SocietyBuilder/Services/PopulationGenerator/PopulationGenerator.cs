﻿using SocietyBuilder.Models.Population;
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
            var parcels = area.NorthCenter.South.MicroParcels;
            int i = 0;
            while (i < quantity)
            {
                foreach (Parcel littleParcel in parcels)
                {
                    if (littleParcel != null)
                    {
                        Citizen pop = new();
                        pop.Location = littleParcel;
                        pop.SocialClass = new Owners();
                        pop.SocialStatus = PopulationUtilities.SetSocialStatus(socialStatus);
                        (double capital, double capability) = PopulationUtilities.SetCapabilities(socialStatus);
                        pop.Capabilities = capability;
                        pop.Capital = capital;

                        pop.States = PopulationUtilities.States;
                        pop.Satieties = PopulationUtilities.Satities;
                        pop.Endurances = PopulationUtilities.Endurance;

                        littleParcel.Inhabitants += 1; i++;
                        littleParcel.Population.Append(pop);
                        continue;
                    }
                }
            }
            return area;
        }
    }
}
