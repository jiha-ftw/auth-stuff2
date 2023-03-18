﻿using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using System.Security.Claims;

namespace AuthStuff
{
    public static class AddAuthSchemeClaimOnTokenValidated
    {
        public static OpenIdConnectEvents Create(string scheme) => new OpenIdConnectEvents
        {
            OnTokenValidated = context => 
            {
                ((ClaimsIdentity)context.Principal.Identity).AddClaim(new Claim(".AuthScheme", scheme));

                return Task.CompletedTask;
            }
        };
    }
}
