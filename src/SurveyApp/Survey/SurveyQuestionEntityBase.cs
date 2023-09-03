// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyTemplate;

namespace SurveyApp.Survey;

public abstract class SurveyQuestionEntityBase
{
  public string Text { get; set; } = string.Empty;

  public abstract SurveyQuestionType QuestionType { get; }

  public static SurveyQuestionEntityBase Copy(SurveyTemplateQuestionEntityBase surveyTemplateQuestionEntityBase) =>
    surveyTemplateQuestionEntityBase.QuestionType switch
    {
      SurveyQuestionType.Text => new TextSurveyQuestionEntity((TextSurveyTemplateQuestionEntity)surveyTemplateQuestionEntityBase),
      SurveyQuestionType.YesNo => new YesNoSurveyQuestionEntity((YesNoSurveyTemplateQuestionEntity)surveyTemplateQuestionEntityBase),
      SurveyQuestionType.MultipleChoice => new MultipleChoiceSurveyQuestionEntity((MultipleChoiceSurveyTemplateQuestionEntity)surveyTemplateQuestionEntityBase),
      SurveyQuestionType.SingleChoice => new SingleChoiceSurveyQuestionEntity((SingleChoiceSurveyTemplateQuestionEntity)surveyTemplateQuestionEntityBase),
      _ => throw new NotSupportedException("Unknown question type."),
    };
}
