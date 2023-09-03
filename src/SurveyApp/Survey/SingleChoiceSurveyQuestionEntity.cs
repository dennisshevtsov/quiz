// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyTemplate;

namespace SurveyApp.Survey;

public sealed class SingleChoiceSurveyQuestionEntity : SurveyQuestionEntityBase
{
  public SingleChoiceSurveyQuestionEntity() { }

  public SingleChoiceSurveyQuestionEntity(SingleChoiceSurveyTemplateQuestionEntity singleChoiceSurveyTemplateQuestionEntity)
  {
    Text    = singleChoiceSurveyTemplateQuestionEntity.Text;
    Choices = singleChoiceSurveyTemplateQuestionEntity.Choices.Select(choice => choice).ToArray();
  }

  public override QuestionType QuestionType => QuestionType.SingleChoice;

  public string[] Choices { get; set; } = Array.Empty<string>();
}
