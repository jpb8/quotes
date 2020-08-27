using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Specifications
{
    public class FeaturesWithResourceTypeAndProjecSpecification : BaseSpecifications<Feature>
    {
        private static readonly BaseExpression<Feature> includeProj = new BaseExpression<Feature>(x => x.Project, "Include");
        private static readonly BaseExpression<Feature> includeUserStories = new BaseExpression<Feature>(x => x.UserStories, "Include");
        public FeaturesWithResourceTypeAndProjecSpecification()
        {
            AddInclude(includeProj);
            AddInclude(includeUserStories);
        }

        public FeaturesWithResourceTypeAndProjecSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(includeProj);
            AddInclude(includeUserStories);
        }
    }
}
