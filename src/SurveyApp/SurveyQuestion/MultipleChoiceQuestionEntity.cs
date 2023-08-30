// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyQuestion;

public sealed class MultipleChoiceQuestionEntity : SurveyQuestionEntityBase
{
  public MultipleChoiceQuestionEntity() { }

  public MultipleChoiceQuestionEntity(MultipleChoiceQuestionEntity multipleChoiceQuestionTemplateEntity)
  {
    Text = multipleChoiceQuestionTemplateEntity.Text;
    Choices = multipleChoiceQuestionTemplateEntity.Choices.Select(choice => choice).ToArray();
  }

  public override SurveyQuestionType QuestionType => SurveyQuestionType.MultipleChoice;

  public string[] Choices { get; set; } = Array.Empty<string>();

  public override SurveyQuestionEntityBase Clone() => new MultipleChoiceQuestionEntity(this);
}
