-- Model New Model
-- Updated 6/14/2024 12:37:43 AM
-- DDL Generated 6/14/2024 12:37:50 AM

--**********************************************************************
--	Tables
--**********************************************************************

-- Table dbo.Komentar
-- Model New Model
-- Updated 6/14/2024 12:37:43 AM
-- DDL Generated 6/14/2024 3:06:41 PM

--**********************************************************************
--	Tables
--**********************************************************************

-- Table dbo.Komentar
-- Model New Model
-- Updated 6/14/2024 5:28:54 PM
-- DDL Generated 6/14/2024 5:28:56 PM

--**********************************************************************
--	Tables
--**********************************************************************

-- Table dbo.Komentar
-- Model New Model
-- Updated 6/14/2024 6:51:12 PM
-- DDL Generated 6/14/2024 6:51:16 PM

--**********************************************************************
--	Tables
--**********************************************************************

-- Table dbo.Komentar
-- Model New Model
-- Updated 6/14/2024 7:05:31 PM
-- DDL Generated 6/14/2024 7:05:34 PM

--**********************************************************************
--	Tables
--**********************************************************************

-- Table dbo.Komentar
-- Model New Model
-- Updated 6/14/2024 8:22:42 PM
-- DDL Generated 6/14/2024 8:22:44 PM

--**********************************************************************
--	Tables
--**********************************************************************

-- Table dbo.Komentar
create table
	[dbo].[Komentar]
(
	[komentarId] uniqueidentifier not null
	, [objavaId] uniqueidentifier not null
	, [korisnikId] uniqueidentifier not null
	, [imeKorisnika] nvarchar(50) not null
	, [komentarTekst] nvarchar(max) not null
	, [komentarMedia] image null
,
constraint [Pk_Komentar_komentarId] primary key clustered
(
	[komentarId] asc
)
);
GO
--**********************************************************************
--	Data
--**********************************************************************
--**********************************************************************
--	Relationships
--**********************************************************************

-- Relationship Fk_Korisnik_Komentar_korisnikId
--**********************************************************************
--	Data
--**********************************************************************
--**********************************************************************
--	Relationships
--**********************************************************************

-- Relationship Fk_Korisnik_Komentar_korisnikId
--**********************************************************************
--	Data
--**********************************************************************
--**********************************************************************
--	Relationships
--**********************************************************************

-- Relationship Fk_Korisnik_Komentar_korisnikId
--**********************************************************************
--	Data
--**********************************************************************
--**********************************************************************
--	Relationships
--**********************************************************************

-- Relationship Fk_Korisnik_Komentar_korisnikId
--**********************************************************************
--	Data
--**********************************************************************
--**********************************************************************
--	Relationships
--**********************************************************************

-- Relationship Fk_Korisnik_Komentar_korisnikId
--**********************************************************************
--	Data
--**********************************************************************
--**********************************************************************
--	Relationships
--**********************************************************************

-- Relationship Fk_Korisnik_Komentar_korisnikId
alter table [dbo].[Komentar]
add constraint [Fk_Korisnik_Komentar_korisnikId] foreign key ([korisnikId]) references [dbo].[Korisnik] ([korisnikId]);
GO
-- Relationship Fk_Objava_Komentar_objavaId
-- Relationship Fk_Objava_Komentar_objavaId
-- Relationship Fk_Objava_Komentar_objavaId
-- Relationship Fk_Objava_Komentar_objavaId
-- Relationship Fk_Objava_Komentar_objavaId
-- Relationship Fk_Objava_Komentar_objavaId
alter table [dbo].[Komentar]
add constraint [Fk_Objava_Komentar_objavaId] foreign key ([objavaId]) references [dbo].[Objava] ([objavaId]);