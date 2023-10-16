// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using SurveyApp.SurveyTemplate;

namespace SurveyApp.Survey;

public sealed class SurveyEntity
{
  private SurveyEntity(Guid surveyId, SurveyState state, string title, string description, string intervieweeName, QuestionEntityBase[] questions)
  {
    SurveyId        = surveyId;
    State           = state;
    Title           = title;
    Description     = description;
    IntervieweeName = intervieweeName;
    Questions       = questions;
  }

  private SurveyEntity(string title, string description, string intervieweeName, QuestionEntityBase[] questions)
  : this
  (
    surveyId       : Guid.NewGuid(),
    state          : SurveyState.Draft,
    title          : title,
    description    : description,
    intervieweeName: intervieweeName,
    questions      : questions
  )
  { }

  public SurveyEntity(SurveyTemplateEntity surveyTemplateEntity)
  : this
  (
    title          : surveyTemplateEntity.Title,
    description    : surveyTemplateEntity.Description,
    intervieweeName: string.Empty,
    questions      : QuestionEntityBase.Copy(surveyTemplateEntity.Questions)
  )
  { }

  public Guid SurveyId { get; }

  public SurveyState State { get; private set; }

  public string Title { get; }

  public string Description { get; }

  public string IntervieweeName { get; private set; }

  public QuestionEntityBase[] Questions { get; }

  public static SurveyEntity? New(string intervieweeName, SurveyTemplateEntity template, ExecutingContext context)
  {
    ValidateIntervieweeName(intervieweeName, context);

    if (context.HasErrors)
    {
      return null;
    }

    SurveyEntity surveyEntity = new(template)
    {
      IntervieweeName = intervieweeName,
    };

    return surveyEntity;
  }

  public void MoveTo(SurveyState state, ExecutingContext context)
  {
    Validate(state, context);

    if (context.HasErrors)
    {
      return;
    }

    State = state;
  }

  public void Update(string intervieweeName, ExecutingContext context)
  {
    Validate(intervieweeName, context);

    if (context.HasErrors)
    {
      return;
    }

    IntervieweeName = intervieweeName;
  }

  public void Answer(ExecutingContext context)
  {
    if (context.HasErrors)
    {
      return;
    }

    if (State != SurveyState.Ready)
    {
      context.AddError("Only survey in Ready state can be answered.");
      return;
    }

    State = SurveyState.Done;
  }

  private void Validate(SurveyState state, ExecutingContext context)
  {
    if (state < SurveyState.Draft || state > SurveyState.Cancelled)
    {
      context.AddError("Unknown state.");
    }

    if (State != SurveyState.Ready && state == SurveyState.Done)
    {
      context.AddError("You can move a survey to the done state only if this survey is in the ready state.");
    }

    if (State == SurveyState.Done || State == SurveyState.Cancelled)
    {
      context.AddError("You cannot change a state of a done or cancelled survey.");
    }
  }

  private void Validate(string intervieweeName, ExecutingContext context)
  {
    if (State != SurveyState.Draft)
    {
      context.AddError("You can update only draft surveys.");

      return;
    }

    ValidateIntervieweeName(intervieweeName, context);
  }

  private static void ValidateIntervieweeName(string intervieweeName, ExecutingContext context)
  {
    if (string.IsNullOrWhiteSpace(intervieweeName))
    {
      context.AddError("Interviewee Name is required.");
    }
  }
}
