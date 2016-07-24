using RandomData;
using Trainline.TrainlineService;

namespace Trainline.UnitTests
{
    public class TestHelper
    {
        public static GetSavedAddressesRequest GetGetSavedAddressesRequest(string email)
        {
            return new GetSavedAddressesRequest
            {
                CustomerCredentials = new Credentials
                {
                    EmailAddress = email,
                    Password = "123456789"
                }
            };
        }

        public static AddAddressRequest AddCustomerAddress(string email)
        {
            return new AddAddressRequest
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
            };
        }

        public static RegisterCustomerRequest RegisterCustomer(string email)
        {
           return new RegisterCustomerRequest
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
           };
        }
    }
}
