using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Specifications
{
    public class BaseExpression<T>
    {
        public Expression<Func<T, object>> SpecExpression { get; set; }
        public string IncludeType { get; set; }
        public string SpecExpressionString { get; }

        public BaseExpression(Expression<Func<T, object>> specExpression, string includeType)
        {
            SpecExpression = specExpression;
            IncludeType = includeType;
        }

        public BaseExpression(string specExpressionString, string includeType)
        {
            SpecExpressionString = specExpressionString;
            IncludeType = includeType;
        }
    }
}
