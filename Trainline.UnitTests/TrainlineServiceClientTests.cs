using FluentAssertions;
using NUnit.Framework;
using RandomData;
using System.Configuration;
using Trainline.TrainlineService;
using Trainline.UnitTests;

namespace Trainline.Tests
{
    [TestFixture]
    public class TrainlineServiceClientTests
    {
        ITrainlineServiceClient _trainlineServiceClient = new TrainlineServiceClient("soap", ConfigurationManager.AppSettings["TrainlineUserName"], ConfigurationManager.AppSettings["TrainlineUserPass"]);

        [Test]
        public void RegisterCusomterTest_ShouldReturn_RegisterCustomerResponse()
        {
           var customerEmail = TestData.RandomEmail;
           var response = _trainlineServiceClient.RegisterCustomer(TestHelper.RegisterCustomer(customerEmail));

            response.Model.Should().BeOfType<RegisterCustomerResponse>();
        }

        [Test]
        public void RegisterCusomterTest_ShouldReturnErrorResponse_WhenAddressIsInvalid()
        {
            var customerEmail = TestData.RandomEmail;
            var invalidAddressRequest = TestHelper.RegisterCustomer(customerEmail);
            invalidAddressRequest.HomeAddress.Line1 = null;
            invalidAddressRequest.HomeAddress.Line2 = null;
            invalidAddressRequest.HomeAddress.Postcode= null;

            var response = _trainlineServiceClient.RegisterCustomer(invalidAddressRequest);

            response.HasError.Should().BeTrue();
            response.Error.Should().NotBeNull();
        }

        [Test]
        public void AddCustomerAddressTest_ShouldReturn_RegisterCustomerResponse()
        {
            var customerEmail = TestData.RandomEmail;
            
            //Register customer first
            _trainlineServiceClient.RegisterCustomer(TestHelper.RegisterCustomer(customerEmail));
            
            //Add Customer Address
            var response = _trainlineServiceClient.AddCustomerAddress(TestHelper.AddCustomerAddress(customerEmail));

            response.Model.Should().BeOfType<AddAddressResponse>();
        }

        [Test]
        public void GetCustomerAddressTest_ShouldReturn_RegisterCustomerResponse()
        {
            var customerEmail = TestData.RandomEmail;
            var registerCustomerRequest = TestHelper.RegisterCustomer(customerEmail);
            var addCustomerAddressRequest = TestHelper.AddCustomerAddress(customerEmail);

            //Register customer first
            _trainlineServiceClient.RegisterCustomer(registerCustomerRequest);

            //Add Customer Address
            _trainlineServiceClient.AddCustomerAddress(addCustomerAddressRequest);

            //Get Customer Addresses
            var response = _trainlineServiceClient.GetCustomerAddress(TestHelper.GetGetSavedAddressesRequest(customerEmail));

            response.Model.Should().BeOfType<GetSavedAddressesResponse>();
            var address1 = response.Model.Addresses[0];
            address1.Line1.ShouldBeEquivalentTo(registerCustomerRequest.HomeAddress.Line1);
            address1.Line2.ShouldBeEquivalentTo(registerCustomerRequest.HomeAddress.Line2);
            address1.Postcode.ShouldBeEquivalentTo(registerCustomerRequest.HomeAddress.Postcode);

            var address2 = response.Model.Addresses[1];
            address2.Line1.ShouldBeEquivalentTo(addCustomerAddressRequest.Address.Line1);
            address2.Line2.ShouldBeEquivalentTo(addCustomerAddressRequest.Address.Line2);
            address2.Postcode.ShouldBeEquivalentTo(addCustomerAddressRequest.Address.Postcode);
        }

    }
}