USE [PetKeeper]
ALTER TABLE 
[dbo].[Podaci]
ADD [DatumOdjave] [datetime] DEFAULT '2020-01-05 00:00:00.000' NOT NULL;
GO