namespace MyWardrobeApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class ErrorController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("/error")]
        public IActionResult Error()
        {
            return this.Problem();
        }
    }
}
