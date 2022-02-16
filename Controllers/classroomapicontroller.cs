using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassroomApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ClassroomApp.Controllers
{
    [ApiController]
    [Route("api/Classroom")]
    public class ClassRoomController : ControllerBase
    {
        private IClassroomService _classroomService; 

        public ClassRoomController(IClassroomService classroomService)
        {
            _classroomService = classroomService;
        }

        [HttpPost]
        public ActionResult<bool> AddStudent(Student student)
        {
            if(_classroomService == null)
            {
                return NotFound();
            }

            var result = _classroomService.AddStudent(student);

            return result;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            if(_classroomService == null)
            {
                return NotFound();
            }

            var result = _classroomService.GetAllStudents().ToList();
            return result;
        }

    }
}