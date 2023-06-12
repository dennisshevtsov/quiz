// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace SurveyApp.Domain.Survey
{
    using SurveyApp.Domain.Question;

    /// <summary>Represents survey data.</summary>
    public interface ISurveyData
    {
        /// <summary>Gets an object that represents a name of a survey.</summary>
        public string Name { get; }

        /// <summary>Gets an object that represents a description of survey.</summary>
        public string Description { get; }

        /// <summary>Gets an object that represents a collection of questions.</summary>
        public IQuestionEntity[] Questions { get; }
    }
}
