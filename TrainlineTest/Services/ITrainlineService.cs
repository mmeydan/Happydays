using Trainline.ClientProxy.TrainlineService;

namespace HappyDaysConsoleApp.Services
{
    public interface ITrainlineService
    {
        void AddCustomerAddress();
        void GetCustomerAddress();
        void RegisterCustomer(RegisterCustomerRequest registerCustomerRequest);
    }
}