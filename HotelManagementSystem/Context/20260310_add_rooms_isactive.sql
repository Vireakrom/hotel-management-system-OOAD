USE HotelManagementDB;
GO

IF COL_LENGTH('dbo.Rooms', 'IsActive') IS NULL
BEGIN
    ALTER TABLE dbo.Rooms
    ADD IsActive BIT NOT NULL
        CONSTRAINT DF_Rooms_IsActive DEFAULT 1 WITH VALUES;
END
GO

IF NOT EXISTS (
    SELECT 1
    FROM sys.indexes
    WHERE name = 'IX_Rooms_IsActive'
      AND object_id = OBJECT_ID('dbo.Rooms')
)
BEGIN
    CREATE INDEX IX_Rooms_IsActive ON dbo.Rooms(IsActive);
END
GO

PRINT 'Rooms.IsActive migration complete.';
PRINT 'Review existing rooms that were previously "deleted" via Status = ''Maintenance'' before marking any of them inactive.';
GO
