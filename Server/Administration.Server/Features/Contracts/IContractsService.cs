using System.Collections.Generic;

namespace Administration.Server.Features.Contracts
{
    using System.Threading.Tasks;
    public interface IContractsService
    {
        public Task<string> Create(string type, string contractor, string description, string userId);
        public Task<IEnumerable<GetContractsResponseModel>> Mine(string userId);
        public Task<GetContractDetailsResponseModel> Details(string id);
    }
}
