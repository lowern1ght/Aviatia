using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AuthorizationService.Database;

public sealed class AuthorizationDbContext : IdentityDbContext
{
    public AuthorizationDbContext(DbContextOptions<AuthorizationDbContext> dbContextOptions)
        : base(dbContextOptions)
    { }
}