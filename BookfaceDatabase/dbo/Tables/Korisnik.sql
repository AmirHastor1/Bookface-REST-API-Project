-- Table dbo.Korisnik
-- Table dbo.Korisnik
-- Table dbo.Korisnik
-- Table dbo.Korisnik
-- Table dbo.Korisnik
-- Table dbo.Korisnik
create table
	[dbo].[Korisnik]
(
	[korisnikId] uniqueidentifier not null
	, [naziv] nvarchar(50) not null
	, [email] nvarchar(50) not null
	, [slikaProfila] image null
	, [sifraHash] varbinary(max) not null
	, [sifraSalt] varbinary(max) not null
	, [jwt] nvarchar(max) null
	, [datumKreiranjaProfila] datetime2(7) not null
	, [darkTheme] bit not null
	, [notificationsEnabled] bit not null
	, [twoFAEnabled] bit not null
	, [tipKorisnika] int not null
,
constraint [Pk_Korisnik_korisnikId] primary key clustered
(
	[korisnikId] asc
)
);