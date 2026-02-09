-- =============================================
-- Hotel Management System - Database Creation Script
-- Database: HotelManagementDB
-- SQL Server 2019+
-- =============================================

USE master;
GO

-- Drop database if exists (USE WITH CAUTION!)
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'HotelManagementDB')
BEGIN
    ALTER DATABASE HotelManagementDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE HotelManagementDB;
END
GO

-- Create new database
CREATE DATABASE HotelManagementDB;
GO

USE HotelManagementDB;
GO

-- =============================================
-- TABLE CREATION
-- =============================================

-- 1. Guests Table
CREATE TABLE Guests (
    GuestId INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    Phone NVARCHAR(20),
    IDNumber NVARCHAR(50) UNIQUE,
    Address NVARCHAR(500),
    DateOfBirth DATE,
    Nationality NVARCHAR(100),
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME NOT NULL DEFAULT GETDATE(),
    IsActive BIT NOT NULL DEFAULT 1
);

CREATE INDEX IX_Guests_Email ON Guests(Email);
CREATE INDEX IX_Guests_Phone ON Guests(Phone);
CREATE INDEX IX_Guests_LastName ON Guests(LastName);
GO

-- 2. Rooms Table
CREATE TABLE Rooms (
    RoomId INT PRIMARY KEY IDENTITY(1,1),
    RoomNumber NVARCHAR(10) NOT NULL UNIQUE,
    RoomType NVARCHAR(20) NOT NULL CHECK (RoomType IN ('Single', 'Double', 'Suite', 'Deluxe')),
    Status NVARCHAR(20) NOT NULL DEFAULT 'Available' 
        CHECK (Status IN ('Available', 'Occupied', 'Reserved', 'Maintenance', 'Cleaning')),
    BasePrice DECIMAL(10, 2) NOT NULL,
    FloorNumber INT NOT NULL,
    MaxOccupancy INT NOT NULL,
    BedType NVARCHAR(50),
    Area DECIMAL(6, 2), -- in square meters
    ViewType NVARCHAR(50),
    HasBalcony BIT DEFAULT 0,
    HasSeaView BIT DEFAULT 0,
    HasJacuzzi BIT DEFAULT 0,
    HasPrivatePool BIT DEFAULT 0,
    Amenities NVARCHAR(MAX), -- JSON format: ["WiFi", "TV", "MiniBar"]
    Description NVARCHAR(1000),
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME NOT NULL DEFAULT GETDATE()
);

CREATE INDEX IX_Rooms_Status ON Rooms(Status);
CREATE INDEX IX_Rooms_RoomType ON Rooms(RoomType);
CREATE INDEX IX_Rooms_RoomNumber ON Rooms(RoomNumber);
GO

-- 3. Users Table
CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Salt NVARCHAR(255) NOT NULL,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    Phone NVARCHAR(20),
    Role NVARCHAR(20) NOT NULL CHECK (Role IN ('Admin', 'Manager', 'Receptionist', 'Housekeeping')),
    IsActive BIT NOT NULL DEFAULT 1,
    LastLogin DATETIME,
    LastPasswordChange DATETIME,
    FailedLoginAttempts INT DEFAULT 0,
    LockedUntil DATETIME,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME NOT NULL DEFAULT GETDATE()
);

CREATE INDEX IX_Users_Username ON Users(Username);
CREATE INDEX IX_Users_Email ON Users(Email);
CREATE INDEX IX_Users_Role ON Users(Role);
GO

-- 4. Bookings Table
CREATE TABLE Bookings (
    BookingId INT PRIMARY KEY IDENTITY(1,1),
    GuestId INT NOT NULL,
    RoomId INT NOT NULL,
    CreatedByUserId INT NOT NULL,
    CheckInDate DATETIME NOT NULL,
    CheckOutDate DATETIME NOT NULL,
    ActualCheckInDate DATETIME,
    ActualCheckOutDate DATETIME,
    Status NVARCHAR(20) NOT NULL DEFAULT 'Pending' 
        CHECK (Status IN ('Pending', 'Confirmed', 'CheckedIn', 'CheckedOut', 'Cancelled')),
    NumberOfGuests INT NOT NULL DEFAULT 1,
    RoomCharges DECIMAL(10, 2) NOT NULL DEFAULT 0,
    ServiceCharges DECIMAL(10, 2) NOT NULL DEFAULT 0,
    TotalAmount DECIMAL(10, 2) NOT NULL DEFAULT 0,
    SpecialRequests NVARCHAR(1000),
    Notes NVARCHAR(1000),
    BookingDate DATETIME NOT NULL DEFAULT GETDATE(),
    CancelledDate DATETIME,
    CancellationReason NVARCHAR(500),
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Bookings_Guests FOREIGN KEY (GuestId) REFERENCES Guests(GuestId),
    CONSTRAINT FK_Bookings_Rooms FOREIGN KEY (RoomId) REFERENCES Rooms(RoomId),
    CONSTRAINT FK_Bookings_Users FOREIGN KEY (CreatedByUserId) REFERENCES Users(UserId),
    CONSTRAINT CHK_Bookings_Dates CHECK (CheckOutDate > CheckInDate)
);

CREATE INDEX IX_Bookings_GuestId ON Bookings(GuestId);
CREATE INDEX IX_Bookings_RoomId ON Bookings(RoomId);
CREATE INDEX IX_Bookings_Status ON Bookings(Status);
CREATE INDEX IX_Bookings_CheckInDate ON Bookings(CheckInDate);
CREATE INDEX IX_Bookings_CheckOutDate ON Bookings(CheckOutDate);
GO

-- 5. Invoices Table
CREATE TABLE Invoices (
    InvoiceId INT PRIMARY KEY IDENTITY(1,1),
    BookingId INT NOT NULL UNIQUE,
    InvoiceNumber NVARCHAR(50) NOT NULL UNIQUE,
    IssueDate DATETIME NOT NULL DEFAULT GETDATE(),
    DueDate DATETIME NOT NULL,
    SubTotal DECIMAL(10, 2) NOT NULL,
    TaxRate DECIMAL(5, 2) NOT NULL DEFAULT 0,
    TaxAmount DECIMAL(10, 2) NOT NULL DEFAULT 0,
    Discount DECIMAL(10, 2) NOT NULL DEFAULT 0,
    TotalAmount DECIMAL(10, 2) NOT NULL,
    PaidAmount DECIMAL(10, 2) NOT NULL DEFAULT 0,
    BalanceAmount DECIMAL(10, 2) NOT NULL,
    Status NVARCHAR(20) NOT NULL DEFAULT 'Pending' 
        CHECK (Status IN ('Pending', 'Paid', 'PartiallyPaid', 'Cancelled')),
    PaymentTerms NVARCHAR(200),
    Notes NVARCHAR(1000),
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Invoices_Bookings FOREIGN KEY (BookingId) REFERENCES Bookings(BookingId)
);

CREATE INDEX IX_Invoices_InvoiceNumber ON Invoices(InvoiceNumber);
CREATE INDEX IX_Invoices_Status ON Invoices(Status);
CREATE INDEX IX_Invoices_BookingId ON Invoices(BookingId);
GO

-- 6. Payments Table
CREATE TABLE Payments (
    PaymentId INT PRIMARY KEY IDENTITY(1,1),
    InvoiceId INT NOT NULL,
    Amount DECIMAL(10, 2) NOT NULL,
    PaymentDate DATETIME NOT NULL DEFAULT GETDATE(),
    PaymentMethod NVARCHAR(20) NOT NULL 
        CHECK (PaymentMethod IN ('Cash', 'CreditCard', 'DebitCard', 'OnlineTransfer', 'Check')),
    TransactionId NVARCHAR(100),
    CardNumber NVARCHAR(20), -- Store last 4 digits only for security
    CardHolderName NVARCHAR(100),
    PaymentGateway NVARCHAR(50),
    Status NVARCHAR(20) NOT NULL DEFAULT 'Completed' 
        CHECK (Status IN ('Pending', 'Completed', 'Failed', 'Refunded')),
    Notes NVARCHAR(500),
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    ProcessedByUserId INT,
    CONSTRAINT FK_Payments_Invoices FOREIGN KEY (InvoiceId) REFERENCES Invoices(InvoiceId),
    CONSTRAINT FK_Payments_Users FOREIGN KEY (ProcessedByUserId) REFERENCES Users(UserId)
);

CREATE INDEX IX_Payments_InvoiceId ON Payments(InvoiceId);
CREATE INDEX IX_Payments_PaymentDate ON Payments(PaymentDate);
CREATE INDEX IX_Payments_PaymentMethod ON Payments(PaymentMethod);
GO

-- 7. AdditionalServices Table
CREATE TABLE AdditionalServices (
    ServiceId INT PRIMARY KEY IDENTITY(1,1),
    ServiceName NVARCHAR(100) NOT NULL UNIQUE,
    Category NVARCHAR(50) NOT NULL 
        CHECK (Category IN ('RoomService', 'Laundry', 'Spa', 'Transport', 'Other')),
    Price DECIMAL(10, 2) NOT NULL,
    Description NVARCHAR(500),
    Unit NVARCHAR(20) NOT NULL DEFAULT 'Fixed' 
        CHECK (Unit IN ('PerPerson', 'PerItem', 'PerHour', 'Fixed')),
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME NOT NULL DEFAULT GETDATE()
);

CREATE INDEX IX_AdditionalServices_Category ON AdditionalServices(Category);
CREATE INDEX IX_AdditionalServices_IsActive ON AdditionalServices(IsActive);
GO

-- 8. BookingServices Junction Table
CREATE TABLE BookingServices (
    BookingServiceId INT PRIMARY KEY IDENTITY(1,1),
    BookingId INT NOT NULL,
    ServiceId INT NOT NULL,
    Quantity INT NOT NULL DEFAULT 1,
    UnitPrice DECIMAL(10, 2) NOT NULL,
    TotalPrice DECIMAL(10, 2) NOT NULL,
    ServiceDate DATETIME NOT NULL DEFAULT GETDATE(),
    Status NVARCHAR(20) NOT NULL DEFAULT 'Pending' 
        CHECK (Status IN ('Pending', 'Completed', 'Cancelled')),
    Notes NVARCHAR(500),
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_BookingServices_Bookings FOREIGN KEY (BookingId) REFERENCES Bookings(BookingId) ON DELETE CASCADE,
    CONSTRAINT FK_BookingServices_Services FOREIGN KEY (ServiceId) REFERENCES AdditionalServices(ServiceId)
);

CREATE INDEX IX_BookingServices_BookingId ON BookingServices(BookingId);
CREATE INDEX IX_BookingServices_ServiceId ON BookingServices(ServiceId);
GO

-- 9. HousekeepingTasks Table
CREATE TABLE HousekeepingTasks (
    TaskId INT PRIMARY KEY IDENTITY(1,1),
    RoomId INT NOT NULL,
    AssignedToUserId INT,
    TaskType NVARCHAR(20) NOT NULL CHECK (TaskType IN ('Cleaning', 'Maintenance', 'Inspection')),
    Priority NVARCHAR(20) NOT NULL DEFAULT 'Medium' 
        CHECK (Priority IN ('Low', 'Medium', 'High', 'Urgent')),
    Status NVARCHAR(20) NOT NULL DEFAULT 'Pending' 
        CHECK (Status IN ('Pending', 'InProgress', 'Completed', 'Cancelled')),
    ScheduledDate DATETIME NOT NULL,
    StartTime DATETIME,
    EndTime DATETIME,
    Notes NVARCHAR(1000),
    CompletionNotes NVARCHAR(1000),
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    CreatedByUserId INT NOT NULL,
    CONSTRAINT FK_HousekeepingTasks_Rooms FOREIGN KEY (RoomId) REFERENCES Rooms(RoomId),
    CONSTRAINT FK_HousekeepingTasks_AssignedUser FOREIGN KEY (AssignedToUserId) REFERENCES Users(UserId),
    CONSTRAINT FK_HousekeepingTasks_CreatedUser FOREIGN KEY (CreatedByUserId) REFERENCES Users(UserId)
);

CREATE INDEX IX_HousekeepingTasks_RoomId ON HousekeepingTasks(RoomId);
CREATE INDEX IX_HousekeepingTasks_AssignedToUserId ON HousekeepingTasks(AssignedToUserId);
CREATE INDEX IX_HousekeepingTasks_Status ON HousekeepingTasks(Status);
CREATE INDEX IX_HousekeepingTasks_ScheduledDate ON HousekeepingTasks(ScheduledDate);
GO

-- 10. AuditLogs Table
CREATE TABLE AuditLogs (
    LogId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT,
    Action NVARCHAR(100) NOT NULL,
    TableName NVARCHAR(100) NOT NULL,
    RecordId INT,
    OldValue NVARCHAR(MAX),
    NewValue NVARCHAR(MAX),
    IPAddress NVARCHAR(50),
    Timestamp DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_AuditLogs_Users FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

CREATE INDEX IX_AuditLogs_UserId ON AuditLogs(UserId);
CREATE INDEX IX_AuditLogs_TableName ON AuditLogs(TableName);
CREATE INDEX IX_AuditLogs_Timestamp ON AuditLogs(Timestamp);
GO

-- 11. SystemSettings Table
CREATE TABLE SystemSettings (
    SettingId INT PRIMARY KEY IDENTITY(1,1),
    SettingKey NVARCHAR(100) NOT NULL UNIQUE,
    SettingValue NVARCHAR(MAX) NOT NULL,
    DataType NVARCHAR(20) NOT NULL CHECK (DataType IN ('String', 'Integer', 'Decimal', 'Boolean', 'JSON')),
    Category NVARCHAR(50),
    Description NVARCHAR(500),
    ModifiedDate DATETIME NOT NULL DEFAULT GETDATE(),
    ModifiedByUserId INT,
    CONSTRAINT FK_SystemSettings_Users FOREIGN KEY (ModifiedByUserId) REFERENCES Users(UserId)
);

CREATE INDEX IX_SystemSettings_SettingKey ON SystemSettings(SettingKey);
CREATE INDEX IX_SystemSettings_Category ON SystemSettings(Category);
GO

-- 12. Notifications Table
CREATE TABLE Notifications (
    NotificationId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    Title NVARCHAR(200) NOT NULL,
    Message NVARCHAR(1000) NOT NULL,
    Type NVARCHAR(20) NOT NULL CHECK (Type IN ('Info', 'Warning', 'Error', 'Success')),
    Category NVARCHAR(50) NOT NULL CHECK (Category IN ('Booking', 'Payment', 'Housekeeping', 'System')),
    IsRead BIT NOT NULL DEFAULT 0,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    ReadDate DATETIME,
    CONSTRAINT FK_Notifications_Users FOREIGN KEY (UserId) REFERENCES Users(UserId) ON DELETE CASCADE
);

CREATE INDEX IX_Notifications_UserId ON Notifications(UserId);
CREATE INDEX IX_Notifications_IsRead ON Notifications(IsRead);
CREATE INDEX IX_Notifications_CreatedDate ON Notifications(CreatedDate);
GO

-- =============================================
-- STORED PROCEDURES
-- =============================================

-- Procedure to get available rooms for a date range
CREATE PROCEDURE sp_GetAvailableRooms
    @CheckInDate DATETIME,
    @CheckOutDate DATETIME,
    @RoomType NVARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        R.*
    FROM Rooms R
    WHERE R.Status IN ('Available', 'Cleaning')
        AND (@RoomType IS NULL OR R.RoomType = @RoomType)
        AND R.RoomId NOT IN (
            SELECT DISTINCT RoomId 
            FROM Bookings 
            WHERE Status IN ('Confirmed', 'CheckedIn', 'Pending')
                AND (
                    (@CheckInDate BETWEEN CheckInDate AND CheckOutDate)
                    OR (@CheckOutDate BETWEEN CheckInDate AND CheckOutDate)
                    OR (CheckInDate BETWEEN @CheckInDate AND @CheckOutDate)
                )
        )
    ORDER BY R.RoomType, R.RoomNumber;
END
GO

-- Procedure to create a new booking
CREATE PROCEDURE sp_CreateBooking
    @GuestId INT,
    @RoomId INT,
    @CreatedByUserId INT,
    @CheckInDate DATETIME,
    @CheckOutDate DATETIME,
    @NumberOfGuests INT,
    @SpecialRequests NVARCHAR(1000) = NULL,
    @BookingId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    
    BEGIN TRY
        -- Calculate room charges
        DECLARE @BasePrice DECIMAL(10,2);
        DECLARE @NumberOfDays INT;
        DECLARE @RoomCharges DECIMAL(10,2);
        
        SELECT @BasePrice = BasePrice FROM Rooms WHERE RoomId = @RoomId;
        SET @NumberOfDays = DATEDIFF(DAY, @CheckInDate, @CheckOutDate);
        SET @RoomCharges = @BasePrice * @NumberOfDays;
        
        -- Insert booking
        INSERT INTO Bookings (
            GuestId, RoomId, CreatedByUserId, CheckInDate, CheckOutDate, 
            NumberOfGuests, RoomCharges, TotalAmount, SpecialRequests, Status
        )
        VALUES (
            @GuestId, @RoomId, @CreatedByUserId, @CheckInDate, @CheckOutDate,
            @NumberOfGuests, @RoomCharges, @RoomCharges, @SpecialRequests, 'Confirmed'
        );
        
        SET @BookingId = SCOPE_IDENTITY();
        
        -- Update room status
        UPDATE Rooms SET Status = 'Reserved' WHERE RoomId = @RoomId;
        
        COMMIT TRANSACTION;
        
        SELECT @BookingId AS BookingId;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- Procedure to process check-in
CREATE PROCEDURE sp_ProcessCheckIn
    @BookingId INT,
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    
    BEGIN TRY
        DECLARE @RoomId INT;
        
        SELECT @RoomId = RoomId FROM Bookings WHERE BookingId = @BookingId;
        
        -- Update booking
        UPDATE Bookings 
        SET Status = 'CheckedIn',
            ActualCheckInDate = GETDATE(),
            ModifiedDate = GETDATE()
        WHERE BookingId = @BookingId;
        
        -- Update room status
        UPDATE Rooms SET Status = 'Occupied', ModifiedDate = GETDATE() WHERE RoomId = @RoomId;
        
        COMMIT TRANSACTION;
        
        SELECT 'Check-in processed successfully' AS Result;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- Procedure to process check-out
CREATE PROCEDURE sp_ProcessCheckOut
    @BookingId INT,
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    
    BEGIN TRY
        DECLARE @RoomId INT;
        DECLARE @InvoiceExists BIT;
        
        SELECT @RoomId = RoomId FROM Bookings WHERE BookingId = @BookingId;
        
        -- Check if invoice exists
        SELECT @InvoiceExists = CASE WHEN COUNT(*) > 0 THEN 1 ELSE 0 END
        FROM Invoices WHERE BookingId = @BookingId;
        
        -- Create invoice if not exists
        IF @InvoiceExists = 0
        BEGIN
            DECLARE @InvoiceNumber NVARCHAR(50);
            DECLARE @SubTotal DECIMAL(10,2);
            DECLARE @TaxRate DECIMAL(5,2);
            DECLARE @TaxAmount DECIMAL(10,2);
            DECLARE @TotalAmount DECIMAL(10,2);
            
            SET @InvoiceNumber = 'INV' + FORMAT(GETDATE(), 'yyyyMMdd') + '-' + CAST(@BookingId AS NVARCHAR(10));
            
            SELECT 
                @SubTotal = TotalAmount,
                @TaxRate = CAST((SELECT SettingValue FROM SystemSettings WHERE SettingKey = 'TaxRate') AS DECIMAL(5,2))
            FROM Bookings WHERE BookingId = @BookingId;
            
            SET @TaxAmount = @SubTotal * (@TaxRate / 100);
            SET @TotalAmount = @SubTotal + @TaxAmount;
            
            INSERT INTO Invoices (
                BookingId, InvoiceNumber, SubTotal, TaxRate, TaxAmount, 
                TotalAmount, BalanceAmount, DueDate, Status
            )
            VALUES (
                @BookingId, @InvoiceNumber, @SubTotal, @TaxRate, @TaxAmount,
                @TotalAmount, @TotalAmount, GETDATE(), 'Pending'
            );
        END
        
        -- Update booking
        UPDATE Bookings 
        SET Status = 'CheckedOut',
            ActualCheckOutDate = GETDATE(),
            ModifiedDate = GETDATE()
        WHERE BookingId = @BookingId;
        
        -- Update room status
        UPDATE Rooms SET Status = 'Cleaning', ModifiedDate = GETDATE() WHERE RoomId = @RoomId;
        
        -- Create housekeeping task
        INSERT INTO HousekeepingTasks (RoomId, TaskType, Priority, Status, ScheduledDate, CreatedByUserId)
        VALUES (@RoomId, 'Cleaning', 'High', 'Pending', GETDATE(), @UserId);
        
        COMMIT TRANSACTION;
        
        SELECT 'Check-out processed successfully' AS Result;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- =============================================
-- VIEWS
-- =============================================

-- View for current occupancy status
CREATE VIEW vw_CurrentOccupancy
AS
SELECT 
    R.RoomId,
    R.RoomNumber,
    R.RoomType,
    R.Status,
    B.BookingId,
    G.FirstName + ' ' + G.LastName AS GuestName,
    B.CheckInDate,
    B.CheckOutDate,
    B.NumberOfGuests
FROM Rooms R
LEFT JOIN Bookings B ON R.RoomId = B.RoomId 
    AND B.Status IN ('Confirmed', 'CheckedIn')
    AND GETDATE() BETWEEN B.CheckInDate AND B.CheckOutDate
LEFT JOIN Guests G ON B.GuestId = G.GuestId;
GO

-- View for booking summary with guest and room details
CREATE VIEW vw_BookingSummary
AS
SELECT 
    B.BookingId,
    B.BookingDate,
    B.Status AS BookingStatus,
    G.FirstName + ' ' + G.LastName AS GuestName,
    G.Email AS GuestEmail,
    G.Phone AS GuestPhone,
    R.RoomNumber,
    R.RoomType,
    B.CheckInDate,
    B.CheckOutDate,
    B.NumberOfGuests,
    B.TotalAmount,
    U.FirstName + ' ' + U.LastName AS CreatedBy
FROM Bookings B
INNER JOIN Guests G ON B.GuestId = G.GuestId
INNER JOIN Rooms R ON B.RoomId = R.RoomId
INNER JOIN Users U ON B.CreatedByUserId = U.UserId;
GO

-- View for revenue report
CREATE VIEW vw_RevenueReport
AS
SELECT 
    YEAR(B.BookingDate) AS Year,
    MONTH(B.BookingDate) AS Month,
    DATENAME(MONTH, B.BookingDate) AS MonthName,
    COUNT(B.BookingId) AS TotalBookings,
    SUM(B.TotalAmount) AS TotalRevenue,
    AVG(B.TotalAmount) AS AverageBookingValue,
    COUNT(DISTINCT B.GuestId) AS UniqueGuests
FROM Bookings B
WHERE B.Status != 'Cancelled'
GROUP BY YEAR(B.BookingDate), MONTH(B.BookingDate), DATENAME(MONTH, B.BookingDate);
GO

-- =============================================
-- SAMPLE DATA INSERTION
-- =============================================

-- Insert default admin user
-- Password: Admin@123 (This is a sample hash - you should use proper password hashing in your application)
INSERT INTO Users (Username, PasswordHash, Salt, FirstName, LastName, Email, Role, LastPasswordChange)
VALUES ('admin', 'A665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3', 
        'SampleSaltValue123', 'System', 'Administrator', 'admin@hotel.com', 'Admin', GETDATE());

-- Insert sample staff users
INSERT INTO Users (Username, PasswordHash, Salt, FirstName, LastName, Email, Role)
VALUES 
    ('receptionist1', 'hash_here', 'salt_here', 'John', 'Doe', 'john.doe@hotel.com', 'Receptionist'),
    ('manager1', 'hash_here', 'salt_here', 'Jane', 'Smith', 'jane.smith@hotel.com', 'Manager'),
    ('housekeeping1', 'hash_here', 'salt_here', 'Maria', 'Garcia', 'maria.garcia@hotel.com', 'Housekeeping');

-- Insert sample rooms
INSERT INTO Rooms (RoomNumber, RoomType, BasePrice, FloorNumber, MaxOccupancy, BedType, Area, ViewType, Description)
VALUES 
    -- Floor 1 - Single Rooms
    ('101', 'Single', 50.00, 1, 1, 'Single', 20.00, 'Garden', 'Cozy single room with garden view'),
    ('102', 'Single', 50.00, 1, 1, 'Single', 20.00, 'Garden', 'Cozy single room with garden view'),
    ('103', 'Single', 55.00, 1, 1, 'Single', 22.00, 'Street', 'Single room with street view'),
    
    -- Floor 2 - Double Rooms
    ('201', 'Double', 80.00, 2, 2, 'Queen', 30.00, 'City', 'Comfortable double room with city view'),
    ('202', 'Double', 80.00, 2, 2, 'Queen', 30.00, 'City', 'Comfortable double room with city view'),
    ('203', 'Double', 90.00, 2, 2, 'King', 32.00, 'Sea', 'Double room with sea view'),
    ('204', 'Double', 90.00, 2, 2, 'King', 32.00, 'Sea', 'Double room with sea view'),
    
    -- Floor 3 - Suite Rooms
    ('301', 'Suite', 150.00, 3, 4, 'King', 50.00, 'Sea', 'Luxury suite with separate living area and sea view'),
    ('302', 'Suite', 150.00, 3, 4, 'King', 50.00, 'City', 'Luxury suite with separate living area and city view'),
    
    -- Floor 4 - Deluxe Rooms
    ('401', 'Deluxe', 250.00, 4, 4, 'King', 70.00, 'Sea', 'Premium deluxe room with private balcony and jacuzzi');

-- Update room amenities (as JSON)
UPDATE Rooms SET Amenities = '["WiFi", "TV", "Air Conditioning", "Phone"]' WHERE RoomType = 'Single';
UPDATE Rooms SET Amenities = '["WiFi", "TV", "Air Conditioning", "Mini Bar", "Safe", "Phone"]' WHERE RoomType = 'Double';
UPDATE Rooms SET Amenities = '["WiFi", "Smart TV", "Air Conditioning", "Mini Bar", "Safe", "Coffee Maker", "Balcony", "Phone"]' WHERE RoomType = 'Suite';
UPDATE Rooms SET Amenities = '["WiFi", "Smart TV", "Air Conditioning", "Mini Bar", "Safe", "Coffee Maker", "Balcony", "Jacuzzi", "Sea View", "Phone"]' WHERE RoomType = 'Deluxe';

UPDATE Rooms SET HasBalcony = 1 WHERE RoomType IN ('Suite', 'Deluxe');
UPDATE Rooms SET HasSeaView = 1 WHERE ViewType = 'Sea';
UPDATE Rooms SET HasJacuzzi = 1 WHERE RoomType = 'Deluxe';

-- Insert sample services
INSERT INTO AdditionalServices (ServiceName, Category, Price, Unit, Description)
VALUES 
    ('Breakfast Buffet', 'RoomService', 15.00, 'PerPerson', 'All-you-can-eat breakfast buffet'),
    ('Room Service - Dinner', 'RoomService', 25.00, 'PerPerson', 'In-room dinner service'),
    ('Laundry Service', 'Laundry', 10.00, 'PerItem', 'Professional laundry and dry cleaning'),
    ('Airport Transfer', 'Transport', 50.00, 'Fixed', 'One-way airport pickup or drop-off'),
    ('Spa Package - Basic', 'Spa', 80.00, 'PerPerson', '60-minute massage and facial'),
    ('Spa Package - Premium', 'Spa', 150.00, 'PerPerson', '120-minute full body treatment'),
    ('Extra Bed', 'Other', 20.00, 'Fixed', 'Additional bed in room'),
    ('Late Checkout', 'Other', 30.00, 'Fixed', 'Checkout after 2 PM');

-- Insert system settings
INSERT INTO SystemSettings (SettingKey, SettingValue, DataType, Category, Description)
VALUES 
    ('TaxRate', '10.0', 'Decimal', 'Billing', 'Tax rate percentage applied to all invoices'),
    ('CancellationPenalty', '20.0', 'Decimal', 'Booking', 'Cancellation penalty percentage of total booking'),
    ('CheckInTime', '14:00', 'String', 'Booking', 'Standard check-in time'),
    ('CheckOutTime', '11:00', 'String', 'Booking', 'Standard check-out time'),
    ('MaxAdvanceBookingDays', '365', 'Integer', 'Booking', 'Maximum days in advance for booking'),
    ('MinimumStayNights', '1', 'Integer', 'Booking', 'Minimum number of nights for booking'),
    ('HotelName', 'Grand Paradise Hotel', 'String', 'General', 'Hotel name'),
    ('HotelAddress', '123 Beach Road, Paradise City', 'String', 'General', 'Hotel address'),
    ('HotelPhone', '+1-555-HOTEL', 'String', 'General', 'Hotel contact phone'),
    ('HotelEmail', 'info@grandparadise.com', 'String', 'General', 'Hotel contact email'),
    ('Currency', 'USD', 'String', 'Billing', 'Currency code');

-- Insert sample guests
INSERT INTO Guests (FirstName, LastName, Email, Phone, IDNumber, Address, DateOfBirth, Nationality)
VALUES 
    ('Michael', 'Johnson', 'michael.j@email.com', '+1-555-0101', 'ID001234', '456 Oak Street, Cityville', '1985-06-15', 'USA'),
    ('Sarah', 'Williams', 'sarah.w@email.com', '+1-555-0102', 'ID001235', '789 Pine Avenue, Townsville', '1990-03-22', 'USA'),
    ('David', 'Brown', 'david.b@email.com', '+1-555-0103', 'ID001236', '321 Maple Drive, Villageton', '1978-11-08', 'Canada'),
    ('Emma', 'Davis', 'emma.d@email.com', '+1-555-0104', 'ID001237', '654 Cedar Lane, Hamletville', '1995-01-30', 'UK');

-- Insert sample bookings (for testing)
DECLARE @AdminUserId INT;
SELECT @AdminUserId = UserId FROM Users WHERE Username = 'admin';

INSERT INTO Bookings (GuestId, RoomId, CreatedByUserId, CheckInDate, CheckOutDate, NumberOfGuests, Status, RoomCharges, TotalAmount)
VALUES 
    (1, 1, @AdminUserId, DATEADD(DAY, 1, GETDATE()), DATEADD(DAY, 3, GETDATE()), 1, 'Confirmed', 100.00, 100.00),
    (2, 4, @AdminUserId, DATEADD(DAY, 2, GETDATE()), DATEADD(DAY, 5, GETDATE()), 2, 'Confirmed', 240.00, 240.00);

GO

-- =============================================
-- VERIFICATION QUERIES
-- =============================================

PRINT '========================================';
PRINT 'Database created successfully!';
PRINT '========================================';
PRINT '';
PRINT 'Table counts:';
SELECT 'Guests' AS TableName, COUNT(*) AS RecordCount FROM Guests
UNION ALL
SELECT 'Rooms', COUNT(*) FROM Rooms
UNION ALL
SELECT 'Users', COUNT(*) FROM Users
UNION ALL
SELECT 'Bookings', COUNT(*) FROM Bookings
UNION ALL
SELECT 'AdditionalServices', COUNT(*) FROM AdditionalServices
UNION ALL
SELECT 'SystemSettings', COUNT(*) FROM SystemSettings;

PRINT '';
PRINT 'Default Admin Credentials:';
PRINT 'Username: admin';
PRINT 'Password: Admin@123 (CHANGE THIS IMMEDIATELY!)';
PRINT '';
PRINT '========================================';

GO
