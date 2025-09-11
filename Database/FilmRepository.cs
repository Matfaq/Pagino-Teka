using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Pagino_Teka.Services;

namespace Pagino_Teka.Database
{
    /// <summary>
    /// Repozytorium odpowiedzialne za operacje na danych związanych z filmami.
    /// Oddziela logikę bazy od reszty aplikacji.
    /// </summary>
    public class FilmRepository
    {
        private readonly DatabaseService _databaseService;

        /// <summary>
        /// Konstruktor przyjmujący instancję DatabaseService.
        /// Dzięki temu wszystkie zapytania korzystają z jednego połączenia.
        /// </summary>
        public FilmRepository(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        /// <summary>
        /// Pobiera wszystkie gatunki filmów z tabeli FilmGenres.
        /// </summary>
        /// <returns>Lista nazw gatunków filmowych.</returns>
        public List<string> GetAllGenres()
        {
            var genres = new List<string>();

            try
            {
                // Pobieramy dane jako DataTable
                var table = _databaseService.ExecuteQuery(
                    "SELECT name FROM FilmGenres ORDER BY name;"
                );

                // Iterujemy po wierszach i dodajemy nazwy gatunków do listy
                foreach (System.Data.DataRow row in table.Rows)
                {
                    genres.Add(row["name"].ToString() ?? string.Empty);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas pobierania gatunków filmów: {ex.Message}");
            }

            return genres;
        }
    }
}
