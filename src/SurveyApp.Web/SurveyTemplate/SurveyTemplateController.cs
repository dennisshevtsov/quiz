// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Mvc;

namespace SurveyApp.SurveyTemplate.Web;

[ApiController]
[Route("api/survey-template")]
public sealed class SurveyTemplateController : ControllerBase
{
  private readonly ISurveyTemplateRepository _surveyTemplateRepository;

  public SurveyTemplateController(ISurveyTemplateRepository surveyTemplateRepository)
  {
    _surveyTemplateRepository = surveyTemplateRepository ?? throw new ArgumentNullException(nameof(surveyTemplateRepository));
  }

  [HttpGet("{surveyTemplateId}", Name = nameof(SurveyTemplateController.GetSurveyTemplate))]
  public async Task<IActionResult> GetSurveyTemplate([FromRoute] Guid surveyTemplateId, CancellationToken cancellationToken)
  {
    SurveyTemplateEntity? surveyTemplateEntity = await _surveyTemplateRepository.GetSurveyTemplateAsync(surveyTemplateId, cancellationToken);

    if (surveyTemplateEntity == null)
    {
      return NotFound();
    }

    return Ok(new GetSurveyTemplateResponseDto(surveyTemplateEntity));
  }

  [HttpPost(Name = nameof(SurveyTemplateController.AddSurveyTemplate))]
  public async Task<IActionResult> AddSurveyTemplate(
    AddSurveyTemplateRequestDto addSurveyTemplateRequestDto,
    CancellationToken cancellationToken)
  {
    ExecutingContext context = new();
    SurveyTemplateEntity? newSurveyTemplateEntity =
      addSurveyTemplateRequestDto.ToSurveyTemplateEntity(context);

    if (context.HasErrors)
    {
      return BadRequest(context.Errors);
    }

    SurveyTemplateEntity surveyTemplateEntity =
      await _surveyTemplateRepository.AddSurveyTemplateAsync(
        newSurveyTemplateEntity!,
        cancellationToken);

    return CreatedAtAction
    (
      actionName : nameof(SurveyTemplateController.GetSurveyTemplate),
      routeValues: new { surveyTemplateEntity.SurveyTemplateId },
      value      : new GetSurveyTemplateResponseDto(surveyTemplateEntity)
    );
  }

  [HttpPut("{surveyTemplateId}", Name = nameof(SurveyTemplateController.UpdateSurveyTemplate))]
  public async Task<IActionResult> UpdateSurveyTemplate(
    UpdateSurveyTemplateRequestDto updateSurveyTemplateRequestDto,
    CancellationToken cancellationToken)
  {
    SurveyTemplateEntity? surveyTemplateEntity =
      await _surveyTemplateRepository.GetSurveyTemplateAsync(
        updateSurveyTemplateRequestDto.SurveyTemplateId, cancellationToken);

    if (surveyTemplateEntity == null)
    {
      return NotFound();
    }

    ExecutedContext<SurveyTemplateEntity> updatedSurveyTemplateEntityContext =
      updateSurveyTemplateRequestDto.UpdateSurveyTemplate(surveyTemplateEntity, new ExecutingContext());

    if (updatedSurveyTemplateEntityContext.HasErrors)
    {
      return BadRequest(updatedSurveyTemplateEntityContext.Errors);
    }

    await _surveyTemplateRepository.UpdateSurveyTemplateAsync(
      updatedSurveyTemplateEntityContext.Rusult,
      cancellationToken);

    return NoContent();
  }

  [HttpDelete("{surveyTemplateId}", Name = nameof(SurveyTemplateController.DeleteSurveyTemplate))]
  public async Task<IActionResult> DeleteSurveyTemplate(Guid surveyTemplateId, CancellationToken cancellationToken)
  {
    SurveyTemplateEntity? surveyTemplateEntity = await _surveyTemplateRepository.GetSurveyTemplateAsync(surveyTemplateId, cancellationToken);

    if (surveyTemplateEntity == null)
    {
      return NotFound();
    }

    await _surveyTemplateRepository.DeleteSurveyTemplateAsync(surveyTemplateId, cancellationToken);

    return NoContent();
  }
}
