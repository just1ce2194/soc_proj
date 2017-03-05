using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soc_Project.BLL.Models
{
    public class PositionDto
    {
        public string Name { get; set; }

        public List<YearCountAlumnusDto> Alumnuses { get; set; }
    }
}
