using Soc_Project.DAL.Entities;
using Soc_Project.DAL.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VkNet;
using VkNet.Enums.Filters;

namespace Soc_Project.BLL.Api
{
    public class VkApiService
    {
        private IUnitOfWork UnitOfWork { get; set; }

        private VkApiWraper vk;

        public VkApiService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;

            vk = VkApiWraper.getInstance();

            Sync();
        }
       
        public void Sync()
        {
            var persons = UnitOfWork.Persons.Query().ToList();

            foreach (var person in persons)
            {
                Thread.Sleep(500);

                if (!String.IsNullOrEmpty(person.VkId))
                {
                    try
                    {
                        var vkUser = vk.Users.Get(person.VkId, ProfileFields.All);

                        if (vkUser != null)
                        {
                            if (vkUser.Career != null)
                            {
                                foreach (var career in vkUser.Career)
                                {
                                    var company = career.Company != null ? career.Company : vk.Groups.GetById(career.GroupId.GetValueOrDefault()).Name;

                                    if (company != null)
                                    {
                                        AddOrganization(new Organization()
                                        {
                                            Name = company,
                                            SocialId = career.GroupId.GetValueOrDefault().ToString()
                                        });

                                        var org = UnitOfWork.Organizations.Query().Where(x => x.Name == company).FirstOrDefault();

                                        AddJob(new Job()
                                        {
                                            PersonId = person.Id,
                                            OrganizationId = org.Id,
                                            Position = career.Position,
                                            Start = career.From.HasValue ? (int?)Convert.ToInt32(career.From.Value) : null,
                                            End = career.Until.HasValue ? (int?)Convert.ToInt32(career.Until.Value) : null,
                                        });

                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex) { }
                }
            }
        }

        private void AddJob(Job job)
        {
            var job_ = UnitOfWork.Jobs.FirstOrDefault(x => x.PersonId == job.PersonId && x.OrganizationId == job.OrganizationId);
            if (job_ == null)
            {
                UnitOfWork.Jobs.Add(job);
                UnitOfWork.Save();
            }
        }

        private void AddOrganization(Organization org)
        {
            var organization = UnitOfWork.Organizations.FirstOrDefault(x => x.Name == org.Name);
            if (organization == null)
            {
                UnitOfWork.Organizations.Add(org);
                UnitOfWork.Save();
            }
        }
    }
}
