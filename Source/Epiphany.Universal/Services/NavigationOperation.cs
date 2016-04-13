using Epiphany.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Epiphany.View.Services
{
    class NavigationOperation<TViewModel> : INavigationOperation<TViewModel>
    {
        private readonly IDictionary<string, string> parameters;
        private readonly INavigationService service;
        private readonly IViewLocator viewLocator;

        public NavigationOperation(INavigationService service, IViewLocator locator)
        {
            if (service == null || locator == null)
                throw new ArgumentNullException("service");
            
            this.service = service;
            this.viewLocator = locator;
            this.parameters = new Dictionary<string, string>();
        }

        public INavigationOperation<TViewModel> AddParam<TValue>(Expression<Func<TViewModel, TValue>> expr, TValue value)
        {
            if (value is ValueType || !ReferenceEquals(null, value))
            {
                parameters[GetProperty(expr).Name] = value.ToString();
            }

            return this;
        }

        public void Navigate()
        {
            string key = viewLocator.GetViewKey<TViewModel>();
            string queryString = BuildQueryString();
            string uri = key + queryString;
            this.service.Navigate(uri);
        }

        private PropertyInfo GetProperty<T>(Expression<Func<TViewModel, T>> expr)
        {
            var member = expr.Body as MemberExpression;
            if (member == null)
                throw new InvalidOperationException("Expression is not a member access expression.");
            var property = member.Member as PropertyInfo;
            if (property == null)
                throw new InvalidOperationException("Member in expression is not a property.");
            return property;
        }

        private string BuildQueryString()
        {
            if (parameters.Count < 1)
            {
                return string.Empty;
            }

            var result = parameters
                .Aggregate("?", (current, pair) => current + (pair.Key + "=" + Uri.EscapeDataString(pair.Value) + "&"));

            return result.Remove(result.Length - 1);
        }

    }
}
