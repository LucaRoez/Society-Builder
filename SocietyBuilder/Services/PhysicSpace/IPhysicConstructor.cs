﻿using SocietyBuilder.Models.Spaces;

namespace SocietyBuilder.Services.PhysicSpace
{
    public interface IPhysicConstructor
    {
        Region CreateNewRegion(string latitude);
    }
}