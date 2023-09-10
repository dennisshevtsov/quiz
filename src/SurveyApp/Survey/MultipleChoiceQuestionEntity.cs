// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyTemplate;

namespace SurveyApp.Survey;

public sealed class MultipleChoiceQuestionEntity : QuestionEntityBase
{
  public MultipleChoiceQuestionEntity(string text, string[] choices, string[] answers) : base(text)
  {
    Choices = choices;
    Answers  = answers;
  }

  public MultipleChoiceQuestionEntity(MultipleChoiceQuestionTemplateEntity multipleChoiceQuestionTemplateEntity)
     : this(multipleChoiceQuestionTemplateEntity.Text, multipleChoiceQuestionTemplateEntity.Choices, Array.Empty<string>())
  { }

  public override QuestionType QuestionType => QuestionType.MultipleChoice;

  public string[] Choices { get; private set; }

  public string[] Answers { get; private set; }

  public void SetAnswers(string[] answer)
  {
    Answers = answer;
  }
}
