namespace Administration.Server.Features.Contracts.Models
{
    public class GetContractDetailsResponseModel
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Contractor { get; set; }
        public string Description { get; set; }
        public string CreatorName { get; set; }
    }
}
