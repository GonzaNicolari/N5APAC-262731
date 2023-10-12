using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PAC.Domain;
using PAC.IBusinessLogic;
using PAC.WebAPI.Filters;

namespace PAC.WebAPI
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        IStudentLogic _studentLogic;
        public StudentController(IStudentLogic studentLogic)
        {
            _studentLogic = studentLogic;
        }
        [HttpPost]
        [AuthorizationFilter]
        public IActionResult CreateStudent([FromQuery] string name) 
        {
            if (name == null)
                return new BadRequestResult();

            _studentLogic.InsertStudents(new Student
            {
                Name = name
            });
            return new OkResult();
        }
        [HttpGet]
        public IActionResult GetStudents([FromBody] int? filterAge)
        {
            var result = _studentLogic.GetStudents(filterAge);
            if (result == null)
                return new NotFoundResult();
            
            return new OkObjectResult(result);
        }
        [HttpGet]
        public IActionResult GetStudentById([FromQuery] int id) 
        {
            var student = _studentLogic.GetStudentById(id);
            if (student == null)
                return new NotFoundResult();
            
            return new OkObjectResult(student);
        }
    }
}
