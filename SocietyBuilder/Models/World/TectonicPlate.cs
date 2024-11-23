using SocietyBuilder.Models.World.Interface;

namespace SocietyBuilder.Models.World
{
    public class TectonicPlate : ITectonicPlate
    {
        public int Id { get; }
        public bool IsContinental { get; }
        public bool IsShield { get; }
        public bool IsMassif { get; }
        public List<bool> Direction { get; }

        public TectonicPlate(int id, bool isContinental, List<bool> directions, bool isShield = false, bool isMassif = false)
        {
            Id = id;
            IsContinental = isContinental;
            Direction = directions;
            IsShield = isShield;
            IsMassif = isMassif;
        }
    }
}
