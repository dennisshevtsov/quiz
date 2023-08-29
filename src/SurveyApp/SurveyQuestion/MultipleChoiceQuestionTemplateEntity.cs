// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyQuestion;

public sealed class MultipleChoiceQuestionTemplateEntity : SurveyQuestionTemplateEntityBase
{
  public MultipleChoiceQuestionTemplateEntity() { }

  public MultipleChoiceQuestionTemplateEntity(MultipleChoiceQuestionTemplateEntity multipleChoiceQuestionTemplateEntity)
  {
    Text = multipleChoiceQuestionTemplateEntity.Text;
    Choices = multipleChoiceQuestionTemplateEntity.Choices.Select(choice => choice).ToArray();
  }

  public override SurveyQuestionType QuestionType => SurveyQuestionType.MultipleChoice;

  public string[] Choices { get; set; } = Array.Empty<string>();

  public override SurveyQuestionTemplateEntityBase Clone() => new MultipleChoiceQuestionTemplateEntity(this);
}
