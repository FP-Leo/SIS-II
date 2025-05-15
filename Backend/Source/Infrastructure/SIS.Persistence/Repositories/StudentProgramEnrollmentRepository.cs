using SIS.Application.Interfaces.Repositories;
using SIS.Domain.Entities;

namespace SIS.Persistence.Repositories
{
    public class StudentProgramEnrollmentRepository : IStudentProgramEnrollmentRepository
    {
        public Task<StudentProgramEnrollment> CreateStudentProgramEnrollmentAsync(StudentProgramEnrollment Student, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteStudentProgramEnrollmentAsync(StudentProgramEnrollment Student, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StudentProgramEnrollment>> GetAllStudentProgramEnrollments(int studentProfileId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<StudentProgramEnrollment?> GetStudentProgramEnrollmentByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ProgramEnrollmentExistsAsync(int profileId, int programId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ProgramEnrollmentExistsAsync(int id, int profileId, int programId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ProgramEnrollmentExistsByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateStudentProgramEnrollmentAsync(StudentProgramEnrollment Student, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
