namespace Administration.Server.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public ICollection<Contract> Contracts { get; } = new HashSet<Contract>();
    }
}
