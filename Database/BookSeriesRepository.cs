using Microsoft.Data.Sqlite;
using Pagino_Teka.Models;
using Pagino_Teka.Services;
using System;
using System.Collections.Generic;
using System.Data;

namespace Pagino_Teka.Repositories
{
    public class BookSeriesRepository
    {
        private readonly DatabaseService _db;

        public BookSeriesRepository(DatabaseService databaseService)
        {
            _db = databaseService ?? throw new ArgumentNullException(nameof(databaseService));
        }

        /// <summary>
        /// Pobiera wszystkie serie książek.
        /// </summary>
        public IEnumerable<BookSeries> GetAll()
        {
            var series = new List<BookSeries>();
            DataTable table = _db.ExecuteQuery("SELECT id, name FROM BookSeries ORDER BY name;");

            foreach (DataRow row in table.Rows)
            {
                series.Add(new BookSeries
                {
                    Id = Convert.ToInt32(row["id"]),
                    Name = row["name"].ToString() ?? string.Empty
                });
            }

            return series;
        }

        /// <summary>
        /// Pobiera serię po nazwie.
        /// </summary>
        public BookSeries? GetByName(string name)
        {
            DataTable table = _db.ExecuteQuery(
                "SELECT id, name FROM BookSeries WHERE name = @name LIMIT 1;",
                new SqliteParameter("@name", name)
            );

            if (table.Rows.Count == 0) return null;

            var row = table.Rows[0];
            return new BookSeries
            {
                Id = Convert.ToInt32(row["id"]),
                Name = row["name"].ToString() ?? string.Empty
            };
        }

        /// <summary>
        /// Dodaje serię, jeśli nie istnieje, i zwraca jej ID.
        /// </summary>
        public int AddIfNotExists(string name)
        {
            var existing = GetByName(name);
            if (existing != null) return existing.Id;

            _db.ExecuteNonQuery(
                "INSERT INTO BookSeries (name) VALUES (@name);",
                new SqliteParameter("@name", name)
            );

            object idObj = _db.ExecuteScalar("SELECT last_insert_rowid();");
            return Convert.ToInt32(idObj);
        }
    }
}
