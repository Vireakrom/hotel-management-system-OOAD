using System;

namespace HotelManagementSystem.Helpers
{
    /// <summary>
    /// Centralizes role aliases so the UI and database use the same role values.
    /// </summary>
    public static class RoleHelper
    {
        public const string Admin = "Admin";
        public const string Manager = "Manager";
        public const string Receptionist = "Receptionist";
        public const string Housekeeping = "Housekeeping";

        public static readonly string[] AssignableRoles =
        {
            Admin,
            Manager,
            Receptionist,
            Housekeeping
        };

        public static string Normalize(string role)
        {
            if (string.IsNullOrWhiteSpace(role))
                return string.Empty;

            switch (role.Trim().ToLowerInvariant())
            {
                case "admin":
                    return Admin;

                case "manager":
                    return Manager;

                case "receptionist":
                case "frontdesk":
                case "front desk":
                    return Receptionist;

                case "housekeeping":
                case "house keeping":
                    return Housekeeping;

                default:
                    return role.Trim();
            }
        }

        public static string ToDisplayName(string role)
        {
            return Normalize(role);
        }

        public static bool IsRole(string role, string expectedRole)
        {
            return string.Equals(Normalize(role), Normalize(expectedRole), StringComparison.OrdinalIgnoreCase);
        }
    }
}
