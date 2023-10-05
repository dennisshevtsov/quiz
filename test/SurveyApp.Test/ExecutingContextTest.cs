// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Test;

[TestClass]
public sealed class ExecutingContextTest
{
  [TestMethod]
  public void AddError_Error_HasErrorsIsTrue()
  {
    // Arrange
    ExecutingContext context = new();

    // Act
    context.AddError(Guid.NewGuid().ToString());

    // Assert
    Assert.IsTrue(context.HasErrors);
  }

  [TestMethod]
  public void AddError_Error_ErrorsContainsError()
  {
    // Arrange
    string error = Guid.NewGuid().ToString();
    ExecutingContext context = new();

    // Act
    context.AddError(error);

    // Assert
    Assert.IsTrue(context.Errors.Contains(error));
  }

  [TestMethod]
  public void Constructor_InitialState_HasErrorsIsFalse()
  {
    // Act
    ExecutingContext context = new();

    // Assert
    Assert.IsFalse(context.HasErrors);
  }

  [TestMethod]
  public void Constructor_InitialState_ErrorsIsEmpty()
  {
    // Act
    ExecutingContext context = new();

    // Assert
    Assert.AreEqual(0, context.Errors.Count);
  }
}
