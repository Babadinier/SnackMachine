CREATE TABLE [dbo].[Slot] (
    [SlotID]         INT             IDENTITY (1, 1) NOT NULL,
    [Quantity]       INT             NOT NULL,
    [Price]          DECIMAL (18, 2) NOT NULL,
    [SnackID]        INT             NOT NULL,
    [SnackMachineID] INT             NOT NULL,
    [Position]       INT             NOT NULL,
    CONSTRAINT [PK_Slot] PRIMARY KEY CLUSTERED ([SlotID] ASC),
    CONSTRAINT [FK_Slot_Slot] FOREIGN KEY ([SlotID]) REFERENCES [dbo].[Slot] ([SlotID]),
    CONSTRAINT [FK_Slot_Snack] FOREIGN KEY ([SnackID]) REFERENCES [dbo].[Snack] ([SnackID]),
    CONSTRAINT [FK_Slot_SnackMachine] FOREIGN KEY ([SnackMachineID]) REFERENCES [dbo].[SnackMachine] ([SnackMachineID])
);

