using Administration.Server.Features.Contracts.Models;
using AutoMapper;

namespace Administration.Server.Features.Contracts
{
    using System.Threading.Tasks;
    using Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;


    public class ContractsController : ApiController
    {
        private readonly IContractsService _contractsService;
        private readonly IMapper _mapper;


        public ContractsController(IContractsService contractsService, IMapper mapper)
        {
            _contractsService = contractsService;
            _mapper = mapper;

        }

        [HttpGet]
        [Authorize]
        [Route(nameof(Mine))]
        public async Task<IEnumerable<GetContractsResponseModel>> Mine() =>
            await _contractsService.Mine(this.User.GetId());

        [HttpGet]
        [Authorize]
        [Route("{id}")]
        public async Task<ActionResult<GetContractDetailsResponseModel>> Details(string id) =>
            await _contractsService.Details(id);

        [HttpDelete]
        [Authorize]
        [Route("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var userId = this.User.GetId();
            var deleted = await _contractsService.Delete(id, userId);
            if (!deleted)
            {
                return BadRequest();
            }
            return Ok();
        }


        [HttpPut]
        [Authorize]
        [Route(nameof(Update))]
        public async Task<ActionResult<UpdateContractRequestModel>> Update(UpdateContractRequestModel model)
        {
            var userId = this.User.GetId();
            var updated = await _contractsService.Update(model.Id, model.Type, model.Contractor, model.Description, userId);

            if (!updated) return BadRequest();

            return Ok();
        }

        [HttpPost]
        [Authorize]
        [Route(nameof(Create))]
        public async Task<ActionResult> Create(CreateContractRequestModel model)
        {
            var userId = this.User.GetId();
            var contract = _mapper.Map<ContractServiceModel>(model);

            contract.UserId = userId;
            var contractId = await _contractsService.Create(contract);

            return Created(nameof(this.Create), contractId);
        }
    }
}
