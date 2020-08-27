using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(
            IQueryable<TEntity> inputQuery,
            ISpecification<TEntity> spec
            )
        {
            var query = inputQuery;

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            foreach (BaseExpression<TEntity> include in spec.Includes)
            {
                if (include.IncludeType == "Include")
                {
                    query = query.Include(include.SpecExpression);
                } 
                else if (include.IncludeType == "IncludeString")
                {
                    query = query.Include(include.SpecExpressionString);
                }
            }
            
            return query;
        }
    }
}
