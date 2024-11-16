using SocietyBuilder.Models.World.Interface;

namespace SocietyBuilder.Models.World
{
    public class TectonicPlate : ITectonicPlate
    {
        public int Id { get; }
        public bool IsContinental { get; }

        public TectonicPlate(int id, bool isContinental)
        {
            Id = id;
            IsContinental = isContinental;
        }
    }
}
