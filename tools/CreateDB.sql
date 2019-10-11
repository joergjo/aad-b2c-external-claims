USE [CustomerDB]
GO

/****** Object: Table [dbo].[UserProfiles] Script Date: 23.09.2019 09:31:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[UserProfiles];


GO
CREATE TABLE [dbo].[UserProfiles] (
    [Id]				INT            IDENTITY (1, 1) NOT NULL,
    [UserIdentifier]    NVARCHAR (255) NOT NULL,
    [CustomerNumber]	NVARCHAR (36)  NOT NULL,
    [Status]			SMALLINT       NOT NULL
);


