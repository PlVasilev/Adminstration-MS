namespace Administration.Server.Features.Contracts.Models
{
    using System.ComponentModel.DataAnnotations;
    public class UpdateContractRequestModel
    {
        public string Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Contractor { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
