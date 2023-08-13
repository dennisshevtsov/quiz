// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace SurveyApp.SurveyTemplate.Web;

[JsonDerivedType(typeof(MultipleChoiceQuestionTemplateDto))]
[JsonDerivedType(typeof(SingleChoiceQuestionTemplateDto))]
[JsonDerivedType(typeof(TextQuestionTemplateDto))]
[JsonDerivedType(typeof(YesNoQuestionTemplateDto))]
public abstract class SurveyTemplateQuestionDtoBase
{
  public string Text { get; set; } = string.Empty;

  public SurveyQuestionType QuestionType { get; set; }
}
