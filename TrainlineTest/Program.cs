using Microsoft.Practices.Unity;
using Trainline.ClientProxy;
using Trainline.ClientProxy.TrainlineService;
using HappyDaysConsoleApp.Services;

namespace HappyDaysConsoleApp
{
    class Program
    {
        private static readonly IUnityContainer _container= BootStrapper.StartIoC();
        private static readonly ITrainlineService _trainlineService= _container.Resolve<ITrainlineService>();
        static void Main(string[] args)
        {
            _trainlineService.RegisterCustomer(new RegisterCustomerRequest
            {
                CustomerCredentials = new Credentials { EmailAddress = "test1@hotmail.com", Password = "123456789" },
                DataProtectionActConcentIndicators = new DataProtectionActConcentIndicators
                { DataProtectionAct1984ConsentIndicator = true, DataProtectionAct2003ConsentIndicator = true },
                Title = "Mr",
                Forename = "James",
                Surname = "Smith",
                DaytimePhoneNumber = "012345678901",
                HomeAddress = new Address
                {
                    CountryCode = "Z0",
                    CountryName = "UK",
                    Line1 = "123 Great portland street",
                    Line2 = "London",
                    Postcode = "EC3n 1AH"
                }
            });

            //{
            //    Authentication = new UsernameAndPassword { Username = "TRAINLINE_INTERVIEW", Password = "8gP9t49a" },
            //    Request = new RegisterCustomerRequest
            //    {
            //        CustomerCredentials = new Credentials { EmailAddress = "test1@hotmail.com", Password = "123456789" },
            //        DataProtectionActConcentIndicators = new DataProtectionActConcentIndicators
            //        { DataProtectionAct1984ConsentIndicator = true, DataProtectionAct2003ConsentIndicator = true },
            //        Title = "Mr",
            //        Forename = "James",
            //        Surname = "Smith",
            //        DaytimePhoneNumber = "012345678901",
            //        HomeAddress = new Address
            //        {
            //            CountryCode = "Z0",
            //            CountryName = "UK",
            //            Line1 = "123 Great portland street",
            //            Line2 = "London",
            //            Postcode = "EC3n 1AH"
            //        }
            //    }
            //};

           var response = trainlineService.Process(request);
            trainlineService.Close();
        }
    }
}
