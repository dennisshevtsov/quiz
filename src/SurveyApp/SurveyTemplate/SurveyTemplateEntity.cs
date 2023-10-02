// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyTemplate;

public sealed class SurveyTemplateEntity
{
  private SurveyTemplateEntity(Guid surveyTemplateId, string title, string description, QuestionTemplateEntityBase[] questions)
  {
    SurveyTemplateId = surveyTemplateId;
    Title            = title;
    Description      = description;
    Questions        = questions;
  }

  public Guid SurveyTemplateId { get; private set; }

  public string Title { get; private set; }

  public string Description { get; private set; }

  public QuestionTemplateEntityBase[] Questions { get; private set; }

  public ExecutedContext<SurveyTemplateEntity> Update(string title, string description, QuestionTemplateEntityBase[] questions)
  {
    string[] errors = Validate(title, description);

    if (errors.Length > 0)
    {
      return ExecutedContext<SurveyTemplateEntity>.Fail(errors);
    }

    Title       = title;
    Description = description;
    Questions   = questions;

    return ExecutedContext<SurveyTemplateEntity>.Ok(this);
  }

  public static ExecutedContext<SurveyTemplateEntity> New(
    string title, string description, QuestionTemplateEntityBase[] questions)
  {
    string[] errors = Validate(title, description);

    if (errors.Length > 0)
    {
      return ExecutedContext<SurveyTemplateEntity>.Fail(errors);
    }

    SurveyTemplateEntity surveyTemplateEntity = new
    (
      surveyTemplateId: Guid.NewGuid(),
      title           : title,
      description     : description,
      questions       : questions
    );

    return ExecutedContext<SurveyTemplateEntity>.Ok(surveyTemplateEntity);
  }

  private static string[] Validate(string title, string description)
  {
    List<string> errors = new(2);

    if (string.IsNullOrEmpty(title))
    {
      errors.Add("Title is required.");
    }

    if (string.IsNullOrEmpty(description))
    {
      errors.Add("Description is required.");
    }

    return errors.ToArray();
  }
}
