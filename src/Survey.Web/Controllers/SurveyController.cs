// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.Web.Controllers
{
  using System;

  using Microsoft.AspNetCore.Mvc;

  using Survey.Domain.Services;
  using Survey.Web.Defaults;
  using Survey.Web.ViewModels;

  /// <summary>Provides a simple API to handle HTTP request.</summary>
  [ApiController]
  [Route(SurveyController.SurveyRoute)]
  [Produces(ContentType.Json)]
  public sealed class SurveyController : ControllerBase
  {
    private const string SurveyRoute = "api/survey";
    private const string GetSurveySubRoute = "{surveyId}";

    private readonly ISurveyService _surveyService;

    /// <summary>Initializes a new instance of the <see cref="Survey.Api.Controllers.SurveyController"/> class.</summary>
    /// <param name="surveyService">An object that provides a simple API to the survey entity.</param>
    public SurveyController(ISurveyService surveyService)
    {
      _surveyService = surveyService ?? throw new ArgumentNullException(nameof(surveyService));
    }

    /// <summary>Handles the add survey command request.</summary>
    /// <param name="vm">An object that represents a survey view model.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>.</returns>
    [HttpPost(Name = nameof(SurveyController.AddSurvey))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [Consumes(typeof(SurveyViewModel), ContentType.Json)]
    public async Task<IActionResult> AddSurvey([FromBody] SurveyViewModel vm, CancellationToken cancellationToken)
    {
      var surveyIdentity = await _surveyService.AddNewSurveyAsync(vm, cancellationToken);

      return CreatedAtRoute(nameof(SurveyController.GetSurvey), new { surveyId = surveyIdentity.SurveyId }, null);
    }

    /// <summary>Handles the add survey command request.</summary>
    /// <param name="surveyId">An object that represents an identity of a survey.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>.</returns>
    [HttpGet(SurveyController.GetSurveySubRoute, Name = nameof(SurveyController.GetSurvey))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(SurveyViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSurvey([FromRoute] Guid surveyId, CancellationToken cancellationToken)
    {
      var surveyEntity = await _surveyService.GetSurveyAsync(surveyId, cancellationToken);

      if (surveyEntity == null)
      {
        return NotFound();
      }

      return Ok(new SurveyViewModel(surveyEntity));
    }
  }
}
