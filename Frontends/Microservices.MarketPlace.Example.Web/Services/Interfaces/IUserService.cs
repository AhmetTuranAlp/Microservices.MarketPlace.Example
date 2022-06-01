using Microservices.MarketPlace.Example.Web.Models;
using System.Threading.Tasks;

namespace Microservices.MarketPlace.Example.Web.Services.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Kullanıcıya ait tüm datalar alınmaktadır.
        /// </summary>
        /// <returns></returns>
        Task<UserViewModel> GetUser();
    }
}
