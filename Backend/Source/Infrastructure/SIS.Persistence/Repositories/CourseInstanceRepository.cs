using SIS.Application.Interfaces.Repositories;
using SIS.Domain.Entities;

namespace SIS.Persistence.Repositories
{
    public class CourseInstanceRepository : ICourseInstanceRepository
    {
        public Task<bool> CourseInstanceExistsByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CourseInstanceExistsIdAsync(int courseId, int semesterId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<CourseInstance> CreateCourseInstanceAsync(CourseInstance courseInstance, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCourseInstanceAsync(CourseInstance courseInstance, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseInstance>> GetAllCourseInstancesOfSemesterAsync(int semesterId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseInstance>> GetAllInstancesOfCourseAsync(int courseId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<CourseInstance?> GetCourseInstanceByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCourseInstanceAsync(CourseInstance courseInstance, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
