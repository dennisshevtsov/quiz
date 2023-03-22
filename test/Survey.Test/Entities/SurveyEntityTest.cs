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
      var testSurveyData = new TestSurveyData();
      var testSurveyEntity = new SurveyEntity(testSurveyData);

      Assert.AreEqual(testSurveyData.Name, testSurveyEntity.Name);
      Assert.AreEqual(testSurveyData.Description, testSurveyEntity.Description);
    }

    [TestMethod]
    public void Constructor_Should_Copy_Entity()
    {
      var testSurveyEntity = new TestSurveyEntity();
      var actualSurveyEntity = new SurveyEntity(testSurveyEntity);

      Assert.AreEqual(testSurveyEntity.Name, actualSurveyEntity.Name);
      Assert.AreEqual(testSurveyEntity.Description, actualSurveyEntity.Description);
    }

    private sealed class TestSurveyData : ISurveyData
    {
      public string Name { get; } = Guid.NewGuid().ToString();

      public string Description { get; } = Guid.NewGuid().ToString();
    }

    private sealed class TestSurveyEntity : ISurveyEntity
    {
      public Guid SurveyId { get; } = Guid.NewGuid();

      public string Name { get; } = Guid.NewGuid().ToString();

      public string Description { get; } = Guid.NewGuid().ToString();
    }
  }
}
