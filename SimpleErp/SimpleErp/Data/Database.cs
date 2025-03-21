using SQLite;
using System.Diagnostics;

namespace SimpleErp.Data
{
    public class Database
    {
        private SQLiteAsyncConnection _sqlConnection;

        public static string DatabaseFilename = "DB.db3";

        public static  string DatabasePath =>
        Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

        public const SQLite.SQLiteOpenFlags Flags =
        // open the database in read/write mode
        SQLite.SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLite.SQLiteOpenFlags.Create |
        // enable multi-threaded database access
        SQLite.SQLiteOpenFlags.SharedCache;

        public async Task OpenDatabaseAsync()
        {
            _sqlConnection = new SQLiteAsyncConnection(DatabasePath);
            await _sqlConnection.CreateTableAsync<Person>();

            Debug.WriteLine($"{Database.DatabasePath}");
        }

        public async Task InsertAsync(Person person)
        {
            await _sqlConnection.InsertAsync(person);
        }

        public async Task UpdateAsync(Person person)
        {
            await _sqlConnection.UpdateAsync(person);
        }

        public async Task<List<Person>> SelectAsync()
        {
            // SELECT * FROM Person
            return await _sqlConnection.Table<Person>().ToListAsync();
        }

        public async Task<List<Person>> SelectWithEmail(string email)
        {
            return await _sqlConnection.Table<Person>()
                .Where(s => s.Email == email)
                .ToListAsync();
        }

        public async Task<Person> CheckPassword(string email, string password)
        {
            List<Person> list = await SelectWithEmail(email);

            if (list.Any())
            {
                var person = list.First();
                if(person.Password == password)
                {
                    return person;
                }

            }

            return null;
        }


    }
}
