using Microsoft.Data.Sqlite;
using Pagino_Teka.Models;
using Pagino_Teka.Services;
using System;
using System.Collections.Generic;
using System.Data;

namespace Pagino_Teka.Database
{
    public class BookSeriesRepository
    {
        private readonly DatabaseService _databaseService;

        public BookSeriesRepository(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public List<BookSeries> GetAllSeries()
        {
            var series = new List<BookSeries>();
            DataTable table = _databaseService.ExecuteQuery("SELECT id, name FROM BookSeries ORDER BY name;");
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

        public BookSeries? GetSeriesByName(string name)
        {
            DataTable table = _databaseService.ExecuteQuery(
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

        public int AddSeriesIfNotExists(string name)
        {
            var existing = GetSeriesByName(name);
            if (existing != null) return existing.Id;

            _databaseService.ExecuteNonQuery(
                "INSERT INTO BookSeries (name) VALUES (@name);",
                new SqliteParameter("@name", name)
            );

            object idObj = _databaseService.ExecuteScalar("SELECT last_insert_rowid();");
            return Convert.ToInt32(idObj);
        }
    }
}
