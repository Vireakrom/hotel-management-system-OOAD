using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Helpers
{
    /// <summary>
    /// Manages the current user session
    /// </summary>
    public static class SessionManager
    {
        public static User CurrentUser { get; set; }

        public static bool IsLoggedIn => CurrentUser != null;

        public static bool IsAdmin => RoleHelper.IsRole(CurrentUser?.Role, RoleHelper.Admin);

        public static bool IsReceptionist => RoleHelper.IsRole(CurrentUser?.Role, RoleHelper.Receptionist);

        public static void Logout()
        {
            CurrentUser = null;
        }
    }
}
