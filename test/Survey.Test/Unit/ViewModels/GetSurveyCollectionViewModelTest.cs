// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.Web.ViewModels.Test
{
  using Survey.Domain.Entities;

  [TestClass]
  public sealed class GetSurveyCollectionViewModelTest
  {
    [TestMethod]
    public void Constructor_Should_Copy_Data()
    {
      var controlSurveyEntityCollection =
        GetSurveyCollectionViewModelTest.GenerateTestSurveyEntityCollection(5);

      var actualGetSurveyCollectionViewModel =
        new GetSurveyCollectionViewModel(controlSurveyEntityCollection);

      GetSurveyCollectionViewModelTest.AreEqual(
        controlSurveyEntityCollection,
        actualGetSurveyCollectionViewModel);
    }

    private static ISurveyEntity[] GenerateTestSurveyEntityCollection(int entities)
    {
      var controlSurveyEntityCollection = new ISurveyEntity[entities];

      for (int i = 0; i < entities; i++)
      {
        controlSurveyEntityCollection[i] = new TestSurveyEntity();
      }

      return controlSurveyEntityCollection;
    }

    private static void AreEqual(ISurveyEntity controlSurveyEntity, GetSurveyViewModel actualGetSurveyViewModel)
    {
      Assert.AreEqual(controlSurveyEntity.SurveyId, actualGetSurveyViewModel.SurveyId);
      Assert.AreEqual(controlSurveyEntity.Name, actualGetSurveyViewModel.Name);
      Assert.AreEqual(controlSurveyEntity.Description, actualGetSurveyViewModel.Description);
    }

    private static void AreEqual(ISurveyEntity[] controlSurveyEntityCollection, GetSurveyCollectionViewModel actualGetSurveyCollectionViewModel)
    {
      Assert.AreEqual(
        controlSurveyEntityCollection.Length,
        actualGetSurveyCollectionViewModel.Surveys.Length);

      for (int i = 0; i < controlSurveyEntityCollection.Length; i++)
      {
        GetSurveyCollectionViewModelTest.AreEqual(
          controlSurveyEntityCollection[i],
          actualGetSurveyCollectionViewModel.Surveys[i]);
      }
    }

    private sealed class TestSurveyEntity : ISurveyEntity
    {
      public Guid SurveyId { get; set; } = Guid.NewGuid();

      public string Name { get; } = Guid.NewGuid().ToString();

      public string Description { get; } = Guid.NewGuid().ToString();
    }
  }
}
