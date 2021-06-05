namespace Administration.Server.Features.Contracts
{
    using System.Threading.Tasks;
    public interface IContractsService
    {
        public Task<string> Create(string type, string contractor, string description, string userId);
    }
}
