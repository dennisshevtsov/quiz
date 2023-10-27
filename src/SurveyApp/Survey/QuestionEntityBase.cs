// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyTemplate;
using System.Text.Json.Serialization;

namespace SurveyApp.Survey;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$")]
[JsonDerivedType(typeof(TextQuestionEntity), (int)QuestionType.Text)]
[JsonDerivedType(typeof(YesNoQuestionEntity), (int)QuestionType.YesNo)]
[JsonDerivedType(typeof(MultipleChoiceQuestionEntity), (int)QuestionType.MultipleChoice)]
[JsonDerivedType(typeof(SingleChoiceQuestionEntity), (int)QuestionType.SingleChoice)]
public abstract class QuestionEntityBase : IEquatable<QuestionEntityBase>
{
  protected QuestionEntityBase(string text)
  {
    Text = text;
  }

  public string Text { get; private set; }

  public abstract QuestionType QuestionType { get; }

  public abstract bool Equals(QuestionEntityBase? other);

  public static QuestionEntityBase Copy(QuestionTemplateEntityBase questionTemplateEntity) =>
    questionTemplateEntity.QuestionType switch
    {
      QuestionType.Text           => new TextQuestionEntity((TextQuestionTemplateEntity)questionTemplateEntity),
      QuestionType.YesNo          => new YesNoQuestionEntity((YesNoQuestionTemplateEntity)questionTemplateEntity),
      QuestionType.MultipleChoice => new MultipleChoiceQuestionEntity((MultipleChoiceQuestionTemplateEntity)questionTemplateEntity),
      QuestionType.SingleChoice   => new SingleChoiceQuestionEntity((SingleChoiceQuestionTemplateEntity)questionTemplateEntity),
      _                           => throw new NotSupportedException("Unknown question type."),
    };

  public static QuestionEntityBase[] Copy(QuestionTemplateEntityBase[] questionTemplateEntities)
  {
    QuestionEntityBase[] questionEntities = new QuestionEntityBase[questionTemplateEntities.Length];

    for (int i = 0; i < questionTemplateEntities.Length; i++)
    {
      questionEntities[i] = QuestionEntityBase.Copy(questionTemplateEntities[i]);
    }

    return questionEntities;
  }
}
