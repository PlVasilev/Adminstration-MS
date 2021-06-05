namespace Administration.Server.Features.Contracts
{
    using System;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    public class ContractsService : IContractsService
    {
        private readonly AdministrationDbContext _data;
        public ContractsService(AdministrationDbContext data)
        {
            _data = data;
        }

        public async Task<string> Create(string type, string contractor, string description, string userId)
        {
            var contract = new Contract
            {
                Id = Guid.NewGuid().ToString(),
                Contractor = contractor,
                Description = description,
                Type = type,
                UserId = userId
            };

            _data.Contracts.Add(contract);
            await _data.SaveChangesAsync();

            return contract.Id;
        }
    }
}
