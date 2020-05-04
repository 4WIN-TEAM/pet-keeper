USE [PetKeeper]
ALTER TABLE 
[dbo].[Podaci]
ADD [UserName] [nvarchar](256) DEFAULT 'petkeeper2020@gmail.com' NOT NULL;
GO