// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Mvc;

namespace SurveyApp.SurveyTemplate.Web;

[ApiController]
[Route("api/survey-template")]
public class SurveyTemplateController : ControllerBase
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
  public async Task<IActionResult> AddSurveyTemplate(SurveyTemplateEntity surveyTemplateEntity, CancellationToken cancellationToken)
  {
    await _surveyTemplateRepository.AddSurveyTemplateAsync(surveyTemplateEntity, cancellationToken);

    return CreatedAtAction(
      nameof(SurveyTemplateController.GetSurveyTemplate),
      new { surveyTemplateEntity },
      surveyTemplateEntity);
  }
}
