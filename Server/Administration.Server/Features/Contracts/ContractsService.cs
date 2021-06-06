namespace Administration.Server.Features.Contracts
{
    using System;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> Update(string id, string type, string contractor, string description, string userId)
        {
            var contract = await _data.Contracts.FirstOrDefaultAsync(x => x.UserId == userId && x.Id == id);

            if (contract == null) return false;

            contract.Type = type;
            contract.Contractor = contractor;
            contract.Description = description;

            await _data.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<GetContractsResponseModel>> Mine(string userId) =>
            await _data
                .Contracts
                .Where(x => x.UserId == userId)
                .Select(x => new GetContractsResponseModel
                {
                    Id = x.Id,
                    Contractor = x.Contractor,
                    Type = x.Type
                })
                .ToListAsync();

        public async Task<GetContractDetailsResponseModel> Details(string id) =>
            await _data.Contracts
                .Include(x => x.User)
                .Where(x => x.Id == id)
                .Select(contract => new GetContractDetailsResponseModel
                 {
                     Id = contract.Id,
                     Contractor = contract.Contractor,
                     CreatorName = contract.User.UserName,
                     Description = contract.Description,
                     Type = contract.Type
                 }).FirstOrDefaultAsync();

        public async Task<bool> Delete(string id, string userId)
        {
            var contract = await _data.Contracts.FirstOrDefaultAsync(x => x.UserId == userId && x.Id == id);
            if (contract == null) return false;

            _data.Remove(contract);
            await _data.SaveChangesAsync();
            return true;
        }
    }
}
