// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Survey;

public enum SurveyState : byte
{
  Draft     = 0,
  Ready     = 1,
  Done      = 2,
  Cancelled = 3,
}
