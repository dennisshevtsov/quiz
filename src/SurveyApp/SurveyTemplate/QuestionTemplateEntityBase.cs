// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace SurveyApp.SurveyTemplate;

/// <summary>
/// This class contains metadata for this JSON serialization/deserialization.
/// The desriminator property name is $, beacause the descrimitator should be
/// the first property and JSONB orders property by its length.
/// </summary>
[JsonPolymorphic(TypeDiscriminatorPropertyName = "$")]
[JsonDerivedType(typeof(TextQuestionTemplateEntity), (int)QuestionType.Text)]
[JsonDerivedType(typeof(YesNoQuestionTemplateEntity), (int)QuestionType.YesNo)]
[JsonDerivedType(typeof(MultipleChoiceQuestionTemplateEntity), (int)QuestionType.MultipleChoice)]
[JsonDerivedType(typeof(SingleChoiceQuestionTemplateEntity), (int)QuestionType.SingleChoice)]
public abstract class QuestionTemplateEntityBase : IEquatable<QuestionTemplateEntityBase>
{
  protected QuestionTemplateEntityBase(string text)
  {
    Text = text;
  }

  public string Text { get; private set; }

  public abstract QuestionType QuestionType { get; }

  public abstract bool Equals(QuestionTemplateEntityBase? other);
}
