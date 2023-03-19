// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.ApplicationCore.Entities
{
  public interface ISurveyEntity
  {
    public Guid SurveyId { get; }

    public string Name { get; }

    public string Description { get; }
  }
}
