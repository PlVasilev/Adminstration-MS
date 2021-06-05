namespace Administration.Server.Features.Contracts
{
    using System.Threading.Tasks;
    using Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ContractsController : ApiController
    {
        private readonly IContractsService _contractsService;

        public ContractsController(IContractsService contractsService)
        {
            _contractsService = contractsService;
        }


        [HttpPost]
        [Authorize]
        [Route(nameof(Create))]
        public async Task<ActionResult<string>> Create(CreateContractRequestModel model)
        {
            var userId = this.User.GetId();
            var contractId = await _contractsService.Create(model.Type, model.Contractor, model.Description, userId);
       
            return Created(nameof(this.Create), contractId);
        }
    }
}
