// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Web.Dtos.Test
{
  using SurveyApp.SurveyTemplate;

  [TestClass]
  public sealed class GetSurveyCollectionResponseDtoTest
  {
    [TestMethod]
    public void Constructor_Should_Copy_Data()
    {
      var controlSurveyEntityCollection =
        GetSurveyCollectionResponseDtoTest.GenerateTestSurveyEntityCollection(5);

      var actualGetSurveyCollectionViewModel =
        new GetSurveyCollectionResponseDto(controlSurveyEntityCollection);

      GetSurveyCollectionResponseDtoTest.AreEqual(
        controlSurveyEntityCollection,
        actualGetSurveyCollectionViewModel);
    }

    private static ISurveyTemplateEntity[] GenerateTestSurveyEntityCollection(int entities)
    {
      var controlSurveyEntityCollection = new ISurveyTemplateEntity[entities];

      for (int i = 0; i < entities; i++)
      {
        controlSurveyEntityCollection[i] = new TestSurveyEntity();
      }

      return controlSurveyEntityCollection;
    }

    private static void AreEqual(ISurveyTemplateEntity controlSurveyEntity, GetSurveyResponseDto actualGetSurveyViewModel)
    {
      Assert.AreEqual(controlSurveyEntity.SurveyId, actualGetSurveyViewModel.SurveyId);
      Assert.AreEqual(controlSurveyEntity.Name, actualGetSurveyViewModel.Name);
      Assert.AreEqual(controlSurveyEntity.Description, actualGetSurveyViewModel.Description);
    }

    private static void AreEqual(ISurveyTemplateEntity[] controlSurveyEntityCollection, GetSurveyCollectionResponseDto actualGetSurveyCollectionViewModel)
    {
      Assert.AreEqual(
        controlSurveyEntityCollection.Length,
        actualGetSurveyCollectionViewModel.Surveys.Length);

      for (int i = 0; i < controlSurveyEntityCollection.Length; i++)
      {
        GetSurveyCollectionResponseDtoTest.AreEqual(
          controlSurveyEntityCollection[i],
          actualGetSurveyCollectionViewModel.Surveys[i]);
      }
    }

    private sealed class TestSurveyEntity : ISurveyTemplateEntity
    {
      public Guid SurveyId { get; set; } = Guid.NewGuid();

      public string Name { get; } = Guid.NewGuid().ToString();

      public string Description { get; } = Guid.NewGuid().ToString();
    }
  }
}
