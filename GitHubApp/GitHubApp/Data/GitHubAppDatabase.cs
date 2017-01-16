using GitHubApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubApp.Data
{
    public class GitHubAppDatabase
    {
        readonly SQLiteConnection database;

        public GitHubAppDatabase(string dbPath)
        {
            database = new SQLiteConnection(dbPath);
            database.CreateTable<Repository>();
            database.CreateTable<User>();
        }

        public List<Repository> GetRepositories()
        {
            return database.Table<Repository>().ToList();
        }

        public int SaveRepository(Repository favoriteRepo)
        {
            if(favoriteRepo != null)
            {
                var repoUpdate = database.Table<Repository>().Where(i => i.id == favoriteRepo.id).FirstOrDefault();

                if (repoUpdate != null)
                    return database.Update(favoriteRepo);
                else
                    return database.Insert(favoriteRepo);
            }

            return 0;
        }

        public List<User> GetUsers()
        {
            return database.Table<User>().ToList();
        }

        public int SaveUser(User favoriteUser)
        {
            if(favoriteUser != null)
            {
                var userUpdate = database.Table<User>().Where(i => i.login == favoriteUser.login).FirstOrDefault();
                if (userUpdate != null)
                    return database.Update(favoriteUser);
                else
                    return database.Insert(favoriteUser);
            }

            return 0;
        }
    }
}
