using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Entities.Specifications
{
    public abstract class Specification<T>
    {
        public abstract Expression<Func<T, bool>> ConditionExpresion { get; }
        public bool IsSatisfied(T entity) 
        {
            Func<T, bool> ExpressionDelegate = ConditionExpresion.Compile();
            return ExpressionDelegate(entity);
        }
    }
}
