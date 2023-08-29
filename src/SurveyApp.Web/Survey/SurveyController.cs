// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Mvc;

namespace SurveyApp.Survey.Web;

[ApiController]
[Route("api/survey")]
public sealed class SurveyController : ControllerBase
{
  [HttpGet("{surveyId}", Name = nameof(SurveyController.GetSurvey))]
  public Task<IActionResult> GetSurvey(Guid surveyId, CancellationToken cancellationToken)
  {
    return Task.FromResult<IActionResult>(Ok());
  }

  [HttpGet(Name = nameof(SurveyController.AddSurvey))]
  public Task<IActionResult> AddSurvey(AddSurveyRequestDto requestDto, CancellationToken cancellationToken)
  {
    return Task.FromResult<IActionResult>(Ok());
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
