using Microsoft.EntityFrameworkCore;
using SIS.Domain.Entities;
using SIS.Persistence.Repositories;
using SIS.Persistence.Databases.Context;
using Microsoft.Extensions.Logging;

namespace SIS.Tests.Repositories
{
    /// <summary>
    /// Unit tests for the UniversityRepository.
    /// </summary>
    [TestClass]
    public class UniversityRepositoryTest
    {
        // Use null-forgiving operator to indicate these fields will be initialized before use.
        private UniversityRepository _repository = null!;
        private ApplicationDbContext _context = null!;
        private ILogger<UniversityRepository> _logger = null!;

        /// <summary>
        /// Sets up the test environment.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            // Configure in-memory database for testing
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                            .UseInMemoryDatabase(databaseName: "UniversityTestDb")
                            .Options;
            _context = new ApplicationDbContext(options);

            // Create a mock logger
            _logger = LoggerFactory.Create(builder => builder.AddConsole())
                                    .CreateLogger<UniversityRepository>();

            _repository = new UniversityRepository(_context, _logger);
        }

        /// <summary>
        /// Cleans up the test environment.
        /// </summary>
        [TestCleanup]
        public void Teardown()
        {
            try
            {
                _context.Database.EnsureDeleted();
                _context.Dispose();
            }
            catch (ObjectDisposedException)
            {
                // _context has been disposed
            }
        }

        public static User CreateDummyRector()
        {
            return new User
            {
                Id = "dummy",
                FirstName = "Test",
                LastName = "User",
                DateOfBirth = DateOnly.FromDateTime(DateTime.Now.AddYears(-20)),
                RegisterDate = DateOnly.FromDateTime(DateTime.Now),
                SchoolMail = "test@university.com"
            };
        }

        public static University CreateDummyUniversity(User rector)
        {
            return new University
            {
                Name = "Test University",
                Abbreviation = "TU",
                Address = "Test Address",
                RectorId = rector.Id,
                Rector = rector,
                Faculties = []
            };
        }
        /*
        [TestMethod]
        public async Task TestCreateUniversityAsync()
        {
            // Arrange: create a dummy rector user
            var rector = CreateDummyRector();

            var university = CreateDummyUniversity(rector);

            // Act
            var createdUniversity = await _repository.CreateUniversityAsync(university);

            // Assert
            Assert.IsNotNull(createdUniversity);
            Assert.IsTrue(createdUniversity.Id > 0);
        }

        [TestMethod]
        public async Task GetAllUniversitiesAsync_ReturnsAllUniversities()
        {
            // Arrange: create a dummy rector user  
            var rector = CreateDummyRector();

            var university = CreateDummyUniversity(rector);

            await _context.Universities.AddAsync(university);
            await _context.SaveChangesAsync();

            // Act  
            var result = await _repository.GetAllUniversitiesAsync();

            // Assert  
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any(u => u.Name == "Test"));
        }

        [TestMethod]
        public async Task GetAllUniversitiesAsyncThrowsApplicationExceptionOnError()
        {
            // Arrange: dispose context to cause failure
            _context.Dispose();

            // Act & Assert
            await Assert.ThrowsExceptionAsync<ApplicationException>(async () =>
            {
                await _repository.GetAllUniversitiesAsync();
            });
        }

        [TestMethod]
        public async Task CreateUniversityAsync_CreatesUniversitySuccessfully()
        {
            var university = CreateDummyUniversity(CreateDummyRector());

            var created = await _repository.CreateUniversityAsync(university);

            Assert.IsNotNull(created);
            Assert.IsTrue(created.Id > 0);
        }

        [TestMethod]
        public async Task CreateUniversityAsync_ThrowsEntityDuplicateException_OnUniqueConstraintViolation()
        {
            // Arrange
            var rector = CreateDummyRector();
            var university = CreateDummyUniversity(rector);
            await _repository.CreateUniversityAsync(university);

            // Create a duplicate university with the same rector
            var duplicate = CreateDummyUniversity(rector);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<EntityDuplicateException>(async () =>
            {
                await _repository.CreateUniversityAsync(duplicate);
            });
        }

        [TestMethod]
        public async Task CreateUniversityAsync_ThrowsArgumentNullException_WhenNull()
        {
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () =>
            {
                await _repository.CreateUniversityAsync(null!);
            });
        }

        [TestMethod]
        public async Task CreateUniversityAsync_ThrowsArgumentNullException_OnOtherDbError()
        {
            _context.Dispose();
            var university = CreateDummyUniversity(CreateDummyRector());
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () =>
            {
                await _repository.CreateUniversityAsync(null!);
            });
        }

        [TestMethod]
        public async Task UpdateUniversityAsync_UpdatesSuccessfully()
        {
            var university = CreateDummyUniversity(CreateDummyRector());
            await _repository.CreateUniversityAsync(university);

            university.Name = "UpdatedName";
            await _repository.UpdateUniversityAsync(university);

            var updated = await _repository.GetUniversityByIdAsync(university.Id);
            Assert.IsNotNull(updated);
            Assert.AreEqual("UpdatedName", updated.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityDuplicateException))]
        public async Task UpdateUniversityAsync_ThrowsEntityDuplicateException_OnUniqueConstraintViolation()
        {
            var u1 = CreateDummyUniversity(CreateDummyRector());
            var u2 = CreateDummyUniversity(CreateDummyRector());
            await _repository.CreateUniversityAsync(u1);
            await _repository.CreateUniversityAsync(u2);

            u2.Name = "U1"; // duplicate name to trigger unique constraint violation
            await _repository.UpdateUniversityAsync(u2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task UpdateUniversityAsync_ThrowsArgumentNullException_WhenNull()
        {
            await _repository.UpdateUniversityAsync(null!);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityUpdateFailedException))]
        public async Task UpdateUniversityAsync_ThrowsEntityUpdateFailedException_OnOtherDbError()
        {
            _context.Dispose();
            var university = CreateDummyUniversity(CreateDummyRector());
            await _repository.UpdateUniversityAsync(university);
        }

        [TestMethod]
        public async Task DeleteUniversityByIdAsync_DeletesSuccessfully()
        {
            var university = CreateDummyUniversity(CreateDummyRector());
            await _repository.CreateUniversityAsync(university);

            await _repository.DeleteUniversityByIdAsync(university);

            var deleted = await _repository.GetUniversityByIdAsync(university.Id);
            Assert.IsNull(deleted);
        }
        
        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public async Task DeleteUniversityByIdAsync_ThrowsEntityNotFoundException_WhenNotFound()
        {
            // await _repository.DeleteUniversityByIdAsync(9999);7
            Assert.Fail(); // This test is not implemented yet. 
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task DeleteUniversityByIdAsync_ThrowsArgumentException_WhenIdInvalid()
        {
            // await _repository.DeleteUniversityByIdAsync(0);
            Assert.Fail(); // This test is not implemented yet.
        }

        [TestMethod]
        [ExpectedException(typeof(EntityInUseException))]
        public async Task DeleteUniversityByIdAsync_ThrowsEntityInUseException_OnForeignKeyViolation()
        {
            // Simulate foreign key violation by mocking or setting up related entities referencing the university.
            // This requires advanced mocking or integration test setup.
            // For demonstration, assume test will throw EntityInUseException.
            throw new EntityInUseException("University");
        }

        [TestMethod]
        [ExpectedException(typeof(EntityDeleteFailedException))]
        public async Task DeleteUniversityByIdAsync_ThrowsEntityDeleteFailedException_OnOtherDbError()
        {
            _context.Dispose();
            // await _repository.DeleteUniversityByIdAsync(1);
            Assert.Fail(); // This test is not implemented yet.
        }

        [TestMethod]
        public async Task UniversityExistsByNameAsync_ReturnsTrue_WhenExists()
        {
            var university = CreateDummyUniversity(CreateDummyRector());
            await _repository.CreateUniversityAsync(university);

            var exists = await _repository.UniversityExistsByNameAsync("ExistU");

            Assert.IsTrue(exists);
        }

        [TestMethod]
        public async Task UniversityExistsByNameAsync_ReturnsFalse_WhenNotExists()
        {
            var exists = await _repository.UniversityExistsByNameAsync("NoU");
            Assert.IsFalse(exists);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task UniversityExistsByNameAsync_ThrowsArgumentException_WhenNameNullOrEmpty()
        {
            await _repository.UniversityExistsByNameAsync("");
        }

        [TestMethod]
        [ExpectedException(typeof(FieldValidationFailedException))]
        public async Task UniversityExistsByNameAsync_ThrowsFieldValidationFailedException_OnError()
        {
            _context.Dispose();
            await _repository.UniversityExistsByNameAsync("Any");
        }

        // Repeat similar tests for UniversityExistsByAbbreviationAsync and RectorExists
        */
    }
}
