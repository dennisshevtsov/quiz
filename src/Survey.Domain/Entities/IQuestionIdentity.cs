// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.Domain.Entities
{
  /// <summary>Represents a survey identity.</summary>
  public interface IQuestionIdentity
  {
    /// <summary>Gets an object that represents an identity of a survey.</summary>
    public Guid QuestionId { get; }
  }
}
