using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MVC_employee.Controllers;
using MVC_employee.Interfaces;
using MVC_employee.Models;

using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

using Employee_tests.Helpers;
using Xunit.Sdk;

namespace Employee_tests
{
    public class EmployeeControllerTest
    {
        private TestHelper _helper;

        public EmployeeControllerTest()
        {
            _helper = new TestHelper();
        }

        [Fact]
        public void Index_ReturnsAViewResult_WithAListOfEmplyees()
        {
            //Arrange
            var mockRepo = new Mock<IDataRepository<Employee>>();
            mockRepo.Setup(repo => repo.GetAll()).Returns(_helper.GetTestEmployees());
            var controller = new EmployeeController(mockRepo.Object);

            //Act
            var result = controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Employee>>(viewResult.ViewData.Model);

            Assert.Equal(2, model.Count);
        }

        [Fact]
        public void Add_ReturnsBadRequestResult_WhenModelStateIsInvalid()
        {
            //Arrange
            var mockRepo = new Mock<IDataRepository<Employee>>();

            var controller = new EmployeeController(mockRepo.Object);
            controller.ModelState.AddModelError("Name", "Required");
            var newEmployee = _helper.getTestEmployee();

            //Act
            var result= controller.Add(newEmployee);

            //Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            //Assert.IsType<SerializableError>(badRequestResult);
        }

        [Fact]
        public void Add_AddsEmployeeAndReturnsARedirect_WhenModelStateIsValid()
        {
            //Arrange
            var mockRepo= new Mock<IDataRepository<Employee>>();
            mockRepo.Setup(repo => repo.Add(It.IsAny<Employee>())).Verifiable();
            var controller = new EmployeeController(mockRepo.Object);
            var newEmployee = _helper.getTestEmployee();

            //Act
            var result = controller.Add(newEmployee);

            //Assert
            var redirectToActionResult=Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index",redirectToActionResult.ActionName);
            mockRepo.Verify();
        }
    }
}
