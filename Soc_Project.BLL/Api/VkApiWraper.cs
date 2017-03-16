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
            //Set here yours credentionals, AppId. See: https://vk.com/dev/web_how_to_start

            ulong appID = 0;
            string email = "+";
            string pass = "";
            Settings scope = Settings.All;

            //Authorize(new ApiAuthParams
            //{
            //    ApplicationId = appID,
            //    Login = email,
            //    Password = pass,
            //    Settings = scope
            //});
        }

        public static VkApiWraper getInstance()
        {
            if (instance == null)
                instance = new VkApiWraper();
            return instance;
        }
    }
}
