﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdFundingCH.Areas.Identity.Data;
using CrowdFundingCH.Options;
using CrowdFundingCH.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrowdFundingCH.Models
{
    public class ProjectController : Controller
    {
        private IProjectManager projMangr;
       private readonly CrowdFundingDBContext _db;

        public ProjectController(IProjectManager _projMangr, CrowdFundingDBContext db)
        {
            projMangr = _projMangr;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

       // [Authorize("Admin,Project Creator")]
        [HttpPost]
        public Project AddProject([FromBody] ProjectOptions projOpt)
        {
            return projMangr.CreateProject(projOpt);
        }



    }
}