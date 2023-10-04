// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp;

public sealed class ExecutingContext
{
  private readonly List<string> _errors;

  public ExecutingContext()
  {
    _errors = new List<string>();
  }

  public IReadOnlyList<string> Errors => _errors;

  public bool HasErrors => _errors.Count > 0;

  internal void AddError(string error) => _errors.Add(error);
}
