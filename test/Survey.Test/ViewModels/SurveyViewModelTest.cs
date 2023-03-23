// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.Web.ViewModels.Test
{
  using Survey.Domain.Entities;

  [TestClass]
  public sealed class SurveyViewModelTest
  {
    [TestMethod]
    public void Constructor_Should_Copy_Data()
    {
      var controlSurveyData = new TestSurveyData();
      var actualSurveyViewModel = new SurveyViewModel(controlSurveyData);

      Assert.AreEqual(controlSurveyData.Name, actualSurveyViewModel.Name);
      Assert.AreEqual(controlSurveyData.Description, actualSurveyViewModel.Description);
    }

    private sealed class TestSurveyData : ISurveyData
    {
      public string Name { get; } = Guid.NewGuid().ToString();

      public string Description { get; } = Guid.NewGuid().ToString();
    }
  }
}
