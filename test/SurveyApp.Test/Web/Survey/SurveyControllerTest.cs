// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey.Web.Test;

[TestClass]
public sealed class SurveyControllerTest
{
#pragma warning disable CS8618
  private Mock<ISurveyRepository> _surveyRepositoryMock;
  private SurveyController _surveyController;
#pragma warning restore CS8618

  [TestInitialize]
  public void Initialize()
  {
    _surveyRepositoryMock = new Mock<ISurveyRepository>();
    _surveyController     = new SurveyController(_surveyRepositoryMock.Object);
  }
}
