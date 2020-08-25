using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Specifications
{
    public class FeaturesWithResourceTypeAndProjecSpecification : BaseSpecifications<Feature>
    {
        public FeaturesWithResourceTypeAndProjecSpecification()
        {
            AddInclude(x => x.ResourceType);
            AddInclude(x => x.Project);
        }

        public FeaturesWithResourceTypeAndProjecSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ResourceType);
            AddInclude(x => x.Project);
        }
    }
}
