using System;
using System.Collections.Generic;
using System.Text;

namespace Microservices.MarketPlace.Example.CommonUses.Result
{
    public class ErrorDto
    {
        public ErrorDto()
        {
            Errors = new List<string>();
        }
        public List<string> Errors { get; set; }
    }
}
