// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace SurveyApp.SurveyTemplate.Web;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "questionType")]
[JsonDerivedType(typeof(TextQuestionTemplateDto), (int)SurveyQuestionType.Text)]
[JsonDerivedType(typeof(YesNoQuestionTemplateDto), (int)SurveyQuestionType.YesNo)]
[JsonDerivedType(typeof(MultipleChoiceQuestionTemplateDto), (int)SurveyQuestionType.MultipleChoice)]
[JsonDerivedType(typeof(SingleChoiceQuestionTemplateDto), (int)SurveyQuestionType.SingleChoice)]
public abstract class SurveyTemplateQuestionDtoBase
{
  public string Text { get; set; } = string.Empty;

  public SurveyQuestionType QuestionType { get; set; }

  public abstract SurveyTemplateQuestionEntityBase ToSurveyTemplateQuestionEntity();

  public static SurveyTemplateQuestionDtoBase FromQuestionTemplateEntity(SurveyTemplateQuestionEntityBase surveyTemplateQuestionEntity) =>
    surveyTemplateQuestionEntity.QuestionType switch
    {
      SurveyQuestionType.Text => new TextQuestionTemplateDto((TextSurveyTemplateQuestionEntity)surveyTemplateQuestionEntity),
      SurveyQuestionType.YesNo => new YesNoQuestionTemplateDto((YesNoSurveyTemplateQuestionEntity)surveyTemplateQuestionEntity),
      SurveyQuestionType.MultipleChoice => new MultipleChoiceQuestionTemplateDto((MultipleChoiceSurveyTemplateQuestionEntity)surveyTemplateQuestionEntity),
      SurveyQuestionType.SingleChoice => new SingleChoiceQuestionTemplateDto((SingleChoiceSurveyTemplateQuestionEntity)surveyTemplateQuestionEntity),
      _ => throw new NotSupportedException("Unknown question type."),
    };

  public static List<SurveyTemplateQuestionEntityBase> ToQuestionTemplateEntityCollection(SurveyTemplateQuestionDtoBase[] surveyTemplateQuestionDtoCollection)
  {
    List<SurveyTemplateQuestionEntityBase> surveyTemplateQuestionEntityCollection =
      new(surveyTemplateQuestionDtoCollection.Length);

    for (int i = 0; i < surveyTemplateQuestionDtoCollection.Length; i++)
    {
      surveyTemplateQuestionEntityCollection.Add(surveyTemplateQuestionDtoCollection[i].ToSurveyTemplateQuestionEntity());
    }

    return surveyTemplateQuestionEntityCollection;
  }
}
