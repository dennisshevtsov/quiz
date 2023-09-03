// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate;

public sealed class MultipleChoiceSurveyTemplateQuestionEntity : SurveyTemplateQuestionEntityBase
{
  public MultipleChoiceSurveyTemplateQuestionEntity() { }

  public MultipleChoiceSurveyTemplateQuestionEntity(MultipleChoiceSurveyTemplateQuestionEntity multipleChoiceQuestionTemplateEntity)
  {
    Text = multipleChoiceQuestionTemplateEntity.Text;
    Choices = multipleChoiceQuestionTemplateEntity.Choices.Select(choice => choice).ToArray();
  }

  public override QuestionType QuestionType => QuestionType.MultipleChoice;

  public string[] Choices { get; set; } = Array.Empty<string>();
}
