// -----------------------------------------------------------------------
// <copyright file="ErrorController.cs" company="WardrobeApi">
//     Copyright (c) WardrobeApi. All rights reserved.
//     Licensed under the MIT License (MIT). See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------
// <summary>
//     Represents global application errors.
// </summary>
// -----------------------------------------------------------------------

namespace WardrobeApi.Application.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller for handling global application errors.
    /// </summary>
    [ApiController]
    [Route("api/v1/error")]
    public class ErrorController : ControllerBase
    {
        /// <summary>
        /// Handles application errors and returns a standardized error response.
        /// </summary>
        /// <remarks>
        /// This endpoint is not exposed in the API documentation due to <see cref="ApiExplorerSettingsAttribute"/>.
        /// </remarks>
        /// <returns>A standardized problem details response.</returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error()
        {
            return this.Problem();
        }
    }
}
