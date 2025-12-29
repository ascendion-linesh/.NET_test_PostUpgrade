using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Data;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class StudentsController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public StudentsController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: api/students
		[HttpGet]
		public IActionResult GetAllStudents()
		{
			return Ok(_context.Students.ToList());
		}

		// GET: api/students/1
		[HttpGet("{id}")]
		public IActionResult GetStudent(int id)
		{
			var student = _context.Students.Find(id);
			if (student == null)
				return NotFound();

			return Ok(student);
		}

		// POST: api/students
		[HttpPost]
		public IActionResult AddStudent(Student student)
		{
			_context.Students.Add(student);
			_context.SaveChanges();
			return Ok(student);
		}

		// PUT: api/students/1
		[HttpPut("{id}")]
		public IActionResult UpdateStudent(int id, Student student)
		{
			var existingStudent = _context.Students.Find(id);
			if (existingStudent == null)
				return NotFound();

			existingStudent.Name = student.Name;
			existingStudent.Age = student.Age;
			existingStudent.Class = student.Class;
			existingStudent.Email = student.Email;

			_context.SaveChanges();
			return Ok(existingStudent);
		}

		// DELETE: api/students/1
		[HttpDelete("{id}")]
		public IActionResult DeleteStudent(int id)
		{
			var student = _context.Students.Find(id);
			if (student == null)
				return NotFound();

			_context.Students.Remove(student);
			_context.SaveChanges();
			return Ok();
		}
	}
}
