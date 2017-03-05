using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Soc_Project.Models.Dto
{
    public class JobDto
    {
        public long Id { get; set; }

        public string Employer { get; set; }

        public int Start { get; set; }

        public int End { get; set; }

        public string Position { get; set; }

        public string Organization { get; set; }

    }
}