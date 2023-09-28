// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate;

public sealed class MultipleChoiceQuestionTemplateEntity : QuestionTemplateEntityBase
{
  public MultipleChoiceQuestionTemplateEntity(string text, string[] choices) : base(text)
  {
    Choices = choices;
  }

  public MultipleChoiceQuestionTemplateEntity(MultipleChoiceQuestionTemplateEntity multipleChoiceQuestionTemplateEntity)
    : this(multipleChoiceQuestionTemplateEntity.Text, multipleChoiceQuestionTemplateEntity.Choices)
  { }

  public override QuestionType QuestionType => QuestionType.MultipleChoice;

  public string[] Choices { get; private set; }
}
