// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp;

public sealed class ExecutedContext<TResult> where TResult : class
{
  private ExecutedContext(TResult? rusult, string[] errors)
  {
    Rusult = rusult;
    Errors = errors;
  }

  public TResult? Rusult { get; }

  public string[] Errors { get; }

  public bool Success => Errors.Length > 0;

  public static ExecutedContext<TResult> Ok(TResult result) => new(result, Array.Empty<string>());

  public static ExecutedContext<TResult> Fail(string[] errors) => new(null, errors);
}
