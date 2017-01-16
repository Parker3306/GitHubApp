using GitHubApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace GitHubApp.Views
{
    public partial class MenuPage : ContentPage
    {
        public ListView ListView { get { return menuListView; } }

        public MenuPage()
        {
            InitializeComponent();

            var menuPageItems = new List<MasterPageItem>();

            menuPageItems.Add(new MasterPageItem
            {
                Title = "User Search",
                IconSource = "contacts.png",
                TargetType = typeof(UserSearchPage)
            });
            menuPageItems.Add(new MasterPageItem {
                Title = "Favorites",
                IconSource = "favorites.png",
                TargetType = typeof(FavoritesPage)
            });

            menuListView.ItemsSource = menuPageItems;
        }
    }
}
