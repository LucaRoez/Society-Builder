using SocietyBuilder.Models.Population.Interfaces.IDemography;
using SocietyBuilder.Models.Production.Interfaces;

namespace SocietyBuilder.Models.Production
{
    public class Product : IProduct
    {
        public int Id { get; }
        public float RateOfUsability { get; set; }
        public int Quantity { get; set; }
        public int[,] Requirements { get; set; }

        public Product()
        {
        }

        // we gonna need that inputs list must have all required or optional inputs for this to work
        (bool value, List<IProduct>? missedInputs) IProduct.CanProduce(List<IProduct> inputs, INiche job)
        {
            List<IProduct> missedInputs = new List<IProduct>();
            foreach (IProduct input in inputs)
            {
                if (input.Quantity < this.Requirements[input.Id, job.Id])
                    missedInputs.Add(input);
            }
            if (missedInputs.Count > 0) return (false, missedInputs);
            return (true, null);
        }
        public List<IProduct> BeUsed(float capacity, List<IProduct> inputs, int job)
        {
            int[] amounts = new int[inputs.Count]; int index = 0;
            foreach (IProduct input in inputs)
            {
                int amount = input.Quantity / this.Requirements[input.Id, job];
                amounts[index] = amount; index++;
            }
            return Enumerable.Repeat((IProduct)new Product(), Convert.ToInt32(amounts.Min() * capacity)).ToList();
        }

        public List<List<IProduct>> ConsumeInputs(int amount, float capacityOfUse, List<IProduct> inputs, int job)
        {
            List<List<IProduct>> waste = new List<List<IProduct>>();
            foreach (IProduct input in inputs)
            {
                waste.Add(input.BeUsedAsInput(amount, capacityOfUse, job));
            }
            return waste;
        }

        public List<IProduct> BeUsedAsInput(int amount, float capacityOfUse, int job)
        {
            int netUse = (int)Math.Min(1, this.RateOfUsability * capacityOfUse);
            Lis﻿t<IProduct> waste = Enumerable.Repeat((IProduct)new Product(), amount * netUse).ToList();
            return waste;
        }
    }
}
