﻿using SwitchPlay.Data;

namespace SwitchPlay.Services
{
    public interface IGamePlatformService
    {
        Task CreateGamePlatformAsync(int gameId, List<int> platformIds);
        Task<IEnumerable<GamePlatform>> GetByGameId(int gameId);
    }
}
