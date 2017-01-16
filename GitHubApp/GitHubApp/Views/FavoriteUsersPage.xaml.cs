using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace GitHubApp.Views
{
    public partial class FavoriteUsersPage : ContentPage
    {
        public FavoriteUsersPage()
        {
            InitializeComponent();
            favoriteUsersListView.ItemsSource = App.Database.GetUsers();
        }
    }
}
