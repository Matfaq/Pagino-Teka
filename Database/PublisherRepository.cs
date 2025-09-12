using Microsoft.Data.Sqlite;
using Pagino_Teka.Models;
using Pagino_Teka.Services;
using System;
using System.Collections.Generic;
using System.Data;


namespace Pagino_Teka.Repositories
{
    public class PublisherRepository
    {
        private readonly DatabaseService _db;

        public PublisherRepository(DatabaseService db)
        {
            _db = db;
        }

        public IEnumerable<Publisher> GetAll()
        {
            string sql = "SELECT * FROM publishers ORDER BY name";
            var dt = _db.ExecuteQuery(sql);
            var list = new List<Publisher>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapFromDataRow(row));
            }

            return list;
        }

        // NOWA METODA – dodanie wydawcy jeśli nie istnieje
        public Publisher AddIfNotExists(string name)
        {
            var existing = GetByName(name);
            if (existing != null) return existing;

            string sql = "INSERT INTO publishers (name) VALUES (@name)";
            _db.ExecuteNonQuery(sql, new SqliteParameter("@name", name));
            return GetByName(name);
        }

        public Publisher GetByName(string name)
        {
            string sql = "SELECT * FROM publishers WHERE name = @name LIMIT 1";
            var dt = _db.ExecuteQuery(sql, new SqliteParameter("@name", name));

            if (dt.Rows.Count == 0) return null;
            return MapFromDataRow(dt.Rows[0]);
        }

        private Publisher MapFromDataRow(DataRow row)
        {
            return new Publisher
            {
                Id = Convert.ToInt32(row["id"]),
                Name = row["name"].ToString()
            };
        }
    }
}
