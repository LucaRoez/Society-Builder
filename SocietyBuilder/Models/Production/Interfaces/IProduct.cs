using SocietyBuilder.Models.Population.Interfaces.IDemography;

namespace SocietyBuilder.Models.Production.Interfaces
{
    public interface IProduct
    {
        int Id { get; }
        float RateOfUsability { get; set; }
        int Quantity { get; set; }
        int[,] Requirements { get; set; }

        (bool value, Lis﻿t<IProduct>? missedInputs) CanProduce(List<IProduct> inputs, INiche job);
        Lis﻿t<IProduct> BeUsed(float capacity, List<IProduct> inputs, int job);
        List<List<IProduct>> ConsumeInputs(int amount, float capacityOfUse, L﻿ist<IProduct> inputs, int job);
        Lis﻿t<IProduct> Be﻿UsedAsInput(int amount, float capacityOfUse, int job);
    }
}
