using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MyTicketsPlugin.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


public class ApplicationUserClaimsPrincipalFactory :
                       UserClaimsPrincipalFactory<ApplicationUser>
{
    public ApplicationUserClaimsPrincipalFactory(UserManager<ApplicationUser> userManager,
                              IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
    {
    }

    protected override async Task<ClaimsIdentity>
             GenerateClaimsAsync(ApplicationUser user)
    {
        ClaimsIdentity claims = await
                        base.GenerateClaimsAsync(user);


        claims.AddClaim(new Claim("name", user.FirstName));

        return claims;
    }

}