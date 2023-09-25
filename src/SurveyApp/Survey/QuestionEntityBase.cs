// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyTemplate;

namespace SurveyApp.Survey;

public abstract class QuestionEntityBase
{
  protected QuestionEntityBase(string text)
  {
    Text = text;
  }

  public string Text { get; private set; }

  public abstract QuestionType QuestionType { get; }

  public static QuestionEntityBase Copy(QuestionTemplateEntityBase surveyTemplateQuestionEntityBase) =>
    surveyTemplateQuestionEntityBase.QuestionType switch
    {
      QuestionType.Text           => new TextQuestionEntity((TextQuestionTemplateEntity)surveyTemplateQuestionEntityBase),
      QuestionType.YesNo          => new YesNoQuestionEntity((YesNoQuestionTemplateEntity)surveyTemplateQuestionEntityBase),
      QuestionType.MultipleChoice => new MultipleChoiceQuestionEntity((MultipleChoiceQuestionTemplateEntity)surveyTemplateQuestionEntityBase),
      QuestionType.SingleChoice   => new SingleChoiceQuestionEntity((SingleChoiceQuestionTemplateEntity)surveyTemplateQuestionEntityBase),
      _                           => throw new NotSupportedException("Unknown question type."),
    };
}
