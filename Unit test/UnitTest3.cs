using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using task.Data;
using task.Models;
using task.Repositories;

namespace Unit_test
{
    [TestFixture]
    public class UnitTest3
    {
        private CourseRepository repository;
        private Mock<SchoolContext> context;
        private Mock<DbSet<Course>> mockSet;
        [SetUp]
        public void Setup()
        {
            context = new Mock<SchoolContext>();
            mockSet = new Mock<DbSet<Course>>();
            repository = new CourseRepository(context.Object);

        }
        [Test]
        public void CheckCourse_Service_Ok()
        {
            //Arrange
            int idFound = 1;
            var courses = new List<Course> { new Course
            {
                Id = idFound,
                Name = "Viktor",
                TeacherId = idFound,
                Teacher = new Teacher
                {
                    Name = "teacher",
                },
                Groups = new List<Group>(),
            },
        }.AsQueryable();

            mockSet.As<IQueryable<Course>>().Setup(m => m.Provider).Returns(courses.Provider);
            mockSet.As<IQueryable<Course>>().Setup(m => m.Expression).Returns(courses.Expression);
            mockSet.As<IQueryable<Course>>().Setup(m => m.ElementType).Returns(courses.ElementType);
            mockSet.As<IQueryable<Course>>().Setup(m => m.GetEnumerator()).Returns(courses.GetEnumerator());
            context.Setup(c => c.Courses).Returns(mockSet.Object);

            var _course = repository.Retrieve(idFound);

            //Assert
            Assert.AreEqual(courses.ToList()[0].Name, _course.Name);

        }
        [Test]
        public void CheckCourse_Service_NotFound()
        {
            int idFound = 1;
            var courses = new List<Course>().AsQueryable();

            mockSet.As<IQueryable<Course>>().Setup(m => m.Provider).Returns(courses.Provider);
            mockSet.As<IQueryable<Course>>().Setup(m => m.Expression).Returns(courses.Expression);
            mockSet.As<IQueryable<Course>>().Setup(m => m.ElementType).Returns(courses.ElementType);
            mockSet.As<IQueryable<Course>>().Setup(m => m.GetEnumerator()).Returns(courses.GetEnumerator());
            context.Setup(c => c.Courses).Returns(mockSet.Object);
            //Act

            var _course = repository.Retrieve(idFound);

            //Assert
            Assert.IsNull(_course);
        }
    }
}
