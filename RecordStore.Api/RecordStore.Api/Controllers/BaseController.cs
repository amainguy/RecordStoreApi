using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RecordStore.Api.Controllers
{
    public class BaseController : Controller
    {
        protected async Task<IActionResult> TryExecutingServiceAsync(Action action, IActionResult actionResultWhenSucceed)
        {
            try
            {
                await Task.Run(action);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

            return actionResultWhenSucceed;
        }
    }
}
