using Leyadech.Core.Entities;
using System.Collections.Generic;

namespace Leyadech.Core.Services
{
    /// <summary>
    /// Service interface for managing Volunteer entities.
    /// </summary>
    public interface IVolunteerService
    {
        /// <summary>
        /// Retrieves all volunteers.
        /// </summary>
        /// <returns>A result containing a collection of volunteers.</returns>
        Result<IEnumerable<Volunteer>> GetAllVolunteers();

        /// <summary>
        /// Retrieves a specific volunteer by their ID.
        /// </summary>
        /// <param name="id">The ID of the volunteer.</param>
        /// <returns>A result containing the volunteer.</returns>
        Result<Volunteer> GetVolunteerById(int id);

        /// <summary>
        /// Adds a new volunteer.
        /// </summary>
        /// <param name="volunteer">The volunteer to add.</param>
        /// <returns>A result indicating whether the operation was successful.</returns>
        Result<bool> AddVolunteer(Volunteer volunteer);

        /// <summary>
        /// Updates the fields of an existing volunteer.
        /// </summary>
        /// <param name="id">The ID of the volunteer to update.</param>
        /// <param name="volunteer">The updated volunteer details.</param>
        /// <returns>A result indicating whether the operation was successful.</returns>
        Result<bool> UpdateVolunteer(int id, Volunteer volunteer);

        /// <summary>
        /// Deletes a volunteer by their ID.
        /// </summary>
        /// <param name="id">The ID of the volunteer to delete.</param>
        /// <returns>A result indicating whether the operation was successful.</returns>
        Result<bool> DeleteVolunteer(int id);

        /// <summary>
        /// Updates the status of a volunteer.
        /// </summary>
        /// <param name="id">The ID of the volunteer to update.</param>
        /// <param name="status">The new status of the volunteer.</param>
        /// <returns>A result indicating whether the operation was successful.</returns>
        //Result<bool> UpdateVolunteerStatus(int id, EVolunteerStatus status);

        /// <summary>
        /// Retrieves all volunteering activities associated with a volunteer's ID.
        /// </summary>
        /// <param name="id">The ID of the volunteer.</param>
        /// <returns>A result containing a collection of volunteering activities.</returns>
        Result<IEnumerable<Volunteering>> GetAllVolunteeringsById(int id);
    }
}
