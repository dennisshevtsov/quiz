// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.Application.Entities.Test
{
  using Survey.Domain.Entities;

  [TestClass]
  public sealed class SurveyEntityTest
  {
    [TestMethod]
    public void Constructor_Should_Copy_Data()
    {
      var controlSurveyData = new TestSurveyData();
      var actualSurveyEntity = new SurveyEntity(controlSurveyData);

      Assert.AreEqual(controlSurveyData.Name, actualSurveyEntity.Name);
      Assert.AreEqual(controlSurveyData.Description, actualSurveyEntity.Description);
    }

    [TestMethod]
    public void Constructor_Should_Copy_Entity()
    {
      var controlSurveyEntity = new TestSurveyEntity();
      var actualSurveyEntity = new SurveyEntity(controlSurveyEntity);

      Assert.AreEqual(controlSurveyEntity.Name, actualSurveyEntity.Name);
      Assert.AreEqual(controlSurveyEntity.Description, actualSurveyEntity.Description);
    }

    private sealed class TestSurveyData : ISurveyData
    {
      public string Name { get; } = Guid.NewGuid().ToString();

      public string Description { get; } = Guid.NewGuid().ToString();

      public IQuestionEntity[] Questions { get; } = new IQuestionEntity[0];
    }

    private sealed class TestSurveyEntity : ISurveyEntity
    {
      public Guid SurveyId { get; } = Guid.NewGuid();

      public string Name { get; } = Guid.NewGuid().ToString();

      public string Description { get; } = Guid.NewGuid().ToString();

      public IQuestionEntity[] Questions { get; } = new IQuestionEntity[0];
    }
  }
}
