using Sparkle.LinkedInNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soc_Project.BLL.Api
{
    class LinkenInApiWraper : LinkedInApi
    {
        private static LinkenInApiWraper instance;

        protected LinkenInApiWraper(LinkedInApiConfiguration config) : base(config)
        {

        }

        public static LinkenInApiWraper getInstance()
        {
            if (instance == null)
            {
                var config = new LinkedInApiConfiguration("86eiib65xp5z67", "xyA4alNXOLO2GiyZ");
                instance = new LinkenInApiWraper(config);
            }
            return instance;
        }
    }
}
