
namespace Administration.Server.Features.Contracts.Models
{
    using Administration.Server.Data.Models;
    using Infrastructure.Mapping;

    public class ContractServiceModel : IMapFrom<Contract>, IMapTo<Contract>
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Contractor { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
    }
}
