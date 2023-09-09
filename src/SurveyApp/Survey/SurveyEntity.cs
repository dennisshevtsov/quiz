// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyTemplate;

namespace SurveyApp.Survey;

public sealed class SurveyEntity
{
  public SurveyEntity() { }

  public SurveyEntity(SurveyTemplateEntity surveyTemplateEntity)
  {
    Title = surveyTemplateEntity.Title;
    Description = surveyTemplateEntity.Description;
    Questions = surveyTemplateEntity.Questions.Select(QuestionEntityBase.Copy).ToList();
  }

  public Guid SurveyId { get; set; }

  public SurveyState State { get; set; }

  public string Title { get; set; } = string.Empty;

  public string Description { get; set; } = string.Empty;

  public string CandidateName { get; set; } = string.Empty;

  public List<QuestionEntityBase> Questions { get; set; } = new();

  public bool TryMoveTo(SurveyState state)
  {
    if (state < SurveyState.Draft || state > SurveyState.Cacelled)
    {
      return false;
    }

    if (state == SurveyState.Done && State != SurveyState.Ready)
    {
      return false;
    }

    if (State == SurveyState.Done || State == SurveyState.Cacelled)
    {
      return false;
    }

    State = state;

    return true;
  }
}
