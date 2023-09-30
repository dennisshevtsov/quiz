// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Test;

[TestClass]
public sealed class ExecutedContextTest
{
  [TestMethod]
  public void Ok_Null_ExceptionThrown()
  {
    // Act
    Action act = () => ExecutedContext<object>.Ok(null!);

    // Assert
    Assert.ThrowsException<ArgumentNullException>(() => act());
  }

  [TestMethod]
  public void Ok_Result_ContextContainsResult()
  {
    // Arrange
    object result = new();

    // Act
    ExecutedContext<object> context = ExecutedContext<object>.Ok(result);

    // Assert
    Assert.AreEqual(result, context.Rusult);
  }

  [TestMethod]
  public void Fail_Null_ExceptionThrown()
  {
    // Act
    Action act = () => ExecutedContext<object>.Fail(null!);

    // Assert
    Assert.ThrowsException<ArgumentNullException>(() => act());
  }

  [TestMethod]
  public void Fail_Errors_ContextContainsErrors()
  {
    // Arrange
    string[] errors = new[]
    {
      Guid.NewGuid().ToString(),
    };

    // Act
    ExecutedContext<object> context = ExecutedContext<object>.Fail(errors);

    // Assert
    Assert.AreEqual(errors, context.Errors);
  }
}
