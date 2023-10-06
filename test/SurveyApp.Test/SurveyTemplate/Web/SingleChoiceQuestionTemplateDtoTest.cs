// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate.Web.Test;

[TestClass]
public sealed class SingleChoiceQuestionTemplateDtoTest
{
  [TestMethod]
  public void ToQuestionTemplateEntity_SingleChoiceQuestionTemplateDto_SingleChoiceQuestionTemplateEntityReturned()
  {
    // Arrange
    SingleChoiceQuestionTemplateDto singleChoiceQuestionTemplateDto = new()
    {
      Text    = Guid.NewGuid().ToString(),
      Choices = new[]
      {
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
      },
    };

    // Act
    QuestionTemplateEntityBase questionTemplateEntityBase = singleChoiceQuestionTemplateDto.ToTemplateQuestionEntity(new ExecutingContext())!;

    // Assert
    Assert.IsInstanceOfType(questionTemplateEntityBase, typeof(SingleChoiceQuestionTemplateEntity));
  }

  [TestMethod]
  public void ToQuestionTemplateEntity_SingleChoiceQuestionTemplateDto_TextFilled()
  {
    // Arrange
    SingleChoiceQuestionTemplateDto singleChoiceQuestionTemplateDto = new()
    {
      Text    = Guid.NewGuid().ToString(),
      Choices = new[]
      {
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
      },
    };

    // Act
    QuestionTemplateEntityBase questionTemplateEntityBase = singleChoiceQuestionTemplateDto.ToTemplateQuestionEntity(new ExecutingContext())!;

    // Assert
    Assert.AreEqual(singleChoiceQuestionTemplateDto.Text, questionTemplateEntityBase.Text);
  }

  [TestMethod]
  public void ToQuestionTemplateEntity_SingleChoiceQuestionTemplateDto_ChoicesFilled()
  {
    // Arrange
    SingleChoiceQuestionTemplateDto singleChoiceQuestionTemplateDto = new()
    {
      Text    = Guid.NewGuid().ToString(),
      Choices = new[]
      {
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
      },
    };

    // Act
    QuestionTemplateEntityBase questionTemplateEntityBase = singleChoiceQuestionTemplateDto.ToTemplateQuestionEntity(new ExecutingContext())!;

    // Assert
    Assert.AreEqual(singleChoiceQuestionTemplateDto.Choices, ((SingleChoiceQuestionTemplateEntity)questionTemplateEntityBase).Choices);
  }

  [TestMethod]
  public void ToQuestionTemplateEntity_NoText_NullReturned()
  {
    // Arrange
    SingleChoiceQuestionTemplateDto singleChoiceQuestionTemplateDto = new()
    {
      Text    = string.Empty,
      Choices = new[]
      {
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
      },
    };

    // Act
    QuestionTemplateEntityBase? questionTemplateEntityBase = singleChoiceQuestionTemplateDto.ToTemplateQuestionEntity(new ExecutingContext());

    // Assert
    Assert.IsNull(questionTemplateEntityBase);
  }

  [TestMethod]
  public void ToQuestionTemplateEntity_NoText_ContextHasErrors()
  {
    // Arrange
    SingleChoiceQuestionTemplateDto singleChoiceQuestionTemplateDto = new()
    {
      Text    = string.Empty,
      Choices = new[]
      {
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
      },
    };

    ExecutingContext context = new();

    // Act
    singleChoiceQuestionTemplateDto.ToTemplateQuestionEntity(context);

    // Assert
    Assert.IsTrue(context.HasErrors);
  }

  [TestMethod]
  public void ToQuestionTemplateEntity_NoChoices_NullReturned()
  {
    // Arrange
    SingleChoiceQuestionTemplateDto singleChoiceQuestionTemplateDto = new()
    {
      Text    = Guid.NewGuid().ToString(),
      Choices = Array.Empty<string>(),
    };

    // Act
    QuestionTemplateEntityBase? questionTemplateEntityBase = singleChoiceQuestionTemplateDto.ToTemplateQuestionEntity(new ExecutingContext());

    // Assert
    Assert.IsNull(questionTemplateEntityBase);
  }

  [TestMethod]
  public void ToQuestionTemplateEntity_NoChoices_ContextHasErrors()
  {
    // Arrange
    SingleChoiceQuestionTemplateDto singleChoiceQuestionTemplateDto = new()
    {
      Text    = Guid.NewGuid().ToString(),
      Choices = Array.Empty<string>(),
    };

    ExecutingContext context = new();

    // Act
    singleChoiceQuestionTemplateDto.ToTemplateQuestionEntity(context);

    // Assert
    Assert.IsTrue(context.HasErrors);
  }

  [TestMethod]
  public void ToQuestionTemplateEntity_EmptyChoice_NullReturned()
  {
    // Arrange
    SingleChoiceQuestionTemplateDto singleChoiceQuestionTemplateDto = new()
    {
      Text    = Guid.NewGuid().ToString(),
      Choices = new[]
      {
        Guid.NewGuid().ToString(),
        string.Empty,
        Guid.NewGuid().ToString(),
      },
    };

    // Act
    QuestionTemplateEntityBase? questionTemplateEntityBase = singleChoiceQuestionTemplateDto.ToTemplateQuestionEntity(new ExecutingContext());

    // Assert
    Assert.IsNull(questionTemplateEntityBase);
  }

  [TestMethod]
  public void ToQuestionTemplateEntity_EmptyChoice_ContextHasErrors()
  {
    // Arrange
    SingleChoiceQuestionTemplateDto singleChoiceQuestionTemplateDto = new()
    {
      Text    = Guid.NewGuid().ToString(),
      Choices = new[]
      {
        Guid.NewGuid().ToString(),
        string.Empty,
        Guid.NewGuid().ToString(),
      },
    };

    ExecutingContext context = new();

    // Act
    singleChoiceQuestionTemplateDto.ToTemplateQuestionEntity(context);

    // Assert
    Assert.IsTrue(context.HasErrors);
  }
}
