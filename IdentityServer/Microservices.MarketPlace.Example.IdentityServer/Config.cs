// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Microservices.MarketPlace.Example.IdentityServer
{
    public static class Config
    {

        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("resource_product"){Scopes={"product_fullpermission"}},
            new ApiResource("resource_image"){Scopes={"image_cdn_fullpermission"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
}       ;

        public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {

        };

        public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("product_fullpermission","Product API için full erişim"),
            new ApiScope("image_cdn_fullpermission","Image CDN API için full erişim"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new Client
                {
                    ClientName="UI Client",
                    ClientId="UIClient",
                    ClientSecrets= {new Secret("UIClientPassword".Sha256())},
                    AllowedGrantTypes= GrantTypes.ClientCredentials,
                    AllowedScopes={ "product_fullpermission", "image_cdn_fullpermission", IdentityServerConstants.LocalApi.ScopeName }
                }
        };
    }
}