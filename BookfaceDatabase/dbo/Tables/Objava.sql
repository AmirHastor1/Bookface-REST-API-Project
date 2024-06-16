-- Table dbo.Objava
-- Table dbo.Objava
-- Table dbo.Objava
-- Table dbo.Objava
-- Table dbo.Objava
-- Table dbo.Objava
create table
	[dbo].[Objava]
(
	[objavaId] uniqueidentifier not null
	, [korisnikId] uniqueidentifier not null
	, [objavaTekst] nvarchar(max) null
	, [objavaMedia] image null
	, [vrijemeObjave] datetime2(7) not null
	, [brojLajkova] int null
	, [brojKomentara] int null
	, [objavaTagovi] nvarchar(80) null
,
constraint [Pk_Objava_objavaId] primary key clustered
(
	[objavaId] asc
)
);
GO
-- Relationship Fk_Korisnik_Objava_korisnikId
-- Relationship Fk_Korisnik_Objava_korisnikId
-- Relationship Fk_Korisnik_Objava_korisnikId
-- Relationship Fk_Korisnik_Objava_korisnikId
-- Relationship Fk_Korisnik_Objava_korisnikId
-- Relationship Fk_Korisnik_Objava_korisnikId
alter table [dbo].[Objava]
add constraint [Fk_Korisnik_Objava_korisnikId] foreign key ([korisnikId]) references [dbo].[Korisnik] ([korisnikId]);