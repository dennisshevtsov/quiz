// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate;

public sealed class SurveyTemplateEntity
{
  public SurveyTemplateEntity(Guid surveyTemplateId, string title, string description, QuestionTemplateEntityBase[] questions)
  {
    SurveyTemplateId = surveyTemplateId;
    Title            = title;
    Description      = description;
    Questions        = questions;
  }

  public SurveyTemplateEntity(SurveyTemplateEntity surveyTemplateEntity) : this
  (
    surveyTemplateId: surveyTemplateEntity.SurveyTemplateId,
    title           : surveyTemplateEntity.Title,
    description     : surveyTemplateEntity.Description,
    questions       : surveyTemplateEntity.Questions
  )
  { }

  public Guid SurveyTemplateId { get; private set; }

  public string Title { get; private set; }

  public string Description { get; private set; }

  public QuestionTemplateEntityBase[] Questions { get; private set; }

  public void Update(string title, string description, QuestionTemplateEntityBase[] questions, ExecutingContext context)
  {
    Validate(title, description, context);

    if (context.HasErrors)
    {
      return;
    }

    Title       = title;
    Description = description;
    Questions   = questions;
  }

  public static SurveyTemplateEntity? New(
    string title,
    string description,
    QuestionTemplateEntityBase[] questions,
    ExecutingContext context)
  {
    Validate
    (
      title      : title,
      description: description,
      context    : context
    );

    if (context.HasErrors)
    {
      return null;
    }

    SurveyTemplateEntity surveyTemplateEntity = new
    (
      surveyTemplateId: Guid.NewGuid(),
      title           : title,
      description     : description,
      questions       : questions
    );

    return surveyTemplateEntity;
  }

  private static void Validate(string title, string description, ExecutingContext context)
  {
    if (string.IsNullOrEmpty(title))
    {
      context.AddError("Title is required.");
    }

    if (string.IsNullOrEmpty(description))
    {
      context.AddError("Description is required.");
    }
  }
}
