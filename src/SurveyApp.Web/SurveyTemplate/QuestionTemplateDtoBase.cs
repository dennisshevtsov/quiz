// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Text.Json.Serialization;

namespace SurveyApp.SurveyTemplate.Web;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "questionType")]
[JsonDerivedType(typeof(TextQuestionTemplateDto), (int)QuestionType.Text)]
[JsonDerivedType(typeof(YesNoQuestionTemplateDto), (int)QuestionType.YesNo)]
[JsonDerivedType(typeof(MultipleChoiceQuestionTemplateDto), (int)QuestionType.MultipleChoice)]
[JsonDerivedType(typeof(SingleChoiceQuestionTemplateDto), (int)QuestionType.SingleChoice)]
public abstract class QuestionTemplateDtoBase
{
  public string Text { get; set; } = string.Empty;

  public QuestionType QuestionType { get; set; }

  public abstract ExecutedContext<QuestionTemplateEntityBase> ToTemplateQuestionEntity();

  public static QuestionTemplateDtoBase FromQuestionTemplateEntity(QuestionTemplateEntityBase questionTemplateEntity) =>
    questionTemplateEntity.QuestionType switch
    {
      QuestionType.Text           => new TextQuestionTemplateDto((TextQuestionTemplateEntity)questionTemplateEntity),
      QuestionType.YesNo          => new YesNoQuestionTemplateDto((YesNoQuestionTemplateEntity)questionTemplateEntity),
      QuestionType.MultipleChoice => new MultipleChoiceQuestionTemplateDto((MultipleChoiceQuestionTemplateEntity)questionTemplateEntity),
      QuestionType.SingleChoice   => new SingleChoiceQuestionTemplateDto((SingleChoiceQuestionTemplateEntity)questionTemplateEntity),
      _                           => throw new NotSupportedException("Unknown question type."),
    };

  public static ExecutedContext<QuestionTemplateEntityBase[]> ToQuestionTemplateEntityCollection(QuestionTemplateDtoBase[] questionTemplateDtoCollection)
  {
    List<string> errors = new();
    QuestionTemplateEntityBase[] questionTemplateEntityCollection =
      new QuestionTemplateEntityBase[questionTemplateDtoCollection.Length];

    for (int i = 0; i < questionTemplateDtoCollection.Length; i++)
    {
      ExecutedContext<QuestionTemplateEntityBase> newQuestionTemplateEntity =
        questionTemplateDtoCollection[i].ToTemplateQuestionEntity();

      if (newQuestionTemplateEntity.HasErrors)
      {
        errors.AddRange(newQuestionTemplateEntity.Errors);
      }
      else
      {
        questionTemplateEntityCollection[i] = newQuestionTemplateEntity.Rusult;
      }
    }

    return errors.Count == 0 ?
           ExecutedContext<QuestionTemplateEntityBase[]>.Ok(questionTemplateEntityCollection) :
           ExecutedContext<QuestionTemplateEntityBase[]>.Fail(errors.ToArray());
  }
}
