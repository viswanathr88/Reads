using Epiphany.View.Attributes;
using Microsoft.Phone.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace Epiphany.View.Services
{
    class ViewLocator : IViewLocator
    {
        private readonly IDictionary<Type, Type> viewModelToViewMap;
        private readonly string prefixPath = "View";
        public ViewLocator()
        {
            this.viewModelToViewMap = new Dictionary<Type, Type>();
            IList<Type> types = GetAllViews();
            foreach (Type type in types)
            {
                Type viewModelType = GetViewModelType(type);
                if (viewModelType != default(Type))
                    viewModelToViewMap[viewModelType] = type;
            }
        }

        public Type GetViewType<TViewModel>()
        {
            Type viewType = default(Type);
            if (viewModelToViewMap.ContainsKey(typeof(TViewModel)))
                viewType = viewModelToViewMap[typeof(TViewModel)];
            return viewType;
        }

        public string GetViewKey<TViewModel>()
        {
            Type viewType = GetViewType<TViewModel>();
            return GetViewKey(viewType);
        }

        public string GetViewKey(Type viewType)
        {
            string assemblyName = GetAssemblyName(viewType.Assembly);
            string pageName = viewType.FullName.Split('.').Last();
            string key = @"/" + prefixPath + "/" + pageName + ".xaml";
            //string key = viewType.FullName.Replace(assemblyName, "").Replace(".", "/") + ".xaml";

            if (!GetAssemblyName(Application.Current.GetType().Assembly).Equals(assemblyName))
            {
                return "/" + assemblyName + ";component" + key;
            }

            return key;
        }

        private string GetAssemblyName(Assembly assembly)
        {
            return assembly.FullName.Remove(assembly.FullName.IndexOf(","));
        }

        private IList<Type> GetAllViews()
        {
            List<Type> viewTypes = new List<Type>();
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                viewTypes.AddRange(
                    (from t in assembly.GetTypes()
                     where t.IsSubclassOf(typeof(PhoneApplicationPage))
                     select t).ToList());
            }

            return viewTypes;
        }

        private Type GetViewModelType(Type type)
        {
            Type viewModelType = default(Type);
            object[] attributes = type.GetCustomAttributes(typeof(SourceModel), false);
            if (attributes.Count() <= 0)
            {
                return viewModelType;
            }
            else
            {
                SourceModel viewModelAttribute = (SourceModel)attributes.First();
                if (viewModelAttribute != null)
                {
                    viewModelType = viewModelAttribute.Type;
                }
            }
            return viewModelType;
        }
    }
}
