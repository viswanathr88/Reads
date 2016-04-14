﻿

//------------------------------------------------------------------------------ 
// <auto-generated> 
// This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if 
// the code is regenerated. 
// </auto-generated> 
//------------------------------------------------------------------------------

using System;

namespace Epiphany.Model.Settings
{
	/// <summary>
    /// EventArgs for the SettingChanged event
    /// </summary>
	public class SettingChangedEventArgs : EventArgs
	{
		private string settingName;

		public SettingChangedEventArgs(string settingName)
		{
			this.settingName = settingName;	
		}
		/// <summary>
		/// Gets the name of the setting that changed
		/// </summary>
		public string SettingName
		{
			get 
			{
				return this.settingName;
			}
		}
	}
	
	/// <summary>
    /// Represents a strongly-typed settings class
    /// </summary>
	public class ApplicationSettings
	{
		private static ApplicationSettings _instance;
		private static object syncRoot = new object();
		private Model.Settings.ISettingStorage storage = new DefaultSettingsStorage();
		private bool EnableLoggingDefault = true;
		private Epiphany.Model.Services.FeedUpdateType UpdateTypeDefault = Epiphany.Model.Services.FeedUpdateType.all;
		private Epiphany.Model.Services.FeedUpdateFilter UpdateFilterDefault = Epiphany.Model.Services.FeedUpdateFilter.friends;
		private Epiphany.Model.Services.BookSortType SortTypeDefault = Epiphany.Model.Services.BookSortType.date_added;
		private Epiphany.Model.Services.BookSortOrder SortOrderDefault = Epiphany.Model.Services.BookSortOrder.a;
		private Epiphany.Model.Services.BookSearchType SearchTypeDefault = Epiphany.Model.Services.BookSearchType.All;
		private bool ShowAnimationsDefault = true;
		private bool EncryptAuthTokenDefault = false;
		private bool EnableTransparentTileDefault = true;
		private bool UseMyLocationDefault = false;
		private string AccessTokenDefault = string.Empty;
		private string AccessTokenSecretDefault = string.Empty;
		private int CurrentUserIdDefault = -1;
		private string CurrentUsernameDefault = string.Empty;
		public event EventHandler<SettingChangedEventArgs> SettingChanged;
		
		/// <summary>
		/// Gets the settings instance
		/// </summary>
		public static ApplicationSettings Instance
		{
			get 
			{
				if (_instance == null)
				{
					lock(syncRoot)
					{
						if (_instance == null)
							_instance = new ApplicationSettings();

					}
				}

				return _instance;
			}
		}
		/// <summary>
		/// Raise the setting changed event
		/// </summary>
		public void RaiseSettingChanged(string name) => SettingChanged?.Invoke(this, new SettingChangedEventArgs(name));
		/// <summary>
		/// Set the backing store for the settings
		/// </summary>
		public void SetBackingStore(Model.Settings.ISettingStorage store)
		{
			if (store == null)
			{
				throw new ArgumentNullException(nameof(store));
			}

			storage = store;
		}

		/// <summary>
		/// Gets or sets the EnableLogging setting
		/// </summary>
		public bool EnableLogging
		{
			get 
			{ 
				return storage.GetValueOrDefault<bool>(@"EnableLogging", EnableLoggingDefault);
			}
			set 
			{
				if (storage.AddOrUpdate(@"EnableLogging", value))
				{
					RaiseSettingChanged(@"EnableLogging");
				}
			}
		}		
		/// <summary>
		/// Gets or sets the UpdateType setting
		/// </summary>
		public Epiphany.Model.Services.FeedUpdateType UpdateType
		{
			get 
			{ 
				return storage.GetValueOrDefault<Epiphany.Model.Services.FeedUpdateType>(@"UpdateType", UpdateTypeDefault);
			}
			set 
			{
				if (storage.AddOrUpdate(@"UpdateType", value))
				{
					RaiseSettingChanged(@"UpdateType");
				}
			}
		}		
		/// <summary>
		/// Gets or sets the UpdateFilter setting
		/// </summary>
		public Epiphany.Model.Services.FeedUpdateFilter UpdateFilter
		{
			get 
			{ 
				return storage.GetValueOrDefault<Epiphany.Model.Services.FeedUpdateFilter>(@"UpdateFilter", UpdateFilterDefault);
			}
			set 
			{
				if (storage.AddOrUpdate(@"UpdateFilter", value))
				{
					RaiseSettingChanged(@"UpdateFilter");
				}
			}
		}		
		/// <summary>
		/// Gets or sets the SortType setting
		/// </summary>
		public Epiphany.Model.Services.BookSortType SortType
		{
			get 
			{ 
				return storage.GetValueOrDefault<Epiphany.Model.Services.BookSortType>(@"SortType", SortTypeDefault);
			}
			set 
			{
				if (storage.AddOrUpdate(@"SortType", value))
				{
					RaiseSettingChanged(@"SortType");
				}
			}
		}		
		/// <summary>
		/// Gets or sets the SortOrder setting
		/// </summary>
		public Epiphany.Model.Services.BookSortOrder SortOrder
		{
			get 
			{ 
				return storage.GetValueOrDefault<Epiphany.Model.Services.BookSortOrder>(@"SortOrder", SortOrderDefault);
			}
			set 
			{
				if (storage.AddOrUpdate(@"SortOrder", value))
				{
					RaiseSettingChanged(@"SortOrder");
				}
			}
		}		
		/// <summary>
		/// Gets or sets the SearchType setting
		/// </summary>
		public Epiphany.Model.Services.BookSearchType SearchType
		{
			get 
			{ 
				return storage.GetValueOrDefault<Epiphany.Model.Services.BookSearchType>(@"SearchType", SearchTypeDefault);
			}
			set 
			{
				if (storage.AddOrUpdate(@"SearchType", value))
				{
					RaiseSettingChanged(@"SearchType");
				}
			}
		}		
		/// <summary>
		/// Gets or sets the ShowAnimations setting
		/// </summary>
		public bool ShowAnimations
		{
			get 
			{ 
				return storage.GetValueOrDefault<bool>(@"ShowAnimations", ShowAnimationsDefault);
			}
			set 
			{
				if (storage.AddOrUpdate(@"ShowAnimations", value))
				{
					RaiseSettingChanged(@"ShowAnimations");
				}
			}
		}		
		/// <summary>
		/// Gets or sets the EncryptAuthToken setting
		/// </summary>
		public bool EncryptAuthToken
		{
			get 
			{ 
				return storage.GetValueOrDefault<bool>(@"EncryptAuthToken", EncryptAuthTokenDefault);
			}
			set 
			{
				if (storage.AddOrUpdate(@"EncryptAuthToken", value))
				{
					RaiseSettingChanged(@"EncryptAuthToken");
				}
			}
		}		
		/// <summary>
		/// Gets or sets the EnableTransparentTile setting
		/// </summary>
		public bool EnableTransparentTile
		{
			get 
			{ 
				return storage.GetValueOrDefault<bool>(@"EnableTransparentTile", EnableTransparentTileDefault);
			}
			set 
			{
				if (storage.AddOrUpdate(@"EnableTransparentTile", value))
				{
					RaiseSettingChanged(@"EnableTransparentTile");
				}
			}
		}		
		/// <summary>
		/// Gets or sets the UseMyLocation setting
		/// </summary>
		public bool UseMyLocation
		{
			get 
			{ 
				return storage.GetValueOrDefault<bool>(@"UseMyLocation", UseMyLocationDefault);
			}
			set 
			{
				if (storage.AddOrUpdate(@"UseMyLocation", value))
				{
					RaiseSettingChanged(@"UseMyLocation");
				}
			}
		}		
		/// <summary>
		/// Gets or sets the AccessToken setting
		/// </summary>
		public string AccessToken
		{
			get 
			{ 
				return storage.GetValueOrDefault<string>(@"AccessToken", AccessTokenDefault);
			}
			set 
			{
				if (storage.AddOrUpdate(@"AccessToken", value))
				{
					RaiseSettingChanged(@"AccessToken");
				}
			}
		}		
		/// <summary>
		/// Gets or sets the AccessTokenSecret setting
		/// </summary>
		public string AccessTokenSecret
		{
			get 
			{ 
				return storage.GetValueOrDefault<string>(@"AccessTokenSecret", AccessTokenSecretDefault);
			}
			set 
			{
				if (storage.AddOrUpdate(@"AccessTokenSecret", value))
				{
					RaiseSettingChanged(@"AccessTokenSecret");
				}
			}
		}		
		/// <summary>
		/// Gets or sets the CurrentUserId setting
		/// </summary>
		public int CurrentUserId
		{
			get 
			{ 
				return storage.GetValueOrDefault<int>(@"CurrentUserId", CurrentUserIdDefault);
			}
			set 
			{
				if (storage.AddOrUpdate(@"CurrentUserId", value))
				{
					RaiseSettingChanged(@"CurrentUserId");
				}
			}
		}		
		/// <summary>
		/// Gets or sets the CurrentUsername setting
		/// </summary>
		public string CurrentUsername
		{
			get 
			{ 
				return storage.GetValueOrDefault<string>(@"CurrentUsername", CurrentUsernameDefault);
			}
			set 
			{
				if (storage.AddOrUpdate(@"CurrentUsername", value))
				{
					RaiseSettingChanged(@"CurrentUsername");
				}
			}
		}		
	}
}

