-- Table dbo.Prijava
-- Table dbo.Prijava
-- Table dbo.Prijava
-- Table dbo.Prijava
-- Table dbo.Prijava
-- Table dbo.Prijava
create table
	[dbo].[Prijava]
(
	[prijavaId] uniqueidentifier not null
	, [prijavljenaObjavaId] uniqueidentifier null
	, [prijavljeniKomentarId] uniqueidentifier null
	, [podnosilacPrijave] uniqueidentifier not null
	, [vrstaPrijave] int not null
	, [opis] nvarchar(100) not null
,
constraint [Pk_Prijava_prijavaId] primary key clustered
(
	[prijavaId] asc
)
);
GO
-- Relationship Fk_Korisnik_Prijava_podnosilacPrijave
-- Relationship Fk_Korisnik_Prijava_podnosilacPrijave
-- Relationship Fk_Korisnik_Prijava_podnosilacPrijave
-- Relationship Fk_Korisnik_Prijava_podnosilacPrijave
-- Relationship Fk_Korisnik_Prijava_podnosilacPrijave
-- Relationship Fk_Korisnik_Prijava_podnosilacPrijave
alter table [dbo].[Prijava]
add constraint [Fk_Korisnik_Prijava_podnosilacPrijave] foreign key ([podnosilacPrijave]) references [dbo].[Korisnik] ([korisnikId]);
GO
-- Relationship Fk_Objava_Prijava_prijavljenaObjavaId
-- Relationship Fk_Objava_Prijava_prijavljenaObjavaId
-- Relationship Fk_Objava_Prijava_prijavljenaObjavaId
-- Relationship Fk_Objava_Prijava_prijavljenaObjavaId
-- Relationship Fk_Objava_Prijava_prijavljenaObjavaId
-- Relationship Fk_Objava_Prijava_prijavljenaObjavaId
alter table [dbo].[Prijava]
add constraint [Fk_Objava_Prijava_prijavljenaObjavaId] foreign key ([prijavljenaObjavaId]) references [dbo].[Objava] ([objavaId]);
GO
-- Relationship Fk_Komentar_Prijava_prijavljeniKomentarId
-- Relationship Fk_Komentar_Prijava_prijavljeniKomentarId
-- Relationship Fk_Komentar_Prijava_prijavljeniKomentarId
-- Relationship Fk_Komentar_Prijava_prijavljeniKomentarId
-- Relationship Fk_Komentar_Prijava_prijavljeniKomentarId
-- Relationship Fk_Komentar_Prijava_prijavljeniKomentarId
alter table [dbo].[Prijava]
add constraint [Fk_Komentar_Prijava_prijavljeniKomentarId] foreign key ([prijavljeniKomentarId]) references [dbo].[Komentar] ([komentarId]);