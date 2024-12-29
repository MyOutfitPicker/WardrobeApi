// -----------------------------------------------------------------------
// <copyright file="OutfitController.cs" company="WardrobeApi">
//     Copyright (c) WardrobeApi. All rights reserved.
//     Licensed under the MIT License (MIT). See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------
// <summary>
//     Represents the entry point to the outfit endpoint.
// </summary>
// -----------------------------------------------------------------------

namespace WardrobeApi.Application.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WardrobeApi.Data;

    /// <summary>
    /// Controller for managing outfit-related operations.
    /// </summary>
    [Route("api/v1/outfits")]
    public class OutfitController : ControllerBase
    {
        /// <summary>
        /// The Wardrobe database context that acts as a bridge between the application and the database.
        /// </summary>
        private readonly WardrobeContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="OutfitController"/> class.
        /// </summary>
        /// <param name="context">The database context for the wardrobe.</param>
        public OutfitController(WardrobeContext context)
        {
            this._context = context;
        }
    }
}