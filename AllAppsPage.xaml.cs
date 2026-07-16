using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Data.Json;
using Windows.UI.Popups;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Windows.ApplicationModel.Search;

namespace XenonStore
{
    public sealed partial class AllAppsPage : Page
    {
        private List<StoreApplication> _allApps = new List<StoreApplication>();
        public ObservableCollection<StoreApplication> Apps { get; set; }

        private bool _isDataLoaded = false;
        private TypedEventHandler<SearchPane, SearchPaneQueryChangedEventArgs> _queryChangedHandler;

        public AllAppsPage()
        {
            this.InitializeComponent();
            Apps = new ObservableCollection<StoreApplication>();
            this.DataContext = this;

            MainGrid.ItemsSource = Apps;

            this.Loaded += AllAppsPage_Loaded;
        }

        private void Button_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void AllAppsPage_Loaded(object sender, RoutedEventArgs e)
        {
            TypeBox.SelectedIndex = 0;
            CategoryBox.ItemsSource = allCategories;
            CategoryBox.SelectedIndex = 0;
        }

        public async Task LoadApps()
        {
            try
            {
                var client = new HttpClient();
                string json = await client.GetStringAsync(new Uri("http://xenonstore.dankassassin368.com/data/apps.json"));
                var array = JsonArray.Parse(json);

                _allApps.Clear();

                foreach (var item in array)
                {
                    JsonObject o = item.GetObject();
                    _allApps.Add(new StoreApplication
                    {
                        Id = o.GetNamedNumber("id"),
                        Name = o.GetNamedString("name"),
                        Publisher = o.GetNamedString("publisher"),
                        Version = o.GetNamedString("version"),
                        Description = o.GetNamedString("description"),
                        DownloadUrl = o.GetNamedString("downloadurl"),
                        IconUrl = o.GetNamedString("iconurl"),
                        Type = o.GetNamedString("type"),
                        Category = o.GetNamedString("category"),
                        Platform = o.GetNamedString("platform")
                    });
                }
                _isDataLoaded = true;
            }
            catch (Exception ex)
            {
                ShowMessage("Error loading apps: " + ex.Message);
            }
        }

        private async void ShowMessage(string msg)
        {
            var dlg = new MessageDialog(msg);
            await dlg.ShowAsync();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var searchPane = SearchPane.GetForCurrentView();
            _queryChangedHandler = new TypedEventHandler<SearchPane, SearchPaneQueryChangedEventArgs>(searchPane_queryChanged);
            searchPane.QueryChanged += _queryChangedHandler;

            await LoadApps();

            string navParams = e.Parameter as string;

            if (!string.IsNullOrEmpty(navParams) && navParams.Contains("|"))
            {
                string[] parts = navParams.Split('|');
                string targetType = parts[0];
                string targetCategory = parts[1];

                foreach (ComboBoxItem item in TypeBox.Items)
                {
                    if (item.Content.ToString() == targetType)
                    {
                        TypeBox.SelectedItem = item;
                        break;
                    }
                }

                CategoryBox.SelectedItem = targetCategory;
            }

            ApplyFilters();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            var searchPane = SearchPane.GetForCurrentView();
            searchPane.QueryChanged -= _queryChangedHandler;
        }

        private void searchPane_queryChanged(SearchPane sender, SearchPaneQueryChangedEventArgs args)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            if (!_isDataLoaded || TypeBox == null || CategoryBox == null) return;

            var searchPane = SearchPane.GetForCurrentView();
            string search = searchPane.QueryText.ToLower();

            ComboBoxItem typeItem = TypeBox.SelectedItem as ComboBoxItem;
            string selectedType = (typeItem != null) ? typeItem.Content.ToString() : "All types";

            string selectedCategory = (CategoryBox.SelectedItem != null) ? CategoryBox.SelectedItem.ToString() : "All categories";

            var filtered = _allApps.Where(app =>
            {
                bool matchesSearch = string.IsNullOrEmpty(search) ||
                                     (app.Name != null && app.Name.ToLower().Contains(search));

                bool matchesType = (selectedType == "All types") ||
                                   (string.Equals(app.Type, selectedType, StringComparison.OrdinalIgnoreCase));

                bool matchesCategory = (selectedCategory == "All categories") ||
                                       (string.Equals(app.Category, selectedCategory, StringComparison.OrdinalIgnoreCase));

                return matchesSearch && matchesType && matchesCategory;
            }).ToList();

            Apps.Clear();
            foreach (var app in filtered)
            {
                Apps.Add(app);
            }

            UpdateUIState(search);
        }

        private void UpdateUIState(string search)
        {
            Label.Text = string.IsNullOrEmpty(search) ? "All Apps" : string.Format("Results for \"{0}\"", search);

            string countText = Apps.Count.ToString();
            if (Apps.Count == 1) AppsCountLabel.Text = countText + " app";
            else if (Apps.Count == 0) AppsCountLabel.Text = "No apps";
            else AppsCountLabel.Text = countText + " apps";
        }

        private void TypeBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (CategoryBox == null) return;

            ComboBoxItem selected = TypeBox.SelectedItem as ComboBoxItem;
            if (selected == null) return;

            string selection = selected.Content.ToString();

            if (selection == "All types") CategoryBox.ItemsSource = allCategories;
            else if (selection == "App") CategoryBox.ItemsSource = appCategories;
            else if (selection == "Game") CategoryBox.ItemsSource = gamesCategories;

            if (CategoryBox.Items.Count > 0)
            {
                CategoryBox.SelectedIndex = 0;
            }

            ApplyFilters();
        }

        private void CategoryBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void Grid_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            var grid = sender as Grid;
            if (grid != null)
            {
                var selectedApp = grid.DataContext as StoreApplication;
                if (selectedApp != null)
                {
                    Frame.Navigate(typeof(AppDetails), selectedApp);
                }
            }
        }

        private List<string> allCategories = new List<string> { "All categories", "Books + Reference", "Dependency", "Education", "Finance", "Food + Cooking", "Government", "Health + Fitness", "Music + Audio", "News + Weather", "Other", "Photo + Design", "Security", "Shopping", "Social", "Sports", "Travel + Navigation", "Utilities", "Video + Entertainment", "Action", "Adventure", "Arcade", "Card + Casino", "Classics", "Family + Kids", "Games", "Music + Rhythm", "Puzzle", "Racing + Flying", "Strategy", "Simulation" };
        private List<string> appCategories = new List<string> { "All categories", "Books + Reference", "Dependency", "Education", "Finance", "Food + Cooking", "Government", "Health + Fitness", "Music + Audio", "News + Weather", "Other", "Photo + Design", "Security", "Shopping", "Social", "Sports", "Travel + Navigation", "Utilities", "Video + Entertainment" };
        private List<string> gamesCategories = new List<string> { "All categories", "Action", "Adventure", "Arcade", "Card + Casino", "Classics", "Family + Kids", "Games", "Music + Rhythm", "Puzzle", "Racing + Flying", "Strategy", "Simulation" };

        private void CategoryBox_Loaded_1(object sender, RoutedEventArgs e) { }
        private void TypeBox_Loaded_1(object sender, RoutedEventArgs e) { }
    }

    public class StoreApplication
    {
        public double Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public string DownloadUrl { get; set; }
        public string IconUrl { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public string Platform { get; set; }
    }
}