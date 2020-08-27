using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Specifications
{
    public class BaseSpecifications<T> : ISpecification<T>
    {
        public BaseSpecifications()
        {
        }

        public BaseSpecifications(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public List<BaseExpression<T>> Includes { get; } = new List<BaseExpression<T>>();

        protected void AddInclude(BaseExpression<T> includeExpression)
        {
            Includes.Add(includeExpression);
        }

    }
}
