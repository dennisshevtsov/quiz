// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyQuestion.Web;

public sealed class MultipleChoiceQuestionTemplateDto : SurveyQuestionDtoBase
{
    public MultipleChoiceQuestionTemplateDto() { }

    public MultipleChoiceQuestionTemplateDto(MultipleChoiceQuestionEntity multipleChoiceQuestionTemplateEntity)
    {
        Text = multipleChoiceQuestionTemplateEntity.Text;
        Choices = multipleChoiceQuestionTemplateEntity.Choices;
    }

    public string[] Choices { get; set; } = Array.Empty<string>();

    public override SurveyQuestionEntityBase ToQuestionTemplateEntity() => new MultipleChoiceQuestionEntity
    {
        Text = Text,
        Choices = Choices,
    };
}
