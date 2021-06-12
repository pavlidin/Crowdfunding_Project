using CrowdFundingMVC.Models;
using CrowdFundingMVC.Models.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingMVC.Services.Interfaces
{
    public interface IFundServices
    {
        Result<Fund> AddFund(FundOptions fundOptions);
        IQueryable<Fund> GetUserFunds();
    }
}
