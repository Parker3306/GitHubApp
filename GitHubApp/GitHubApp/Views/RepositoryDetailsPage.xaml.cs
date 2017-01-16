using GitHubApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace GitHubApp.Views
{
    public partial class RepositoryDetailsPage : ContentPage
    {
        Repository currentRepository;
        public RepositoryDetailsPage(Repository selectedRepository)
        {
            InitializeComponent();
            repositoryTableView.BindingContext = selectedRepository;
        }

        void OnUserClicked(object sender, EventArgs args)
        {
            var favoritelogin = (Repository)repositoryTableView.BindingContext;
            User favoriteUser = new User();
            favoriteUser.login = favoritelogin.login;
            App.Database.SaveUser(favoriteUser);
            DisplayAlert("Favorite User", "User has been added to favorites", "OK");
        }

        void OnRepoClicked(object sender, EventArgs args)
        {
            var favoriteRepo = (Repository)repositoryTableView.BindingContext;
            App.Database.SaveRepository(favoriteRepo);
            DisplayAlert("Favorite Repository", "Repository has been added to favorites", "OK");
        }
    }
}
