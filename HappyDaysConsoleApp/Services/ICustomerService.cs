using Trainline.TrainlineService;

namespace HappyDaysConsoleApp.Services
{
    public interface ICustomerService
    {
        void AddCustomerAddress(AddAddressRequest request);
        void GetCustomerAddress(GetSavedAddressesRequest request);
        void RegisterCustomer(RegisterCustomerRequest request);
    }
}