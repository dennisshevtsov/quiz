// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Patchable;

namespace SurveyApp.Survey.Web;

public sealed class UpdateQuestionsRequestDto : IComposable
{
  public Guid SurveyId { get; set; }

  public QuestionDtoBase[] Questions { get; set; } = Array.Empty<QuestionDtoBase>();
}
