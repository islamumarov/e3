using PlatformService.Dtos;

namespace PlatformService.SyncDataServives.Http
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommand(PlatformReadDto platform);
    }
}