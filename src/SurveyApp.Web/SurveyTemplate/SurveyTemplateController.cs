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
  public async Task<IActionResult> GetSurveyTemplate(Guid surveyTemplateId, CancellationToken cancellationToken)
  {
    return Ok(await _surveyTemplateRepository.GetSurveyTemplateAsync(surveyTemplateId, cancellationToken));
  }

  [HttpPost(Name = nameof(SurveyTemplateController.GetSurveyTemplate))]
  public async Task<IActionResult> AddSurveyTemplate(
    AddSurveyTemplateRequestDto addSurveyTemplateRequestDto,
    CancellationToken cancellationToken)
  {
    await _surveyTemplateRepository.AddSurveyTemplateAsync(surveyTemplateEntity, cancellationToken);

    return CreatedAtAction(
      nameof(SurveyTemplateController.GetSurveyTemplate),
      new { surveyTemplateEntity },
      surveyTemplateEntity);
  }

  [HttpPut("{surveyTemplateId}", Name = nameof(SurveyTemplateController.UpdateSurveyTemplate))]
  public async Task<IActionResult> UpdateSurveyTemplate(SurveyTemplateEntity surveyTemplateEntity, CancellationToken cancellationToken)
  {
    if (await _surveyTemplateRepository.GetSurveyTemplateAsync(surveyTemplateEntity.SurveyId, cancellationToken) == null)
    {
      return NotFound();
    }

    await _surveyTemplateRepository.UpdateSurveyTemplateAsync(surveyTemplateEntity, cancellationToken);

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
