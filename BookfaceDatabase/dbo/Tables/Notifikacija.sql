-- Table dbo.Notifikacija
-- Table dbo.Notifikacija
-- Table dbo.Notifikacija
-- Table dbo.Notifikacija
-- Table dbo.Notifikacija
-- Table dbo.Notifikacija
create table
	[dbo].[Notifikacija]
(
	[notifikacijaId] uniqueidentifier not null
	, [objavaId] uniqueidentifier null
	, [komentarId] uniqueidentifier null
	, [prijavaId] uniqueidentifier null
	, [korisnikId] uniqueidentifier not null
	, [notifikacijaTekst] nvarchar(max) not null
	, [vrijemeSlanjaNotifikacije] datetime2(7) not null
	, [novaNotifikacija] bit not null
	, [tipNotifikacije] int not null
,
constraint [Pk_Notifikacija_notifikacijaId] primary key clustered
(
	[notifikacijaId] asc
)
);
GO
-- Relationship Fk_Korisnik_Notifikacija_korisnikId
-- Relationship Fk_Korisnik_Notifikacija_korisnikId
-- Relationship Fk_Korisnik_Notifikacija_korisnikId
-- Relationship Fk_Korisnik_Notifikacija_korisnikId
-- Relationship Fk_Korisnik_Notifikacija_korisnikId
-- Relationship Fk_Korisnik_Notifikacija_korisnikId
alter table [dbo].[Notifikacija]
add constraint [Fk_Korisnik_Notifikacija_korisnikId] foreign key ([korisnikId]) references [dbo].[Korisnik] ([korisnikId]);
GO
-- Relationship Fk_Objava_Notifikacija_objavaId
-- Relationship Fk_Objava_Notifikacija_objavaId
-- Relationship Fk_Objava_Notifikacija_objavaId
-- Relationship Fk_Objava_Notifikacija_objavaId
-- Relationship Fk_Objava_Notifikacija_objavaId
-- Relationship Fk_Objava_Notifikacija_objavaId
alter table [dbo].[Notifikacija]
add constraint [Fk_Objava_Notifikacija_objavaId] foreign key ([objavaId]) references [dbo].[Objava] ([objavaId]);
GO
-- Relationship Fk_Komentar_Notifikacija_komentarId
-- Relationship Fk_Komentar_Notifikacija_komentarId
-- Relationship Fk_Komentar_Notifikacija_komentarId
-- Relationship Fk_Komentar_Notifikacija_komentarId
-- Relationship Fk_Komentar_Notifikacija_komentarId
-- Relationship Fk_Komentar_Notifikacija_komentarId
alter table [dbo].[Notifikacija]
add constraint [Fk_Komentar_Notifikacija_komentarId] foreign key ([komentarId]) references [dbo].[Komentar] ([komentarId]);
GO
-- Relationship Fk_Prijava_Notifikacija_prijavaId
-- Relationship Fk_Prijava_Notifikacija_prijavaId
-- Relationship Fk_Prijava_Notifikacija_prijavaId
-- Relationship Fk_Prijava_Notifikacija_prijavaId
-- Relationship Fk_Prijava_Notifikacija_prijavaId
-- Relationship Fk_Prijava_Notifikacija_prijavaId
alter table [dbo].[Notifikacija]
add constraint [Fk_Prijava_Notifikacija_prijavaId] foreign key ([prijavaId]) references [dbo].[Prijava] ([prijavaId]);