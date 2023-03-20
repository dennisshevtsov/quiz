// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.Api.Controllers
{
  using Microsoft.AspNetCore.Mvc;

  using Survey.Api.Defaults;
  using Survey.Api.ViewModels;

  /// <summary>Provides a simple API to handle HTTP request.</summary>
  [ApiController]
  [Route(SurveyController.SurveyRoute)]
  [Produces(ContentType.Json)]
  public sealed class SurveyController : ControllerBase
  {
    private const string SurveyRoute = "api/survey";

    [HttpPost(Name = nameof(SurveyController.AddSurvey))]
    [Consumes(typeof(SurveyViewModel), ContentType.Json)]
    public IActionResult AddSurvey([FromBody] SurveyViewModel vm)
    {
      return Ok(vm);
    }
  }
}
