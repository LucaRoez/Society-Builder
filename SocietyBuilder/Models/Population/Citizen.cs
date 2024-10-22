using SocietyBuilder.Models.Activity.Interfaces;
using SocietyBuilder.Models.Population.Elements;
using SocietyBuilder.Models.Population.Interfaces;
using SocietyBuilder.Models.Population.Interfaces.IDemography;
using SocietyBuilder.Models.Population.Interfaces.ISociologic;
using SocietyBuilder.Models.Production.Interfaces;
using SocietyBuilder.Models.Spaces;

namespace SocietyBuilder.Models.Population
{
    public class Citizen : IPopulation
    {
        public string Name => "Citizen";
        public Parcel Location { get; set; }
        public IClass SocialClass { get; set; }
        public IStatus SocialStatus { get; set; }
        public INiche WorkNiche { get; set; }
        public string[] States { get; set; }
        public float Capacity { get; set; }
        public Dictionary<Necessity, float> Satieties { get; set; }
        public Dictionary<string, double> Endurances { get; set; }
        public double Incomes { get; set; }
        public double Capital { get; set; }

        public Citizen()
        {

        }

        float SetCapacity(INiche job, List<IProduct> technologies, float capacity)
        {
            this.Capacity = this.Capacity - capacity;
            float capacityUsed = capacity * job.Level;
            float improvements = 0.0;
            foreach (IProduct tech in technologies)
            {
                improvements = improvements + tech.Multiplier;
            }
            return capacityUsed * improvements;
        }

        (Lis﻿t<IProduct>?, Lis﻿t<IProduct>) DoWork(Lis﻿t<IProduct> inputs, IProduct raw, INiche job)
        {
            (bool value, Lis﻿t<IProduct>?) response = raw.CanProduce(inputs, job);
            (Lis﻿t<I﻿Product>?, Lis﻿t<IProduct>) finalResponse = (null, response.missedInputs);

            if (response.value)
            {
                float capacity = this.SetCapacity();
                Lis﻿t<IProduct> output = raw.BeUsed(capacity, job.id);
                Lis﻿t<IProduct> waste = raw.ConsumeInputs(output.Count, this.CapacityOfUse, inputs, job.id);
                return (output, waste);
            }
            return finalResponse;
        }
    }
}
