// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyQuestion.Web;

public sealed class SingleChoiceQuestionTemplateDto : SurveyTemplateQuestionDtoBase
{
    public SingleChoiceQuestionTemplateDto() { }

    public SingleChoiceQuestionTemplateDto(SingleChoiceQuestionEntity singleChoiceQuestionTemplateEntity)
    {
        Text = singleChoiceQuestionTemplateEntity.Text;
        Choices = singleChoiceQuestionTemplateEntity.Choices;
    }

    public string[] Choices { get; set; } = Array.Empty<string>();

    public override SurveyQuestionEntityBase ToQuestionTemplateEntity() => new SingleChoiceQuestionEntity
    {
        Text = Text,
        Choices = Choices,
    };
}
