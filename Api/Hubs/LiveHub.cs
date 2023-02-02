using Api.Hubs.Client;
using Microsoft.AspNetCore.SignalR;
using Model.Dto.SignalR;

namespace Api.Hubs
{
    public class LiveHub : Hub<ILiveClient>
    {
        public async Task UpdateCharacterPosition(CharacterPositionDto dto)
        {
            //replace All with Others
            await Clients.All.UpdateCharacterPositions(dto);
        }
    }
}
