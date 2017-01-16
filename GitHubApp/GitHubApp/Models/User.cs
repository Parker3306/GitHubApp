using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubApp.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public string login { get; set; }
    }
}
