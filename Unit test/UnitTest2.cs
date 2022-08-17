using Moq;
using NUnit.Framework;
using task.Models;
using task.Repositories;
using task.Services;

namespace Unit_test
{
    [TestFixture]
    public class UnitTest2
    {
        private CourseService service;
        private Mock<IRepository<Course>> repository;
        [SetUp]
        public void Setup()
        {
            repository = new Mock<IRepository<Course>>();
            service = new CourseService(repository.Object);
        }
        [Test]
        public void CheckCourse_Service_Ok()
        {
            //Arrange
            int idFound = 1;
            Course course = new Course
            {
                Id = idFound,
                Name = "hfghfdg",
                Teacher = new Teacher
                {
                    Name = "Vasya",
                },
                Groups = new List<Group>(), 
            };
            repository.Setup(c => c.Retrieve(idFound)).Returns(course);
            //Act
            var res = service.Retrieve(idFound);
            //Assert
            Assert.AreEqual(res.Name,course.Name);
        }
        [Test]
        public void CheckCourse_Service_NotFound()
        {
            //Arrange
            int idFound = 1;
            repository.Setup(c => c.Retrieve(idFound)).Returns<Course>(null);
            //Assert
            Assert.Throws<ArgumentNullException>(() => service.Retrieve(idFound));
        }
    }
}
