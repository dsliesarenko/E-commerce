﻿using System.Net;

namespace API.Errors
{
    public class ApiException : ApiResponse
    {
        public ApiException(HttpStatusCode statusCode,
            string message = null, string details = null) : base(statusCode, message)
        {
            Details = details;
        }

        public string Details { get; set; }
    }
}
