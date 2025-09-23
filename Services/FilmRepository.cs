using Microsoft.Data.Sqlite;

namespace Services
{
    public class FilmRepository
    {
        private readonly SqliteConnection _db;

        public FilmRepository(SqliteConnection db)
        {
            _db = db;
        }

        public bool IsTitleUnique(string title)
        {
            var result = _db.ExecuteScalar(
                "SELECT COUNT(*) FROM filmy WHERE title = @title",
                new SqliteParameter("@title", title)
            );
            return Convert.ToInt32(result) == 0;
        }
    }
}