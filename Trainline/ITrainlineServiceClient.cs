using System;
using System.ServiceModel;
using Trainline.Models;
using Trainline.TrainlineService;

namespace Trainline
{
    /// <summary>
    /// Trainline service client wrapper
    /// </summary>
    public interface ITrainlineServiceClient
    {
        ServiceResponse<RegisterCustomerResponse> RegisterCustomer(RegisterCustomerRequest request);

        ServiceResponse<AddAddressResponse> AddCustomerAddress(AddAddressRequest request);

        ServiceResponse<GetSavedAddressesResponse> GetCustomerAddress(GetSavedAddressesRequest request);
    }
}