// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Composable;

namespace SurveyApp.SurveyTemplate.Web;

public sealed class GetSurveyTemplateRequestDto : IComposable
{
  public GetSurveyTemplateRequestDto() { }

  public GetSurveyTemplateRequestDto(SurveyTemplateEntity surveyTemplateEntity)
  {
    SurveyTemplateId = surveyTemplateEntity.SurveyTemplateId;
  }

  public Guid SurveyTemplateId { get; set; }
}
