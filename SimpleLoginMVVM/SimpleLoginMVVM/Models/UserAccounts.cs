using SQLite;

namespace SimpleLoginMVVM.Models
{
        public class UserAccounts
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}