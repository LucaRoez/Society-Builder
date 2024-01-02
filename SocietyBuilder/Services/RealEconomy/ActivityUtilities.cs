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
using SocietyBuilder.Models.Activity.Interfaces;
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
using SocietyBuilder.Models.Population.Demography.Niche;
using SocietyBuilder.Models.Population.Elements;
using SocietyBuilder.Models.Population.Interfaces.IDemography;

namespace SocietyBuilder.Services.RealEconomy
{
    public static class ActivityUtilities
    {
        private static Dictionary<IActivity[], INiche> ActivityTable = new()
        {
            ////////////////////////////    Rough Stage    ////////////////////////////
            { new[] { new WaterIntake() }, new WaterSupplier() }, { new[] { new Hunting() }, new Hunter() },
            { new IActivity[] { new FruitsGathering(), new SeedsGathering(), new HerbsGathering() }, new Gatherer() },
            { new IActivity[] { new CoastalFishing(), new NearbyFishing(), new DistantFishing(), new DeepFishing() }, new Fisherman() },
            { new IActivity[] { new Livestock(), new BloodTractionBreeding() }, new Breeder() },
            { new IActivity[] { new FellingIndustry(), new RubberIndustry() }, new Woodsman()}, { new[] { new Sawmill() }, new Lumberman() },
            { new IActivity[] {new Farming(), new HerbsFarming(), new RubberIndustry() }, new Farmer() },
            { new IActivity[] { new ClayMining(), new Quarry(), new RockMining(), new MineralMining(), new MetalMining() }, new Miner() },
            { new IActivity[] { new HydraulicCompany(), new WindCompany(), new ElectricalCompany(), new OilCompany() }, new Engineer() },
            ////////////////////////////    Fabrication Stage    ////////////////////////////
            { new[] { new Destillery() }, new Distiller() }, { new[] { new Butchery() }, new AbattoirWorker() },
            { new IActivity[] { new Warehouse(), new Cellar() }, new Storekeeper() }, { new[] { new Mill() }, new Miller() },
            { new IActivity[] { new LowQualityTextile(), new HighQualityTextile(), new DecorTextile() }, new Weaver() },
            { new IActivity[] { new GarbageTreatmentPlant() , new GargabePit(), new SwagePit(), new SwageTreatmentPlant(), new Metallurgy(),
                new MineralRefinery(), new WaterTreatmentPlant() }, new Technician() }, { new IActivity[] { new Dock(), new Harbor() }, new Marine() },
            { new IActivity[] { new CheapestMetalsIndustry(), new IronIndustry(), new MostExpensiveMetalsIndustry(), new SteelIndustry() }, new Smith() },
            { new IActivity[] { new InfrastructureBuilding(), new SmallBuilding(), new MidBuilding(), new BigBuilding(), new MonumentalBuilding() },
                new Builder() }, { new[] { new WeaponFactory() }, new Gunsmith() }, { new[] { new ArtWorkshop() }, new Artist() },
            { new IActivity[] {  new ApplianceFactory(), new BoatFactory(), new CartsFactory(), new GadgetWorkshop(), new ToolFactory(),
                new UtensilsFactory() }, new Manufacturer() }, { new IActivity[] { new JewelryIndustry(), new GlassIndustry()}, new Jeweler() },
            { new IActivity[] { new TextileFactory(), new FabricIndustry(), new LeatherIndustry() }, new TextileWorker() },
            { new IActivity[] { new FurnitureFactory(), new DecorWorkshop() }, new Carpenter() }, { new[] { new ShoeFactory() }, new Shoemaker() },
            { new IActivity[] { new ConstructionMaterialsIndustry(), new PaperMill(), new CarIndustry(), new ShipIndustry(), new MotorIndustry(),
                new MachineIndustry(), new PlasticIndustry(), new PlaneIndustry()}, new Industrial() },
            { new IActivity[] { new BactericideIndustry(), new ChemicalsIndustry(), new FertilizerIndustry(), new PreservativesIndustry(),
                new ProtectorsIndustry(), new Pharmaceutical(), new DyeIndustry() }, new Chemist() },
            ////////////////////////////    Service Stage    ////////////////////////////
            { new IActivity[] { new ApplianceStore(), new Bazaar(), new CleaningStore(), new Dealership(), new FoodMarket(), new Shop(), new Store(),
                new FurnitureStore(), new Ironmongery(), new JewelryStore(), new Librery(), new Market(), new RealEstate() }, new Merchant() },
            { new IActivity[] { new HeatSupplier(), new EnergySupplier(), new LightingSupplier(), new CombustionSupplier() }, new EnergyRetailer() },
            { new IActivity[] { new Primary(), new Secondary(), new Academic() }, new Teacher() }, { new[] { new Creed() }, new Priest() },
            { new IActivity[] { new Basis(), new Intermediate(), new Advance(), new Sophisticated() }, new Researcher() },
            { new IActivity[] { new Basis(), new Intermediate(), new Advance(), new Sophisticated() }, new Theorist() },
            { new IActivity[] { new Civil(), new Commercial(), new Criminal(), new Labor() }, new Judge() }, { new [] { new Pub() }, new Bartender() },
            { new IActivity[] { new Civil(), new Commercial(), new Criminal(), new Labor() }, new Lawyer() }, { new[] { new Cleaning() }, new Cleaner() },
            { new IActivity[] { new SpecialForce(), new CivilIntelligence() }, new Agent() }, { new[] { new Restaurant() }, new Culinary() },
            { new IActivity[] { new Patrol(), new Surveillance() }, new Guard() }, { new[] { new WasteRecolection() }, new WasteCollector() },
            { new IActivity[] { new Funding(), new Banking(), new Foundation() }, new Trader() }, { new[] { new MilitaryIntelligence() }, new Agent() },
            { new IActivity[] { new Patrol(), new Surveillance(), new SpecialForce() }, new Police() },
            { new IActivity[] { new Blood(), new Steam(), new Fosil() }, new Chauffeur() }, { new[] { new Medication() }, new Pharmacist() },
            { new IActivity[] { new MedicalCare(), new Sanitation(), new Surgery() }, new Doctor() }, { new[] { new Clerkship() }, new Clerk() },
            { new IActivity[] { new Folk(), new Popular(), new Elaborated(), new Avant_Garde() }, new Artist() },
            { new IActivity[] { new Landlord(), new HotelRental(), new ResidentialRental() }, new Holder() }, { new[] { new Army() }, new Soldier() },
            { new[] { new Assistance() }, new Assistant() }, { new[] { new Army() }, new Chevalier() }, { new[] { new AirForce() }, new Pilot() },
            { new IActivity[] { new Centrism(), new Right_Wing(), new Left_Wing(), new ThirdForce(), new Relegated() }, new Politic() }
        };
        private static readonly (string, string)[] NecessitiesMap = new[]
        {
            ("Water","Feed"), ("Feeding","Feed"), ("Nutrition","Feed"), ("Plenty","Feed"),
            ("Coat","Garment"), ("Clothes","Garment"), ("Outfit","Garment"), ("Plenty","Garment"),
            ("Shelter","Dwelling"), ("Homely","Dwelling"), ("Coverage","Dwelling"), ("Plenty","Dwelling"), ("Monumental","Dwelling"),
            ("Defense","Security"), ("Politics","Security"), ("Stability","Security"), ("Security","Security"), ("Reliance","Security"), ("Insurance","Security"), ("Armed Defense","Security"),
            ("Faith","Knowledge"), ("Reasoning","Knowledge"), ("Cience","Knowledge"), ("Virtue","Knowledge"), ("Wisdom","Knowledge"), ("Tolerance","Knowledge"),
            ("Heat","Energy"), ("Energy","Energy"), ("Steam","Energy"), ("Electricyty","Energy"), ("Fusel Oil","Energy"),
            ("Amusement","Social"), ("Recreation","Social"), ("Syncretism","Social"), ("Institutionality","Social"),
            ("Hygiene","Health"), ("Medical Attention","Health"), ("Surgeries","Health"), ("Luxury","Basics")
        };
        private static Dictionary<IActivity[], Necessity> SatietyMap = new()
        {
            { new IActivity[] { new WaterIntake(), new WaterTreatmentPlant(), new InfrastructureBuilding() }, new Necessity(1, "Water") },
            { new IActivity[] { new Hunting(), new CoastalFishing(), new NearbyFishing(), new FruitsGathering(), new Butchery(),
                new Warehouse() }, new Necessity(2, "Feeding") },
            { new IActivity[] { new SeedsGathering(), new LeatherIndustry(), new LowQualityTextile() }, new Necessity(3, "Coat") },
            { new IActivity[] { new FellingIndustry(), new ClayMining(), new Sawmill(), new MineralRefinery(), new ConstructionMaterialsIndustry(),
                new SmallBuilding(), new Landlord() }, new Necessity(4, "Shelter") },
            { new IActivity[] { new Patrol(), new Army(), new WeaponFactory(), new Basis() }, new Necessity(5, "Defense") },
            { new IActivity[] { new FellingIndustry(), new Sawmill(), new HeatSupplier() }, new Necessity(6, "Heat") },
            { new[] { new Creed() }, new Necessity(7, "Faith") }, { new[] { new Folk() }, new Necessity(8, "Amusement") },
            { new IActivity[] { new SeedsGathering(), new HerbsGathering(), new Farming(), new HerbsFarming(), new Livestock(), new FoodMarket(),
                new FellingIndustry(), new Sawmill(), new BoatFactory(), new CartsFactory(), new ToolFactory(), new MetalMining(), new Metallurgy(),
                new CheapestMetalsIndustry(), new UtensilsFactory(), new Dock(), new ApplianceFactory(), new FurnitureFactory(), new Bazaar(),
                 new ApplianceStore(), new FurnitureStore(), new Ironmongery(), new Store(), new Basis() }, new Necessity(9, "Nutrition") },
            { new IActivity[] { new Farming(), new Livestock(), new HighQualityTextile(), new TextileFactory(),
                new ShoeFactory(), new Market() }, new Necessity(10, "Clothes") },
            { new IActivity[] { new Quarry(), new ExtractionMining(), new RockMining(), new MetalMining(), new Metallurgy(), new ToolFactory(),
                new MachineIndustry(), new IronIndustry(), new FurnitureFactory(), new FurnitureStore(), new ApplianceFactory(), new ApplianceStore(),
                new Basis(), new MidBuilding(), new InfrastructureBuilding(), new DecorWorkshop() }, new Necessity(11, "Homely") },
            { new[] { new Popular() }, new Necessity(12, "Recreation") }, { new IActivity[] { new }, new Necessity(21, "Politics") },
            { new IActivity[] { new Basis(), new FellingIndustry(), new Sawmill(), new PaperMill(), new Printing(), new Editorial(),
                new Primary() }, new Necessity(13, "Reasoning") },
            { new IActivity[] { new Basis(), new MedicalCare(), new Cleaning(), new Intermediate(), new ChemicalsIndustry() }, new Necessity(14, "Hygiene") },
            { new IActivity[] { new BloodTractionBreeding(), new WindCompany(), new HydraulicCompany(), new MetalMining(), new Metallurgy(),
                new CheapestMetalsIndustry(), new IronIndustry(), new MachineIndustry(), new EnergySupplier() }, new Necessity(15, "Energy") },
            { new IActivity[] { new Funding(), new Civil(), new Commercial(), new Criminal(), new Clerkship(), new Assistance(),
                new MetalMining(), new MineralMining(), new MineralRefinery(), new Metallurgy(), new MostExpensiveMetalsIndustry(),
                new JewelryIndustry() }, new Necessity(16, "Stability") },
            { new IActivity[] { new Mill(), new Destillery(), new Cellar(), new Intermediate(), new MachineIndustry(), new Harbor(), new DistantFishing(),
                new ChemicalsIndustry(), new Advance(), new FertilizerIndustry(), new PreservativesIndustry()}, new Necessity(17, "Food Plenty") },
            { new IActivity[] { new Basis(), new GadgetWorkshop(), new DecorTextile(), new FabricIndustry(), new Shop(),
                new Intermediate(), new DyeIndustry() }, new Necessity(18, "Outfit") },
            { new IActivity[] { new RealEstate(), new ResidentialRental(), new HotelRental(), new Intermediate(),
                new ProtectorsIndustry(), new GlassIndustry(), new BigBuilding(), }, new Necessity(19, "Coverage") },
            { new IActivity[] { new MedicalCare(), new Basis(), new HerbsGathering(), new HerbsFarming(), new Sanitation(), new Medication(),
                new Intermediate(), new ToolFactory(), new Surgery(), new Advance() }, new Necessity(20, "Medical Attention") },
            { new IActivity[] { new Intermediate(), new MetalMining(), new Metallurgy(), new IronIndustry(), new MineralMining(), new MineralRefinery(),
                new Shop(), new Harbor(), new Navy(), new Surveillance() }, new Necessity(21, "Security") },
            { new IActivity[] { new }, new Necessity(21, "Syncretism") },
        };

        public static INiche SearchActivity(KeyValuePair<Necessity, AggregateDemand> needToSatisfy)
        {

            KeyValuePair<IActivity[], INiche> activityProvider = ActivityTable.Where(a => a.Value.Name????)
        }
    }
}
