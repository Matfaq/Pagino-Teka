using Microsoft.Data.Sqlite;
using Pagino_Teka.Models;
using Pagino_Teka.Services;
using System;
using System.Data;

namespace Pagino_Teka.Database
{
    public class AuthorRepository
    {
        private readonly DatabaseService _databaseService;

        public AuthorRepository(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public Author? GetAuthorByName(string name)
        {
            DataTable table = _databaseService.ExecuteQuery(
                "SELECT id, name FROM Authors WHERE name = @name LIMIT 1;",
                new SqliteParameter("@name", name)
            );

            if (table.Rows.Count == 0) return null;

            var row = table.Rows[0];
            return new Author
            {
                Id = Convert.ToInt32(row["id"]),
                Name = row["name"].ToString() ?? string.Empty
            };
        }

        public int AddAuthorIfNotExists(string name)
        {
            var existing = GetAuthorByName(name);
            if (existing != null) return existing.Id;

            _databaseService.ExecuteNonQuery(
                "INSERT INTO Authors (name) VALUES (@name);",
                new SqliteParameter("@name", name)
            );

            object idObj = _databaseService.ExecuteScalar("SELECT last_insert_rowid();");
            return Convert.ToInt32(idObj);
        }
    }
}
