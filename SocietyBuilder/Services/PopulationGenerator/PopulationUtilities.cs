using SocietyBuilder.Models.Population.Demography.Status;
using SocietyBuilder.Models.Population.Features;
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

        public static Necessity[] Necessities = new[]
        {
            new Necessity()
            {
                Name = "Feeding",
                Priority = 1,
                Level = 1
            },
            new Necessity()
            {
                Name = "Garment",
                Priority = 1,
                Level = 1
            },
            new Necessity()
            {
                Name = "Dwelling",
                Priority = 1,
                Level = 1
            },
            new Necessity()
            {
                Name = "Security",
                Priority = 1,
                Level = 1
            },
            new Necessity()
            {
                Name = "Knowledge",
                Priority = 1,
                Level = 1
            },
            new Necessity()
            {
                Name = "Energy",
                Priority = 1,
                Level = 1
            },
            new Necessity()
            {
                Name = "Social",
                Priority = 1,
                Level = 1
            },
            new Necessity()
            {
                Name = "Health",
                Priority = 1,
                Level = 1
            }
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
