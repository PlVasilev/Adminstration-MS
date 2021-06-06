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

        public ContractsController(IContractsService contractsService)
        {
            _contractsService = contractsService;
        }

        [HttpGet]
        [Authorize]
        [Route(nameof(Mine))]
        public async Task<IEnumerable<GetContractsResponseModel>> Mine() =>
            await _contractsService.Mine(this.User.GetId());

        [HttpGet]
        [Authorize]
        [Route(nameof(Details)+"/{id}")]
        public async Task<ActionResult<GetContractDetailsResponseModel>> Details(string id) => 
            await _contractsService.Details(id);
        
        [HttpPost]
        [Authorize]
        [Route(nameof(Create))]
        public async Task<ActionResult> Create(CreateContractRequestModel model)
        {
            var userId = this.User.GetId();
            var contractId = await _contractsService.Create(model.Type, model.Contractor, model.Description, userId);

            return Created(nameof(this.Create), contractId);
        }
    }
}
