using System;
using System.Collections.Generic;
using System.Text;

namespace Microservices.MarketPlace.Example.CommonUses.Services.Interfaces
{
    public interface ISharedIdentityService
    {
        public string GetUserId { get; }
    }
}
