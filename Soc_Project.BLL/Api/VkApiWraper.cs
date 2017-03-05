using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet;
using VkNet.Enums.Filters;

namespace Soc_Project.BLL.Api
{
    class VkApiWraper : VkApi
    {
        private static VkApiWraper instance;

        protected VkApiWraper() : base()
        {
            ulong appID = 5783219;
            string email = "+380992361276";
            string pass = "";
            Settings scope = Settings.All;

            Authorize(new ApiAuthParams
            {
                ApplicationId = appID,
                Login = email,
                Password = pass,
                Settings = scope
            });
        }

        public static VkApiWraper getInstance()
        {
            if (instance == null)
                instance = new VkApiWraper();
            return instance;
        }
    }
}
