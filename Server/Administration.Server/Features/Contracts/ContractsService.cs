using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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



    }
}
