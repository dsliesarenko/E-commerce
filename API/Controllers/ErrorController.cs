using API.Errors;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [Route("errors/{code}")]
    public class ErrorController : BaseApiController
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error(HttpStatusCode code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
