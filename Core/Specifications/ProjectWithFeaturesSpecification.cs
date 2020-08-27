using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Specifications
{
    public class ProjectFullDataSpecification : BaseSpecifications<Project>
    {
        private static readonly BaseExpression<Project> includeFeatures = new BaseExpression<Project>(x => x.Features, "Include");
        private static readonly BaseExpression<Project> includeUserStories = new BaseExpression<Project>($"{nameof(Project.Features)}.{nameof(Feature.UserStories)}", "IncludeString");
        private static readonly BaseExpression<Project> includeResourceType = new BaseExpression<Project>($"{nameof(Project.Features)}.{nameof(Feature.UserStories)}.{nameof(UserStory.ResourceType)}", "IncludeString");
        public ProjectFullDataSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(includeFeatures);
            AddInclude(includeUserStories);
            AddInclude(includeResourceType);
        }
    }
}
