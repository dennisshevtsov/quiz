// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.Web.ViewModels.Test
{
  using Survey.Domain.Entities;
  using Survey.Web.ViewModels;

  [TestClass]
  public sealed class GetSurveyViewModelTest
  {
    [TestMethod]
    public void Constructor_Should_Copy_Data()
    {
      var controlSurveyEntity = new TestSurveyEntity();
      var actualSurveyViewModel = new GetSurveyViewModel(controlSurveyEntity);

      Assert.AreEqual(controlSurveyEntity.SurveyId, actualSurveyViewModel.SurveyId);
      Assert.AreEqual(controlSurveyEntity.Name, actualSurveyViewModel.Name);
      Assert.AreEqual(controlSurveyEntity.Description, actualSurveyViewModel.Description);
    }

    private sealed class TestSurveyEntity : ISurveyEntity
    {
      public Guid SurveyId { get; set; } = Guid.NewGuid();

      public string Name { get; } = Guid.NewGuid().ToString();

      public string Description { get; } = Guid.NewGuid().ToString();
    }
  }
}
