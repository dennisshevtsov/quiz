// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Data.Initialization;

/// <summary>Provides a simple API to initialize the database.</summary>
public interface IDatabaseInitializer
{
  /// <summary>Initializes the database.</summary>
  /// <param name="cancellationToken">An object that propagates notification that operations should be canceled.</param>
  /// <returns>An object that represents an asynchronous operation.</returns>
  public Task InitializeAsync(CancellationToken cancellationToken);
}
