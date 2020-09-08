using Core.Entities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Core.Specifications
{
    public class ProjectListSpecification : BaseSpecifications<Project>
    {
        private static readonly BaseExpression<Project> includeFeatures = new BaseExpression<Project>(x => x.Features, "Include");
        public ProjectListSpecification(string sort, string search)
            : base(x => (string.IsNullOrEmpty(search) || x.Name.ToLower().Contains(search)))
        {
            AddInclude(includeFeatures);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "nameAsc":
                        AddOrderBy(p => p.Name);
                        break;
                    case "nameDesc":
                        AddOrderByDesc(p => p.Name);
                        break;
                    case "tigaIdAsc":
                        AddOrderBy(p => p.TigaId);
                        break;
                    case "tigaIdDesc":
                        AddOrderByDesc(p => p.TigaId);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }
        }
    }
}
