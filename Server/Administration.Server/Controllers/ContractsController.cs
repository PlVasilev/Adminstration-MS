namespace Administration.Server.Controllers
{
    using System;
    using Data;
    using Administration.Server.Data.Models;
    using System.Threading.Tasks;
    using Infrastructure;
    using Models.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    public class ContractsController : ApiController
    {
        private AdministrationDbContext _data;

        public ContractsController(AdministrationDbContext data)
        {
            _data = data;
        }

        private DbSet<Contract> Contracts { get; set; }

        [Authorize]
        [HttpPost]
        [Route(nameof(Create))]
        public async Task<ActionResult<string>> Create(CreateContractRequestModel model)
        {
            var userId = this.User.GetId();

            var contract = new Contract
            {
                Id = Guid.NewGuid().ToString(),
                Contractor = model.Contractor,
                Description = model.Description,
                Type = model.Type,
                UserId = userId
            };

            await _data.AddAsync(contract);
            await _data.SaveChangesAsync();
            return Created(nameof(this.Create), contract.Id);
            
        }
    }
}
