using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Pagino_Teka.Database;
using Pagino_Teka.Models;

namespace Pagino_Teka.Services
{
    /// <summary>
    /// Serwis do obsługi logiki biznesowej filmów.
    /// Oddziela logikę aplikacji od operacji na bazie danych.
    /// </summary>
    public class FilmService
    {
        private readonly DatabaseService _db;

        // Repozytorium filmów, obsługuje operacje CRUD na bazie
        public Pagino_Teka.Database.FilmRepository FilmRepository { get; }

        // Singleton - jedna instancja serwisu w aplikacji
        private static FilmService? _instance;
        public static FilmService Instance => _instance ??= new FilmService(DatabaseService.Instance);

        /// <summary>
        /// Konstruktor przyjmujący instancję DatabaseService.
        /// </summary>
        public FilmService(DatabaseService databaseService)
        {
            _db = databaseService;
            FilmRepository = new Pagino_Teka.Database.FilmRepository(_db);
        }

        /// <summary>
        /// Zwraca wszystkie gatunki filmowe z bazy.
        /// </summary>
        public IEnumerable<Genre> GetAllGenres() => FilmRepository.GetAllGenres();

        /// <summary>
        /// Zwraca wszystkie filmy z bazy.
        /// </summary>
        public IEnumerable<Film> GetAllFilms() => FilmRepository.GetAll();

        /// <summary>
        /// Dodaje nowy film do bazy.
        /// </summary>
        public void SaveFilm(Film film) => FilmRepository.Add(film);

        /// <summary>
        /// Aktualizuje dane filmu w bazie.
        /// </summary>
        public void UpdateFilm(Film film) => FilmRepository.Update(film);

        /// <summary>
        /// Usuwa film z bazy.
        /// </summary>
        public void DeleteFilm(int filmId) => FilmRepository.Delete(filmId);

        /// <summary>
        /// Pobiera film po ID.
        /// </summary>
        public Film? GetFilmById(int id) => FilmRepository.GetById(id);

        /// <summary>
        /// Zwraca ID osoby (reżysera/scenarzysty) o podanym imieniu i typie.
        /// Jeśli nie istnieje, dodaje do bazy i zwraca nowy ID.
        /// </summary>
        public int GetOrAddPersonId(string name, string type)
        {
            string table;
            if (type == "Director")
                table = "Directors";
            else if (type == "Screenwriter")
                table = "Screenwriters";
            else
                throw new ArgumentException("Nieznany typ osoby: " + type);

            string selectSql = $"SELECT id FROM {table} WHERE name = @name LIMIT 1";
            var dt = _db.ExecuteQuery(selectSql, new Microsoft.Data.Sqlite.SqliteParameter("@name", name));
            if (dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0]["id"]);

            string insertSql = $"INSERT INTO {table} (name) VALUES (@name); SELECT last_insert_rowid();";
            var id = Convert.ToInt32(_db.ExecuteScalar(insertSql, new Microsoft.Data.Sqlite.SqliteParameter("@name", name)));
            return id;
        }

        public int GetOrAddDirectorId(string name)
        {
            string selectSql = "SELECT id FROM Directors WHERE name = @name LIMIT 1";
            var dt = _db.ExecuteQuery(selectSql, new SqliteParameter("@name", name));
            if (dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0]["id"]);
            string insertSql = "INSERT INTO Directors (name) VALUES (@name); SELECT last_insert_rowid();";
            return Convert.ToInt32(_db.ExecuteScalar(insertSql, new SqliteParameter("@name", name)));
        }

        public int GetOrAddScreenwriterId(string name)
        {
            string selectSql = "SELECT id FROM Screenwriters WHERE name = @name LIMIT 1";
            var dt = _db.ExecuteQuery(selectSql, new SqliteParameter("@name", name));
            if (dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0]["id"]);
            string insertSql = "INSERT INTO Screenwriters (name) VALUES (@name); SELECT last_insert_rowid();";
            return Convert.ToInt32(_db.ExecuteScalar(insertSql, new SqliteParameter("@name", name)));
        }

        /// <summary>
        /// Sprawdza, czy tytuł filmu jest unikalny w bazie.
        /// </summary>
        public bool IsTitleUnique(string title)
        {
            // Implementacja sprawdzania unikalności tytułu
            var allFilms = FilmRepository.GetAll();
            return !allFilms.Any(f => f.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        // Tu możesz dodać logikę integracji z zewnętrznymi API (np. TMDB)
        // oraz inne metody biznesowe, np. walidację, wyszukiwanie, itp.
    }
}
