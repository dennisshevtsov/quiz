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
    private const string UpdateSurveySubRoute = "{surveyId}";

    private readonly ISurveyService _surveyService;

    /// <summary>Initializes a new instance of the <see cref="Survey.Web.Controllers.SurveyController"/> class.</summary>
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
    [Consumes(typeof(AddSurveyViewModel), ContentType.Json)]
    public async Task<IActionResult> AddSurvey([FromBody] AddSurveyViewModel vm, CancellationToken cancellationToken)
    {
      var surveyEntity = await _surveyService.AddNewSurveyAsync(vm, cancellationToken);

      return CreatedAtRoute(nameof(SurveyController.GetSurvey), new { surveyId = surveyEntity.SurveyId }, new GetSurveyViewModel(surveyEntity));
    }

    /// <summary>Handles the update survey command request.</summary>
    /// <param name="vm">An object that represents a survey view model.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>.</returns>
    [HttpPut(SurveyController.UpdateSurveySubRoute, Name = nameof(SurveyController.UpdateSurvey))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [Consumes(typeof(UpdateSurveyViewModel), ContentType.Json)]
    public async Task<IActionResult> UpdateSurvey([FromBody] UpdateSurveyViewModel vm, CancellationToken cancellationToken)
    {
      var surveyEntity = await _surveyService.GetSurveyAsync(vm.SurveyId, cancellationToken);

      if (surveyEntity == null)
      {
        return NotFound();
      }

      await _surveyService.UpdateSurveyAsync(surveyEntity, cancellationToken);

      return NoContent();
    }

    /// <summary>Handles the add survey query request.</summary>
    /// <param name="surveyId">An object that represents an identity of a survey.</param>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>.</returns>
    [HttpGet(SurveyController.GetSurveySubRoute, Name = nameof(SurveyController.GetSurvey))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(GetSurveyViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSurvey([FromRoute] Guid surveyId, CancellationToken cancellationToken)
    {
      var surveyEntity = await _surveyService.GetSurveyAsync(surveyId, cancellationToken);

      if (surveyEntity == null)
      {
        return NotFound();
      }

      return Ok(new GetSurveyViewModel(surveyEntity));
    }

    /// <summary>Handles the get surveys query request.</summary>
    /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
    /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>.</returns>
    [HttpGet(Name = nameof(SurveyController.GetSurveys))]
    [ProducesResponseType(typeof(GetSurveyCollectionViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSurveys(CancellationToken cancellationToken)
    {
      var surveyEntityCollection =
        await _surveyService.GetSurveysAsync(cancellationToken);

      var getSurveyCollectionViewModel =
        new GetSurveyCollectionViewModel(surveyEntityCollection);

      return Ok(getSurveyCollectionViewModel);
    }
  }
}
