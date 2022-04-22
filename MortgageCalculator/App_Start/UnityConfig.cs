using MortgageBLL.IServices;
using MortgageBLL.Services;
using MortgageCalculator.Exceptions;
using MortgageDAL.Repository;
using MortgageLogger;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace MortgageCalculator
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IMortgageService, MortgageService>();
            container.RegisterType<IMortgageRepository, MortgageRepository>();
            container.RegisterType<MortgageDAL.Models.MortgageEntities>();
            container.RegisterType<IMortgateLoanCalulator, MortgateLoanCalulator>();
            container.RegisterType<SingletonLogger>();
            container.RegisterType<MartgageExceptionFilter>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}