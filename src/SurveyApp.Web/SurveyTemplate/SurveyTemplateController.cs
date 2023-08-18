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
    
    return Ok(surveyTemplateEntity);
  }

  [HttpPost(Name = nameof(SurveyTemplateController.AddSurveyTemplate))]
  public async Task<IActionResult> AddSurveyTemplate(
    [FromBody] AddSurveyTemplateRequestDto addSurveyTemplateRequestDto,
    CancellationToken cancellationToken)
  {
    SurveyTemplateEntity surveyTemplateEntity =
      await _surveyTemplateRepository.AddSurveyTemplateAsync(
        addSurveyTemplateRequestDto.ToSurveyTemplateEntity(),
        cancellationToken);

    return CreatedAtAction(
      nameof(SurveyTemplateController.GetSurveyTemplate),
      new { surveyTemplateEntity },
      surveyTemplateEntity);
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

    await _surveyTemplateRepository.UpdateSurveyTemplateAsync(
      updateSurveyTemplateRequestDto.UpdateSurveyTemplate(surveyTemplateEntity),
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
