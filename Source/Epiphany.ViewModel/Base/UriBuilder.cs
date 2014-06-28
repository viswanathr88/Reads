using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Epiphany.ViewModel.Services
{
    public class UriBuilder<TViewModel> where TViewModel : ViewModelBase
    {
        private readonly IDictionary<string, string> parameters = new Dictionary<string, string>();

        public UriBuilder<TViewModel> AddParam<TValue>(Expression<Func<TValue>> expr, TValue value)
        {
            if (value is ValueType || !ReferenceEquals(null, value))
            {
                parameters[GetProperty(expr).Name] = value.ToString();
            }

            return this;
        }

        private PropertyInfo GetProperty<T>(Expression<Func<T>> expr)
        {
            var member = expr.Body as MemberExpression;
            if (member == null)
                throw new InvalidOperationException("Expression is not a member access expression.");
            var property = member.Member as PropertyInfo;
            if (property == null)
                throw new InvalidOperationException("Member in expression is not a property.");
            return property;
        }
    }
}
