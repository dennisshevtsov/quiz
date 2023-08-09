// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate;

public sealed class SingleChoiceQuestionTemplateEntity : QuestionTemplateEntityBase
{
  public override SurveyQuestionType QuestionType => SurveyQuestionType.SingleChoice;

  public string[] Choices { get; set; } = Array.Empty<string>();
}
