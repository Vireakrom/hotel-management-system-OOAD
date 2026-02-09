using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
