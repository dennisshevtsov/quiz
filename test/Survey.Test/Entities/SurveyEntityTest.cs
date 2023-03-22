// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.Application.Entities.Test
{
  using Survey.Web.ViewModels;

  [TestClass]
  public sealed class SurveyEntityTest
  {
    [TestMethod]
    public void Constructor_Should_Copy_Data()
    {
      var surveyData = new SurveyViewModel
      {
        Name = Guid.NewGuid().ToString(),
        Description = Guid.NewGuid().ToString(),
      };

      var surveyEntity = new SurveyEntity(surveyData);

      Assert.AreEqual(surveyData.Name, surveyEntity.Name);
      Assert.AreEqual(surveyData.Description, surveyEntity.Description);
    }
  }
}
