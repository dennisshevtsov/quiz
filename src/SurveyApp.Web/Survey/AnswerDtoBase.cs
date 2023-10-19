// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace SurveyApp.Survey.Web;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "questionType")]
[JsonDerivedType(typeof(TextAnswerDto), (int)QuestionType.Text)]
[JsonDerivedType(typeof(YesNoAnswerDto), (int)QuestionType.YesNo)]
[JsonDerivedType(typeof(MultipleChoiceAnswerDto), (int)QuestionType.MultipleChoice)]
[JsonDerivedType(typeof(SingleChoiceAnswerDto), (int)QuestionType.SingleChoice)]
public abstract class AnswerDtoBase
{
  public abstract void SetAnswer(QuestionEntityBase questionEntity, ExecutingContext context);
}
