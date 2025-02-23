namespace AdessoApi.Data.DTOs.Response.Shared
{
    public class ServiceResponse<T>
    {
        public bool Succeed { get; set; } = true;
        public string Message { get; set; } = "";
        public T? Data { get; set; } // Single object return type
        public List<T>? DataList { get; set; } // List return type

        // SetSuccessAdd for a successful creation
        public ServiceResponse<T> SetSuccessAdd(string entity, T data, string? message = null)
        {
            Succeed = true;
            Message = message ?? $"{entity} created successfully.";
            Data = data;
            return this;
        }

        // SetErrorAdd for an error during creation
        public ServiceResponse<T> SetErrorAdd(string entity, string? message = null)
        {
            Succeed = false;
            Message = message ?? $"{entity} could not be created.";
            return this;
        }

        // SetSuccessData for a successful data retrieval, list of items
        public ServiceResponse<T> SetSuccessData(List<T> data, string? message = null)
        {
            Succeed = true;
            Message = message ?? "Data retrieved successfully.";
            DataList = data; // Return the list of data
            return this;
        }

        // SetSuccessData for returning a single item
        public ServiceResponse<T> SetSuccessData(T data, string? message = null)
        {
            Succeed = true;
            Message = message ?? "Data retrieved successfully.";
            Data = data; // Return the single data item
            return this;
        }

        // Error handling if the request body is invalid
        public ServiceResponse<T> SetRequestBodyError(string? message = null)
        {
            Succeed = false;
            Message = message ?? "Please check your request data.";
            return this;
        }

        // If the object wasn't found
        public ServiceResponse<T> SetObjectNotFound(string entity, string? message = null)
        {
            Succeed = false;
            Message = message ?? $"{entity} could not be found.";
            return this;
        }

        // Generic success method
        public ServiceResponse<T> SetSuccess(string? message = null)
        {
            Succeed = true;
            Message = message ?? "Operation succeeded.";
            return this;
        }

        public ServiceResponse<T> SetError(string? message = null)
        {
            Succeed = true;
            Message = message ?? "Operation failed.";
            return this;
        }
    }
}
