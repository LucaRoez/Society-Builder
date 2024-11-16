using SocietyBuilder.Models.Activity.Fabrication.Blacksmith;
using SocietyBuilder.Models.Activity.Fabrication.Chemical;
using SocietyBuilder.Models.Activity.Fabrication.Feeding;
using SocietyBuilder.Models.Activity.Fabrication.Harbor;
using SocietyBuilder.Models.Activity.Fabrication.Industry;
using SocietyBuilder.Models.Activity.Fabrication.Infrastructure;
using SocietyBuilder.Models.Activity.Fabrication.Manufacture;
using SocietyBuilder.Models.Activity.Fabrication.Purification;
using SocietyBuilder.Models.Activity.Fabrication.Refinery;
using SocietyBuilder.Models.Activity.Fabrication.Sawmill;
using SocietyBuilder.Models.Activity.Fabrication.Textile;
using SocietyBuilder.Models.Activity.Fabrication.WasteIndustry;
using SocietyBuilder.Models.Activity;
using SocietyBuilder.Models.Activity.Rough.Energy;
using SocietyBuilder.Models.Activity.Rough.Farming;
using SocietyBuilder.Models.Activity.Rough.Felling;
using SocietyBuilder.Models.Activity.Rough.Fishing;
using SocietyBuilder.Models.Activity.Rough.Gathering;
using SocietyBuilder.Models.Activity.Rough.Livestock;
using SocietyBuilder.Models.Activity.Rough.Minning;
using SocietyBuilder.Models.Activity.Rough.Water;
using SocietyBuilder.Models.Activity.Serving.Ciencie;
using SocietyBuilder.Models.Activity.Serving.Commerce;
using SocietyBuilder.Models.Activity.Serving.Culture;
using SocietyBuilder.Models.Activity.Serving.Education;
using SocietyBuilder.Models.Activity.Serving.Energy;
using SocietyBuilder.Models.Activity.Serving.Finance;
using SocietyBuilder.Models.Activity.Serving.Healthcare;
using SocietyBuilder.Models.Activity.Serving.Justice;
using SocietyBuilder.Models.Activity.Serving.Militia;
using SocietyBuilder.Models.Activity.Serving.Politic;
using SocietyBuilder.Models.Activity.Serving.Religion;
using SocietyBuilder.Models.Activity.Serving.Rental;
using SocietyBuilder.Models.Activity.Serving.Security;
using SocietyBuilder.Models.Activity.Serving.Services;
using SocietyBuilder.Models.Activity.Serving.Transportation;
using SocietyBuilder.Models.Population.Features;
using SocietyBuilder.Models.Population.Interfaces.IDemography;
using SocietyBuilder.Models.Production;
using SocietyBuilder.Models.Production.Raw.Maritime;

using SocietyBuilder.Services.UniversalServices;

namespace SocietyBuilder.Services.RealEconomy
{
    public static class ActivityUtilities
    {
        private static IExcelManager _excelManager => UniversalServiceProvider.ServiceProvider?.GetRequiredService<IExcelManager>();

        //  Real Objects
        private static readonly Dictionary<(int, int), Necessity> _NecessityList = new()
        {
            // Fedding
            { (1, 1), new Necessity(1, "Water", 1) }, { (1, 2), new Necessity(1.2f, "Feeding", 1) },
            { (1, 3), new Necessity(1, "Nutrition", 2) }, { (1, 4), new Necessity(1.5f, "FoodPlenty", 3) },
            { (1, 5), new Necessity(3, "FoodVariety", 4) }, { (1, 6), new Necessity(4, "FoodLuxury", 5) },
            { (1, 7), new Necessity(5, "Plastic", 6) },

            // Garment
            { (2, 1), new Necessity(1.8f, "Coat", 1) }, { (2, 2), new Necessity(1.2f, "Clothes", 2) },
            { (2, 3), new Necessity(1.5f, "Outfit", 3) }, { (2, 4), new Necessity(2, "GarmentPlenty", 4) },
            { (2, 5), new Necessity(2.5f, "GarmentVariety", 5) }, { (2, 6), new Necessity(3, "GarmentLuxury", 6) },
            { (2, 7), new Necessity(2, "Plastic", 7) },

            // Dwelling
            { (3, 1), new Necessity(2, "Shelter", 1) }, { (3, 2), new Necessity(1.5f, "Home", 2) },
            { (3, 3), new Necessity(2, "Extension", 3) }, { (3, 4), new Necessity(2.5f, "DwellingPlenty", 4) },
            { (3, 5), new Necessity(4, "DwellingLuxury", 5) }, { (3, 6), new Necessity(6, "Monumental", 6) },
            { (3, 7), new Necessity(5, "Plastic", 7) },

            // Security
            { (4, 1), new Necessity(2.2f, "Defense", 1) }, { (4, 2), new Necessity(2.5f, "Politics", 2) },
            { (4, 3), new Necessity(2, "Stability", 3) }, { (4, 4), new Necessity(1.5f, "Security", 4) },
            { (4, 5), new Necessity(1, "Reliance", 5) }, { (4, 6), new Necessity(2, "Insurance", 6) },
            { (4, 7), new Necessity(5, "Martial", 7) },

            // Knowledge
            { (5, 1), new Necessity(3, "Faith", 1) }, { (5, 2), new Necessity(2, "Awareness", 2) },
            { (5, 3), new Necessity(3.5f, "Science", 3) }, { (5, 4), new Necessity(5, "Complexity", 4) },
            { (5, 5), new Necessity(4, "Virtue", 5) }, { (5, 6), new Necessity(6, "Wisdom", 6) },
            { (5, 7), new Necessity(7, "Tolerance", 7) },

            // Energy
            { (6, 1), new Necessity(3.2f, "Heat", 1) }, { (6, 2), new Necessity(2, "Kinetic", 2) },
            { (6, 3), new Necessity(2, "Powerful", 3) }, { (6, 4), new Necessity(3, "EnergyPlenty", 4) },
            { (6, 5), new Necessity(4, "Steam", 5) }, { (6, 6), new Necessity(4, "Electricity", 6) },
            { (6, 7), new Necessity(4, "Fuel", 7) },

            // Social
            { (7, 1), new Necessity(1, "Clanship", 1) }, { (7, 2), new Necessity(1.5f, "Recreation", 2) },
            { (7, 3), new Necessity(2, "Moral", 3) }, { (7, 4), new Necessity(2.5f, "Instruction", 4) },
            { (7, 5), new Necessity(1.5f, "Syncretism", 5) }, { (7, 6), new Necessity(1, "Institution", 4) },
            { (7, 7), new Necessity(2, "SocialTolerance", 7) },

            // Health
            { (8, 1), new Necessity(5, "FirstAid", 1) }, { (8, 2), new Necessity(2.3f, "MedicalCare", 2) },
            { (8, 3), new Necessity(3, "ParticularCare", 3) }, { (8, 4), new Necessity(1.5f, "Surgery", 4) },
            { (8, 5), new Necessity(2.5f, "Hygiene", 5) }, { (8, 6), new Necessity(2, "PreventCare", 6) },
            { (8, 7), new Necessity(2, "Plastic", 7) }
        };

        private static readonly string[] _productNames = new string[1]
        {
            "SweetWater"
        };
        private static readonly Dictionary<string, Product> _ProductList = new()
        {
            { _productNames[0], new SweetWater(_productNames[0], _excelManager) }
        };

        //  Object Mapping
        private static Dictionary<SocialActivity[], (INiche, Product[])> _ActivityMap = new()
        {
            ////////////////////////////    Rough Stage    ////////////////////////////
            { new SocialActivity[] { new WaterIntake() }, new WaterSupplier() }, { new SocialActivity[] { new Hunting() }, new Hunter() },
            { new SocialActivity[] { new FruitsGathering(), new SeedsGathering(), new HerbsGathering() }, new Gatherer() },
            { new SocialActivity[] { new CoastalFishing(), new NearbyFishing(), new DistantFishing(), new DeepFishing() }, new Fisherman() },
            { new SocialActivity[] { new Livestock(), new BloodTractionBreeding() }, new Breeder() },
            { new SocialActivity[] { new FellingIndustry(), new RubberIndustry() }, new Woodsman()}, { new SocialActivity[] { new Sawmill() }, new Lumberman() },
            { new SocialActivity[] {new Farming(), new HerbsFarming(), new RubberIndustry() }, new Farmer() },
            { new SocialActivity[] { new ClayMining(), new Quarry(), new RockMining(), new MineralMining(), new MetalMining() }, new Miner() },
            { new SocialActivity[] { new HydraulicCompany(), new WindCompany(), new ElectricalCompany(), new OilCompany() }, new Engineer() },
            ////////////////////////////    Fabrication Stage    ////////////////////////////
            { new SocialActivity[] { new Destillery() }, new Distiller() }, { new[] { new Butchery() }, new AbattoirWorker() },
            { new SocialActivity[] { new Warehouse(), new Cellar() }, new Storekeeper() }, { new[] { new Mill() }, new Miller() },
            { new SocialActivity[] { new LowQualityTextile(), new HighQualityTextile(), new DecorTextile() }, new Weaver() },
            { new SocialActivity[] { new GarbageTreatmentPlant() , new GargabePit(), new SwagePit(), new SwageTreatmentPlant(), new Metallurgy(),
                new MineralRefinery(), new WaterTreatmentPlant() }, new Technician() }, { new SocialActivity[] { new Dock(), new Harbor() }, new Marine() },
            { new SocialActivity[] { new CheapestMetalsIndustry(), new IronIndustry(), new MostExpensiveMetalsIndustry(), new SteelIndustry() }, new Smith() },
            { new SocialActivity[] { new InfrastructureBuilding(), new SmallBuilding(), new MidBuilding(), new BigBuilding(), new MonumentalBuilding() },
                new Builder() }, { new[] { new WeaponFactory() }, new Gunsmith() }, { new[] { new ArtWorkshop() }, new Artist() },
            { new SocialActivity[] {  new ApplianceFactory(), new BoatFactory(), new CartsFactory(), new GadgetWorkshop(), new ToolFactory(),
                new UtensilsFactory() }, new Manufacturer() }, { new SocialActivity[] { new JewelryIndustry(), new GlassIndustry()}, new Jeweler() },
            { new SocialActivity[] { new TextileFactory(), new FabricIndustry(), new LeatherIndustry() }, new TextileWorker() },
            { new SocialActivity[] { new FurnitureFactory(), new DecorWorkshop() }, new Carpenter() }, { new[] { new ShoeFactory() }, new Shoemaker() },
            { new SocialActivity[] { new ConstructionMaterialsIndustry(), new PaperMill(), new CarIndustry(), new ShipIndustry(), new MotorIndustry(),
                new MachineIndustry(), new PlasticIndustry(), new PlaneIndustry()}, new Industrial() },
            { new SocialActivity[] { new BactericideIndustry(), new ChemicalsIndustry(), new FertilizerIndustry(), new PreservativesIndustry(),
                new ProtectorsIndustry(), new Pharmaceutical(), new DyeIndustry() }, new Chemist() },
            ////////////////////////////    Service Stage    ////////////////////////////
            { new SocialActivity[] { new ApplianceStore(), new Bazaar(), new CleaningStore(), new Dealership(), new FoodMarket(), new Shop(), new Store(),
                new FurnitureStore(), new Ironmongery(), new JewelryStore(), new Librery(), new Market(), new RealEstate() }, new Merchant() },
            { new SocialActivity[] { new HeatSupplier(), new EnergySupplier(), new LightingSupplier(), new CombustionSupplier() }, new EnergyRetailer() },
            { new SocialActivity[] { new Primary(), new Secondary(), new Academic() }, new Teacher() }, { new SocialActivity[] { new Creed() }, new Priest() },
            { new SocialActivity[] { new Basis(), new Intermediate(), new Advance(), new Sophisticated() }, new Researcher() },
            { new SocialActivity[] { new Basis(), new Intermediate(), new Advance(), new Sophisticated() }, new Theorist() },
            { new SocialActivity[] { new Civil(), new Commercial(), new Penal(), new Labor() }, new Judge() }, { new SocialActivity[] { new Pub() }, new Bartender() },
            { new SocialActivity[] { new Civil(), new Commercial(), new Penal(), new Labor() }, new Lawyer() }, { new SocialActivity[] { new Cleaning() }, new Cleaner() },
            { new SocialActivity[] { new SpecialForce(), new CivilIntelligence() }, new Agent() }, { new[] { new Restaurant() }, new Cook() },
            { new SocialActivity[] { new Patrol(), new Surveillance() }, new Guard() }, { new[] { new WasteRecolection() }, new WasteCollector() },
            { new SocialActivity[] { new Funding(), new Banking(), new Foundation() }, new Trader() }, { new SocialActivity[] { new MilitaryIntelligence() }, new Agent() },
            { new SocialActivity[] { new Patrol(), new Surveillance(), new SpecialForce() }, new Police() },
            { new SocialActivity[] { new Blood(), new Steam(), new Fosil() }, new Chauffeur() }, { new SocialActivity[] { new Medication() }, new Pharmacist() },
            { new SocialActivity[] { new MedicalCare(), new Sanitation(), new Surgery() }, new Doctor() }, { new SocialActivity[] { new Clerkship() }, new Clerk() },
            { new SocialActivity[] { new Folk(), new Popular(), new Elaborated(), new Avant_Garde() }, new Artist() },
            { new SocialActivity[] { new Landlord(), new HotelRental(), new ResidentialRental() }, new Holder() }, { new SocialActivity[] { new Army() }, new Soldier() },
            { new SocialActivity[] { new Assistance() }, new Assistant() }, { new SocialActivity[] { new Army() }, new Chevalier() }, { new SocialActivity[] { new AirForce() }, new Pilot() },
            { new SocialActivity[] { new Liberal(), new Conservative(), new Socialist(), new Nationalist(), new Outsider() }, new Politic() }
        };

        private static Dictionary<Necessity, Product[]> _SatietyMap = new()
        {
            { _NecessityList[(1, 1)], new Product[1] { _ProductList[_productNames[0]] } }
        };

        private static Dictionary<(Necessity, Product), SocialActivity> _UtilityMap = new()
        {
            { (_NecessityList[(1, 1)], new SweetWater()), new SocialActivity[] { new WaterIntake(), new WaterTreatmentPlant(), new InfrastructureBuilding() } },

            { (_NecessityList[(1, 2)], new), new SocialActivity[] { new Hunting(), new CoastalFishing(), new NearbyFishing(), new FruitsGathering(),
                new Butchery(), new Warehouse(), new UtensilsFactory() } },

            { (_NecessityList[(2, 1)], ), new SocialActivity[] { new SeedsGathering(), new LeatherIndustry(),
                new ShoeFactory(), new LowQualityTextile(), new TextileFactory() } },

            { (_NecessityList[(3, 1)], ), new SocialActivity[] { new FellingIndustry(), new ClayMining(), new Sawmill(),
                new MineralRefinery(), new ConstructionMaterialsIndustry(), new SmallBuilding(), new Landlord() } },

            { (_NecessityList[(4, 1)], ), new SocialActivity[] { new Patrol(), new Army(), new WeaponFactory(), new Basis() } },

            { (_NecessityList[(5, 1)], ), new[] { new Creed() } }, { _NecessityList[(7, 1)], new[] { new Folk() } },

            { (_NecessityList[(6, 1)], ), new SocialActivity[] { new FellingIndustry(), new Sawmill(), new ExtractionMining(),
                new Basis(), new SubstanceRefinery(), new HeatSupplier() } },

            { (_NecessityList[(1, 3)], ), new SocialActivity[] { new SeedsGathering(), new HerbsGathering(), new Farming(), new HerbsFarming(),
                new Livestock(), new FoodMarket(), new FellingIndustry(), new Sawmill(), new BoatFactory(), new CartsFactory(), new ToolFactory(),
                new MetalMining(), new Metallurgy(), new CheapestMetalsIndustry(), new Dock(), new ApplianceFactory(), new FurnitureFactory(),
                new Bazaar(), new ApplianceStore(), new FurnitureStore(), new Ironmongery(), new Store(), new Basis() } },

            { (_NecessityList[(2, 2)], ), new SocialActivity[] { new Farming(), new Livestock(), new ToolFactory(),
                new HighQualityTextile(), new Market() } },

            { (_NecessityList[(3, 2)], ), new SocialActivity[] { new Quarry(), new ExtractionMining(), new RockMining(), new MetalMining(),
                new Metallurgy(), new ToolFactory(), new MachineIndustry(), new IronIndustry(), new FurnitureFactory(), new FurnitureStore(),
                new ApplianceFactory(), new ApplianceStore(), new Basis(), new MidBuilding(), new InfrastructureBuilding(), new DecorWorkshop() } },

            { (_NecessityList[(7, 2)], ), new[] { new Popular() } },

            { (_NecessityList[(4, 2)], ), new SocialActivity[] { new Liberal(), new Conservative(), new Socialist(), new Nationalist(), new Outsider()} },

            { (_NecessityList[(5, 2)], ), new SocialActivity[] { new Basis(),new FellingIndustry(), new Sawmill(), new PaperMill(),
                new Printing(), new Editorial(), new Primary() } },

            { (_NecessityList[(8, 2)], ), new SocialActivity[] { new GargabePit(), new SwagePit(), new Basis(), new WasteRecolection(),
                new MedicalCare(), new Cleaning(), new Intermediate(), new ChemicalsIndustry() } },

            { (_NecessityList[(6, 2)], ), new SocialActivity[] { new BloodTractionBreeding(), new WindCompany(), new HydraulicCompany(),
                new MetalMining(), new Metallurgy(), new CheapestMetalsIndustry(), new IronIndustry(), new MachineIndustry(),
                new EnergySupplier(), new Blood(), new Intermediate() } },

            { (_NecessityList[(4, 3)], ), new SocialActivity[] { new Funding(), new Basis(), new Civil(), new Commercial(), new Penal(),
                new Clerkship(), new Assistance(), new MetalMining(), new MineralMining(), new MineralRefinery(),
                new Metallurgy(), new MostExpensiveMetalsIndustry(), new JewelryIndustry() } },

            { (_NecessityList[(1, 4)], ), new SocialActivity[] { new Mill(), new Destillery(), new Cellar(), new Intermediate(),
                new MachineIndustry(), new Harbor(), new DistantFishing(), new ChemicalsIndustry(), new Advance(),
                new FertilizerIndustry(), new PreservativesIndustry()} },

            { (_NecessityList[(2, 3)], ), new SocialActivity[] { new Basis(), new GadgetWorkshop(), new DecorTextile(),
                new FabricIndustry(), new Shop(), new Intermediate(), new MachineIndustry(), new DyeIndustry() } },

            { (_NecessityList[(3, 3)], ), new SocialActivity[] { new RealEstate(), new ResidentialRental(), new HotelRental(), new Intermediate(),
                new ProtectorsIndustry(), new GlassIndustry(), new BigBuilding(), } },

            { (_NecessityList[(8, 1)], ), new SocialActivity[] { new MedicalCare(), new Basis(), new HerbsGathering(), new HerbsFarming(),
                new Sanitation(), new Medication(), new Intermediate(), new ToolFactory() } },

            { (_NecessityList[(4, 4)], ), new SocialActivity[] { new Intermediate(), new MetalMining(), new Metallurgy(), new IronIndustry(),
                new MineralMining(), new MineralRefinery(), new Shop(), new Harbor(), new Navy(), new Surveillance() } },

            { (_NecessityList[(7, 3)], ), new SocialActivity[] { new Elaborated(), new Pub() } },

            { (_NecessityList[(5, 3)], ), new SocialActivity[] { new Intermediate(), new Secondary() } },

            { (_NecessityList[(6, 3)], ), new SocialActivity[] { new Advance(), new MineralMining(), new MineralRefinery(), new FellingIndustry(),
                new Sawmill(), new MotorIndustry(), new MachineIndustry(), new TrainIndustry(), new ShipIndustry(), new CarIndustry(), new Steam() } },

            { (_NecessityList[(4, 5)], ), new SocialActivity[] { new Banking(), new Intermediate(), new Foundation() } },

            { (_NecessityList[(8, 4)], ), new SocialActivity[] { new Surgery(), new Advance(), new MachineIndustry() } },

            { (_NecessityList[(2, 4)], ), new[] { new Advance() } },

            { (_NecessityList[(3, 4)]), ), new[] { new Advance() } },

            { (_NecessityList[(5, 5)], ), new SocialActivity[] { new Academic() } },

            { (_NecessityList[(4, 6)], ), new[] { new Insurance() } },

            { (new Necessity(32, "ArmedDefense"), ), new SocialActivity[] { new Advance(), new MachineIndustry(), new MilitaryIntelligence() } },

            { (_NecessityList[(7, 4)], ), new SocialActivity[] { new Avant_Garde(), new Restaurant() } },

            { (_NecessityList[(6, 6)], ), new SocialActivity[] { new Sophisticated(), new ElectricalCompany(),
                new InfrastructureBuilding(), new LightingSupplier() } },

            { (_NecessityList[(1, 6)], ), new SocialActivity[] { new Sophisticated(), new BactericideIndustry(), new Pharmaceutical() } },

            { (_NecessityList[(2, 6)], ), new[] { new Sophisticated() } },

            { _NecessityList[(3, 5)], ), new[] { new Sophisticated() } },

            { (_NecessityList[(8, 5)], ), new[] { new Sophisticated() } },

            { (_NecessityList[(5, 6)], ), new SocialActivity[] { new Advance(), new PlaneIndustry() } },

            { (_NecessityList[(3, 6)], ), new[] { new MonumentalBuilding() } },

            { (_NecessityList[(5, 7)], ), new[] { new Sophisticated() } },

            { (_NecessityList[(6, 7)], ), new SocialActivity[] { new OilCompany(), new SubstanceRefinery(), new MotorIndustry(),
                new MachineIndustry(), new CarIndustry(), new ShipIndustry(), new TrainIndustry(), new PlaneIndustry(), new Fosil(), } },

            { (new Necessity(43, "Latex"), ), new SocialActivity[] { new OilCompany(), new SubstanceRefinery(), new LatexIndustry() } },

            { (new Necessity(44, "Plastic"), ), new SocialActivity[] { new OilCompany(), new SubstanceRefinery(), new PlasticIndustry() }
        };

        public static (Necessity, SocialActivity) FindUtility(int productId)
        {
            Necessity relatedNeed = _SatietyMap.FirstOrDefault(utilityMap => utilityMap.Value.Any(p => p.Id == productId)).Key;
            Product? productChosen = _SatietyMap.FirstOrDefault(utilityMap => utilityMap.Value.Any(p => p.Id == productId))
                .Value.FirstOrDefault(p => p.Id == productId);
            SocialActivity relatedActivity = _UtilityMap.FirstOrDefault(map => map.Key.Item2.Equals(productChosen)).Value;
            return (relatedNeed, relatedActivity);
        }
        public static INiche FindJob(Product product, SocialActivity activity) => _ActivityMap.FirstOrDefault(activityMap =>
            activityMap.Key.Any(a => a.Id == activity.Id) && activityMap.Value.Item2.Any(p => p.Id == product.Id)
        ).Value.Item1;
    }
}
