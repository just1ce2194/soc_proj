using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soc_Project.BLL.Models;
using Soc_Project.DAL.Uow;
using AutoMapper;
using Soc_Project.DAL;
using VkNet;
using Soc_Project.BLL.Api;
using Soc_Project.DAL.Entities;
using Soc_Project.Models;
using Soc_Project.Models.Dto;
using Soc_Project.Models.Job;

namespace Soc_Project.BLL.Services
{
    public class SocialService : ISocialService
    {
        private IUnitOfWork Database { get; set; }

        private VkApiService VkApiService { get; set; }
        
        private LinkedInApiService LinkedInApiService { get; set; }

        public SocialService(IUnitOfWork uow, VkApiService vkApiService, LinkedInApiService linkedInApiService)
        {
            this.Database = uow;
            this.VkApiService = vkApiService;
            this.LinkedInApiService = linkedInApiService;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public JobsVm GetJobs()
        {
            var result = new JobsVm();

            var jobs = Database.Jobs.Query(x => x.Person, x => x.Organization).ToList();
            var jobss = Database.Jobs.Query().ToList();
            foreach (var job in jobs)
            {
                result.Jobs.Add(new JobDto()
                {
                    Id = job.Id,
                    Start = job.Start.GetValueOrDefault(),
                    End = job.End.GetValueOrDefault(),
                    Employer = job.Person.FullName,
                    Organization = job.Organization.Name,
                    Position = job.Position
                });
            }

            return result;
        }

        public PeopleVm GetPeople()
        {
            var result = new PeopleVm();

            Database.Persons.Query().ToList().ForEach(x => result.Persons.Add(Mapper.Map<Person, PersonDto>(x)));

            return result;
        }

        public void AddPerson(PersonVm person)
        {
            if (person.Id == 0)
            {
                Database.Persons.Add(Mapper.Map<PersonVm, Person>(person));
                Database.Save();
            }
            else
            {
                var entity = Database.Persons.FirstOrDefault(x => x.Id == person.Id);
                if (entity != null)
                {
                    entity.FirstName = person.FirstName;
                    entity.LastName = person.LastName;
                    entity.MiddleName = person.MiddleName;
                    entity.LinkedInId = person.LinkedInId;
                    entity.VkId = person.VkId;
                    entity.FacebookId = person.FacebookId;
                    entity.GraduateYear = person.GraduateYear;

                    Database.Persons.Update(entity);
                    Database.Save();
                }
            }
        }

        public PersonVm GetPerson(long? id)
        {
            var result = new PersonVm();

            if (id.HasValue)
            {
                var person = Database.Persons.FirstOrDefault(x => x.Id == id);

                if (person != null)
                {
                    result = Mapper.Map<Person, PersonVm>(person);
                }
            }

            return result;
        }
    }
}
