CREATE TABLE [dbo].[Child]
(
    [Id] int not null primary key identity,
    [ParentId] int not null,
    [Name] nvarchar(64) not null,
    [Value] int not null, 
    CONSTRAINT [CK_Child_Value] CHECK ([Value] between 1 and 10), 
    CONSTRAINT [AK_Child_Name] UNIQUE ([Name]), 
    CONSTRAINT [FK_Child_ToParent] FOREIGN KEY ([ParentId]) REFERENCES [Parent]([Id])
)
GO

CREATE UNIQUE INDEX [IX_Child_Value] ON [dbo].[Child] ([Value])
