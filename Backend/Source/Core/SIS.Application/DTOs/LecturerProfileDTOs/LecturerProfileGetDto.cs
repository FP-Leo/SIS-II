﻿using SIS.Domain.Shared;

namespace SIS.Application.DTOs.LecturerProfileDTOs
{
    /// <summary>
    /// Data Transfer Object (DTO) for retrieving lecturer profile information.
    /// </summary>
    public class LecturerProfileGetDto
    {
        /// <summary>
        /// Gets or sets the unique identifier for the lecturer profile.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the lecturer (e.g., "Professor", "Associate Professor").
        /// </summary>
        public LecturerType Title { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the lecturer.
        /// </summary>
        public required string UserId;
    }
}
