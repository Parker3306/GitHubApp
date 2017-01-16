using GitHubApp.Data;
using GitHubApp.Services;
using GitHubApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace GitHubApp
{
    public class App : Application
    {

        static GitHubAppDatabase database;

        public App()
        {
            // The root page of your application
            MainPage = new MasterPage();
        }

        public static GitHubAppDatabase Database
        {
            get {
                if (database == null)
                    database = new GitHubAppDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("GitHubAppDB.db3"));
                return database;
                        }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
