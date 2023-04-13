// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.Web.Dtos.Test
{
  using Survey.Domain.Entities;
  using Survey.Web.Dtos;

  [TestClass]
  public sealed class GetSurveyResponseDtoTest
  {
    [TestMethod]
    public void Constructor_Should_Copy_Data()
    {
      var controlSurveyEntity = new TestSurveyEntity();
      var actualGetSurveyViewModel = new GetSurveyResponseDto(controlSurveyEntity);

      Assert.AreEqual(controlSurveyEntity.SurveyId, actualGetSurveyViewModel.SurveyId);
      Assert.AreEqual(controlSurveyEntity.Name, actualGetSurveyViewModel.Name);
      Assert.AreEqual(controlSurveyEntity.Description, actualGetSurveyViewModel.Description);
    }

    private sealed class TestSurveyEntity : ISurveyEntity
    {
      public Guid SurveyId { get; set; } = Guid.NewGuid();

      public string Name { get; } = Guid.NewGuid().ToString();

      public string Description { get; } = Guid.NewGuid().ToString();

      public IQuestionEntity[] Questions { get; } = new IQuestionEntity[0];
    }
  }
}
