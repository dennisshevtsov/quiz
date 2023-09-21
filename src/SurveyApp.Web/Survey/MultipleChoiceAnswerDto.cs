// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.Web;

public sealed class MultipleChoiceAnswerDto : AnswerDtoBase
{
  public string[] Answers { get; set; } = Array.Empty<string>();

  public override void Update(QuestionEntityBase questionEntity)
  {
    if (questionEntity is MultipleChoiceQuestionEntity multipleChoiceQuestionEntity)
    {
      multipleChoiceQuestionEntity.SetAnswers(Answers);
    }
  }
}
