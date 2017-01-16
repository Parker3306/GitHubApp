using System;
using GitHubApp.Droid;
using Xamarin.Forms;
using System.IO;
using GitHubApp.Services;

[assembly: Dependency(typeof(FileHelper))]
namespace GitHubApp.Droid
{
    class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}