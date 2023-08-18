// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate.Web.Test;

[TestClass]
public sealed class SurveyTemplateControllerTest
{
#pragma warning disable CS8618
  private Mock<ISurveyTemplateRepository> _surveyTemplateRepositoryMock;
  private SurveyTemplateController _surveyTemplateController;
#pragma warning restore CS8618

  [TestInitialize]
  public void Initialize()
  {
    _surveyTemplateRepositoryMock = new Mock<ISurveyTemplateRepository>();
    _surveyTemplateController = new SurveyTemplateController(_surveyTemplateRepositoryMock.Object);
  }
}
