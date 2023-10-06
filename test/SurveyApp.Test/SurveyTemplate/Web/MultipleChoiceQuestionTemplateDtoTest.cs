// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate.Web.Test;

[TestClass]
public sealed class MultipleChoiceQuestionTemplateDtoTest
{
  [TestMethod]
  public void ToQuestionTemplateEntity_MultipleChoiceQuestionTemplateDto_MultipleChoiceQuestionTemplateEntityReturned()
  {
    // Arrange
    MultipleChoiceQuestionTemplateDto multipleChoiceQuestionTemplateDto = new()
    {
      Text = Guid.NewGuid().ToString(),
      Choices = new[]
      {
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
        Guid.NewGuid().ToString(),
      },
    };

    // Act
    QuestionTemplateEntityBase questionTemplateEntityBase = multipleChoiceQuestionTemplateDto.ToTemplateQuestionEntity(new ExecutingContext())!;

    // Assert
    Assert.IsInstanceOfType(questionTemplateEntityBase, typeof(MultipleChoiceQuestionTemplateEntity));
  }

  [TestMethod]
  public void ToQuestionTemplateEntity_MultipleChoiceQuestionTemplateDto_TextFilled()
  {
    // Arrange
    MultipleChoiceQuestionTemplateDto multipleChoiceQuestionTemplateDto = new()
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
    QuestionTemplateEntityBase questionTemplateEntityBase = multipleChoiceQuestionTemplateDto.ToTemplateQuestionEntity(new ExecutingContext())!;

    // Assert
    Assert.AreEqual(multipleChoiceQuestionTemplateDto.Text, questionTemplateEntityBase.Text);
  }

  [TestMethod]
  public void ToQuestionTemplateEntity_MultipleChoiceQuestionTemplateDto_ChoicesFilled()
  {
    // Arrange
    MultipleChoiceQuestionTemplateDto multipleChoiceQuestionTemplateDto = new()
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
    QuestionTemplateEntityBase questionTemplateEntityBase = multipleChoiceQuestionTemplateDto.ToTemplateQuestionEntity(new ExecutingContext())!;

    // Assert
    Assert.AreEqual(multipleChoiceQuestionTemplateDto.Choices, ((MultipleChoiceQuestionTemplateEntity)questionTemplateEntityBase).Choices);
  }

  [TestMethod]
  public void ToQuestionTemplateEntity_NoText_NullReturned()
  {
    // Arrange
    MultipleChoiceQuestionTemplateDto multipleChoiceQuestionTemplateDto = new()
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
    QuestionTemplateEntityBase? questionTemplateEntityBase = multipleChoiceQuestionTemplateDto.ToTemplateQuestionEntity(new ExecutingContext());

    // Assert
    Assert.IsNull(questionTemplateEntityBase);
  }

  [TestMethod]
  public void ToQuestionTemplateEntity_NoText_ContextHasErrors()
  {
    // Arrange
    MultipleChoiceQuestionTemplateDto multipleChoiceQuestionTemplateDto = new()
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
    multipleChoiceQuestionTemplateDto.ToTemplateQuestionEntity(context);

    // Assert
    Assert.IsTrue(context.HasErrors);
  }

  [TestMethod]
  public void ToQuestionTemplateEntity_NoChoices_NullReturned()
  {
    // Arrange
    MultipleChoiceQuestionTemplateDto multipleChoiceQuestionTemplateDto = new()
    {
      Text    = Guid.NewGuid().ToString(),
      Choices = Array.Empty<string>(),
    };

    // Act
    QuestionTemplateEntityBase? questionTemplateEntityBase = multipleChoiceQuestionTemplateDto.ToTemplateQuestionEntity(new ExecutingContext());

    // Assert
    Assert.IsNull(questionTemplateEntityBase);
  }

  [TestMethod]
  public void ToQuestionTemplateEntity_NoChoices_ContextHasErrors()
  {
    // Arrange
    MultipleChoiceQuestionTemplateDto multipleChoiceQuestionTemplateDto = new()
    {
      Text    = Guid.NewGuid().ToString(),
      Choices = Array.Empty<string>(),
    };

    ExecutingContext context = new();

    // Act
    multipleChoiceQuestionTemplateDto.ToTemplateQuestionEntity(context);

    // Assert
    Assert.IsTrue(context.HasErrors);
  }

  [TestMethod]
  public void ToQuestionTemplateEntity_EmptyChoice_NullReturned()
  {
    // Arrange
    MultipleChoiceQuestionTemplateDto multipleChoiceQuestionTemplateDto = new()
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
    QuestionTemplateEntityBase? questionTemplateEntityBase = multipleChoiceQuestionTemplateDto.ToTemplateQuestionEntity(new ExecutingContext());

    // Assert
    Assert.IsNull(questionTemplateEntityBase);
  }

  [TestMethod]
  public void ToQuestionTemplateEntity_EmptyChoice_ContextHasErrors()
  {
    // Arrange
    MultipleChoiceQuestionTemplateDto multipleChoiceQuestionTemplateDto = new()
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
    multipleChoiceQuestionTemplateDto.ToTemplateQuestionEntity(context);

    // Assert
    Assert.IsTrue(context.HasErrors);
  }
}
