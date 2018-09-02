
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleLoginMVVM.Models;
using SQLite;

namespace SimpleLoginMVVM
{

    public class UsersDatabase
    {
      // public string dbPath;
         SQLiteAsyncConnection database;
        public UsersDatabase(string dbPath)
        {
          // this.dbPath = dbPath;
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<UserAccounts>().Wait();
            
        }

        public Task<List<UserAccounts>> GetUsersAsync()
        {
            return database.Table<UserAccounts>().ToListAsync();
        }

        public Task<List<UserAccounts>> GetUsersNotDoneAsync()
        {
            return database.QueryAsync<UserAccounts>("SELECT * FROM [UserAccounts]");//WHERE [Done] = 0
        }

        public Task<UserAccounts> GetUserAsync(string username)
        {
            return database.Table<UserAccounts>().Where(i => i.Username == username).FirstOrDefaultAsync();
        }

        public Task<int> SaveUserAsync(UserAccounts User)
        {
            return database.InsertAsync(User);
        
        }

        public Task<int> DeleteUserAsync(Models.UserAccounts User)
        {
            return database.DeleteAsync(User);
        }
        public Task<UserAccounts> FindAsync(UserAccounts User)
        {


            return database.Table<UserAccounts>().Where(i => i.Username == User.Username && i.Password == User.Password).FirstOrDefaultAsync();
            //SELECT id FROM user WHERE name=? AND password=?
        }

        public Task<int> UpdateUserAsync(UserAccounts userAccounts)
        {    //if (database.Table<UserAccounts>().Where(i => i.Username == userAccounts.Username).FirstOrDefaultAsync() != null)
           
                return database.UpdateAsync(userAccounts);
            
          
        }
    }
}

