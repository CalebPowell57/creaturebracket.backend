using DnD5e.Data;
using DND5E.Service.Responses;

namespace DND5E.Service.Services
{
    public class SubraceService : DND5EService<Subrace>
    {
        public async Task<string> GetRaceFromSubraceName(string subrace)
        {
            subrace = subrace.ToLower().Replace(" ", "-");

            var response = await Get<SubraceResponse>(subrace);

            return response.Race.Name;
        }
    }
}
