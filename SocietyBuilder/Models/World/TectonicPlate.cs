using SocietyBuilder.Models.World.Interface;

namespace SocietyBuilder.Models.World
{
    public class TectonicPlate : ITectonicPlate
    {
        public int Id { get; }
        public bool IsContinental { get; }
        public bool IsShield { get; }
        public bool IsMassif { get; }

        public TectonicPlate(int id, bool isContinental, bool isShield = false, bool isMassif = false)
        {
            Id = id;
            IsContinental = isContinental;
            IsShield = isShield;
            IsMassif = isMassif;
        }
    }
}
