// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.Survey.Test;

namespace SurveyApp.Survey.Web.Test;

[TestClass]
public sealed class UpdateSurveyRequestDtoTest
{
  [TestMethod]
  public void UpdateSurvey_SurveyEntity_IntervieweeNameUpdated()
  {
    // Arrange
    UpdateSurveyRequestDto updateSurveyRequestDto = new()
    {
      IntervieweeName = Guid.NewGuid().ToString(),
    };

    SurveyEntity surveyEntity = new
    (
      surveyId       : default,
      state          : default,
      title          : string.Empty,
      description    : string.Empty,
      intervieweeName: string.Empty,
      questions      : Array.Empty<QuestionEntityBase>()
    );

    // Act
    updateSurveyRequestDto.UpdateSurvey(surveyEntity, new ExecutingContext());

    // Assert
    Assert.AreEqual(updateSurveyRequestDto.IntervieweeName, surveyEntity.IntervieweeName);
  }

  [TestMethod]
  public void UpdateSurvey_NoIntervieweeName_IntervieweeNameNotUpdated()
  {
    // Arrange
    UpdateSurveyRequestDto updateSurveyRequestDto = new()
    {
      IntervieweeName = string.Empty,
    };

    string originalCandidateName = Guid.NewGuid().ToString();

    SurveyEntity surveyEntity = new
    (
      surveyId       : default,
      state          : default,
      title          : string.Empty,
      description    : string.Empty,
      intervieweeName: originalCandidateName,
      questions      : Array.Empty<QuestionEntityBase>()
    );

    // Act
    updateSurveyRequestDto.UpdateSurvey(surveyEntity, new ExecutingContext());

    // Assert
    Assert.AreEqual(originalCandidateName, surveyEntity.IntervieweeName);
  }

  [TestMethod]
  public void UpdateSurvey_NoIntervieweeName_ContextHasErrors()
  {
    // Arrange
    UpdateSurveyRequestDto updateSurveyRequestDto = new()
    {
      IntervieweeName = string.Empty,
    };

    SurveyEntity surveyEntity = new
    (
      surveyId       : default,
      state          : default,
      title          : string.Empty,
      description    : string.Empty,
      intervieweeName: string.Empty,
      questions      : Array.Empty<QuestionEntityBase>()
    );

    ExecutingContext context = new();

    // Act
    updateSurveyRequestDto.UpdateSurvey(surveyEntity, context);

    // Assert
    Assert.IsTrue(context.HasErrors);
  }
}
