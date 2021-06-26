
namespace Administration.Server.Features.Contracts
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Models;

    public interface IContractsService
    {
        public Task<string> Create(ContractServiceModel model);
        public Task<bool> Update(string id, string type, string contractor, string description, string userId);
        public Task<IEnumerable<GetContractsResponseModel>> Mine(string userId);
        public Task<GetContractDetailsResponseModel> Details(string id);
        public Task<bool> Delete(string id, string userId);
    }
}
