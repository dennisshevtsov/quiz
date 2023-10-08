// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyTemplate;

namespace SurveyApp.Survey;

public sealed class SurveyEntity
{
  public SurveyEntity(Guid surveyId, SurveyState state, string title, string description, string candidateName, QuestionEntityBase[] questions)
  {
    SurveyId      = surveyId;
    State         = state;
    Title         = title;
    Description   = description;
    CandidateName = candidateName;
    Questions     = questions;
  }

  public SurveyEntity(string title, string description, string candidateName, QuestionEntityBase[] questions)
  : this
  (
    surveyId     : Guid.NewGuid(),
    state        : SurveyState.Draft,
    title        : title,
    description  : description,
    candidateName: candidateName,
    questions    : questions
  )
  { }

  public SurveyEntity(SurveyTemplateEntity surveyTemplateEntity)
  : this
  (
    title        : surveyTemplateEntity.Title,
    description  : surveyTemplateEntity.Description,
    candidateName: string.Empty,
    questions    : surveyTemplateEntity.Questions.Select(QuestionEntityBase.Copy).ToArray()
  )
  { }

  public Guid SurveyId { get; private set; }

  public SurveyState State { get; private set; }

  public string Title { get; private set; }

  public string Description { get; private set; }

  public string CandidateName { get; private set; }

  public QuestionEntityBase[] Questions { get; private set; }

  public bool TryMoveTo(SurveyState state)
  {
    if (state < SurveyState.Draft || state > SurveyState.Cancelled)
    {
      return false;
    }

    if (state == SurveyState.Done && State != SurveyState.Ready)
    {
      return false;
    }

    if (State == SurveyState.Done || State == SurveyState.Cancelled)
    {
      return false;
    }

    State = state;

    return true;
  }

  public SurveyEntity Update(string title, string description, string candidateName, QuestionEntityBase[] questions)
  {
    Title         = title;
    Description   = description;
    CandidateName = candidateName;
    Questions     = questions;

    return this;
  }
}
