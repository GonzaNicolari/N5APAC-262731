namespace PAC.Tests.WebApi;
using System.Collections.ObjectModel;

using System.Data;
using Moq;
using PAC.IBusinessLogic;
using PAC.Domain;
using PAC.WebAPI;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

[TestClass]
public class StudentControllerTest
{
    Mock<IStudentLogic> mockStudentLogic;

    [TestInitialize]
    public void InitTest()
    {
        mockStudentLogic = new Mock<IStudentLogic>(MockBehavior.Strict);
    }
    [TestMethod]
    public void PostStudentFail() 
    {
        // Arrange
        string name = null;
        mockStudentLogic.Setup(x => x.InsertStudents(It.IsAny<Student>()));
        var controller = new StudentController(mockStudentLogic.Object);
        
        // Act
        var result = controller.CreateStudent(name);

        // Asert
        Assert.IsInstanceOfType(result, typeof(BadRequestResult));
    }
    [TestMethod]
    public void PostStudentOk() 
    {
        // Arrange
        string name = "testName";
        mockStudentLogic.Setup(x => x.InsertStudents(It.IsAny<Student>()));
        var controller = new StudentController(mockStudentLogic.Object);

        // Act
        var result = controller.CreateStudent(name);

        // Asert
        Assert.IsInstanceOfType(result, typeof(OkResult));
    }
}
