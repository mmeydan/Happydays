using Trainline.TrainlineService;

namespace Trainline.Models
{
    /// <summary>
    /// Wrapper for the response model
    /// </summary>
    /// <typeparam name="T">Generic model returned from the service</typeparam>
    public class ServiceResponse<T>
    {
        public bool HasError { get { return Error != null; } }
        public ErrorResponse Error { get; set; }
        public T Model { get; set; }

        public ServiceResponse() { }

        public ServiceResponse(T model) 
        {
            Model = model;
        }

        public ServiceResponse(ErrorResponse error)
        {
            Error = error;
        }
    }
}
