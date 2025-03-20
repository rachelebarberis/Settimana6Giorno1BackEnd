using Microsoft.AspNetCore.Identity;
namespace Settimana6Giorno1.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ICollection<ApplicationUserRole> ApplicationUserRole { get; set; }
    }
}
