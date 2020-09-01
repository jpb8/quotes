using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Core.Specifications
{
    public class FeaturesWithResourceTypeAndProjecSpecification : BaseSpecifications<Feature>
    {
        private static readonly BaseExpression<Feature> includeProj = new BaseExpression<Feature>(x => x.Project, "Include");
        private static readonly BaseExpression<Feature> includeUserStories = new BaseExpression<Feature>(x => x.UserStories, "Include");
        public FeaturesWithResourceTypeAndProjecSpecification(string sort, int? projectId, string search)
            : base(x =>
                (string.IsNullOrEmpty(search) || x.Description.ToLower().Contains(search)) &&
                (!projectId.HasValue || x.ProjectId == projectId)
            )
        {
            AddInclude(includeProj);
            AddInclude(includeUserStories);
            AddOrderBy(x => x.Description);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "descAsc": 
                        AddOrderBy(p => p.Description); 
                        break;
                    case "descDesc":
                        AddOrderByDesc(p => p.Description);
                        break;
                    case "milestoneAsc":
                        AddOrderBy(p => p.MileStone);
                        break;
                    case "milestoneDesc":
                        AddOrderByDesc(p => p.MileStone);
                        break;
                    default:
                        AddOrderBy(p => p.Description);
                        break;
                }
            }
        }

        public FeaturesWithResourceTypeAndProjecSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(includeProj);
            AddInclude(includeUserStories);
        }
    }
}
