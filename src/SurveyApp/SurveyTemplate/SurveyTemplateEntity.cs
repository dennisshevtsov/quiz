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

  public SurveyTemplateEntity(string title, string description, QuestionTemplateEntityBase[] questions)
    : this(Guid.NewGuid(), title, description, questions)
  { }

  public Guid SurveyTemplateId { get; private set; }

  public string Title { get; private set; }

  public string Description { get; private set; }

  public QuestionTemplateEntityBase[] Questions { get; private set; }

  public SurveyTemplateEntity Update(string title, string description, QuestionTemplateEntityBase[] questions)
  {
    Title       = title;
    Description = description;
    Questions   = questions;

    return this;
  }
}
