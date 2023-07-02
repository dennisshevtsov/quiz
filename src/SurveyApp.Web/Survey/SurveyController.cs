// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Mvc;

using SurveyApp.Web;

namespace SurveyApp.Survey.Web;

/// <summary>Provides a simple API to handle HTTP request.</summary>
[ApiController]
[Route(SurveyController.Route)]
[Produces(ContentType.Json)]
public sealed class SurveyController : ControllerBase
{
  private const string Route = "api/survey";
  private const string IdParameter = "{surveyId}";
  private const string GetSubRoute = SurveyController.IdParameter;
  private const string UpdateSubRoute = SurveyController.IdParameter;
  private const string DeleteSubRoute = SurveyController.IdParameter;

  private readonly ISurveyService _surveyService;

  /// <summary>Initializes a new instance of the <see cref="SurveyApp.Survey.Web.SurveyController"/> class.</summary>
  /// <param name="surveyService">An object that provides a simple GRUD API for the <see cref="SurveyApp.Survey.ISurveyEntity"/>.</param>
  public SurveyController(ISurveyService surveyService)
  {
    _surveyService = surveyService ?? throw new ArgumentNullException(nameof(surveyService));
  }

  /// <summary>Handles the add survey command request.</summary>
  /// <param name="requestDto">An object that represents data to add a survey.</param>
  /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
  /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>.</returns>
  [HttpPost(Name = nameof(SurveyController.AddSurvey))]
  [ProducesResponseType(StatusCodes.Status201Created)]
  [Consumes(typeof(AddSurveyRequestDto), ContentType.Json)]
  public async Task<IActionResult> AddSurvey([FromBody] AddSurveyRequestDto requestDto, CancellationToken cancellationToken)
  {
    var surveyEntity = await _surveyService.AddAsync(requestDto, cancellationToken);

    return CreatedAtRoute(
      nameof(SurveyController.GetSurvey),
      new GetSurveyRequestDto(surveyEntity.SurveyId),
      new GetSurveyResponseDto(surveyEntity));
  }

  /// <summary>Handles the update survey command request.</summary>
  /// <param name="requestDto">An object that represents data to update a survey.</param>
  /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
  /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>.</returns>
  [HttpPut(SurveyController.UpdateSubRoute, Name = nameof(SurveyController.UpdateSurvey))]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [Consumes(typeof(UpdateSurveyRequestDto), ContentType.Json)]
  public async Task<IActionResult> UpdateSurvey([FromBody] UpdateSurveyRequestDto requestDto, CancellationToken cancellationToken)
  {
    var surveyEntity = await _surveyService.GetAsync(requestDto, cancellationToken);

    if (surveyEntity == null)
    {
      return NotFound();
    }

    await _surveyService.UpdateAsync(surveyEntity, requestDto, cancellationToken);

    return NoContent();
  }

  /// <summary>Handles the delete survey command request.</summary>
  /// <param name="requestDto">An object that represents data to delete a survey.</param>
  /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
  /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>.</returns>
  [HttpDelete(SurveyController.DeleteSubRoute, Name = nameof(SurveyController.DeleteSurvey))]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  public async Task<IActionResult> DeleteSurvey([FromRoute] DeleteSurveyRequestDto requestDto, CancellationToken cancellationToken)
  {
    var surveyEntity = await _surveyService.GetAsync(requestDto, cancellationToken);

    if (surveyEntity == null)
    {
      return NotFound();
    }

    await _surveyService.DeleteAsync(requestDto, cancellationToken);

    return NoContent();
  }

  /// <summary>Handles the add survey query request.</summary>
  /// <param name="requestDto">An object that represents a codition to query a survey.</param>
  /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
  /// <returns>An object that represents an asynchronous operation that produces a result at some time in the future. The result is an instance of the <see cref="Microsoft.AspNetCore.Mvc.IActionResult"/>.</returns>
  [HttpGet(SurveyController.GetSubRoute, Name = nameof(SurveyController.GetSurvey))]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(typeof(GetSurveyResponseDto), StatusCodes.Status200OK)]
  public async Task<IActionResult> GetSurvey([FromRoute] GetSurveyRequestDto requestDto, CancellationToken cancellationToken)
  {
    var surveyEntity = await _surveyService.GetAsync(requestDto, cancellationToken);

    if (surveyEntity == null)
    {
      return NotFound();
    }

    return Ok(new GetSurveyResponseDto(surveyEntity));
  }
}
