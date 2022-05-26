// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace Microservices.MarketPlace.Example.IdentityServer
{
    public static class Config
    {

        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("resource_product"){Scopes={"product_fullpermission"}},
            new ApiResource("resource_image"){Scopes={"image_cdn_fullpermission"}},
            new ApiResource("resource_basket"){Scopes={"basket_fullpermission"}},
            new ApiResource("resource_discount"){Scopes={"discount_fullpermission"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
};

        public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
             //Genel izinler tanımlanmıştır.
             new IdentityResources.Email(),
             new IdentityResources.OpenId(),
             new IdentityResources.Profile(),
             new IdentityResource(){ Name="roles", DisplayName="Roles", Description="Kullanıcı rolleri", UserClaims=new []{ "role"} }
        };

        public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("product_fullpermission","Product API için full erişim"),
            new ApiScope("image_cdn_fullpermission","Image CDN API için full erişim"),
            new ApiScope("basket_fullpermission","Basket API için full erişim"),
            new ApiScope("discount_fullpermission","Discount API için full erişim"),
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
            },
            new Client
            {
                ClientName="UI Client User ",
                ClientId="UIClientForUserNameandPassword",
                AllowOfflineAccess=true,
                ClientSecrets= {new Secret("UIClientPassword".Sha256())},
                AllowedGrantTypes= GrantTypes.ResourceOwnerPassword,
                //AllowedScopes = Kullanıcı token aldıgında token ile beraber hangi bilgilere erişebileceği tanımlanmıştır.
                AllowedScopes=
                {
                  "basket_fullpermission",
                  IdentityServerConstants.StandardScopes.Email,
                  IdentityServerConstants.StandardScopes.OpenId,
                  IdentityServerConstants.StandardScopes.Profile,
                  IdentityServerConstants.StandardScopes.OfflineAccess,//Kullanıcı token ömrü bittiğinde login ekranına gönderilmektedir.
                  IdentityServerConstants.LocalApi.ScopeName,"roles"
                },
                AccessTokenLifetime=1*60*60, //AccessToken ömrü belirnenmektedir.
                RefreshTokenExpiration=TokenExpiration.Absolute, //RefreshToken istedikçe ömrü artılılaması saglanmaktadır.
                AbsoluteRefreshTokenLifetime= (int) (DateTime.Now.AddDays(60)- DateTime.Now).TotalSeconds,//RefreshToken ömrü belirlenmekte 
                RefreshTokenUsage= TokenUsage.ReUse //RefreshToken kullanım durumu belirlenmektedir. Tekrar kullanılabilir yapılmıştır.
            },
            new Client
            {
                ClientName="Token Exchange Client",
                ClientId="TokenExhangeClient",
                ClientSecrets= {new Secret("UIClientPassword".Sha256())},
                AllowedGrantTypes= new []{ "urn:ietf:params:oauth:grant-type:token-exchange" },
                AllowedScopes={ "discount_fullpermission", "payment_fullpermission", IdentityServerConstants.StandardScopes.OpenId }
            },
        };
    }
}