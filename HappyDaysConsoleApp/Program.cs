using Microsoft.Practices.Unity;
using HappyDaysConsoleApp.Services;
using Trainline.TrainlineService;
using System;
using RandomData;
using NLog;

namespace HappyDaysConsoleApp
{
    class Program
    {
        private static readonly IUnityContainer _container = BootStrapper.StartIoC();
        private static readonly ICustomerService _customerService = _container.Resolve<ICustomerService>();
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            string uniqueCustomerEmail = TestData.RandomEmail;

            try
            {
                RegisterCustomer(uniqueCustomerEmail);
                AddCustomerAddress(uniqueCustomerEmail);
                GetCustomerAddress(uniqueCustomerEmail);
            }
            catch (Exception ex)
            {
                //Catch communication and timeout exceptions here if we want to retry or log exception
                Console.WriteLine($"Exception {ex.Message}");
                _logger.Error(ex);
            }
        }

        private static void GetCustomerAddress(string email)
        {
            _customerService.GetCustomerAddress(new GetSavedAddressesRequest
            {
                CustomerCredentials = new Credentials
                {
                    EmailAddress = email,
                    Password = "123456789"
                }
            });
        }

        private static void AddCustomerAddress(string email)
        {
            _customerService.AddCustomerAddress(new AddAddressRequest
            {
                Address = new Address
                {
                    Alias = "Office Address",
                    CountryCode = "Z0",
                    CountryName = "UK",
                    Line1 = TestData.RandomStreet,
                    Line2 = "London",
                    Postcode = TestData.RandomPostCode,
                    Type = AddressType.Billing
                },
                CustomerCredentials = new Credentials
                {
                    EmailAddress = email,
                    Password = "123456789"
                }
            });
        }

        private static void RegisterCustomer(string email)
        {
            _customerService.RegisterCustomer(new RegisterCustomerRequest
            {
                Title = "Mr",
                Forename = TestData.RandomFirstName,
                Surname = TestData.RandomSurname,
                DaytimePhoneNumber = "012345678901",
                HomeAddress = new Address
                {
                    CountryCode = "Z0",
                    CountryName = "UK",
                    Line1 = TestData.RandomStreet,
                    Line2 = "London",
                    Postcode = TestData.RandomPostCode,
                },
                CustomerCredentials = new Credentials
                {
                    EmailAddress = email,
                    Password = "123456789"
                },
                DataProtectionActConcentIndicators = new DataProtectionActConcentIndicators
                {
                    DataProtectionAct1984ConsentIndicator = true,
                    DataProtectionAct2003ConsentIndicator = true
                }
            });
        }
    }
}
