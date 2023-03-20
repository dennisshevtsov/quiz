// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.Api.Controllers
{
  using Microsoft.AspNetCore.Mvc;

  using Survey.Api.ViewModels;

  /// <summary>Provides a simple API to handle HTTP request.</summary>
  [ApiController]
  [Route("api/survey")]
  [Produces("application/json")]
  public sealed class SurveyController : ControllerBase
  {
    [HttpPost(Name = nameof(SurveyController.AddSurvey))]
    [Consumes(typeof(SurveyViewModel), "application/json")]
    public IActionResult AddSurvey([FromBody] SurveyViewModel vm)
    {
      return Ok(vm);
    }
  }
}
