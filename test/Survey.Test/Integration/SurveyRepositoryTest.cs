﻿// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace Survey.Infrastructure.Repositories.Test
{
  using Microsoft.Extensions.DependencyInjection;

  using Survey.Domain.Repositories;
  using Survey.Test.Integration;

  [TestClass]
  public sealed class SurveyRepositoryTest : IntegrationTestBase
  {

#pragma warning disable CS8618
    private ISurveyRepository _surveyRepository;
#pragma warning restore CS8618

    protected override void InitializeInternal()
    {
      _surveyRepository = ServiceProvider.GetRequiredService<ISurveyRepository>();
    }
  }
}
