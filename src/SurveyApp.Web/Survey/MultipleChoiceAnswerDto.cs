// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace SurveyApp.Survey.Web;

public sealed class MultipleChoiceAnswerDto : AnswerDtoBase
{
  [JsonPropertyName("answers")]
  public string[] Answers { get; set; } = Array.Empty<string>();

  public override void SetAnswer(QuestionEntityBase questionEntity, ExecutingContext context)
  {
    if (questionEntity is MultipleChoiceQuestionEntity multipleChoiceQuestionEntity)
    {
      multipleChoiceQuestionEntity.SetAnswers(Answers, context);
    }
  }
}
