using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models;

public class User : IdentityUser
{
    public string Document { get; set; } = string.Empty;
}
