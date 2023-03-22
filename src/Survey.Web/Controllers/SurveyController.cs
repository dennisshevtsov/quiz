// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.Web.Controllers
{
  using System;

  using Microsoft.AspNetCore.Mvc;

  using Survey.Web.Defaults;
  using Survey.Web.ViewModels;
  using Survey.Domain.Services;

  /// <summary>Provides a simple API to handle HTTP request.</summary>
  [ApiController]
  [Route(SurveyController.SurveyRoute)]
  [Produces(ContentType.Json)]
  public sealed class SurveyController : ControllerBase
  {
    private const string SurveyRoute = "api/survey";

    private readonly ISurveyService _surveyService;

    /// <summary>Initializes a new instance of the <see cref="Survey.Api.Controllers.SurveyController"/> class.</summary>
    /// <param name="surveyService">An object that provides a simple API to the survey entity.</param>
    public SurveyController(ISurveyService surveyService)
    {
      _surveyService = surveyService ?? throw new ArgumentNullException(nameof(surveyService));
    }

    /// <summary>Handles the add survey command request.</summary>
    /// <param name="vm"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost(Name = nameof(SurveyController.AddSurvey))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Consumes(typeof(SurveyViewModel), ContentType.Json)]
    public async Task<IActionResult> AddSurvey([FromBody] SurveyViewModel vm, CancellationToken cancellationToken)
    {
      await _surveyService.AddNewSurveyAsync(vm, cancellationToken);

      return Ok();
    }
  }
}
