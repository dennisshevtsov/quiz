// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Domain.Question
{
  /// <summary>Represents question data.</summary>
  public interface IQuestionData
  {
    /// <summary>Gest an object that represents a question.</summary>
    public string Question { get; }
  }
}
