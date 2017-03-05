using Soc_Project.BLL.Models;
using Soc_Project.Models;
using Soc_Project.Models.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Soc_Project.BLL.Services
{
    public interface ISocialService
    {
        JobsVm GetJobs();

        PeopleVm GetPeople();

        PersonVm GetPerson(long? id);

        void AddPerson(PersonVm model);

    }
}
