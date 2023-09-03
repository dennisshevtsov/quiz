// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyTemplate;

namespace SurveyApp.Survey;

public abstract class SurveyQuestionEntityBase
{
  public string Text { get; set; } = string.Empty;

  public abstract QuestionType QuestionType { get; }

  public static SurveyQuestionEntityBase Copy(SurveyTemplateQuestionEntityBase surveyTemplateQuestionEntityBase) =>
    surveyTemplateQuestionEntityBase.QuestionType switch
    {
      QuestionType.Text => new TextSurveyQuestionEntity((TextSurveyTemplateQuestionEntity)surveyTemplateQuestionEntityBase),
      QuestionType.YesNo => new YesNoSurveyQuestionEntity((YesNoSurveyTemplateQuestionEntity)surveyTemplateQuestionEntityBase),
      QuestionType.MultipleChoice => new MultipleChoiceSurveyQuestionEntity((MultipleChoiceSurveyTemplateQuestionEntity)surveyTemplateQuestionEntityBase),
      QuestionType.SingleChoice => new SingleChoiceSurveyQuestionEntity((SingleChoiceSurveyTemplateQuestionEntity)surveyTemplateQuestionEntityBase),
      _ => throw new NotSupportedException("Unknown question type."),
    };
}
