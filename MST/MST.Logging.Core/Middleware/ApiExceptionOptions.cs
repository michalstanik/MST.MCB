using Microsoft.AspNetCore.Http;
using System;

namespace MST.Flogging.Core.Middleware
{
    public class ApiExceptionOptions
    {
        public Action<HttpContext, Exception, ApiError> AddResponseDetails { get; set; }
    }
}
