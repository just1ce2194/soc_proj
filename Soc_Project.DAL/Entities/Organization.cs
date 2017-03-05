using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soc_Project.DAL.Entities
{
    public class Organization
    {
        public long Id { get; set; }

        public string SocialId { get; set; }

        public string Name { get; set; }

        public ICollection<Job> Jobs { get; set; }
    }
}
