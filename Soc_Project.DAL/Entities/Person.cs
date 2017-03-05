using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soc_Project.DAL.Entities
{
    public class Person
    {
        public Person()
        {
            Jobs = new List<Job>();
        }

        public long Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public int? GraduateYear { get; set; }

        public int? GraduateLevelID { get; set; }

        public string VkId { get; set; }

        public string FacebookId { get; set; }

        public string LinkedInId { get; set; }

        #region Virtual

        public ICollection<Job> Jobs { get; set; }

        #endregion

        #region Custom

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        #endregion
    }
}
