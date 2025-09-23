-- Tabele normalizujące 
  -- Tabele przechowujące unikalne informacje o reżyserach, scenarzystach i gatunkach filmowych
  -- Tabele te są używane do normalizacji danych w bazie danych filmowej
  -- Każda tabela zawiera unikalne identyfikatory i nazwy dla reżyserów, scenarzystów i gatunków filmowych
  -- Dzięki temu można łatwo zarządzać danymi i unikać duplikacji informacji
  -- Tabele te są również używane do tworzenia relacji między filmami a reżyserami, scenarzystami i gatunkami filmowymi

  -- Tabela przechowująca informacje o reżyserach
	create table if not exists Directors (
		id integer primary key autoincrement, -- id Reżysera
		name text not null unique
);
	-- Tabela przechowująca informacje o scenarzystach
	create table if not exists Screenwriters (
		id integer primary key autoincrement, -- id Scenarzysty
		name text not null unique
);
	-- Tabela przechowująca informacje o gatunkach filmowych
	create table if not exists FilmGenres (
		id integer primary key autoincrement, -- id Gatunku filmowego
		name text not null unique
);
		-- Dane początkowe dla gatunków filmowych
		insert or ignore into FilmGenres (name) values
		('Akcja'),('Film sensacyjny'),('Akcja szpiegowska'),('Akcja przygodowa'),('Akcja militarna'),('Akcja science-fiction'),('Akcja superbohaterska'),('Animacja'),('Animacja 2D'),
		('Animacja 3D'),('Anime'),('Animacja lalkowa'),('Animacja poklatkowa'),('Dla dzieci'),('Animacja komputerowa'),('Biograficzny'),('Biografia historyczna'),('Biografia artysty'),
		('Biografia sportowca'),('Biografia naukowca'),('Familijny'),('Bajki'),('Filmy przygodowe dla dzieci'),('Animacje edukacyjne'),('Musical dla dzieci'),('Dokumentalny'),('Przyrodniczy'),
		('Historyczny'),('Społeczny'),('Kryminalny (true crime)'),('Polityczny'),('Biograficzny (dokument)'),('Dramat'),('Dramat psychologiczny'),('Dramat społeczny'),('Dramat rodzinny'),
		('Dramat wojenny'),('Dramat sądowy'),('Dramat historyczny'),('Dramat medyczny'),('Dramat biograficzny'),('Fantasy'),('Epicka fantasy'),('Urban fantasy'),('Dark fantasy'),('High fantasy'),
		('Fantasy przygodowa'),('Historyczny'),('Film kostiumowy'),('Biografia historyczna'),('Film batalistyczny'),('Dramat sądowy historyczny'),('Horror'),('Horror psychologiczny'),
		('Horror gore'),('Horror paranormalny'),('Slasher'),('Horror komediowy'),('Zombie'),('Potwory'),('Klątwa'),('Komedia'),('Komedia romantyczna'),('Komedia sytuacyjna'),('Komedia kryminalna'),
		('Komedia obyczajowa'),('Komedia polityczna'),('Komedia slapstickowa'),('Czarna komedia'),('Parodia'),('Kryminalny'),('Thriller kryminalny'),('Film detektywistyczny'),('Noir'),
		('Heist movie'),('Gangsterski'),('Melodramat'),('Klasyczny melodramat'),('Melodramat historyczny'),('Melodramat społeczny'),('Musical'),('Musical klasyczny'),('Musical nowoczesny'),
		('Musical animowany'),('Musical fantasy'),('Obyczajowy'),('Film społeczny'),('Film o dojrzewaniu'),('Film rodzinny'),('Film edukacyjny'),('Film o relacjach'),('Przygodowy'),('Przygodowy młodzieżowy'),
		('Fantasy przygodowy'),('Historyczny przygodowy'),('Poszukiwanie skarbów'),('Survival'),('Romans'),('Romans historyczny'),('Komedia romantyczna'),('Romans młodzieżowy'),('Romans dramatyczny'),
		('Romans fantasy'),('Science-fiction'),('Sci-fi militarne'),('Sci-fi kosmiczne'),('Cyberpunk'),('Dystopia'),('Utopia'),('Postapo'),('Sci-fi przygodowe'),('Sci-fi filozoficzne'),
		('Sensacyjny'),('Thriller akcji'),('Polityczny'),('Szpiegowski'),('Militarny'),('Technologiczny'),('Thriller'),('Thriller psychologiczny'),('Thriller polityczny'),('Thriller medyczny'),
		('Thriller erotyczny'),('Thriller sądowy'),('Thriller katastroficzny'),('Wojenny'),('Dramat wojenny'),('Akcja wojskowa'),('Film szpiegowski'),('Film partyzancki'),('Film batalistyczny'),
		('Western'),('Western klasyczny'),('Neo-western'),('Western spaghetti'),('Western psychologiczny'),('Western historyczny'),('Eksperymentalny'),('Awangardowy'),('Oniryczny'),('Film artystyczny'),
		('Psychodeliczny');



	-- Tabela przechowywujaca informacje o filmach

	create table if not exists filmy (
		id integer primary key autoincrement,		-- Unikalny identyfikator filmu
		title text not null,						-- Tytul filmu
		director_id integer not null,				-- Reżyser filmu
		screenwriter_id integer not null,			-- Scenarzysta filmu
		year integer not null,						-- Rok produkcji filmu
		run_time integer not null,					-- Czas trwania filmu w minutach
		genre_id integer not null,					-- Gatunek filmu
		language text not null,						-- Język filmu
		based_on text,								-- Film oparty na książce lub innym dziele
		poster text,								-- Ścieżka do plakatu filmu
		description text,							-- Opis filmu

	-- Klucze obce
	foreign key (director_id) references Directors(id),
	foreign key (screenwriter_id) references Screenwriters(id),
	foreign key (genre_id) references FilmGenres(id)
);

	-- Indeks na tytule filmu dla szybszego wyszukiwania
	create index if not exists idx_filmy_title on filmy (title);

	-- Indeks na reżyserze filmu dla szybszego wyszukiwania
	create index if not exists idx_filmy_director on filmy (director_id);

	-- Indeks na scenarzyście filmu dla szybszego wyszukiwania
	create index if not exists idx_filmy_screenwriter on filmy (screenwriter_id);

	-- Indeks na gatunku filmu dla szybszego wyszukiwania
	create index if not exists idx_filmy_genre on filmy (genre_id);

	-- Indeks na roku produkcji filmu dla szybszego wyszukiwania
	create index if not exists idx_filmy_year on filmy (year);


	-- Tabele przechowująca informacje o książkach

	-- Tabele normalizujące dla książek

	-- Tabela przechowująca informacje o autorach książek
	create table if not exists Authors (
		id integer primary key autoincrement, -- id Autora
		name text not null unique
		);

	-- Tabela przechowująca informacje o gatunkach książek
	create table if not exists BookGenres (
		id integer primary key autoincrement, -- id Gatunku książki
		name text not null unique
		);

		-- Dane początkowe dla gatunków książek
		INSERT OR IGNORE INTO BookGenres (name) VALUES
		('Anegdota'),('Anakreontyk'),('Autobiografia'),('Awangardowa forma'),('Bajka'),('Baśń'),('Ballada'),('Ballada ludowa'),('Biografia'),
		('Crossover literacki'),('Cyberpunk'),('Dziennik'),('Dystopia'),('Elegia'),('Epicedium'),('Epigramat'),('Epitafium'),('Epos / epopeja'),
		('Esej'),('Esej naukowy'),('Eksperymentalna proza'),('Fanfiction'),('Fantastyka naukowa'),('Fantasy'),('Farsa'),('Felieton'),('Flash fiction'),
		('Fraszka'),('Gawęda'),('Gawęda literacka'),('Haiku'),('High Fantasy / Epic Fantasy'),('Humoreska'),('Hymn'),('Komedia'),('Komedia romantyczna'),
		('Komiks literacki'),('Legenda'),('Lament'),('Limerik'),('List otwarty'),('Listy literackie / epistolografia'),('Magiczny realizm'),('Memoir'),
		('Metapowieść'),('Mikroesej'),('Monodram'),('Moralitet'),('Misterium'),('Musical'),('Mythologia (mity)'),('Nowela'),('Nowela psychologiczna'),
		('Nowela satyryczna'),('Novela'),('Oda'),('Oniryczna'),('Opowiadanie'),('Opowiadanie grozy'),('Opowiadanie historyczne'),('Opowiadanie science fiction'),
		('Opera / operetka'),('Pamflet'),('Panegryczny panegiryk'),('Pamiętnik'),('Pamiętnik podróżniczy'),('Pantomima literacka'),('Parabola'),('Pieśń'),
		('Pieśń biesiadna'),('Poemat dygresyjny'),('Poemat liryczny'),('Postapokaliptyczna'),('Proza poetycka'),('Psalm'),('Psychodeliczna literatura'),
		('Recenzja'),('Reportaż'),('Reportaż literacki'),('Reportaż podróżniczy'),('Rondel'),('Romans'),('Romans epistolarzy'),('Romans historyczny'),
		('Romans młodzieżowy'),('Romanse rycerski'),('Saga'),('Satyra'),('Sielanka'),('Sonet'),('Speculative Fiction'),('Steampunk'),('Sword and Sorcery'),
		('Tanka'),('Tragikomedia'),('Tragedia'),('Tragedia antyczna'),('Tragedia współczesna'),('Tren'),('Urban Fantasy'),('Utopia'),('Wywiad');



	-- Tabela przechowująca informacje o cyklach książek
	create table if not exists BookSeries (
		id integer primary key autoincrement, -- id Cyklu książek
		name text not null unique
		);
	-- Tabela przechowująca informacje o wydawcach książek
	create table if not exists Publishers (
		id integer primary key autoincrement, -- id Wydawcy
		name text not null unique
		);

	-- Tabela przechowująca informacje o książkach
	create table if not exists books (
		id integer primary key autoincrement,		-- Unikalny identyfikator książki
		title text not null,						-- Tytuł książki
		author_id integer not null,					-- Autor książki
		isbn text not null unique,					-- ISBN książki
		genre_id integer not null,					-- Gatunek książki
		pages integer not null,						-- Liczba stron w książce
		read_time integer not null,					-- Czas czytania książki w minutach
		book_series_id integer,						-- Cykl książek
		tome integer,								-- Numer tomu w cyklu książek
		published_kind text not null,				-- Rodzaj wydania książki (np. e-book, audiobook, papierowa)
		adaptation text,							-- Czy książka jest adaptacją filmu lub innego dzieła
		publisher_id integer not null,				-- Wydawca książki
		image text,									-- Ścieżka do okładki książki
		description text,							-- Opis książki
		
		-- Klucze obce	
		foreign key (author_id) references Authors(id),
		foreign key (genre_id) references BookGenres(id),
		foreign key (book_series_id) references BookSeries(id),
		foreign key (publisher_id) references Publishers(id)
		);

		-- Indeks na tytule książki dla szybszego wyszukiwania
		create index if not exists idx_books_title on books (title);

		-- Indeks na autorze książki dla szybszego wyszukiwania
		create index if not exists idx_books_author on books (author_id);

		-- Indeks na gatunku książki dla szybszego wyszukiwania
		create index if not exists idx_books_genre on books (genre_id);

		-- Indeks na cyklu książek dla szybszego wyszukiwania
		create index if not exists idx_books_series on books (book_series_id);

		-- Indeks na wydawcy książki dla szybszego wyszukiwania
		create index if not exists idx_books_publisher on books (publisher_id);

		-- Indeks na ISBN książki dla szybszego wyszukiwania
		create index if not exists idx_books_isbn on books (isbn);


-- Tabela łącząca filmy i gatunki filmowe (wiele-do-wielu)
CREATE TABLE IF NOT EXISTS FilmGenresMap (
    film_id INTEGER NOT NULL,
    genre_id INTEGER NOT NULL,
    FOREIGN KEY (film_id) REFERENCES filmy(id),
    FOREIGN KEY (genre_id) REFERENCES FilmGenres(id),
    PRIMARY KEY (film_id, genre_id)
);