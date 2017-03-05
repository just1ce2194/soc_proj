using Soc_Project.BLL.Models;
using Soc_Project.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Soc_Project.Models
{
    public class PeopleVm
    {
        public PeopleVm()
        {
            this.Persons = new List<PersonDto>();
        }

        public List<PersonDto> Persons { get; set; }
    }
}