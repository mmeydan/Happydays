using System;
using System.ServiceModel;
using Trainline.Models;
using Trainline.TrainlineService;

namespace Trainline
{
    public class TrainlineServiceClient:ITrainlineServiceClient
    {
        private string _bindingName;
        private string _trainlineUserName;
        private string _trainlineUserPassword;

        public TrainlineServiceClient(string bindingName,string trainlineUserName,string trainlineUserPassword)
        {
            _bindingName = bindingName;
            _trainlineUserName = trainlineUserName;
            _trainlineUserPassword = trainlineUserPassword;
        }

        public ServiceResponse<RegisterCustomerResponse> RegisterCustomer(RegisterCustomerRequest request)
        {
            var apiResponse = SubmitAPIRequest(CreateMessageEnvelope(request));

            return (apiResponse is ErrorResponse)
                             ? new ServiceResponse<RegisterCustomerResponse>(apiResponse as ErrorResponse)
                             : new ServiceResponse<RegisterCustomerResponse>(apiResponse as RegisterCustomerResponse);
        }

        public ServiceResponse<AddAddressResponse> AddCustomerAddress(AddAddressRequest request)
        {
            var apiResponse = SubmitAPIRequest(CreateMessageEnvelope(request));

            return (apiResponse is ErrorResponse)
                             ? new ServiceResponse<AddAddressResponse>(apiResponse as ErrorResponse)
                             : new ServiceResponse<AddAddressResponse>(apiResponse as AddAddressResponse);
        }

        public ServiceResponse<GetSavedAddressesResponse> GetCustomerAddress(GetSavedAddressesRequest request)
        {
            var apiResponse = SubmitAPIRequest(CreateMessageEnvelope(request));

            return (apiResponse is ErrorResponse)
                             ? new ServiceResponse<GetSavedAddressesResponse>(apiResponse as ErrorResponse)
                             : new ServiceResponse<GetSavedAddressesResponse>(apiResponse as GetSavedAddressesResponse);
        }

        private RequestEnvelope CreateMessageEnvelope(RequestBody requestBody)
        {
            return new RequestEnvelope
            {
                Authentication = new UsernameAndPassword { Username = _trainlineUserName, Password = _trainlineUserPassword },
                Request = requestBody
            };
        }

        private Response SubmitAPIRequest(RequestEnvelope request)
        {
            Exception exception = null;
            Response response = null;
            ServiceClient serviceClient = null; 

            try
            {
                serviceClient = new ServiceClient(_bindingName);
                serviceClient.Open();
                return serviceClient.Process(request);
            }
            // The following is typically thrown on the client when a channel is terminated due to the server closing the connection.
            catch (ChannelTerminatedException ex)
            {
                exception = ex;
            }
            // The following is thrown when a remote endpoint could not be found or reached.  The endpoint may not be found or
            // reachable because the remote endpoint is down, the remote endpoint is unreachable, or because the remote network is unreachable.
            catch (EndpointNotFoundException ex)
            {
                exception = ex;
            }
            // The following exception that is thrown when a server is too busy to accept a message.
            catch (ServerTooBusyException ex)
            {
                exception = ex;
            }
            catch (TimeoutException ex)
            {
                exception = ex;
            }
            catch (FaultException ex)
            {
                exception = ex;
            }
            catch (CommunicationException ex)
            {
                exception = ex;
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            finally
            {
                if (serviceClient != null && serviceClient.State == CommunicationState.Opened)
                {
                    serviceClient.Close();
                }
                else if (serviceClient != null && serviceClient.State != CommunicationState.Closed)
                {
                    serviceClient.Abort();
                }

                if (serviceClient is IDisposable)
                {
                    ((IDisposable)serviceClient).Dispose();
                }
            }

            if (exception != null)
            {
                throw exception;
            }

            return response;
        }
    }
}
