using CrowdFundingMVC.Models;
using System.Collections.Generic;

namespace CrowdFundingMVC.Services.Interfaces
{
    public interface IMultimediaServices
    {
        List<Multimedia> GetMultimediaOfProject(int projectId);
        List<Multimedia> GetAll();
    }
}
