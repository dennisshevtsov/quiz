// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyQuestion;

public sealed class TextQuestionTemplateEntity : SurveyQuestionTemplateEntityBase
{
  public override SurveyQuestionType QuestionType => SurveyQuestionType.Text;
}
