using SocietyBuilder.Models.Population.Features;
using SocietyBuilder.Models.Population.Interfaces;
using SocietyBuilder.Models.Population.Interfaces.IDemography;
using SocietyBuilder.Models.Population.Interfaces.ISociologic;
using SocietyBuilder.Models.Production;
using SocietyBuilder.Models.Production.Interfaces.IManufactured.Shared;
using SocietyBuilder.Models.Spaces;

namespace SocietyBuilder.Models.Population
{
    public class Citizen : IPopulation
    {
        public string Name { get; }
        public IAge Age { get; set; }
        public Parcel Location { get; set; }
        public Parcel Home { get; set; }
        public IFamily FamilyKind { get; set; }
        public IClass[] SocialClass { get; set; } = new IClass[3];
        public IStatus SocialStatus { get; set; }
        public List<INiche> WorkNiche { get; set; }
        public float Health { get; set; }
        public List<ICondition> Condition { get; set; }
        public float Capacity { get; set; }
        public List<Satiety> Satieties { get; set; }
        public List<Product> Capital { get; set; }

        public Citizen()
        {
        }

        float SetCapacity(INiche job, List<ITechnological> technologies, float capacity)
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

        (Product?, Lis﻿t<Product>) DoWork(Lis﻿t<Product> inputs, Product raw, INiche job)
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
