using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace GitHubApp.Views
{
    public partial class FavoriteReposPage : ContentPage
    {
        public FavoriteReposPage()
        {
            InitializeComponent();
            favoriteReposListView.ItemsSource = App.Database.GetRepositories();
        }
    }
}
