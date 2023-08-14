﻿// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace SurveyApp.SurveyTemplate.Web;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "questionType")]
[JsonDerivedType(typeof(MultipleChoiceQuestionTemplateDto), (int)SurveyQuestionType.MultipleChoice)]
[JsonDerivedType(typeof(SingleChoiceQuestionTemplateDto), (int)SurveyQuestionType.SingleChoice)]
[JsonDerivedType(typeof(TextQuestionTemplateDto), (int)SurveyQuestionType.TextArea)]
[JsonDerivedType(typeof(YesNoQuestionTemplateDto), (int)SurveyQuestionType.YesNo)]
public abstract class SurveyTemplateQuestionDtoBase
{
  public string Text { get; set; } = string.Empty;

  public SurveyQuestionType QuestionType { get; set; }

  public QuestionTemplateEntityBase ToQuestionTemplateEntity() => QuestionType switch
  {
    SurveyQuestionType.TextArea => new TextAreaQuestionTemplateEntity(),
    SurveyQuestionType.YesNo => new YesNoQuestionTemplateEntity(),
    SurveyQuestionType.MultipleChoice => new MultipleChoiceQuestionTemplateEntity(),
    SurveyQuestionType.SingleChoice => new SingleChoiceQuestionTemplateEntity(),
    _ => throw new InvalidOperationException("Unknown survey question type."),
  };
}
