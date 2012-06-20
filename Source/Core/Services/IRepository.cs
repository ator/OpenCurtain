using System.Collections.Generic;

namespace OpenCurtain.Core.Services
{
    /// <summary>
    /// Base interface for any repository. Defines the basic operations needed.
    /// </summary>
    /// <typeparam name="TObj">The type of object that the repository contains</typeparam>
    public interface IRepository<TObj> where TObj: class
    {
        /// <summary>
        /// Save the object to the repository.
        /// </summary>
        /// <param name="obj">Object to save</param>
        void Save(ref TObj obj);

        /// <summary>
        /// Find object with given id.
        /// </summary>
        /// <param name="id">Id value</param>
        /// <returns>Object with given id, or null if none exists</returns>
        TObj FindById(object id);
        
        /// <summary>
        /// Strongly typed version of FindById(object id)
        /// </summary>
        /// <typeparam name="TId">Type of the id</typeparam>
        /// <param name="id">Id value</param>
        /// <returns>Object with given id, or null if none exists</returns>
        TObj FindById<TId>(TId id);

        /// <summary>
        /// Find all object in the repository.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TObj> FindAll();
    }
}
