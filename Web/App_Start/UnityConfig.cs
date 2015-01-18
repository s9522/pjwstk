using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Unity.Mvc5;
using Pjatk.Pab.Books.BLL.Interfaces;
using Pjatk.Pab.Books.BLL.Facades;

namespace Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.LoadConfiguration();

            //container.RegisterType<IAuthors, AuthorsFacade>();
            // e.g. container.RegisterType<ITestService, TestService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}