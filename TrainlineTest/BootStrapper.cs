using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trainline.ClientProxy;
using Trainline.ClientProxy.TrainlineService;
using HappyDaysConsoleApp.Services;

namespace HappyDaysConsoleApp
{
   public class BootStrapper
    {
       public static UnityContainer StartIoC()
        {
           var container = new UnityContainer();

            container.RegisterType(typeof(ITrainlineService), typeof(TrainlineService));
            container.RegisterType(typeof(ITrainlineServiceClient<ServiceClient>), typeof(TrainlineServiceClient<ServiceClient>), new InjectionConstructor("soap"));

            return container;
        } 
    }
}
