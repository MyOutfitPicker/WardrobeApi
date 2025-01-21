namespace WardrobeApi.Application.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WardrobeApi.Data;

    [Route("api/v1/outfits")]
    public class OutfitController : ControllerBase
    {
        private readonly WardrobeContext _context;

        public OutfitController(WardrobeContext context)
        {
            this._context = context;
        }
    }
}