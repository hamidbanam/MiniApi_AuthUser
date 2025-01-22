using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniApi_AuthUser.Application.Tools
{
    public class ApiResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }

        private ApiResponse(bool isSuccess, string message, object? data)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
        }

        public static ApiResponse Success(string message, object? data = null)
        {
            return new ApiResponse(true, message, data);
        }
        public static ApiResponse Failed(string message, object? data = null)
        {
            return new ApiResponse(false, message, data);
        }
    }
}
