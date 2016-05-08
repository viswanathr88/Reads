using Epiphany.ViewModel.Services;
using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using Windows.ApplicationModel.Resources;
using System.Collections.Generic;

namespace Epiphany.View
{
    public class WindowsRuntimeResourceManager : ResourceManager, IResourceLoader
    {
        private readonly ResourceLoader resourceLoader;
        private static WindowsRuntimeResourceManager instance;

        protected WindowsRuntimeResourceManager(string baseName, Assembly assembly) : base(baseName, assembly)
        {
            this.resourceLoader = ResourceLoader.GetForViewIndependentUse(baseName);
        }

        public static void InjectIntoResxGeneratedApplicationResourcesClass(Type resxGeneratedApplicationResourcesClass)
        {
            resxGeneratedApplicationResourcesClass.GetRuntimeFields()
              .First(m => m.Name == "resourceMan")
              .SetValue(null, instance = new WindowsRuntimeResourceManager(resxGeneratedApplicationResourcesClass.FullName, resxGeneratedApplicationResourcesClass.GetTypeInfo().Assembly));
        }

        public static WindowsRuntimeResourceManager Instance
        {
            get
            {
                return instance;
            }
        }

        public IEnumerable<string> GetLocaleGroupHeaders()
        {
            throw new NotImplementedException();
        }

        public int GetLocaleGroupIndex(string item)
        {
            throw new NotImplementedException();
        }

        public override string GetString(string name, CultureInfo culture)
        {
            return this.resourceLoader.GetString(name);
        }

    }
}
