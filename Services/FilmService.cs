using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public FilmRepository FilmRepository { get; }

        // Singleton - jedna instancja serwisu w aplikacji
        private static FilmService? _instance;
        public static FilmService Instance => _instance ??= new FilmService(DatabaseService.Instance);

        /// <summary>
        /// Konstruktor przyjmujący instancję DatabaseService.
        /// </summary>
        public FilmService(DatabaseService databaseService)
        {
            _db = databaseService;
            FilmRepository = new FilmRepository(_db);
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

        // Tu możesz dodać logikę integracji z zewnętrznymi API (np. TMDB)
        // oraz inne metody biznesowe, np. walidację, wyszukiwanie, itp.
    }
}
