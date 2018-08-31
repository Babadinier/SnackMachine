CREATE TABLE [dbo].[Atm] (
    [AtmID]             INT             IDENTITY (1, 1) NOT NULL,
    [MoneyCharged]      DECIMAL (18, 2) NOT NULL,
    [OneCentCount]      INT             NOT NULL,
    [TenCentCount]      INT             NOT NULL,
    [QuarterCentCount]  INT             NOT NULL,
    [OneDollarCount]    INT             NOT NULL,
    [FiveDollarCount]   INT             NOT NULL,
    [TwentyDollarCount] INT             NOT NULL,
    CONSTRAINT [PK_Atm] PRIMARY KEY CLUSTERED ([AtmID] ASC)
);

