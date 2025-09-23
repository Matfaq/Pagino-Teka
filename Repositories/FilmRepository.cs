using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.Sqlite;
using Pagino_Teka.Database;
using Pagino_Teka.Models;

namespace Pagino_Teka.Repositories
{
    /// <summary>
    /// Repozytorium do obs³ugi operacji CRUD na filmach.
    /// </summary>
    public class FilmRepository
    {
        private readonly DatabaseService _db;

        public FilmRepository(DatabaseService db)
        {
            _db = db;
        }

        public void Add(Film film)
        {
            string sql = "INSERT INTO Films (title, year, directorId, screenwriterId) VALUES (@title, @year, @directorId, @screenwriterId)";
            _db.ExecuteNonQuery(sql,
                new SqliteParameter("@title", film.Title),
                new SqliteParameter("@year", film.Year),
                new SqliteParameter("@directorId", film.DirectorId),
                new SqliteParameter("@screenwriterId", film.ScreenwriterId));
        }

        public void Update(Film film)
        {
            string sql = "UPDATE Films SET title = @title, year = @year, directorId = @directorId, screenwriterId = @screenwriterId WHERE id = @id";
            _db.ExecuteNonQuery(sql,
                new SqliteParameter("@title", film.Title),
                new SqliteParameter("@year", film.Year),
                new SqliteParameter("@directorId", film.DirectorId),
                new SqliteParameter("@screenwriterId", film.ScreenwriterId),
                new SqliteParameter("@id", film.Id));
        }

        public void Delete(int id)
        {
            string sql = "DELETE FROM Films WHERE id = @id";
            _db.ExecuteNonQuery(sql, new SqliteParameter("@id", id));
        }

        public Film? GetById(int id)
        {
            string sql = "SELECT * FROM Films WHERE id = @id";
            var dt = _db.ExecuteQuery(sql, new SqliteParameter("@id", id));
            if (dt.Rows.Count == 0)
                return null;
            return MapFromDataRow(dt.Rows[0]);
        }

        public IEnumerable<Film> GetAll()
        {
            string sql = "SELECT * FROM Films";
            var dt = _db.ExecuteQuery(sql);
            foreach (DataRow row in dt.Rows)
                yield return MapFromDataRow(row);
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            string sql = "SELECT * FROM Genres";
            var dt = _db.ExecuteQuery(sql);
            foreach (DataRow row in dt.Rows)
            {
                yield return new Genre
                {
                    Id = Convert.ToInt32(row["id"]),
                    Name = row["name"].ToString() ?? ""
                };
            }
        }

        private Film MapFromDataRow(DataRow row)
        {
            return new Film
            {
                Id = Convert.ToInt32(row["id"]),
                Title = row["title"].ToString() ?? "",
                Year = Convert.ToInt32(row["year"]),
                DirectorId = Convert.ToInt32(row["directorId"]),
                ScreenwriterId = Convert.ToInt32(row["screenwriterId"])
            };
        }

        private List<int> GetGenreIdsForFilm(int filmId)
        {
            string sql = "SELECT genreId FROM FilmGenres WHERE filmId = @filmId";
            var dt = _db.ExecuteQuery(sql, new SqliteParameter("@filmId", filmId));
            var ids = new List<int>();
            foreach (DataRow row in dt.Rows)
                ids.Add(Convert.ToInt32(row["genreId"]));
            return ids;
        }

        public bool IsTitleUnique(string title)
        {
            string sql = "SELECT COUNT(*) FROM Films WHERE title = @title";
            var count = Convert.ToInt32(_db.ExecuteScalar(sql, new SqliteParameter("@title", title)));
            return count == 0;
        }
    }
}