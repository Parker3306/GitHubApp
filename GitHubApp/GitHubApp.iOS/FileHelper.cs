using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Text;
using System.IO;
using GitHubApp.iOS;
using GitHubApp.Services;

[assembly: Dependency(typeof(FileHelper))]
namespace GitHubApp.iOS
{
    class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
                Directory.CreateDirectory(libFolder);

            return Path.Combine(libFolder, filename);
        }
    }
}
