﻿using CrowdFundingMVC.Models;
using CrowdFundingMVC.Models.Options;
using System.Collections.Generic;
using System.Linq;

namespace CrowdFundingMVC.Services.Interfaces
{
    public interface IPledgeServices
    {
        Result<Pledge> CreatePledges(PledgeOptions pledgeOptions);
        Result<BackedPledges> AddPledge(int pledgeId, int projectId);
        Pledge FindPledgeById(int projectId, int pledgeId);
        List<Pledge> GetPledgesByProjectId(int projectId);
        List<Pledge> GetUsersPledges(int projectId);
        IQueryable<BackedPledges> GetUserBackedPledges();
        Result<Pledge> UpdatePledge(PledgeOptions pledgeOptions);
        IQueryable<Pledge> ListPledges(PledgeOptions options);
        bool DeletePledge(int pledgeId);
    }
}