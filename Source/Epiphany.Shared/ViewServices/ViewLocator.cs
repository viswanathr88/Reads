using Epiphany.View.Attributes;
using Epiphany.View.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Epiphany.View
{
    class ViewLocator : IViewLocator
    {
        private readonly IDictionary<Type, Type> viewModelToViewMap;

        public ViewLocator()
        {
            this.viewModelToViewMap = new Dictionary<Type, Type>();
        }

        public async Task LoadViewsAsync()
        {
            IList<Type> types = await GetAllViews();
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
            string assemblyName = GetAssemblyName(viewType.GetTypeInfo().Assembly);
            string key = viewType.FullName.Replace(assemblyName, "").Replace(".", "/") + ".xaml";

            if (!GetAssemblyName(Application.Current.GetType().GetTypeInfo().Assembly).Equals(assemblyName))
            {
                return "/" + assemblyName + ";component" + key;
            }

            return key;
        }

        private string GetAssemblyName(Assembly assembly)
        {
            return assembly.FullName.Remove(assembly.FullName.IndexOf(","));
        }

        private async Task<IList<Type>> GetAllViews()
        {
            List<Type> viewTypes = new List<Type>();
            foreach (Assembly assembly in await GetAssemblyListAsync())
            {
                viewTypes.AddRange(
                    (from t in assembly.DefinedTypes
                     where t.IsSubclassOf(typeof(Page))
                     select t.AsType()).ToList());
            }

            return viewTypes;
        }

        private Type GetViewModelType(Type type)
        {
            Type viewModelType = default(Type);
            IEnumerable<Attribute> attributes = type.GetTypeInfo().GetCustomAttributes(typeof(SourceModel), false);
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

        private async Task<IEnumerable<Assembly>> GetAssemblyListAsync()
        {
            var folder = Windows.ApplicationModel.Package.Current.InstalledLocation;

            List<Assembly> assemblies = new List<Assembly>();
            foreach (Windows.Storage.StorageFile file in await folder.GetFilesAsync())
            {
                if (file.FileType == ".dll" || file.FileType == ".exe")
                {
                    AssemblyName name = new AssemblyName() { Name = Path.GetFileNameWithoutExtension(file.Name) };
                    Assembly asm = Assembly.Load(name);
                    assemblies.Add(asm);
                }
            }

            return assemblies;
        }
    }
}
