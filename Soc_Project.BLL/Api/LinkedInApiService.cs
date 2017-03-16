using LinkedIn.NET;
using LinkedIn.NET.Members;
using LinkedIn.NET.Options;
using Soc_Project.DAL.Entities;
using Soc_Project.DAL.Uow;
using Sparkle.LinkedInNET;
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

        private string redirectUrl = "http://localhost:1883/LinkedPerson";

        public LinkedInApiService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;

            linked = LinkenInApiWraper.getInstance();
        }

        public void SaveUserInfo(string authorizationCode)
        {
            var access_token = linked.OAuth2.GetAccessToken(authorizationCode, redirectUrl);

            UserAuthorization d = new UserAuthorization(access_token.AccessToken);

            var fieldSelector = FieldSelector.For<Sparkle.LinkedInNET.Profiles.Person>();
            fieldSelector.Add("first-name");
            fieldSelector.Add("last-name");
            fieldSelector.Add("positions");
            fieldSelector.Add("public-profile-url");

            var linkedUser = linked.Profiles.GetMyProfile(d, null, fieldSelector);

            var user = UnitOfWork.Persons.Query(x => x.Jobs).FirstOrDefault(x => x.FirstName == linkedUser.Firstname && x.LastName == linkedUser.Lastname);

            if (user == null)
            {
                user = new Person() { FirstName = linkedUser.Firstname, LastName = linkedUser.Lastname, LinkedInId = linkedUser.PublicProfileUrl };
                UnitOfWork.Persons.Add(user);
                UnitOfWork.Save();
            }

            foreach (var position in linkedUser.Positions.Position)
            {
                var org = UnitOfWork.Organizations.FirstOrDefault(x => x.Name == position.Company.Name);

                if (org == null)
                {
                    org = new Organization()
                    {
                        Name = position.Company.Name,
                        SocialId = position.Company.Id.ToString()
                    };

                    UnitOfWork.Organizations.Add(org);
                    UnitOfWork.Save();
                }

                user.Jobs.Add(new Job() { Position = position.Title, Start = position.StartDate != null ? position.StartDate.Year : null, End = position.EndDate != null ? position.EndDate.Year : null, OrganizationId = org.Id });
            }

            UnitOfWork.Save();
        }

        public string GetAuthorizationCode()
        {
            var scope = AuthorizationScope.ReadBasicProfile | AuthorizationScope.ReadEmailAddress;
            var state = Guid.NewGuid().ToString();
            var url = linked.OAuth2.GetAuthorizationUrl(scope, state, redirectUrl);

            return url.AbsoluteUri;
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
