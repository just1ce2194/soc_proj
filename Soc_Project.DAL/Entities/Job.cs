using Soc_Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soc_Project.DAL.Entities
{
    public class Job
    {
        public long Id { get; set; }

        public long PersonId { get; set; }

        public long? OrganizationId { get; set; }

        public int? End { get; set; }

        public int? Start { get; set; }

        public string Position { get; set; }

        #region Virtual

        public Person Person { get; set; }

        public Organization Organization { get; set; }

        #endregion
    }
}
