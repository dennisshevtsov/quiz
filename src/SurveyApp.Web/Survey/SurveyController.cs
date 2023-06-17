// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using Microsoft.AspNetCore.Mvc;

using SurveyApp.Web.Defaults;

namespace SurveyApp.Survey.Web;

/// <summary>Provides a simple API to handle HTTP request.</summary>
[ApiController]
[Route("api/survey")]
[Produces(ContentType.Json)]
public sealed class SurveyController : ControllerBase
{
}
