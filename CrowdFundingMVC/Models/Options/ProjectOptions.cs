﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrowdFundingMVC.Models.Options
{
    public class ProjectOptions
    {
        //test
        public int ProjectId { get; set; }
        //test
        public string ProjectTitle { get; set; }
        
        public string ProjectDescription { get; set; }
        //  [Column(TypeName = "decimal(18,4)")]
        public decimal ProjectTargetAmount { get; set; }
        public string ProjectCategory { get; set; }
        [Required, DataType(DataType.Date), Display(Name = "Ending date"), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime ProjectEndingDate { get; set; }
        public string UserId { get; set; }
        public string Creator { get; set; }
        public IFormFile MultimediaURL { get; set; }
        public string FilePath { get; set; }
        public MultimediaTypes MultimediaTypes { get; set; }
        public string ProjectPhotoProfile { get; set; }
        public ICollection<Fund> Funds { get; set; }
    }
}
