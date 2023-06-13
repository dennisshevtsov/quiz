// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Application.Entities.Test
{
  using SurveyApp.SurveyTemplate;

  [TestClass]
  public sealed class SurveyEntityTest
  {
    [TestMethod]
    public void Constructor_Should_Copy_Data()
    {
      var controlSurveyEntity = new TestSurveyEntity();
      var actualSurveyEntity = new SurveyEntity(controlSurveyEntity);

      Assert.AreEqual(controlSurveyEntity.Name, actualSurveyEntity.Name);
      Assert.AreEqual(controlSurveyEntity.Description, actualSurveyEntity.Description);
    }

    [TestMethod]
    public void Constructor_Should_Copy_Entity()
    {
      var controlSurveyEntity = new TestSurveyEntity();
      var actualSurveyEntity = new SurveyEntity(controlSurveyEntity);

      Assert.AreEqual(controlSurveyEntity.Name, actualSurveyEntity.Name);
      Assert.AreEqual(controlSurveyEntity.Description, actualSurveyEntity.Description);
    }

    private sealed class TestSurveyEntity : ISurveyTemplateEntity
    {
      public Guid SurveyId { get; } = Guid.NewGuid();

      public string Name { get; } = Guid.NewGuid().ToString();

      public string Description { get; } = Guid.NewGuid().ToString();
    }
  }
}
