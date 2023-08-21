namespace SurveyApp.SurveyTemplate.Web;

public sealed class MultipleChoiceQuestionTemplateDto : SurveyTemplateQuestionDtoBase
{
  public MultipleChoiceQuestionTemplateDto() { }

  public MultipleChoiceQuestionTemplateDto(MultipleChoiceQuestionTemplateEntity multipleChoiceQuestionTemplateEntity)
  {
    Text = multipleChoiceQuestionTemplateEntity.Text;
    Choices = multipleChoiceQuestionTemplateEntity.Choices;
  }

  public string[] Choices { get; set; } = Array.Empty<string>();

  public override QuestionTemplateEntityBase ToQuestionTemplateEntity() => new MultipleChoiceQuestionTemplateEntity
  {
    Text = Text,
    Choices = Choices,
  };
}
