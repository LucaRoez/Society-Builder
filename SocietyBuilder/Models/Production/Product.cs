using SocietyBuilder.Models.Population.Interfaces.IDemography;
using SocietyBuilder.Models.Production.General;
using SocietyBuilder.Models.Production.Interfaces;

namespace SocietyBuilder.Models.Production
{
    public abstract class Product : IProduct
    {
        public int Id { get; }
        public float RateOfUsability { get; set; }
        public int Quantity { get; set; }
        public List<Requirement> Requirements { get; set; }
        public abstract Product ReturnProduct(int quantity);
        public abstract List<Product> ReturnWaste();

        public float SatisfactionGiven { get; set; }

        public Product(int quantity)
        {
            Quantity = quantity;
        }

        // we gonna need that inputs list must have all required or optional inputs for this to work
        public (bool value, List<Product>? missedInputs) CanProduce(List<Product> inputs, INiche job)
        {
            List<Product> missedInputs = new List<Product>();
            foreach (Product input in inputs)
            {
                if (this.Requirements.Exists(r => r.Id == input.Id))
                    if (input.Quantity < this.Requirements.Find(r => r.Id == input.Id).QuantityNeeded)
                        missedInputs.Add(input);
            }
            if (missedInputs.Count > 0) return (false, missedInputs);
            return (true, null);
        }

        public Product BeUsed(float capacity, List<Product> inputs, int job)
        {
            int[] amounts = new int[inputs.Count]; int index = 0;
            foreach (Product input in inputs)
            {
                if (this.Requirements.Exists(r => r.Id == input.Id))
                {
                    int amount = input.Quantity / this.Requirements.Find(r => r.Id == input.Id).QuantityNeeded;
                    amounts[index] = amount;
                }
                index++;
            }

            Product output = ReturnProduct(amounts.Min() * (int)capacity);
            return output;
        }

        public List<Product> ConsumeInputs(int amount, float capacityOfUse, List<Product> inputs, int job)
        {
            List<Product> totalWaste = new List<Product>();
            foreach (Product input in inputs)
            {
                foreach (Product waste in input.BeUsedAsInput(amount, capacityOfUse, job))
                {
                    totalWaste.Add(waste);
                }
            }
            return totalWaste;
        }

        public List<Product> BeUsedAsInput(int amount, float capacityOfUse, int job)
        {
            int netUse = (int)Math.Min(1, this.RateOfUsability * capacityOfUse);
            Lis﻿t<Product> waste = ReturnWaste();
            return waste;
        }
    }
}
