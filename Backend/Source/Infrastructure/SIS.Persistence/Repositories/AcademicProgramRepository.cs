using SIS.Application.Interfaces.Repositories;
using SIS.Domain.Entities;

namespace SIS.Persistence.Repositories
{
    public class AcademicProgramRepository : IAcademicProgramRepository
    {
        public Task<bool> AcademicProgramExistsAsync(string name, int depId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AcademicProgramExistsAsync(int id, string name, int depId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AcademicProgramExistsByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<AcademicProgram> CreateAcademicProgramAsync(AcademicProgram academicProgram, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAcademicProgramAsync(AcademicProgram academicProgram, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<AcademicProgram?> GetAcademicProgramByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AcademicProgram>> GetAllAcademicProgramsOfDepartmentAsync(int depId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAcademicProgramAsync(AcademicProgram academicProgram, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
