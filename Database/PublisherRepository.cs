using Microsoft.Data.Sqlite;
using Pagino_Teka.Models;
using Pagino_Teka.Services;
using System;
using System.Collections.Generic;
using System.Data;

namespace Pagino_Teka.Database
{
    public class PublisherRepository
    {
        private readonly DatabaseService _databaseService;

        public PublisherRepository(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public List<Publisher> GetAllPublishers()
        {
            var list = new List<Publisher>();
            DataTable table = _databaseService.ExecuteQuery("SELECT id, name FROM Publishers ORDER BY name;");
            foreach (DataRow r in table.Rows)
            {
                list.Add(new Publisher
                {
                    Id = Convert.ToInt32(r["id"]),
                    Name = r["name"].ToString() ?? string.Empty
                });
            }
            return list;
        }

        public Publisher? GetPublisherByName(string name)
        {
            DataTable table = _databaseService.ExecuteQuery(
                "SELECT id, name FROM Publishers WHERE name = @name LIMIT 1;",
                new SqliteParameter("@name", name)
            );

            if (table.Rows.Count == 0) return null;

            var row = table.Rows[0];
            return new Publisher
            {
                Id = Convert.ToInt32(row["id"]),
                Name = row["name"].ToString() ?? string.Empty
            };
        }

        public int AddPublisherIfNotExists(string name)
        {
            var existing = GetPublisherByName(name);
            if (existing != null) return existing.Id;

            _databaseService.ExecuteNonQuery(
                "INSERT INTO Publishers (name) VALUES (@name);",
                new SqliteParameter("@name", name)
            );

            object idObj = _databaseService.ExecuteScalar("SELECT last_insert_rowid();");
            return Convert.ToInt32(idObj);
        }
    }
}
