// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyTemplate;

namespace SurveyApp.Survey;

public sealed class MultipleChoiceQuestionEntity : QuestionEntityBase
{
  public MultipleChoiceQuestionEntity() { }

  public MultipleChoiceQuestionEntity(MultipleChoiceQuestionTemplateEntity multipleChoiceQuestionTemplateEntity)
  {
    Text    = multipleChoiceQuestionTemplateEntity.Text;
    Choices = multipleChoiceQuestionTemplateEntity.Choices.Select(choice => choice).ToArray();
  }

  public override QuestionType QuestionType => QuestionType.MultipleChoice;

  public string[] Choices { get; set; } = Array.Empty<string>();

  public string[] Answer { get; set; } = Array.Empty<string>();
}
