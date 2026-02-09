using HotelManagementSystem.DAL;
using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem.Testing
{
    public class TestingCode
    {
        private void TestRepositories()
        {
            try
            {
                // TEST UserRepository
                UserRepository userRepo = new UserRepository();
                var allUsers = userRepo.GetAll();
                MessageBox.Show($"Total users in database: {allUsers.Count}");

                // TEST BookingRepository
                BookingRepository bookingRepo = new BookingRepository();
                var allBookings = bookingRepo.GetAll();
                MessageBox.Show($"Total bookings in database: {allBookings.Count}");

                // TEST Active Bookings
                var activeBookings = bookingRepo.GetActiveBookings();
                MessageBox.Show($"Active bookings: {activeBookings.Count}");

                MessageBox.Show("All repository tests passed! ✅", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Test failed: {ex.Message}", "Error");
            }
        }
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

        public void CreateTestUser()
        {
            try
            {
                UserRepository userRepo = new UserRepository();

                // Create a new test user
                User newUser = new User
                {
                    Username = "testadmin",
                    PasswordHash = "Test123!",  // This will be hashed by the repository
                    FirstName = "Test",
                    LastName = "Admin",
                    Email = "testadmin@hotel.com",
                    Phone = "555-0001",
                    Role = "Admin"  // Options: "Admin" or "Receptionist"
                };

                int newUserId = userRepo.Insert(newUser);
                MessageBox.Show($"✅ Test user created successfully!\n\n" +
                               $"User ID: {newUserId}\n" +
                               $"Username: {newUser.Username}\n" +
                               $"Password: Test123!\n" +
                               $"Role: {newUser.Role}\n\n" +
                               $"You can now login with these credentials.", 
                               "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating test user: {ex.Message}", "Error");
            }
        }
    }
}
