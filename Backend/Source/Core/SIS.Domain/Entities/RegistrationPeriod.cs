﻿using Microsoft.EntityFrameworkCore;
using SIS.Domain.Shared;

namespace SIS.Domain.Entities
{
    [Index(nameof(SemesterId), nameof(ProgramId), IsUnique=true)]
    /// <summary>
    /// Represents a registration period in the system.
    /// </summary>
    public class RegistrationPeriod
    {
        /// <summary>
        /// Gets or sets the unique identifier for the registration period.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the start of the registration period.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end of the registration period.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the status of the registration period.
        /// </summary>
        public AcademicEventStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the semester of the program associated with this registration period.
        /// </summary>
        public int SemesterId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the program semester associated with this registration period. If null, it means the registration period is for all programs unless overridden by the program semester.
        /// </summary>
        public int? ProgramId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the semester associated with this registration period.
        /// </summary>
        public AcademicSemester? Semester { get; set; }

        /// <summary>
        /// Gets or sets the program semester associated with this registration period.
        /// </summary>
        public AcademicProgram? Program { get; set; }

    }
}
