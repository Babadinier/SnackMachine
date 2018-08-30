CREATE TABLE [dbo].[Snack] (
    [SnackID] INT           IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Snack] PRIMARY KEY CLUSTERED ([SnackID] ASC)
);

