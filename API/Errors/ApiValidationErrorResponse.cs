﻿using System.Net;

namespace API.Errors
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        public ApiValidationErrorResponse() : base(HttpStatusCode.BadRequest)
        {
        }

        public IEnumerable<string> Errors { get; set; }
    }
}
