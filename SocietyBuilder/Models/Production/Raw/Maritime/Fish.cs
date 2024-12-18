﻿using SocietyBuilder.Models.Activity.Interfaces.SectorClassification.PrimarySector;
using SocietyBuilder.Models.Activity.Interfaces.Sectors;
using SocietyBuilder.Models.Production.Interfaces.IRaw.IFoodSector;
using SocietyBuilder.Services.UniversalServices;

namespace SocietyBuilder.Models.Production.Raw.Maritime
{
    public class Fish : Product, IEdible, IFoodSector, IMaritimeClassification
    {
        public float SmallFishes { get; set; }
        public float MidFishes { get; set; }
        public float BigFishes { get; set; }
        public float VeryBigFishes { get; set; }
        public float SmallShoal { get; set; }
        public float MidShoal { get; set; }
        public bool IsSweetWater { get; set; } // if not sweet then salty
        public bool IsShore { get; set; } // if not shore then whether sweet is river or salty must be high seas
        public bool IsHighSeas { get; set; } // if not high seas then whether sweet is river or salty must be shore

        public Fish(string name, IExcelManager excelManager)
            : base(name, excelManager)
        {
        }

        public override Product ReturnProduct(int quantity)
        {
            throw new NotImplementedException();
        }

        public override List<Product> ReturnWaste()
        {
            throw new NotImplementedException();
        }
    }
}
