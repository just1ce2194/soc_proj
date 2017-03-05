using Soc_Project.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Soc_Project.Models.Job
{
    public class JobsVm
    {
        public JobsVm()
        {
            this.Jobs = new List<JobDto>();
        }

        public List<JobDto> Jobs { get; set; }
    }
}