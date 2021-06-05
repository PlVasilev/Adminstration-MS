namespace Administration.Server.Features.Contracts
{
    using System.ComponentModel.DataAnnotations;
    public class CreateContractRequestModel
    {
        [Required]
        public string Type { get; set; }

        [Required]
        public string Contractor { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

    }
}
