using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Soc_Project.DAL;
using Soc_Project.BLL.Models;
using Soc_Project.DAL.Entities;

namespace Soc_Project.App_Start
{
    public class AutomapperConfig
    {
        public static void Config()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Person, PersonDto>();
                cfg.CreateMap<Person, PersonVm>();
                cfg.CreateMap<PersonVm, Person>();
            });

        }
    }
}