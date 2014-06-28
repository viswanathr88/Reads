using Epiphany.Model.Services;
using Epiphany.Model.Settings;
using System;
using System.Collections.Generic;

namespace Epiphany.Model
{
    public class ModelSettings
    {
        private readonly ISettingStorage storage;

        //
        // Default values
        //
        private const FeedUpdateType updateTypeDefault = FeedUpdateType.all;
        private const FeedUpdateFilter updateFilterDefault = FeedUpdateFilter.friends;
        private const bool enableLoggingDefault = false;
        private const BookSortType sortTypeDefault = BookSortType.date_added;
        private const BookSortOrder sortOrderDefault = BookSortOrder.d;
        private const BookSearchType searchTypeDefault = BookSearchType.All;

        public ModelSettings(ISettingStorage storage)
        {
            if (storage == null)
            {
                throw new ArgumentNullException();
            }

            this.storage = storage;
        }

        public FeedUpdateType UpdateType
        {
            get
            {
                return storage.GetValueOrDefault<FeedUpdateType>(SettingKeys.UpdateTypeKey, updateTypeDefault);
            }
            set
            {
                storage.AddOrUpdate(SettingKeys.UpdateTypeKey, value);
            }
        }

        public FeedUpdateFilter UpdateFilter
        {
            get
            {
                return storage.GetValueOrDefault<FeedUpdateFilter>(SettingKeys.UpdateFilterKey, updateFilterDefault);
            }
            set
            {
                storage.AddOrUpdate(SettingKeys.UpdateFilterKey, value);
            }
        }

        public bool EnableLogging
        {
            get
            {
                return storage.GetValueOrDefault<bool>(SettingKeys.EnableLoggingKey, enableLoggingDefault);
            }
            set
            {
                storage.AddOrUpdate(SettingKeys.EnableLoggingKey, value);
            }
        }

        public BookSortType SortType
        {
            get
            {
                return storage.GetValueOrDefault<BookSortType>(SettingKeys.SortTypeKey, sortTypeDefault);
            }
            set
            {
                storage.AddOrUpdate(SettingKeys.SortTypeKey, value);
            }
        }

        public BookSortOrder SortOrder
        {
            get
            {
                return storage.GetValueOrDefault<BookSortOrder>(SettingKeys.SortOrderKey, sortOrderDefault);
            }
            set
            {
                storage.AddOrUpdate(SettingKeys.SortOrderKey, value);
            }
        }

        public BookSearchType SearchType
        {
            get
            {
                return storage.GetValueOrDefault<BookSearchType>(SettingKeys.SearchTypeKey, searchTypeDefault);
            }
            set
            {
                storage.AddOrUpdate(SettingKeys.SearchTypeKey, value);
            }
        }
    }
}
