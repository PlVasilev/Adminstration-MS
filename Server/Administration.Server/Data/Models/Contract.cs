namespace Administration.Server.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Contract
    {
        public string Id { get; set; }
       
        [Required]
        public string Type { get; set; }
       
        [Required]
        public string Contractor { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
