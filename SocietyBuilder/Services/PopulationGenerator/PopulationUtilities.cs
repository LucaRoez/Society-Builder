using SocietyBuilder.Models.Population.Demography.Status;
using SocietyBuilder.Models.Population.Elements;
using SocietyBuilder.Models.Population.Interfaces.IDemography;
using SocietyBuilder.Models.Population.Interfaces.ISociologic;
using SocietyBuilder.Models.Population.Sociologic.Class;

namespace SocietyBuilder.Services.PopulationGenerator
{
    public static class PopulationUtilities
    {
                                    // multiplicator, modificator
        public static Dictionary<IClass, (double, double)> SocialClass = new()
        {
            { new Worker(), (1, 0) },
            { new Owners(), (1, 1) },
            { new Capitalist(), (1, 0) }
        };
                                        // mult., mod.
        public static Dictionary<IStatus, (double, double)> SocialStatus = new()
        {
            { new Pauper(), (0, 0) },
            { new Poor(), (100, 300) },
            { new Professionals(), (1000, 500) },
            { new Wealthies(), (5000, 1000) },
            { new Richs(), (10000, 40000) },
            { new Elites(), (100000, 500000) }
        };
        public static string[] States = new[]
        {
            "Lived", "Thirsty", "Hungry", "Ravenous", "Starving",                   //  Basics
            "High Defense", "Fragile", "Sick", "Aggravated", "Grave", "Terminal",   //  Health
            "Stripped Off", "Uncover", "Cooled", "Hypothermia", "Dead",             //  Cover
            "Tired", "Exausted", "Drained", "Spent",                                //  Forsake
            "Upset", "Frustrated", "Annoyed", "Vexed", "Angry", "Subversive"        //  Temper
        };
        public static KeyValuePair<Necessity, AggregateDemand>[] RelativeNeeds = new[]
        {
            new KeyValuePair<Necessity, AggregateDemand>(new(1, "Water"), new(1, "Feeding", false)),
            new KeyValuePair<Necessity, AggregateDemand>(new(2, "Feed"), new(1, "Feeding", true)),
            new KeyValuePair<Necessity, AggregateDemand>(new(3, "Garment"), new(1, "Coat", true)),
            new KeyValuePair<Necessity, AggregateDemand>(new(4, "Dwelling"), new(1, "Shelter", false)),
            new KeyValuePair<Necessity, AggregateDemand>(new(5, "Security"), new(1, "Defense", false)),
            new KeyValuePair<Necessity, AggregateDemand>(new(6, "Knowledge"), new(1, "Faith", true)),
            new KeyValuePair<Necessity, AggregateDemand>(new(7, "Energy"), new(1, "Heat", false)),
            new KeyValuePair<Necessity, AggregateDemand>(new(8, "Social"), new(1, "Amusement", true)),
            new KeyValuePair<Necessity, AggregateDemand>(new(1, "Feed"), new(2, "Nutrition", true)),
            new KeyValuePair<Necessity, AggregateDemand>(new(2, "Garment"), new(2, "Clothes", false)),
            new KeyValuePair<Necessity, AggregateDemand>(new(3, "Dwelling"), new(2, "Homely", false)),
            new KeyValuePair<Necessity, AggregateDemand>(new(4, "Social"), new(2, "Recreation", false)),
            new KeyValuePair<Necessity, AggregateDemand>(new(5, "Security"), new(3, "Politics", false)),
            new KeyValuePair<Necessity, AggregateDemand>(new(6, "Knowledge"), new(2, "Reasoning", true)),
            new KeyValuePair<Necessity, AggregateDemand>(new(7, "Health"), new(2, "Hygiene", true)),
            new KeyValuePair<Necessity, AggregateDemand>(new(8, "Energy"), new(2, "Energy", false)),
            new KeyValuePair<Necessity, AggregateDemand>(new(9, "Security"), new(2, "Stability", true)),
            new KeyValuePair<Necessity, AggregateDemand>(new(1, "Feed"), new(3, "Food Plenty", false)),
            new KeyValuePair<Necessity, AggregateDemand>(new(2, "Garment"), new(3, "Outfit", false)),
            new KeyValuePair<Necessity, AggregateDemand>(new(3, "Dwelling"), new(3, "Coverage", false)),
            new KeyValuePair<Necessity, AggregateDemand>(new(4, "Health"), new(3, "Medical Attention", true)),
            new KeyValuePair<Necessity, AggregateDemand>(new(5, "Security"), new(3, "Security", false)),
            new KeyValuePair<Necessity, AggregateDemand>(new(6, "Social"), new(3, "Syncretism", false)),
            new KeyValuePair<Necessity, AggregateDemand>(new(7, "Knowledge"), new(3, "Cience", true)),
            new KeyValuePair<Necessity, AggregateDemand>(new(8, "Energy"), new(3, "Steam", false)),
            new KeyValuePair<Necessity, AggregateDemand>(new(1, "Security"), new(4, "Reliance", false)),
            new KeyValuePair<Necessity, AggregateDemand>(new(2, "Health"), new(4, "Surgeries", false)),
            new KeyValuePair<Necessity, AggregateDemand>(new(3, "Garment"), new(4, "Vestment Plenty", false)),
            new KeyValuePair<Necessity, AggregateDemand>(new(4, "Dwelling"), new(4, "Building Plenty", false)),
            new KeyValuePair<Necessity, AggregateDemand>(new(5, "Knowledge"), new(4, "Virtue", true)),
            new KeyValuePair<Necessity, AggregateDemand>(new(6, "Security"), new(4, "Insurance", false)),
            new KeyValuePair<Necessity, AggregateDemand>(new(8, "Security"), new(4, "Armed Defense", false)),
            new KeyValuePair<Necessity, AggregateDemand>(new(9, "Social"), new(4, "Institutionality", true)),
            new KeyValuePair<Necessity, AggregateDemand>(new(1, "Energy"), new(5, "Electricity", false)),
            new KeyValuePair<Necessity, AggregateDemand>(new(2, "Basics"), new(5, "Luxury", false)),
            new KeyValuePair<Necessity, AggregateDemand>(new(3, "Knowledge"), new(5, "Wisdom", false)),
            new KeyValuePair<Necessity, AggregateDemand>(new(4, "Dwelling"), new(5, "Monumental", false)),
            new KeyValuePair<Necessity, AggregateDemand>(new(5, "Knowledge"), new(5, "Tolerance", false)),
            new KeyValuePair<Necessity, AggregateDemand>(new(6, "Energy"), new(5, "Fusel Oil", false)),
            new KeyValuePair<Necessity, AggregateDemand>(new(7, "Garment"), new(5, "Latex", false)),
            new KeyValuePair<Necessity, AggregateDemand>(new(8, "Basics"), new(5, "Plastic", false)),
        };
        public static Dictionary<Necessity, AggregateDemand> Satities = new()
        {
            { new(1, "Water"), new(1, "Feeding", false) },
            { new(2, "Feed"), new(1, "Feeding", true) },
            { new(3, "Security"), new(1, "Defense", false) },
            { new(4, "Garment"), new(1, "Coat", true) },
            { new(5, "Dwelling"), new(1, "Shelter", false) },
            { new(6, "Knowledge"), new(1, "Faith", true) },
            { new(7, "Energy"), new(1, "Heat", false) },
            { new(8, "Social"), new(1, "Amusement", true) }
        };
        public static Dictionary<string, double> Endurance = new()
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


        internal static IStatus SetSocialStatus(string socialStatus)
        {
            return (IStatus)SocialStatus.Where(sc => sc.Key.Name == socialStatus);
        }

        public static (double capital, double capability) SetCapabilities(string socialStatus)
        {
            var status = SocialStatus.FirstOrDefault(ss => ss.Key.Name.Equals(socialStatus));
            return ((1 * status.Value.Item1) + status.Value.Item2, 1);
        }
    }
}
