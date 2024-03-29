﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobOffersProject.Model
{
    public class JobOffer
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string JobId { get; set; }
        public string Company { get; set; }
        public string Localization { get; set; }
        public string Experience { get; set; }
        public string Salary { get; set; }
        public string Currency { get; set; }
        public string PublishDate { get; set; }
        public string EndDate { get; set; }
        public string Href { get; set; }
        public string Site { get; set; }
    }
}