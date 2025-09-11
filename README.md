# 📚 Pagino-Teka  

**Pagino-Teka** to aplikacja desktopowa w technologii **C# WinForms** z bazą danych **SQLite**, która umożliwia katalogowanie przeczytanych książek i obejrzanych filmów.  

---

## 🚀 Funkcje  

### 📖 Książki  
- Dodawanie książek ręcznie lub po **ISBN** (integracja z OpenLibrary i Google Books).  
- Obsługa wielu autorów (zapisywani w osobnej tabeli, do książki przypisane tylko ID).  
- Obsługa wydawców, serii książek i gatunków.  
- Okładki zapisywane lokalnie w folderze aplikacji (`Images/book_covers`).  
- Możliwość dodania notatek.  
- Rodzaj wydania i adaptacje (obsługa w formularzu).  
- **TODO:** Edycja książek  
  - Wyszukiwanie po autorze, tytule, wydawnictwie lub serii.  
  - Lista wyników umożliwia wybranie książki do edycji.  
  - Uniwersalne okno **EditBookForm** pozwala edytować wszystkie pola lub usunąć książkę z potwierdzeniem.  

### 🎬 Filmy  
- Dodawanie filmów ręcznie.  
- Obsługa gatunków filmowych.  
- Zapisywanie plakatów w lokalnym folderze (`Images/film_posters`).  

### 📊 Status  
- Podsumowanie bazy: liczba książek, autorów, zapisanych okładek.  
- Zestawienie książek w seriach (z numerami i poprawną odmianą słowa „książka”).  

### 🎨 Motywy  
- **Light** i **Dark** – zdefiniowane w `Themes.cs`, stosowane przez `ThemeManager`.  
- Zmiana motywu w menu **Ustawienia → Motyw**.  

### ⚙️ SetupForm (NOWOŚĆ)  
- Wyświetlany przy **pierwszym uruchomieniu aplikacji**.  
- Umożliwia ustawienie klucza API Google lub wybór opcji *„Nie chcę klucza API”*.  
- Ustawienia i preferencje zapisują się w folderze aplikacji w plikach konfiguracyjnych.  
- Jeśli użytkownik wybierze brak klucza API – dane pobierane są wyłącznie z OpenLibrary.  

---

## 🗂️ Struktura projektu  

- **Pagino-Teka**  
  - **Data**  
    - `Schema.sql` – definicja bazy danych SQLite  
  - **Theme**  
    - `ThemeManager.cs` – logika stosowania motywów  
    - `Themes.cs` – definicje Light/Dark  
  - **Forms**  
    - `MainForm.cs` – główne okno aplikacji  
    - `AddBookForm.cs` – formularz dodawania książek  
    - `AddFilmForm.cs` – formularz dodawania filmów  
    - `SetupForm.cs` – konfiguracja przy pierwszym uruchomieniu  
    - `StatusForm.cs` – wyświetlanie statystyk  
    - `EditBookForm.cs` – edycja i usuwanie książek (**TODO**)  
  - **Services**  
    - `DatabaseService.cs` – singleton zarządzający połączeniem SQLite  
    - `BookService.cs` – logika biznesowa książek  
  - **Repositories**  
    - `BookRepository.cs`  
    - `AuthorRepository.cs`  
    - `BookSeriesRepository.cs`  
    - `PublisherRepository.cs`  
    - `FilmRepository.cs`  
  - **Images**  
    - `book_covers/` – okładki książek  
    - `film_posters/` – plakaty filmów  
  - `pa-te.db` – plik bazy SQLite (tworzony automatycznie)  
  - **Pliki konfiguracyjne** – przechowują klucz Google API i preferencje użytkownika  

---

## ⚙️ Ustawienia aplikacji  

- **Lokalizacja plików aplikacji:**  
  Tworzone w folderze użytkownika (`%USERPROFILE%\Pagino-Teka`).  

- **Ustawienia i preferencje:**  
  - Klucz Google API (jeśli podany)  
  - Wybrany motyw  
  - Inne preferencje użytkownika  
  - Wszystko zapisane w plikach konfiguracyjnych w folderze aplikacji  

---

## 📌 Plany rozwoju  

- Rozbudowa formularza dodawania filmów o automatyczne pobieranie danych z API.  
- Zaawansowane filtrowanie i wyszukiwanie w kolekcji.  
- Eksport i import bazy danych.  
- Implementacja **edycji książek** poprzez EditBookForm (**TODO**).  

---

## 📝 Licencja

**All Rights Reserved**  

Ten projekt ("Pagino-Teka") jest udostępniony publicznie wyłącznie do celów edukacyjnych i demonstracyjnych.  
Kod źródłowy może być przeglądany i studiowany, ale:  

- Kopiowanie, rozpowszechnianie lub modyfikowanie kodu w całości lub w części jest **surowo zabronione**.  
- Użycie komercyjne lub prywatne poza tym repozytorium **wymaga pisemnej zgody autora**.  
- Autor zachowuje wszelkie prawa do kodu źródłowego i jego zawartości.  

Copyright (c) 2025 Matfaq. All rights reserved.
