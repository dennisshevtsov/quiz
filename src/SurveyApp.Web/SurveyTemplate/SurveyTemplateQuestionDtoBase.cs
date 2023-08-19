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

  public abstract QuestionTemplateEntityBase ToQuestionTemplateEntity();

  public static SurveyTemplateQuestionDtoBase FromQuestionTemplateEntity(QuestionTemplateEntityBase questionTemplateEntity) =>
    questionTemplateEntity.QuestionType switch
    {
      SurveyQuestionType.Text => new TextQuestionTemplateDto((TextQuestionTemplateEntity)questionTemplateEntity),
      SurveyQuestionType.YesNo => new YesNoQuestionTemplateDto((YesNoQuestionTemplateEntity)questionTemplateEntity),
      SurveyQuestionType.MultipleChoice => new MultipleChoiceQuestionTemplateDto((MultipleChoiceQuestionTemplateEntity)questionTemplateEntity),
      SurveyQuestionType.SingleChoice => new SingleChoiceQuestionTemplateDto((SingleChoiceQuestionTemplateEntity)questionTemplateEntity),
      _ => throw new NotSupportedException("Unknown question type."),
    };
}
