CREATE TABLE [dbo].[SnackMachine] (
    [SnackMachineID]    INT IDENTITY (1, 1) NOT NULL,
    [OneCentCount]      INT NOT NULL,
    [TenCentCount]      INT NOT NULL,
    [QuarterCentCount]  INT NOT NULL,
    [OneDollarCount]    INT NOT NULL,
    [FiveDollarCount]   INT NOT NULL,
    [TwentyDollarCount] INT NOT NULL,
    CONSTRAINT [PK_SnackMachine] PRIMARY KEY CLUSTERED ([SnackMachineID] ASC)
);

