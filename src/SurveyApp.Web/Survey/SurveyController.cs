// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Mvc;
using SurveyApp.SurveyTemplate;

namespace SurveyApp.Survey.Web;

[ApiController]
public sealed class SurveyController : ControllerBase
{
  private readonly ISurveyRepository _surveyRepository;
  private readonly ISurveyTemplateRepository _surveyTemplateRepository;

  public SurveyController(
    ISurveyRepository surveyRepository,
    ISurveyTemplateRepository surveyTemplateRepository)
  {
    _surveyRepository = surveyRepository ?? throw new ArgumentNullException(nameof(surveyRepository));
    _surveyTemplateRepository = surveyTemplateRepository ?? throw new ArgumentNullException(nameof(surveyTemplateRepository));
  }

  [HttpGet("api/survey/{surveyId}", Name = nameof(SurveyController.GetSurvey))]
  public async Task<IActionResult> GetSurvey(GetSurveyRequestDto requestDto, CancellationToken cancellationToken)
  {
    SurveyEntity? surveyEntity = await _surveyRepository.GetSurveyAsync(requestDto.SurveyId, cancellationToken);

    if (surveyEntity == null)
    {
      return NotFound();
    }

    return Ok(new GetSurveyResponseDto(surveyEntity));
  }

  [HttpPost("api/survey-template/{surveyTemplateId}/survey", Name = nameof(SurveyController.AddSurvey))]
  public async Task<IActionResult> AddSurvey(AddSurveyRequestDto requestDto, CancellationToken cancellationToken)
  {
    SurveyTemplateEntity? surveyTemplateEntity = await _surveyTemplateRepository.GetSurveyTemplateAsync(requestDto.SurveyTemplateId, cancellationToken);

    if (surveyTemplateEntity == null)
    {
      return NotFound();
    }

    ExecutingContext context = new();
    SurveyEntity? surveyEntity = SurveyEntity.New
    (
      intervieweeName     : requestDto.IntervieweeName,
      surveyTemplateEntity: surveyTemplateEntity,
      context             : context
    );

    if (context.HasErrors)
    {
      return BadRequest(context.Errors);
    }

    await _surveyRepository.AddSurveyAsync(surveyEntity!, cancellationToken);

    return CreatedAtAction
    (
      actionName : nameof(SurveyController.GetSurvey),
      routeValues: new GetSurveyRequestDto(surveyEntity!),
      value      : new GetSurveyResponseDto(surveyEntity!)
    );
  }

  [HttpPut("api/survey/{surveyId}", Name = nameof(SurveyController.UpdateSurvey))]
  public async Task<IActionResult> UpdateSurvey(UpdateSurveyRequestDto requestDto, CancellationToken cancellationToken)
  {
    SurveyEntity? surveyEntity = await _surveyRepository.GetSurveyAsync(requestDto.SurveyId, cancellationToken);

    if (surveyEntity == null)
    {
      return NotFound();
    }

    ExecutingContext context = new();
    requestDto.UpdateSurvey(surveyEntity, context);

    if (context.HasErrors)
    {
      return BadRequest(context.Errors);
    }

    await _surveyRepository.UpdateSurveyAsync(surveyEntity, cancellationToken);

    return NoContent();
  }

  [HttpGet("api/survey/{surveyId}/state/{state}", Name = nameof(SurveyController.MoveToState))]
  public async Task<IActionResult> MoveToState(Guid surveyId, SurveyState state, CancellationToken cancellationToken)
  {
    SurveyEntity? surveyEntity = await _surveyRepository.GetSurveyAsync(surveyId, cancellationToken);

    if (surveyEntity == null)
    {
      return NotFound();
    }

    ExecutingContext context = new();
    surveyEntity.MoveTo(state, context);

    if (context.HasErrors)
    {
      return BadRequest(context.Errors);
    }

    await _surveyRepository.UpdateSurveyAsync(surveyEntity, cancellationToken);

    return NoContent();
  }

  [HttpPost("api/survey/{surveyId}/question", Name = nameof(SurveyController.UpdateQuestions))]
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
