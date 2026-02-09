# Day 2 Implementation Guide - Repository Pattern
## Hotel Management System | Feb 4, 2025

**Time Allocated:** 2 hours  
**Goal:** Implement Repository pattern with GuestRepository and begin RoomRepository

---

## 📋 Today's Tasks Checklist

- [ ] Create IRepository<T> generic interface
- [ ] Implement GuestRepository with full CRUD
- [ ] Test all Guest CRUD operations
- [ ] Begin RoomRepository implementation
- [ ] Verify database operations work correctly

---

## 🎯 Design Pattern: Repository Pattern

**Purpose:** Abstract all data access logic away from business logic  
**Benefits:** 
- Separation of concerns
- Easier testing (can mock repositories)
- Centralized data access code
- Database-agnostic business logic

**Pattern Count:** 2/5 patterns complete after today ✓

---

## 📁 Files to Create Today

1. `DAL/IRepository.cs` - Generic repository interface
2. `DAL/GuestRepository.cs` - Guest data access implementation
3. `DAL/RoomRepository.cs` - Room data access implementation (start)
4. `DAL/UserRepository.cs` - User data access (bonus if time permits)

---

## ⏱️ Time Breakdown

| Task | Duration | Notes |
|------|----------|-------|
| Create IRepository<T> interface | 15 min | Generic interface with CRUD methods |
| Implement GuestRepository | 45 min | Insert, Update, Delete, GetById, GetAll |
| Test Guest CRUD operations | 30 min | Verify all database operations work |
| Begin RoomRepository | 30 min | At minimum: GetAll and GetById |

**Total:** 2 hours

---

## 🚀 Let's Begin!

### Step 1: Create IRepository<T> Interface

This generic interface defines the contract for all repositories.

**File:** `DAL/IRepository.cs`

```csharp
using System.Collections.Generic;

namespace HotelManagementSystem.DAL
{
    /// <summary>
    /// Generic Repository Pattern interface
    /// Defines standard CRUD operations for all entities
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    public interface IRepository<T> where T : class
    {
        // Create
        int Insert(T entity);
        
        // Read
        T GetById(int id);
        List<T> GetAll();
        
        // Update
        bool Update(T entity);
        
        // Delete
        bool Delete(int id);
    }
}
```

---

### Step 2: Implement GuestRepository

**File:** `DAL/GuestRepository.cs`

```csharp
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.DAL
{
    public class GuestRepository : IRepository<Guest>
    {
        /// <summary>
        /// Insert a new guest into the database
        /// </summary>
        public int Insert(Guest guest)
        {
            string query = @"
                INSERT INTO Guests (FirstName, LastName, Email, Phone, IDNumber, DateOfBirth, Address, Nationality)
                VALUES (@FirstName, @LastName, @Email, @Phone, @IDNumber, @DateOfBirth, @Address, @Nationality);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", guest.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", guest.LastName);
                    cmd.Parameters.AddWithValue("@Email", guest.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Phone", guest.Phone ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IDNumber", guest.IDNumber ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateOfBirth", guest.DateOfBirth.HasValue ? (object)guest.DateOfBirth.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", guest.Address ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Nationality", guest.Nationality ?? (object)DBNull.Value);

                    conn.Open();
                    int newId = (int)cmd.ExecuteScalar();
                    return newId;
                }
            }
        }

        /// <summary>
        /// Get guest by ID
        /// </summary>
        public Guest GetById(int id)
        {
            string query = "SELECT * FROM Guests WHERE GuestId = @GuestId AND IsActive = 1";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@GuestId", id);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapReaderToGuest(reader);
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Get all active guests
        /// </summary>
        public List<Guest> GetAll()
        {
            List<Guest> guests = new List<Guest>();
            string query = "SELECT * FROM Guests WHERE IsActive = 1 ORDER BY LastName, FirstName";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            guests.Add(MapReaderToGuest(reader));
                        }
                    }
                }
            }
            return guests;
        }

        /// <summary>
        /// Update existing guest
        /// </summary>
        public bool Update(Guest guest)
        {
            string query = @"
                UPDATE Guests 
                SET FirstName = @FirstName,
                    LastName = @LastName,
                    Email = @Email,
                    Phone = @Phone,
                    IDNumber = @IDNumber,
                    DateOfBirth = @DateOfBirth,
                    Address = @Address,
                    Nationality = @Nationality,
                    ModifiedDate = GETDATE()
                WHERE GuestId = @GuestId";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@GuestId", guest.GuestId);
                    cmd.Parameters.AddWithValue("@FirstName", guest.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", guest.LastName);
                    cmd.Parameters.AddWithValue("@Email", guest.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Phone", guest.Phone ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IDNumber", guest.IDNumber ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateOfBirth", guest.DateOfBirth.HasValue ? (object)guest.DateOfBirth.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", guest.Address ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Nationality", guest.Nationality ?? (object)DBNull.Value);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        /// <summary>
        /// Soft delete guest (set IsActive = 0)
        /// </summary>
        public bool Delete(int id)
        {
            string query = "UPDATE Guests SET IsActive = 0, ModifiedDate = GETDATE() WHERE GuestId = @GuestId";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@GuestId", id);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        /// <summary>
        /// Search guests by name, email, or phone
        /// </summary>
        public List<Guest> Search(string searchTerm)
        {
            List<Guest> guests = new List<Guest>();
            string query = @"
                SELECT * FROM Guests 
                WHERE IsActive = 1 
                AND (
                    FirstName LIKE @Search OR 
                    LastName LIKE @Search OR 
                    Email LIKE @Search OR 
                    Phone LIKE @Search
                )
                ORDER BY LastName, FirstName";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Search", "%" + searchTerm + "%");

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            guests.Add(MapReaderToGuest(reader));
                        }
                    }
                }
            }
            return guests;
        }

        /// <summary>
        /// Helper method to map SqlDataReader to Guest object
        /// </summary>
        private Guest MapReaderToGuest(SqlDataReader reader)
        {
            return new Guest
            {
                GuestId = (int)reader["GuestId"],
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : null,
                Phone = reader["Phone"] != DBNull.Value ? reader["Phone"].ToString() : null,
                IDNumber = reader["IDNumber"] != DBNull.Value ? reader["IDNumber"].ToString() : null,
                DateOfBirth = reader["DateOfBirth"] != DBNull.Value ? (DateTime?)reader["DateOfBirth"] : null,
                Address = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : null,
                Nationality = reader["Nationality"] != DBNull.Value ? reader["Nationality"].ToString() : null,
                CreatedDate = (DateTime)reader["CreatedDate"],
                ModifiedDate = reader["ModifiedDate"] != DBNull.Value ? (DateTime?)reader["ModifiedDate"] : null,
                IsActive = (bool)reader["IsActive"]
            };
        }
    }
}
```

---

### Step 3: Test Guest Repository

Create a simple test form or add this code to your Main form's Load event temporarily:

```csharp
private void TestGuestRepository()
{
    try
    {
        GuestRepository guestRepo = new GuestRepository();

        // TEST 1: Insert new guest
        Guest newGuest = new Guest
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@email.com",
            Phone = "555-0123",
            IDNumber = "ID123456",
            DateOfBirth = new DateTime(1990, 5, 15),
            Address = "123 Main St",
            Nationality = "USA"
        };

        int newGuestId = guestRepo.Insert(newGuest);
        MessageBox.Show($"Guest inserted! ID: {newGuestId}");

        // TEST 2: Get by ID
        Guest retrievedGuest = guestRepo.GetById(newGuestId);
        MessageBox.Show($"Retrieved: {retrievedGuest.FirstName} {retrievedGuest.LastName}");

        // TEST 3: Update guest
        retrievedGuest.Phone = "555-9999";
        bool updated = guestRepo.Update(retrievedGuest);
        MessageBox.Show($"Guest updated: {updated}");

        // TEST 4: Get all guests
        List<Guest> allGuests = guestRepo.GetAll();
        MessageBox.Show($"Total active guests: {allGuests.Count}");

        // TEST 5: Search
        List<Guest> searchResults = guestRepo.Search("John");
        MessageBox.Show($"Search results for 'John': {searchResults.Count}");

        // TEST 6: Delete (soft delete)
        bool deleted = guestRepo.Delete(newGuestId);
        MessageBox.Show($"Guest deleted: {deleted}");

        // Verify deletion
        Guest deletedGuest = guestRepo.GetById(newGuestId);
        MessageBox.Show($"Guest still exists after delete: {deletedGuest != null}");
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error testing GuestRepository: {ex.Message}");
    }
}
```

---

### Step 4: Begin RoomRepository

**File:** `DAL/RoomRepository.cs`

```csharp
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.DAL
{
    public class RoomRepository : IRepository<Room>
    {
        /// <summary>
        /// Insert a new room
        /// </summary>
        public int Insert(Room room)
        {
            string query = @"
                INSERT INTO Rooms (RoomNumber, RoomType, FloorNumber, Status, BasePrice, MaxOccupancy, Description)
                VALUES (@RoomNumber, @RoomType, @FloorNumber, @Status, @BasePrice, @MaxOccupancy, @Description);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RoomNumber", room.RoomNumber);
                    cmd.Parameters.AddWithValue("@RoomType", room.RoomType);
                    cmd.Parameters.AddWithValue("@FloorNumber", room.FloorNumber);
                    cmd.Parameters.AddWithValue("@Status", room.Status);
                    cmd.Parameters.AddWithValue("@BasePrice", room.BasePrice);
                    cmd.Parameters.AddWithValue("@MaxOccupancy", room.MaxOccupancy);
                    cmd.Parameters.AddWithValue("@Description", room.Description ?? (object)DBNull.Value);

                    conn.Open();
                    int newId = (int)cmd.ExecuteScalar();
                    return newId;
                }
            }
        }

        /// <summary>
        /// Get room by ID
        /// </summary>
        public Room GetById(int id)
        {
            string query = "SELECT * FROM Rooms WHERE RoomId = @RoomId AND IsActive = 1";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RoomId", id);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapReaderToRoom(reader);
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Get all active rooms
        /// </summary>
        public List<Room> GetAll()
        {
            List<Room> rooms = new List<Room>();
            string query = "SELECT * FROM Rooms WHERE IsActive = 1 ORDER BY RoomNumber";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rooms.Add(MapReaderToRoom(reader));
                        }
                    }
                }
            }
            return rooms;
        }

        /// <summary>
        /// Update room
        /// </summary>
        public bool Update(Room room)
        {
            string query = @"
                UPDATE Rooms 
                SET RoomNumber = @RoomNumber,
                    RoomType = @RoomType,
                    FloorNumber = @FloorNumber,
                    Status = @Status,
                    BasePrice = @BasePrice,
                    MaxOccupancy = @MaxOccupancy,
                    Description = @Description,
                    ModifiedDate = GETDATE()
                WHERE RoomId = @RoomId";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RoomId", room.RoomId);
                    cmd.Parameters.AddWithValue("@RoomNumber", room.RoomNumber);
                    cmd.Parameters.AddWithValue("@RoomType", room.RoomType);
                    cmd.Parameters.AddWithValue("@FloorNumber", room.FloorNumber);
                    cmd.Parameters.AddWithValue("@Status", room.Status);
                    cmd.Parameters.AddWithValue("@BasePrice", room.BasePrice);
                    cmd.Parameters.AddWithValue("@MaxOccupancy", room.MaxOccupancy);
                    cmd.Parameters.AddWithValue("@Description", room.Description ?? (object)DBNull.Value);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        /// <summary>
        /// Soft delete room
        /// </summary>
        public bool Delete(int id)
        {
            string query = "UPDATE Rooms SET IsActive = 0, ModifiedDate = GETDATE() WHERE RoomId = @RoomId";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RoomId", id);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        /// <summary>
        /// Get available rooms by date range
        /// </summary>
        public List<Room> GetAvailableRooms(DateTime checkIn, DateTime checkOut)
        {
            List<Room> rooms = new List<Room>();
            string query = @"
                SELECT * FROM Rooms 
                WHERE IsActive = 1 
                AND Status = 'Available'
                AND RoomId NOT IN (
                    SELECT RoomId FROM Bookings 
                    WHERE Status IN ('Confirmed', 'CheckedIn')
                    AND (
                        (CheckInDate <= @CheckOut AND CheckOutDate >= @CheckIn)
                    )
                )
                ORDER BY RoomNumber";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CheckIn", checkIn);
                    cmd.Parameters.AddWithValue("@CheckOut", checkOut);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rooms.Add(MapReaderToRoom(reader));
                        }
                    }
                }
            }
            return rooms;
        }

        /// <summary>
        /// Update room status
        /// </summary>
        public bool UpdateRoomStatus(int roomId, string status)
        {
            string query = "UPDATE Rooms SET Status = @Status, ModifiedDate = GETDATE() WHERE RoomId = @RoomId";

            using (SqlConnection conn = DatabaseManager.Instance.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RoomId", roomId);
                    cmd.Parameters.AddWithValue("@Status", status);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        /// <summary>
        /// Helper method to map SqlDataReader to Room object
        /// </summary>
        private Room MapReaderToRoom(SqlDataReader reader)
        {
            return new Room
            {
                RoomId = (int)reader["RoomId"],
                RoomNumber = reader["RoomNumber"].ToString(),
                RoomType = reader["RoomType"].ToString(),
                FloorNumber = (int)reader["FloorNumber"],
                Status = reader["Status"].ToString(),
                BasePrice = (decimal)reader["BasePrice"],
                MaxOccupancy = (int)reader["MaxOccupancy"],
                Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : null,
                CreatedDate = (DateTime)reader["CreatedDate"],
                ModifiedDate = reader["ModifiedDate"] != DBNull.Value ? (DateTime?)reader["ModifiedDate"] : null,
                IsActive = (bool)reader["IsActive"]
            };
        }
    }
}
```

---

## ✅ Day 2 Completion Checklist

Before ending today's session, verify:

- [ ] IRepository<T> interface created
- [ ] GuestRepository fully implemented (Insert, Update, Delete, GetById, GetAll, Search)
- [ ] RoomRepository created with basic CRUD
- [ ] Tested guest insertion and retrieval from database
- [ ] No compilation errors
- [ ] Database connection works for all operations

---

## 📊 Progress After Day 2

**Days Complete:** 2/35  
**Hours Invested:** 4/70  
**Patterns Implemented:** 2/5 (Singleton ✓, Repository ✓)  
**Project Completion:** ~6%

---

## 🚀 Day 3 Preview - Tomorrow's Tasks

1. **Complete RoomRepository testing**
2. **Create UserRepository for authentication**
3. **Test all CRUD operations thoroughly**
4. **Begin Login form UI**

**Time:** 2 hours | **Files:** 1-2 new files

---

## 💡 Tips for Success

1. **Test as you code** - Don't wait until everything is done
2. **Use MessageBox** for quick testing (we'll build proper UI later)
3. **Handle DBNull.Value** carefully for nullable fields
4. **Commit your code** if using version control
5. **Take a 5-minute break** after each major task

---

## 🎯 Key Learnings from Day 2

- **Repository Pattern** separates data access from business logic
- Generic interfaces (`IRepository<T>`) promote code reuse
- Soft deletes (IsActive flag) are better than hard deletes
- Always use parameterized queries to prevent SQL injection
- Helper methods (like `MapReaderToRoom`) reduce code duplication

---

**Good luck with Day 2! You've got this! 💪**
