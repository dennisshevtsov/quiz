// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyTemplate;

namespace SurveyApp.Survey;

public sealed class MultipleChoiceSurveyQuestionEntity : SurveyQuestionEntityBase
{
  public MultipleChoiceSurveyQuestionEntity() { }

  public MultipleChoiceSurveyQuestionEntity(MultipleChoiceSurveyTemplateQuestionEntity multipleChoiceSurveyTemplateQuestionEntity)
  {
    Text    = multipleChoiceSurveyTemplateQuestionEntity.Text;
    Choices = multipleChoiceSurveyTemplateQuestionEntity.Choices.Select(choice => choice).ToArray();
  }

  public override QuestionType QuestionType => QuestionType.MultipleChoice;

  public string[] Choices { get; set; } = Array.Empty<string>();
}
