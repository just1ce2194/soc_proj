using LinkedIn.NET;
using LinkedIn.NET.Members;
using LinkedIn.NET.Options;
using Soc_Project.DAL.Entities;
using Soc_Project.DAL.Uow;
using Sparkle.LinkedInNET.OAuth2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Soc_Project.BLL.Api
{
    public class LinkedInApiService
    {
        private IUnitOfWork UnitOfWork { get; set; }

        private LinkenInApiWraper linked;

        public LinkedInApiService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;

            linked = LinkenInApiWraper.getInstance();

            Sync();
        }

        public void Sync()
        {
            var scope = AuthorizationScope.ReadBasicProfile | AuthorizationScope.ReadEmailAddress;
            var state = Guid.NewGuid().ToString();
            var redirectUrl = "http://localhost:1883/";
            var url = linked.OAuth2.GetAuthorizationUrl(scope, state, redirectUrl);

            var d = 3;

            //var s = linked.Profiles.GetMyProfile;
            //var persons = UnitOfWork.Persons.Query().ToList();

            //foreach (var person in persons)
            //{
            //    Thread.Sleep(500);

            //    if (!String.IsNullOrEmpty(person.LinkedInId))
            //    {
            //        try
            //        {
            //            var options = new LinkedInGetMemberOptions();
            //            options.BasicProfileOptions.SelectAll();
            //            options.EmailProfileOptions.SelectAll();
            //            options.FullProfileOptions.SelectAll();

            //            options.Parameters.GetBy = LinkedInGetMemberBy.Id;
            //            options.Parameters.RequestBy = person.LinkedInId;

            //            var linkedUser = linked.GetMember(new LinkedInGetMemberOptions());

            //            if (linkedUser != null)
            //            {
            //                var positions = linkedUser.Result.FullProfile.ThreeCurrentPositions;

            //                if (positions != null)
            //                {
            //                    foreach (var career in positions)
            //                    {
            //                        var company = career.Company;

            //                        if (company != null)
            //                        {
            //                            AddOrganization(new Organization()
            //                            {
            //                                Name = company.Name,
            //                                SocialId = company.Id
            //                            });

            //                            var org = UnitOfWork.Organizations.Query().Where(x => x.Name == company.Name).FirstOrDefault();

            //                            AddJob(new Job()
            //                            {
            //                                PersonId = person.Id,
            //                                OrganizationId = org.Id,
            //                                Position = career.Title,
            //                                Start = career.StartDate.Year,
            //                                End = career.EndDate.Year
            //                            });
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //        catch (Exception ex) { }
            //    }
            //}
        }

        private void AddJob(Job job)
        {
            //TODO: create object here and return ID
            var job_ = UnitOfWork.Jobs.FirstOrDefault(x => x.PersonId == job.PersonId && x.OrganizationId == job.OrganizationId);
            if (job_ == null)
            {
                UnitOfWork.Jobs.Add(job);
                UnitOfWork.Save();
            }
        }

        private void AddOrganization(Organization org)
        {
            //TODO: create object here and return ID
            var organization = UnitOfWork.Organizations.FirstOrDefault(x => x.Name == org.Name);
            if (organization == null)
            {
                UnitOfWork.Organizations.Add(org);
                UnitOfWork.Save();
            }
        }
    }
}
