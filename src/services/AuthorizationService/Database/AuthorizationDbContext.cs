using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AuthorizationService.Database;

public class AuthorizationDbContext : IdentityDbContext
{
    public AuthorizationDbContext(DbContextOptions<AuthorizationDbContext> dbContextOptions)
        : base(dbContextOptions) { }
}