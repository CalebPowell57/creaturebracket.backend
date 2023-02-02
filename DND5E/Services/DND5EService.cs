using DND5E.Service.Responses;
using ExternalService;

namespace DND5E.Service.Services
{
    public abstract class DND5EService<T> : BaseService where T : class
    {
        public DND5EService() : base("https://www.dnd5eapi.co/api/")
        {
            SetNoun($"{typeof(T).Name}s");
        }

        public async Task<T> Index(string index)
        {
            var response = await Get<T>(index);

            return response;
        }

        public async Task<IEnumerable<T>> All()
        {
            var response = await Get<BaseResponse<T>>();

            return response.Results;
        }

        //public async Task<D> Get<D>(string routeModifier)
        //{
        //    var response = await Get<D>(routeModifier);

        //    return response;
        //}
    }
}