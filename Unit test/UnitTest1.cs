using task;
using task.Controllers;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using task.Services;
using task.Models;
using FluentAssertions;
using task.DTO;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace Unit_test
{
    [TestFixture]
    public class UnitTest1
    {

        private CourseController controller;
        private Mock<ICourse> repository;
        [SetUp]
        public void Setup()
        {
            repository = new Mock<ICourse>();
            controller = new CourseController(repository.Object);
        }
        [Test]
        public void CheckCourse_Controller_Ok()
        {
            //Arrange
            int idFound = 1;
            var course = new CourseDtoOutput();
            repository.Setup(c => c.Retrieve(idFound)).Returns(course);
            //Act
            var res = controller.Retrieve(idFound) as OkObjectResult;
            //Assert
            Assert.AreEqual(res.StatusCode, 200);
        }
        [Test]
        public void CheckCourse_Controller_NotFound()
        {
            //Arrange
            int idFound = 1;
            var course = new CourseDtoOutput();
            repository.Setup(c => c.Retrieve(idFound)).Returns<CourseDtoOutput>(null);
            //Act
            var res = controller.Retrieve(idFound) as NotFoundResult;
            //Assert
            Assert.AreEqual(res.StatusCode, 404);
        }
    }
}