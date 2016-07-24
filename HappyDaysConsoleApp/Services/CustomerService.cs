using System;
using System.Linq;
using Trainline;
using Trainline.TrainlineService;

namespace HappyDaysConsoleApp.Services
{
    /// <summary>
    /// Interacts with Trainline Service library
    /// </summary>
    public class CustomerService : ICustomerService
    {
        private readonly ITrainlineServiceClient _trainlineServiceClient;
        public CustomerService(ITrainlineServiceClient trainlineServiceClient)
        {
            _trainlineServiceClient = trainlineServiceClient;
        }

        public void AddCustomerAddress(AddAddressRequest request)
        {
            var response = _trainlineServiceClient.AddCustomerAddress(request);

            if (!response.HasError)
            {
                Console.WriteLine($"Customer address created for: {request.CustomerCredentials.EmailAddress} {Environment.NewLine}");
            }
            else
            {
                response.Error.Errors.ToList().ForEach(x => Console.WriteLine($" AddAddressRequest-Error: {x.Message}"));
                Console.WriteLine("");
            }
        }

        public void GetCustomerAddress(GetSavedAddressesRequest request)
        {
            var response = _trainlineServiceClient.GetCustomerAddress(request);

            if (!response.HasError)
            {
                Console.WriteLine($"Customer address retrieved for: {request.CustomerCredentials.EmailAddress} {Environment.NewLine}");
                response.Model.Addresses.ToList().ForEach(x => Console.WriteLine($" Alias:  {x.Alias} - {x.CountryName} - {x.Line1} - {x.Line2}"));
            }
            else
            {
                response.Error.Errors.ToList().ForEach(x => Console.WriteLine($" GetCustomerAddress-Error: {x.Message}"));
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// Submits request to Trainline Service to register a customer and if there is no error display status in console
        /// </summary>
        /// <param name="request"></param>
        public void RegisterCustomer(RegisterCustomerRequest request)
        {
           var response = _trainlineServiceClient.RegisterCustomer(request);

            if (!response.HasError)
            {
                Console.WriteLine($"Customer registered for: {request.CustomerCredentials.EmailAddress} {Environment.NewLine}");
            }
            else
            {
                response.Error.Errors.ToList().ForEach(x => Console.WriteLine($" RegisterCustomer-Error: {x.Message}"));
                Console.WriteLine("");
            }
        }
    }
}
