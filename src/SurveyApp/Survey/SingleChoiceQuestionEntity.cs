// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyTemplate;

namespace SurveyApp.Survey;

public sealed class SingleChoiceQuestionEntity : QuestionEntityBase
{
  public SingleChoiceQuestionEntity() { }

  public SingleChoiceQuestionEntity(SingleChoiceQuestionTemplateEntity singleChoiceQuestionTemplateEntity)
  {
    Text    = singleChoiceQuestionTemplateEntity.Text;
    Choices = singleChoiceQuestionTemplateEntity.Choices.Select(choice => choice).ToArray();
  }

  public override QuestionType QuestionType => QuestionType.SingleChoice;

  public string[] Choices { get; set; } = Array.Empty<string>();

  public string? Answer { get; set; }
}
