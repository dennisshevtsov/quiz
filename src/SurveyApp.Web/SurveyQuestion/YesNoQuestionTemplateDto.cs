// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.SurveyQuestion.Web;

public sealed class YesNoQuestionTemplateDto : SurveyQuestionDtoBase
{
    public YesNoQuestionTemplateDto() { }

    public YesNoQuestionTemplateDto(YesNoQuestionEntity yesNoQuestionTemplateEntity)
    {
        Text = yesNoQuestionTemplateEntity.Text;
    }

    public override SurveyQuestionEntityBase ToQuestionTemplateEntity() => new YesNoQuestionEntity
    {
        Text = Text,
    };
}
