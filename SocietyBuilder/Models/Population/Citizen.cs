using SocietyBuilder.Models.Activity;
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
        public HashSet<Parcel> KnownPlaces { get; set; }

        public IFamily FamilyKind { get; set; }
        public IClass[] SocialClass { get; set; } = new IClass[3];
        public IStatus SocialStatus { get; set; }
        public HashSet<INiche> WorkNiche { get; set; } = new();

        public float Health { get; set; }
        public List<ICondition> Condition { get; set; }
        public float Capacity { get; set; }
        public Necessity[] Necessities { get; set; } = PopulationUtilities.Necessities;
        public (SocialActivity, Parcel) CurrentActivity { get; set; }
        public List<Product> Capital { get; set; }

        public Citizen()
        {
        }

        public void SearchForActivity()
        {
            PrioritizeNecessities();
            Necessity goal = Necessities[0];
// listing: the product, its trasportation cost & the place where it is
            List<(Product, float, Parcel)> possibleProducts = new();

            // forage what could please
            foreach (Parcel knownPlace in KnownPlaces)
            {
                if (knownPlace.Resources.Any(p => p.NecessitiesSatisfied.Item1.Name == goal.Name))
                {
                    // take the possible places to work
                    (float, List<Parcel>)? path = knownPlace.FindClosestPath(Location);
                    if (path != null)
                    {
                        // take the benefits of each work offer
                        foreach (Product product in knownPlace.Resources)
                        {
                            if (product.NecessitiesSatisfied.Item1.Name == goal.Name)
                                possibleProducts.Add((product, path.Value.Item1, knownPlace));
                        }
                    }
                }
            }
            // final cost calculation (in this primary test: the net benefit * skill - plain transportation)
            if (possibleProducts.Count > 0)
                possibleProducts.OrderByDescending(
                    p => (// this is the product by the skill level of the associated activity which is also associated to a job
                        p.Item1.Utility * (
                            WorkNiche.Contains(p.Item1.NecessitiesSatisfied.Item2.GetNiche(p.Item1))
                            ? WorkNiche.FirstOrDefault(job => job.Id == p.Item1.NecessitiesSatisfied.Item2.GetNiche(p.Item1).Id).Level
                        : 1)
                    ) - p.Item2 // minus the transportation cost
                );

            // and finally we choose the winner
            (SocialActivity, INiche) activityChosen = (
                possibleProducts[0].Item1.NecessitiesSatisfied.Item2, 
                possibleProducts[0].Item1.NecessitiesSatisfied.Item2.GetNiche(possibleProducts[0].Item1)
            );
            CurrentActivity = (activityChosen.Item1, possibleProducts[0].Item3);
            if (WorkNiche.Contains(activityChosen.Item2))
                WorkNiche.Add(activityChosen.Item2);
        }
        private void PrioritizeNecessities()
        {
            foreach (Necessity necessity in Necessities)
            {
            // first take the natural Priority, then modify it according to its current Satiety level but "strained" by how much it "weighs"
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

        public (Product?, Lis﻿t<Product>) Produce(Lis﻿t<Product> inputs, Product raw, INiche job)
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

                float capacity = SetCapacity(job, techs, Capacity);
                Product output = raw.BeUsed(capacity, inputs, job.Id);
                Lis﻿t<Product> waste = raw.ConsumeInputs(output.Quantity, job.CapacityOfUse, inputs, job.Id);
                return (output, waste);
            }

            return finalResponse;
        }
    }
}
