// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate;

public sealed class SingleChoiceSurveyTemplateQuestionEntity : SurveyTemplateQuestionEntityBase
{
  public SingleChoiceSurveyTemplateQuestionEntity() { }

  public SingleChoiceSurveyTemplateQuestionEntity(SingleChoiceSurveyTemplateQuestionEntity singleChoiceQuestionTemplateEntity)
  {
    Text = singleChoiceQuestionTemplateEntity.Text;
    Choices = singleChoiceQuestionTemplateEntity.Choices.Select(choice => choice).ToArray();
  }

  public override QuestionType QuestionType => QuestionType.SingleChoice;

  public string[] Choices { get; set; } = Array.Empty<string>();
}
