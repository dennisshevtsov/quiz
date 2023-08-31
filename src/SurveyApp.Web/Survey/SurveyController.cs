// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Mvc;

namespace SurveyApp.Survey.Web;

[ApiController]
[Route("api/survey")]
public sealed class SurveyController : ControllerBase
{
  private readonly ISurveyRepository _surveyRepository;

  public SurveyController(ISurveyRepository surveyRepository)
  {
    _surveyRepository = surveyRepository ?? throw new ArgumentNullException(nameof(surveyRepository));
  }

  [HttpGet("{surveyId}", Name = nameof(SurveyController.GetSurvey))]
  public Task<IActionResult> GetSurvey(Guid surveyId, CancellationToken cancellationToken)
  {
    return Task.FromResult<IActionResult>(Ok());
  }

  [HttpGet(Name = nameof(SurveyController.AddSurvey))]
  public async Task<IActionResult> AddSurvey(AddSurveyRequestDto requestDto, CancellationToken cancellationToken)
  {
    SurveyEntity surveyEntity = await _surveyRepository.AddSurveyAsync(
      requestDto.ToSurveyEntity(), cancellationToken);

    return CreatedAtAction(
      nameof(SurveyController.GetSurvey),
      new { surveyEntity.SurveyId },
      new GetSurveyResponseDto(surveyEntity));
  }

  [HttpGet("{surveyId}", Name = nameof(SurveyController.UpdateSurvey))]
  public Task<IActionResult> UpdateSurvey(UpdateSurveyRequestDto requestDto, CancellationToken cancellationToken)
  {
    return Task.FromResult<IActionResult>(NoContent());
  }

  [HttpGet("{surveyId}", Name = nameof(SurveyController.DeleteSurvey))]
  public Task<IActionResult> DeleteSurvey(Guid surveyId, CancellationToken cancellationToken)
  {
    return Task.FromResult<IActionResult>(NoContent());
  }
}
