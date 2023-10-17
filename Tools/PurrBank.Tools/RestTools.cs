using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PurrBank.Tools
{
    public static class RestTools<T>
    {
        public static async Task<IActionResult> Return(dynamic result)
        {
            var actionResult = new ObjectResult(result);
            if (result.Message.Contains("Ok"))
            {
                actionResult.StatusCode = StatusCodes.Status200OK;
            }
            else if (result.Message.Contains("BadRequest"))
            {
                actionResult.StatusCode = StatusCodes.Status400BadRequest;

            }
            else if (result.Message.Contains("NoContent"))
            {
                actionResult.StatusCode = StatusCodes.Status204NoContent;
            }
            return actionResult;
        }
    }
}
