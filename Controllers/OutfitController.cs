namespace MyWardrobeApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyWardrobeApi.Data;

    [Route("api/[controller]")]
    public class OutfitController : ControllerBase
    {
        private readonly WardrobeContext _context;

        public OutfitController(WardrobeContext context)
        {
            this._context = context;
        }
    }
}