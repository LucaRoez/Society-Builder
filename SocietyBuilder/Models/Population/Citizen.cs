using SocietyBuilder.Models.Activity.Interfaces;
using SocietyBuilder.Models.Population.Features;
using SocietyBuilder.Models.Population.Interfaces;
using SocietyBuilder.Models.Population.Interfaces.IDemography;
using SocietyBuilder.Models.Population.Interfaces.ISociologic;
using SocietyBuilder.Models.Production;
using SocietyBuilder.Models.Production.Interfaces.IManufactured.Shared;
using SocietyBuilder.Models.Spaces;
using SocietyBuilder.Services.PopulationGenerator;
using System.Linq;

namespace SocietyBuilder.Models.Population
{
    public class Citizen : IPopulation
    {
        public string Name { get; }
        public IAge Age { get; set; }
        public Parcel Location { get; set; }
        public Parcel Home { get; set; }
        public List<Parcel> KnownPlaces { get; set; }

        public IFamily FamilyKind { get; set; }
        public IClass[] SocialClass { get; set; } = new IClass[3];
        public IStatus SocialStatus { get; set; }
        public List<INiche> WorkNiche { get; set; }

        public float Health { get; set; }
        public List<ICondition> Condition { get; set; }
        public float Capacity { get; set; }
        public Necessity[] Necessities { get; set; } = PopulationUtilities.Necessities;
        public (IActivity, Parcel) CurrentActivity { get; set; }
        public List<Product> Capital { get; set; }

        public Citizen()
        {
        }

        public void SearchForActivity()
        {
            PrioritizeNecessities();
            Necessity goal = Necessities[0];
            List<Parcel> foundPlaces = new();
            List<(Product, int, Parcel)> possibleProducts = new();

            foreach (Parcel knownPlace in KnownPlaces)
            {
                if (knownPlace.Resources.Any(p => p.NecessitiesSatisfied.Any(n => n.Item1.Name == goal.Name)))
                {
                    foundPlaces.Add(knownPlace);
                }
            }
            if (foundPlaces.Count > 0)
            {
                foreach (Parcel foundPlace in foundPlaces)
                {
                    // this takes the possible places to work
                    (int, List<Parcel>)? path = foundPlace.FindClosestPath(Location);
                    if (path != null)
                    {
                        // this takes the benefits of each work offer
                        foreach (Product product in foundPlace.Resources)
                        {
                            if (product.NecessitiesSatisfied.Any(p => p.Item1.Name == goal.Name))
                                possibleProducts.Add((product, path.Value.Item1, foundPlace));
                        }
                    }
                }
                // final cost calculation (in this primary test: "go there and take" => the net benefit - plain transportation)
                possibleProducts.OrderBy(p => p.Item1.SatisfactionGiven - p.Item2);
            }
            IActivity activityChosen = possibleProducts[0].Item1.GetActivity(goal);

            CurrentActivity = (activityChosen, possibleProducts[0].Item3);
        }
        private void PrioritizeNecessities()
        {
            Necessities.OrderBy(n => n.Priority);
            foreach (Necessity necessity in Necessities)
            {
                necessity.Priority = necessity.Priority + (necessity.Satiety * (1 / necessity.Weighing));
            }
            Necessities.OrderBy(n => n.Priority);
        }

        public float SetCapacity(INiche job, List<ITechnological> technologies, float capacity)
        {
            this.Capacity = this.Capacity - capacity;
            float capacityUsed = capacity * job.Level;
            float improvements = 0.0f;
            foreach (ITechnological tech in technologies)
            {
                improvements = improvements + tech.Multiplier;
            }
            return capacityUsed * improvements;
        }

        public (Product?, Lis﻿t<Product>) DoWork(Lis﻿t<Product> inputs, Product raw, INiche job)
        {
            (bool value, Lis﻿t<Product>? missedInputs) response = raw.CanProduce(inputs, job);
            (Product?, Lis﻿t<Product>?) finalResponse = (null, response.missedInputs);

            if (response.value)
            {
                List<ITechnological> techs = new List<ITechnological>();
                foreach (Product input in inputs)
                {
                    if (input is ITechnological tech)
                    {
                        techs.Add(tech);
                    }
                }

                float capacity = this.SetCapacity(job, techs, Capacity);
                Product output = raw.BeUsed(capacity, inputs, job.Id);
                Lis﻿t<Product> waste = raw.ConsumeInputs(output.Quantity, job.CapacityOfUse, inputs, job.Id);
                return (output, waste);
            }

            return finalResponse;
        }
    }
}
