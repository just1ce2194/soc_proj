using Autofac;
using Autofac.Integration.Mvc;
using Soc_Project.BLL.Api;
using Soc_Project.BLL.Services;
using Soc_Project.DAL.EF;
using Soc_Project.DAL.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Soc_Project.App_Start
{
    public static class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // регистрируем контроллер в текущей сборке
            builder.RegisterControllers(typeof(MvcApplication).Assembly);


            builder.RegisterType<SocContext>().AsSelf();


            // регистрируем споставление типов
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            builder.RegisterType<SocialService>().As<ISocialService>();

            //Apis
            builder.RegisterType<VkApiService>().AsSelf();
            builder.RegisterType<LinkedInApiService>().AsSelf();

            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();
          
            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}