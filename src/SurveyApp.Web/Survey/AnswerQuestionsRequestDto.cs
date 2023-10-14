// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Patchable;

namespace SurveyApp.Survey.Web;

public sealed class AnswerQuestionsRequestDto : IComposable
{
  public Guid SurveyId { get; set; }

  public AnswerDtoBase[] Answers { get; set; } = Array.Empty<AnswerDtoBase>();

  public void Answer(SurveyEntity surveyEntity)
  {
    for (int i = 0; i < surveyEntity.Questions.Length; i++)
    {
      Answers[i].SetAnswer(surveyEntity.Questions[i]);
    }
  }
}
