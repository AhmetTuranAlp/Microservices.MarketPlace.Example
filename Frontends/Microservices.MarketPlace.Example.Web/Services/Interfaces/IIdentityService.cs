using IdentityModel.Client;
using Microservices.MarketPlace.Example.CommonUses.Result;
using Microservices.MarketPlace.Example.Web.Models;
using System.Threading.Tasks;

namespace Microservices.MarketPlace.Example.Web.Services.Interfaces
{
    public interface IIdentityService
    {
        /// <summary>
        /// Kullanıcının login işlemi sonrası IdentityServer üzerinden token alınması gerçekleşmektedir.
        /// </summary>
        /// <param name="signinInput"></param>
        /// <returns></returns>
        Task<Response<bool>> SignIn(SigninInput signinInput);

        /// <summary>
        /// AccessToken'ın ömrü dolduğunda RefreshToken ile beraber Cookie den RefreshToken okunup yeni bir AccessToken elde edilir.
        /// </summary>
        /// <returns></returns>
        Task<TokenResponse> GetAccessTokenByRefreshToken();

        /// <summary>
        /// Kullanıcı signout işlemi yaptıgında RefreshToken sıfırlanmaktadır. IdentityServer üzerinden silinmesi gerekmektedir.
        /// </summary>
        /// <returns></returns>
        Task RevokeRefreshToken();
    }
}
