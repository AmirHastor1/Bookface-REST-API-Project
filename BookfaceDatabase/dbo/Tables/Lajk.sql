-- Table dbo.Lajk
-- Table dbo.Lajk
-- Table dbo.Lajk
-- Table dbo.Lajk
-- Table dbo.Lajk
-- Table dbo.Lajk
create table
	[dbo].[Lajk]
(
	[lajkId] uniqueidentifier not null
	, [korisnikId] uniqueidentifier not null
	, [objavaId] uniqueidentifier not null
,
constraint [Pk_Lajk_lajkId] primary key clustered
(
	[lajkId] asc
)
);
GO
-- Relationship Fk_Korisnik_Lajk_korisnikId
-- Relationship Fk_Korisnik_Lajk_korisnikId
-- Relationship Fk_Korisnik_Lajk_korisnikId
-- Relationship Fk_Korisnik_Lajk_korisnikId
-- Relationship Fk_Korisnik_Lajk_korisnikId
-- Relationship Fk_Korisnik_Lajk_korisnikId
alter table [dbo].[Lajk]
add constraint [Fk_Korisnik_Lajk_korisnikId] foreign key ([korisnikId]) references [dbo].[Korisnik] ([korisnikId]);
GO
-- Relationship Fk_Objava_Lajk_objavaId
-- Relationship Fk_Objava_Lajk_objavaId
-- Relationship Fk_Objava_Lajk_objavaId
-- Relationship Fk_Objava_Lajk_objavaId
-- Relationship Fk_Objava_Lajk_objavaId
-- Relationship Fk_Objava_Lajk_objavaId
alter table [dbo].[Lajk]
add constraint [Fk_Objava_Lajk_objavaId] foreign key ([objavaId]) references [dbo].[Objava] ([objavaId]);