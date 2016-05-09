using Epiphany.ViewModel.Services;
using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using Windows.ApplicationModel.Resources;
using System.Collections.Generic;
using Epiphany.Model.Services;
using Epiphany.Strings;

namespace Epiphany.View
{
    public class WindowsRuntimeResourceManager : ResourceManager, IResourceLoader
    {
        private readonly ResourceLoader resourceLoader;
        private static WindowsRuntimeResourceManager instance;

        private IDictionary<object, string> stringMapping = new Dictionary<object, string>();

        protected WindowsRuntimeResourceManager(string baseName, Assembly assembly) : base(baseName, assembly)
        {
            this.resourceLoader = ResourceLoader.GetForViewIndependentUse(baseName);
        }

        public static void InjectIntoResxGeneratedApplicationResourcesClass(Type resxGeneratedApplicationResourcesClass)
        {
            instance = new WindowsRuntimeResourceManager(resxGeneratedApplicationResourcesClass.FullName, resxGeneratedApplicationResourcesClass.GetTypeInfo().Assembly);

            resxGeneratedApplicationResourcesClass.GetRuntimeFields()
              .First(m => m.Name == "resourceMan")
              .SetValue(null, instance);

            instance.BuildStringMapping();
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

        public string GetString(object key)
        {
            string result = string.Empty;

            if (stringMapping.ContainsKey(key))
            {
                result = stringMapping[key];
            }

            return result;
        }

        private void BuildStringMapping()
        {
            stringMapping[FeedUpdateType.all] = AppStrings.FeedOptionsShowUpdatesForAllText;
            stringMapping[FeedUpdateType.books] = AppStrings.FeedOptionsShowUpdatesForBooksText;
            stringMapping[FeedUpdateType.reviews] = AppStrings.FeedOptionsShowUpdatesForReviewsText;
            stringMapping[FeedUpdateType.statuses] = AppStrings.FeedOptionsShowUpdatesForStatusesText;

            stringMapping[FeedUpdateFilter.following] = AppStrings.FeedOptionsShowUpdatesFromFollowersText;
            stringMapping[FeedUpdateFilter.friends] = AppStrings.FeedOptionsShowUpdatesFromFriendsText;
            stringMapping[FeedUpdateFilter.top_friends] = AppStrings.FeedOptionsShowUpdatesFromTopFriendsText;
        }
    }
}
