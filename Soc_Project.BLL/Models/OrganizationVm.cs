using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soc_Project.BLL.Models
{
    public class OrganizationDto
    {
        public long Id { get; set; }

        public string VkId { get; set; }

        public string Name { get; set; }

        public List<PositionDto> Positions { get; set; }
    }
}
