using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitHubApp.Services;
using Xamarin.Forms;
using GitHubApp.Models;

namespace GitHubApp.Views
{
    public partial class UserSearchPage : ContentPage
    {

        public UserSearchPage()
        {

            InitializeComponent();
        }

        void getUserRepository( object sender, EventArgs args)
        {
            try
            {
                User fetchedUser = new User();
                repositoryListView.BeginRefresh();
                repositoryListView.ItemsSource = APICallHandler.GetUserRepositories(userSearch.Text).Result;
                var repositoryCount = (List<Repository>)repositoryListView.ItemsSource;
                if (repositoryCount.Count() > 0)
                {
                    fetchedUser.login = userSearch.Text;
                    saveUserButton.IsVisible = true;
                }
                else
                {
                    saveUserButton.IsVisible = false;
                    DisplayAlert("User Search", "No repositories found for this user", "OK");
                }


                repositoryListView.EndRefresh();
            }
            catch (Exception ex)
            {
                DisplayAlert("Whoops", "Something broke:" + ex.Message, "OK");
            }
            
        }

        void showDetails(object sender, ItemTappedEventArgs args)
        {
            Repository selectedRepository = (Repository)args.Item;
            selectedRepository.login = userSearch.Text;
            Navigation.PushAsync(new RepositoryDetailsPage(selectedRepository));
        }

        void OnUserClicked(object sender, EventArgs args)
        {
            User favoriteUser = new User();
            favoriteUser.login = userSearch.Text;
            App.Database.SaveUser(favoriteUser);
            DisplayAlert("Favorite User", "User has been added to favorites", "OK");
        }
    }
}
