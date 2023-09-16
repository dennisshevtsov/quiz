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
  public async Task<IActionResult> GetSurvey(GetSurveyRequestDto requestDto, CancellationToken cancellationToken)
  {
    SurveyEntity? surveyEntity = await _surveyRepository.GetSurveyAsync(requestDto.SurveyId, cancellationToken);

    if (surveyEntity == null)
    {
      return NotFound();
    }

    return Ok(new GetSurveyResponseDto(surveyEntity));
  }

  [HttpPost(Name = nameof(SurveyController.AddSurvey))]
  public async Task<IActionResult> AddSurvey(AddSurveyRequestDto requestDto, CancellationToken cancellationToken)
  {
    SurveyEntity surveyEntity = await _surveyRepository.AddSurveyAsync(requestDto.ToSurveyEntity(), cancellationToken);

    return CreatedAtAction(nameof(SurveyController.GetSurvey), new GetSurveyRequestDto(surveyEntity), new GetSurveyResponseDto(surveyEntity));
  }

  [HttpPut("{surveyId}", Name = nameof(SurveyController.UpdateSurvey))]
  public async Task<IActionResult> UpdateSurvey(UpdateSurveyRequestDto requestDto, CancellationToken cancellationToken)
  {
    SurveyEntity? surveyEntity = await _surveyRepository.GetSurveyAsync(requestDto.SurveyId, cancellationToken);

    if (surveyEntity == null)
    {
      return NotFound();
    }

    await _surveyRepository.UpdateSurveyAsync(requestDto.UpdateSurvey(surveyEntity), cancellationToken);

    return NoContent();
  }

  [HttpGet("{surveyId}/state/{state}", Name = nameof(SurveyController.MoveToState))]
  public async Task<IActionResult> MoveToState(Guid surveyId, SurveyState state, CancellationToken cancellationToken)
  {
    SurveyEntity? surveyEntity = await _surveyRepository.GetSurveyAsync(surveyId, cancellationToken);

    if (surveyEntity == null)
    {
      return NotFound();
    }

    if (!surveyEntity.TryMoveTo(state))
    {
      return BadRequest();
    }

    await _surveyRepository.UpdateSurveyAsync(surveyEntity, cancellationToken);

    return NoContent();
  }

  [HttpPost("{surveyId}/question", Name = nameof(SurveyController.UpdateQuestions))]
  public async Task<IActionResult> UpdateQuestions(UpdateQuestionsRequestDto requestDto, CancellationToken cancellationToken)
  {
    SurveyEntity? surveyEntity = await _surveyRepository.GetSurveyAsync(requestDto.SurveyId, cancellationToken);

    if (surveyEntity == null)
    {
      return NotFound();
    }

    requestDto.Update(surveyEntity);

    return NoContent();
  }
}
