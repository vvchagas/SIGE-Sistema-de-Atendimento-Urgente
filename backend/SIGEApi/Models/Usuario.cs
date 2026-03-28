using Microsoft.AspNetCore.Identity;

namespace SIGEApi.Models
{
    public class Usuario : IdentityUser
    {
        public Guid Id { get; set; }
    }
}
