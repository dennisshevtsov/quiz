// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Diagnostics.CodeAnalysis;

namespace SurveyApp;

public sealed class ExecutedContext<TResult> where TResult : class
{
  private ExecutedContext(TResult? result, string[] errors)
  {
    Rusult = result;
    Errors = errors;
  }

  public TResult? Rusult { get; }

  public string[] Errors { get; }

  [MemberNotNullWhen(false, nameof(ExecutedContext<TResult>.Rusult))]
  public bool HasErrors => Errors.Length > 0;

  public static ExecutedContext<TResult> Ok(TResult result) => new
  (
    result: result ?? throw new ArgumentNullException(nameof(result)),
    errors: Array.Empty<string>()
  );

  public static ExecutedContext<TResult> Fail(string[] errors) => new
  (
    result: null,
    errors: errors ?? throw new ArgumentNullException(nameof(errors))
  );
}
