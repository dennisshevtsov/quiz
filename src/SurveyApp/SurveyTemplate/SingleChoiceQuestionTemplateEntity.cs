// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate;

public sealed class SingleChoiceQuestionTemplateEntity : QuestionTemplateEntityBase
{
  public SingleChoiceQuestionTemplateEntity(string text, string[] choices) : base(text)
  {
    Choices = choices;
  }

  public SingleChoiceQuestionTemplateEntity(SingleChoiceQuestionTemplateEntity singleChoiceQuestionTemplateEntity)
    : this(singleChoiceQuestionTemplateEntity.Text, singleChoiceQuestionTemplateEntity.Choices.Select(choice => choice).ToArray())
  { }

  public override QuestionType QuestionType => QuestionType.SingleChoice;

  public string[] Choices { get; private set; }
}
