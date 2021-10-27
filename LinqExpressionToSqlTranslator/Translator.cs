using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace LinqExpressionToSqlTranslator
{
    public class Translator : ExpressionVisitor
    {
        StringBuilder Builder;
        object ExpressionContainer;

        public string Translate(object expressionContainer, Expression expression)
        {
            Builder = new StringBuilder();
            ExpressionContainer = expressionContainer;

            Visit(expression);

            return Builder.ToString();
        }

        protected override Expression VisitBinary(BinaryExpression b)
        {
            Builder.Append("(");
            Visit(b.Left);
            switch (b.NodeType)
            {                
                case ExpressionType.Equal:
                    Builder.Append(" = ");
                    break;
                default:
                    throw new NotSupportedException(string.Format("The binary operator '{0}' is not supported", b.NodeType));
            }
            Builder.Append(b.Right);
            Builder.Append(")");
            return b;
        }

        protected override Expression VisitConstant(ConstantExpression c)
        {
            switch (Type.GetTypeCode(c.Value.GetType()))
            {                
                case TypeCode.DateTime:
                    Builder.Append("'");
                    Builder.Append(((DateTime)c.Value).ToString("o"));
                    Builder.Append("'");
                    break;
                default:
                    throw new NotSupportedException(String.Format("The binary operator '{0}' is not supported", c.NodeType));
            }
            return c;
        }

        bool IsParameterMember(MemberExpression m)
        {
            bool result;
            if (m.Expression is not null &&
                m.Expression.NodeType == ExpressionType.Parameter)
            {
                Builder.Append(m.Member.Name);
                result = true;
            }
            else result = false;
            return result;
        }
        bool IsExpressionContainerFieldMember(MemberExpression m)
        {
            bool result;
            FieldInfo field = ExpressionContainer.GetType().GetField(m.Member.Name,
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (field is not null)
            {
                var fielValue = field.GetValue(ExpressionContainer);
                ConstantExpression c = Expression.Constant(fielValue);
                Visit(c);
                result = true;
            }
            else result= false;
            return result;
        }

        bool IsDatePropertyMember(MemberExpression m)
        {
            bool result;            
            if (m.Member.DeclaringType == typeof(DateTime) && (m.Member.Name == "Date"))
            {
                Builder.Append("Convert(date,");
                Visit(m.Expression);
                Builder.Append(")");
                result = true;
            }
            else result = false;
            return result;
        }

        protected override MemberExpression VisitMember(MemberExpression m)
        {
            if (!IsParameterMember(m) && !IsExpressionContainerFieldMember(m) && !IsDatePropertyMember(m))
            {
                throw new NotSupportedException();
            }
            return m;
        }
    }
}
