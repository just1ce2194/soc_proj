using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soc_Project.BLL.Models
{
    public class PersonVm
    {
        public long Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public int? GraduateYear { get; set; }

        public int? GraduateLevelID { get; set; }

        public string VkId { get; set; }

        public string FacebookId { get; set; }

        public string LinkedInId { get; set; }
    }
}
