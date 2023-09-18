using AuthorizationService.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AuthorizationService.Database;

public sealed class AuthorizationDbContext : IdentityDbContext<Employee>
{
    public AuthorizationDbContext(DbContextOptions<AuthorizationDbContext> dbContextOptions)
        : base(dbContextOptions)
    { }
}