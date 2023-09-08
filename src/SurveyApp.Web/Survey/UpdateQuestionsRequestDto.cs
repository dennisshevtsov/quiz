// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Patchable;

namespace SurveyApp.Survey.Web;

public sealed class UpdateQuestionsRequestDto : IComposable
{
  public Guid SurveyId { get; set; }

  public AnswerDtoBase[] Answers { get; set; } = Array.Empty<AnswerDtoBase>();

  public void Update(SurveyEntity surveyEntity)
  {
    for (int i = 0; i < surveyEntity.Questions.Count; i++)
    {
      Answers[i].Update(surveyEntity.Questions[i]);
    }
  }
}
