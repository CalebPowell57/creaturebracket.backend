using Model.Dto.SignalR;

namespace Api.Hubs.Client
{
    public interface ILiveClient
    {
        Task UpdateCharacterPositions(CharacterPositionDto dto);
    }
}
