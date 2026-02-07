using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.DAL
{
    public sealed class DatabaseManager
    {
        // Static instance - only one will ever exist
        private static DatabaseManager _instance = null;
        private static readonly object _lock = new object();

        // Connection string from App.config
        private readonly string _connectionString;

        // Private constructor - prevents external instantiation
        private DatabaseManager()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["HotelDB"].ConnectionString;
        }

        /// <summary>
        /// Get the single instance of DatabaseManager (Thread-safe)
        /// This is the SINGLETON pattern implementation
        /// </summary>
        public static DatabaseManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)  // Thread-safe double-check locking
                    {
                        if (_instance == null)
                        {
                            _instance = new DatabaseManager();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// Get a new SQL connection
        /// </summary>
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        /// <summary>
        /// Execute a SELECT query and return DataTable
        /// </summary>
        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        conn.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Database query error: {ex.Message}", ex);
            }

            return dataTable;
        }

        /// <summary>
        /// Execute INSERT, UPDATE, DELETE commands
        /// Returns number of rows affected
        /// </summary>
        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        conn.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Database execution error: {ex.Message}", ex);
            }

            return rowsAffected;
        }

        /// <summary>
        /// Execute scalar query (returns single value)
        /// </summary>
        public object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            object result = null;

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        conn.Open();
                        result = cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Database scalar query error: {ex.Message}", ex);
            }

            return result;
        }

        /// <summary>
        /// Test database connection
        /// </summary>
        public bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }

}
