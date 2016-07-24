using Microsoft.Practices.Unity;
using HappyDaysConsoleApp.Services;
using Trainline;
using System.Configuration;

namespace HappyDaysConsoleApp
{
    public class BootStrapper
    {
       public static UnityContainer StartIoC()
        {
           var container = new UnityContainer();

            container.RegisterType(typeof(ICustomerService), typeof(CustomerService));
            container.RegisterType(typeof(ITrainlineServiceClient), typeof(TrainlineServiceClient), new InjectionConstructor("soap", ConfigurationManager.AppSettings["TrainlineUserName"], ConfigurationManager.AppSettings["TrainlineUserPass"]));

            return container;
        } 
    }
}
