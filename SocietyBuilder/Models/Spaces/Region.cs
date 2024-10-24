﻿using SocietyBuilder.Models.Population;
using SocietyBuilder.Models.Spaces.Interfaces;

namespace SocietyBuilder.Models.Spaces
{
    public class Region : IPhysicalSpace
    {
        public Guid ID { get; set; }
        public int OID { get; set; }
        public Guid[] ZoneIDs { get; set; }
        public Zone NorthCenter { get; set; }
        public Zone SouthCenter { get; set; }
        public Zone NorthWest { get; set; }
        public Zone SouthWest { get; set; }
        public Zone NorthEast { get; set; }
        public Zone SouthEast { get; set; }
        public string EnvironmentType { get; set; }

        public int PopulationId { get; set; }
        public Polis Population { get; set; }
        public int[] PopulationIds { get; set; }

        public Region()
        {
            OID = 1;
        }
        public Region(int id)
        {
            OID = id;
        }
    }
}
