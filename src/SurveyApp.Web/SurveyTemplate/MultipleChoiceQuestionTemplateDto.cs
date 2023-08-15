namespace SurveyApp.SurveyTemplate.Web;

public sealed class MultipleChoiceQuestionTemplateDto : SurveyTemplateQuestionDtoBase
{
  public string[] Choices { get; set; } = Array.Empty<string>();

  public override QuestionTemplateEntityBase ToQuestionTemplateEntity() => new MultipleChoiceQuestionTemplateEntity
  {
    Text = Text,
    Choices = Choices,
  };
}
