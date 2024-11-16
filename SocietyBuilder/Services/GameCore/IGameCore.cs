using Microsoft.AspNetCore.Mvc;

namespace SocietyBuilder.Services.GameCore
{
    public interface IGameCore
    {
        void NewGame(string[] difficultSettings);
    }
}
