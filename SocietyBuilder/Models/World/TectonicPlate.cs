using SocietyBuilder.Models.World.Interface;

namespace SocietyBuilder.Models.World
{
    public class TectonicPlate : ITectonicPlate
    {
        public int Id { get; }
        public bool IsContinental { get; }
        public bool IsShield { get; }
        public bool IsMassif { get; }
        public int[] Direction { get; }

        public TectonicPlate(int id, bool isContinental)
        {
            Id = id;
        }
    }
}
