using Microsoft.Data.Sqlite;
using Pagino_Teka.Models;
using Pagino_Teka.Services;
using System;
using System.Collections.Generic;
using System.Data;

namespace Pagino_Teka.Database
{
    /// <summary>
    /// Repozytorium odpowiedzialne za operacje na danych związanych z filmami.
    /// Oddziela logikę bazy od reszty aplikacji.
    /// </summary>
    public class FilmRepository
    {
        private readonly DatabaseService _db;

        /// <summary>
        /// Konstruktor przyjmujący instancję DatabaseService.
        /// Dzięki temu wszystkie zapytania korzystają z jednego połączenia.
        /// </summary>
        public FilmRepository(DatabaseService db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        // --- DODAWANIE FILMU ---
        /// <summary>
        /// Dodaje nowy film do bazy danych.
        /// </summary>
        /// <param name="film">Obiekt filmu do dodania.</param>
        public void Add(Film film)
        {
            // Przygotowujemy zapytanie SQL z parametrami
            string sql = @"INSERT INTO filmy (title, director_id, screenwriter_id, year, run_time, genre_id, language, based_on, poster, description)
                           VALUES (@title, @director, @screenwriter, @year, @runtime, @genre, @lang, @basedon, @poster, @desc);
                           SELECT last_insert_rowid();";

            // Wstawiamy dane do bazy i pobieramy ID nowego filmu
            var id = Convert.ToInt32(_db.ExecuteScalar(sql,
                new SqliteParameter("@title", film.Title),
                new SqliteParameter("@director", film.DirectorId),
                new SqliteParameter("@screenwriter", film.ScreenwriterId),
                new SqliteParameter("@year", film.Year ?? (object)DBNull.Value),
                new SqliteParameter("@runtime", film.Duration ?? (object)DBNull.Value),
                new SqliteParameter("@genre", film.GenreId),
                new SqliteParameter("@lang", film.Language ?? string.Empty),
                new SqliteParameter("@basedon", film.BasedOn ?? string.Empty),
                new SqliteParameter("@poster", film.Image ?? string.Empty),
                new SqliteParameter("@desc", film.Description ?? string.Empty)
            ));

            film.Id = id;

            // Jeśli obsługujesz wiele gatunków, zapisz relacje w tabeli powiązań
            foreach (var genreId in film.GenreIds)
            {
                _db.ExecuteNonQuery("INSERT INTO FilmGenresMap (film_id, genre_id) VALUES (@film_id, @genre_id)",
                    new SqliteParameter("@film_id", id),
                    new SqliteParameter("@genre_id", genreId));
            }
        }

        // --- AKTUALIZACJA FILMU ---
        /// <summary>
        /// Aktualizuje dane filmu w bazie.
        /// </summary>
        /// <param name="film">Obiekt filmu z nowymi danymi.</param>
        public void Update(Film film)
        {
            string sql = @"UPDATE filmy SET
                           title = @title,
                           director_id = @director,
                           screenwriter_id = @screenwriter,
                           year = @year,
                           run_time = @runtime,
                           genre_id = @genre,
                           language = @lang,
                           based_on = @basedon,
                           poster = @poster,
                           description = @desc
                           WHERE id = @id";

            _db.ExecuteNonQuery(sql,
                new SqliteParameter("@title", film.Title),
                new SqliteParameter("@director", film.DirectorId),
                new SqliteParameter("@screenwriter", film.ScreenwriterId),
                new SqliteParameter("@year", film.Year ?? (object)DBNull.Value),
                new SqliteParameter("@runtime", film.Duration ?? (object)DBNull.Value),
                new SqliteParameter("@genre", film.GenreId),
                new SqliteParameter("@lang", film.Language ?? string.Empty),
                new SqliteParameter("@basedon", film.BasedOn ?? string.Empty),
                new SqliteParameter("@poster", film.Image ?? string.Empty),
                new SqliteParameter("@desc", film.Description ?? string.Empty),
                new SqliteParameter("@id", film.Id)
            );

            // Usuwamy stare relacje gatunków i dodajemy nowe
            _db.ExecuteNonQuery("DELETE FROM FilmGenresMap WHERE film_id = @film_id",
                new SqliteParameter("@film_id", film.Id));
            foreach (var genreId in film.GenreIds)
            {
                _db.ExecuteNonQuery("INSERT INTO FilmGenresMap (film_id, genre_id) VALUES (@film_id, @genre_id)",
                    new SqliteParameter("@film_id", film.Id),
                    new SqliteParameter("@genre_id", genreId));
            }
        }

        // --- USUWANIE FILMU ---
        /// <summary>
        /// Usuwa film z bazy danych.
        /// </summary>
        /// <param name="id">Id filmu do usunięcia.</param>
        public void Delete(int id)
        {
            // Najpierw usuwamy powiązania gatunków
            _db.ExecuteNonQuery("DELETE FROM FilmGenresMap WHERE film_id = @film_id",
                new SqliteParameter("@film_id", id));
            // Następnie usuwamy film
            _db.ExecuteNonQuery("DELETE FROM filmy WHERE id = @id",
                new SqliteParameter("@id", id));
        }

        // --- POBIERANIE FILMU PO ID ---
        /// <summary>
        /// Pobiera film o podanym ID.
        /// </summary>
        /// <param name="id">Id filmu.</param>
        /// <returns>Obiekt Film lub null jeśli nie znaleziono.</returns>
        public Film? GetById(int id)
        {
            string sql = "SELECT * FROM filmy WHERE id = @id LIMIT 1";
            var dt = _db.ExecuteQuery(sql, new SqliteParameter("@id", id));
            if (dt.Rows.Count == 0)
                return null;
            return MapFromDataRow(dt.Rows[0]);
        }

        // --- POBIERANIE WSZYSTKICH FILMÓW ---
        /// <summary>
        /// Pobiera wszystkie filmy z bazy.
        /// </summary>
        /// <returns>Lista obiektów Film.</returns>
        public IEnumerable<Film> GetAll()
        {
            var list = new List<Film>();
            string sql = "SELECT * FROM filmy ORDER BY title";
            var dt = _db.ExecuteQuery(sql);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapFromDataRow(row));
            }
            return list;
        }

        // --- POBIERANIE WSZYSTKICH GATUNKÓW FILMÓW ---
        /// <summary>
        /// Pobiera wszystkie gatunki filmów z tabeli FilmGenres.
        /// </summary>
        /// <returns>Lista obiektów Genre.</returns>
        public IEnumerable<Genre> GetAllGenres()
        {
            var list = new List<Genre>();
            string sql = "SELECT id, name FROM FilmGenres ORDER BY name";
            var dt = _db.ExecuteQuery(sql);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Genre
                {
                    Id = Convert.ToInt32(row["id"]),
                    Name = row["name"].ToString()
                });
            }
            return list;
        }

        // --- MAPOWANIE DANYCH Z WIERSZA NA OBIEKT FILMU ---
        /// <summary>
        /// Tworzy obiekt Film na podstawie danych z DataRow.
        /// </summary>
        private Film MapFromDataRow(DataRow row)
        {
            return new Film
            {
                Id = Convert.ToInt32(row["id"]),
                Title = row["title"].ToString(),
                DirectorId = Convert.ToInt32(row["director_id"]),
                ScreenwriterId = Convert.ToInt32(row["screenwriter_id"]),
                Year = row["year"] != DBNull.Value ? Convert.ToInt32(row["year"]) : (int?)null,
                Duration = row["run_time"] != DBNull.Value ? Convert.ToInt32(row["run_time"]) : (int?)null,
                GenreId = Convert.ToInt32(row["genre_id"]),
                Language = row["language"]?.ToString() ?? string.Empty,
                BasedOn = row["based_on"]?.ToString() ?? string.Empty,
                Image = row["poster"]?.ToString() ?? string.Empty,
                Description = row["description"]?.ToString() ?? string.Empty,
                GenreIds = GetGenreIdsForFilm(Convert.ToInt32(row["id"]))
            };
        }

        // --- POMOCNICZA METODA DO POBIERANIA LISTY GATUNKÓW FILMU ---
        /// <summary>
        /// Pobiera listę ID gatunków powiązanych z filmem.
        /// </summary>
        private List<int> GetGenreIdsForFilm(int filmId)
        {
            var genreIds = new List<int>();
            string sql = "SELECT genre_id FROM FilmGenresMap WHERE film_id = @film_id";
            var dt = _db.ExecuteQuery(sql, new SqliteParameter("@film_id", filmId));
            foreach (DataRow r in dt.Rows)
                genreIds.Add(Convert.ToInt32(r["genre_id"]));
            return genreIds;
        }
    }
}
