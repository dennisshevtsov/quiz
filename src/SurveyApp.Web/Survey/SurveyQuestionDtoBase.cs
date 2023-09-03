// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace SurveyApp.Survey.Web;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "questionType")]
[JsonDerivedType(typeof(TextQuestionTemplateDto), (int)QuestionType.Text)]
[JsonDerivedType(typeof(YesNoQuestionTemplateDto), (int)QuestionType.YesNo)]
[JsonDerivedType(typeof(MultipleChoiceQuestionTemplateDto), (int)QuestionType.MultipleChoice)]
[JsonDerivedType(typeof(SingleChoiceQuestionTemplateDto), (int)QuestionType.SingleChoice)]
public abstract class SurveyQuestionDtoBase
{
  public string Text { get; set; } = string.Empty;

  public QuestionType QuestionType { get; set; }

  public abstract SurveyQuestionEntityBase ToSurveyQuestionEntity();

  public static SurveyQuestionDtoBase FromQuestionTemplateEntity(SurveyQuestionEntityBase questionTemplateEntity) =>
    questionTemplateEntity.QuestionType switch
    {
      QuestionType.Text => new TextQuestionTemplateDto((TextSurveyQuestionEntity)questionTemplateEntity),
      QuestionType.YesNo => new YesNoQuestionTemplateDto((YesNoSurveyQuestionEntity)questionTemplateEntity),
      QuestionType.MultipleChoice => new MultipleChoiceQuestionTemplateDto((MultipleChoiceSurveyQuestionEntity)questionTemplateEntity),
      QuestionType.SingleChoice => new SingleChoiceQuestionTemplateDto((SingleChoiceSurveyQuestionEntity)questionTemplateEntity),
      _ => throw new NotSupportedException("Unknown question type."),
    };

  public static List<SurveyQuestionEntityBase> ToQuestionTemplateEntityCollection(SurveyQuestionDtoBase[] surveyTemplateQuestionDtoCollection)
  {
    List<SurveyQuestionEntityBase> surveyTemplateQuestionEntityCollection =
      new(surveyTemplateQuestionDtoCollection.Length);

    for (int i = 0; i < surveyTemplateQuestionDtoCollection.Length; i++)
    {
      surveyTemplateQuestionEntityCollection.Add(surveyTemplateQuestionDtoCollection[i].ToSurveyQuestionEntity());
    }

    return surveyTemplateQuestionEntityCollection;
  }
}
