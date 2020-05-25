﻿using CrowdFundingAPI.Database;
using CrowdFundingAPI.Models;
using CrowdFundingAPI.Models.Options;
using CrowdFundingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace CrowdFundingMVC.Controllers
{

    public class ProjectController : BaseController
    {
        private IProjectServices _projMangr;
        private IPledgeServices _pledges;

        private readonly CrFrDbContext _db;

        private readonly IHttpContextAccessor httpContextAccessor;

        public ProjectController(IProjectServices projMangr, CrFrDbContext db, IHttpContextAccessor _httpContextAccessor, 
            IPledgeServices pledges)
        {
            _projMangr = projMangr;
            _pledges = pledges;
            _db = db;
            httpContextAccessor = _httpContextAccessor;
        }
       
        //All Projects List
        [HttpGet]
        public IActionResult GetAllProjects()
        {
            var projectList = _projMangr
                .ListProjects(new ProjectOptions())
                .ToList();

            return View(projectList);
        }

        [HttpGet]
        public IActionResult SingleProject(int? id)
        {
            var singleproject = _projMangr.FindProjectById((int)id);

            // strongly typed view - by putting object into the view vs. ViewBag.ComicBook = comicBook;
            return View(singleproject);  // will automatically look in the views folder
        }

        //[HttpGet]
        //public IActionResult PledgesByProjId(int? id)
        //{
        //    var pledgebyprojid = _projMangr.PledgesByProjId((int)id);
        
        //    return View(pledgebyprojid);  
        //}

        [HttpGet]
        public IActionResult CreatePledges(int? id)
        {
            var createPledgepage = _pledges.FindPledgeById((int)id);
            return View(createPledgepage);  
        }

        
        [HttpPost("/CreatePledges/{projectId}")]
        public Pledge CreatePledges(int projectId, [FromBody] PledgeOptions options)
        {
            return _pledges.CreatePledges(projectId, options);
        }

        //[HttpPost("project/CreatePledges/{projectId}")]
        //public async Task<IActionResult> CreatePledges2(int projectId,[FromBody] PledgeOptions options)
        //{
        //    var result = await _pledges.CreatePledges(projectId, options);

        //    return result.AsStatusResult();
        //}


        //Get Project by Id
        [HttpGet]
        public IActionResult GetProjectById([FromRoute] int projectId)
        {
            var project = _projMangr
            .SearchProject2(
                new ProjectOptions()
                {
                    ProjectId = projectId
                }).SingleOrDefault();

            return Json(project);
        }

        //Get My Projects by Id
        [HttpGet]
        public IActionResult GetMyProjects()
        {
            string userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var myprojectList = _db.Set<Project>()
                .Where(s => s.UserId == userId)
                .ToList();

            return View(myprojectList);
        }

        //Create Project
        [HttpGet]
        public IActionResult CreateProject()
        {
            return View();
        }

        // [Authorize("Admin,Project Creator")]
        [HttpPost]
        public Project CreateProject([FromBody] ProjectOptions projOpt, PledgeOptions pledgeOptions)
        {
            return _projMangr.CreateProject2(projOpt, pledgeOptions);
        }

        //
        //[HttpPost]
        //public Project AddPledge([FromRoute] PledgeOptions pledgeOpts)
        //{
        //    return _projMangr.CreateProject2(pledgeOpts);
        //}

        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetPopularProjects()
        {
            return View();
        }

        

    }
}