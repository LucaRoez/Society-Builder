using SocietyBuilder.Models.Activity.Interfaces;
using SocietyBuilder.Models.Population;
using SocietyBuilder.Models.Spaces;

namespace SocietyBuilder.Services.PopulationGenerator
{
    public static class PopulationUtilities
    {
        public static string[] States = new[]
        {
            "Lived", "Thirsty", "Hungry", "Ravenous", "Starving",
            "High Defense", "Fragile", "Sick", "Aggravated", "Grave", "Terminal",
            "Stripped Off", "Uncover", "Cooled", "Hypothermia", "Dead",
            "Tired", "Exausted", "Drained", "Spent",
            "Upset", "Frustrated", "Annoyed", "Vexed", "Angry", "Subversive"
        };
        public static Dictionary<string, Dictionary<string, int>> Satities = new()
        {
            { "Water", new(){ { "Feeding", 1 } } },
            { "Feed", new(){ { "Feeding", 1 } } },
            { "Cover", new(){ { "Cover", 1 } } },
            { "Dwelling", new(){ { "Shelter", 1 } } },
            { "Energy", new(){ { "Heat", 1 } } },
            { "Social", new(){ { "Amusement", 1 } } },
            { "Security", new(){ { "Stability", 1 } } },
            { "Knowledge", new(){ { "Faith", 1 } } }
        };
        public static Dictionary<string, int> Endurance = new()
        {
            { "Water", 0 },
            { "Feed", 0 },
            { "Health", 0 },
            { "Cover", 0 },
            { "Dwelling", 0 },
            { "Energy", 0 },
            { "Social", 0 },
            { "Security", 0 },
            { "Knowledge", 0 }
        };


        public static Population SetCapabilities(string socialStatus, MicroParcel microParcel)
        {
            Population pop = new();
            switch (socialStatus)
            {
                case "Poor": pop.Capabilities.Add(microParcel, 1 * 1); break;
                case "Proffessionals": pop.Capabilities.Add(microParcel, 1 * 10); break;
                default: pop.Capabilities.Add(microParcel, 1 * 1000); break;
            }

            return pop;            
        }
    }
}
