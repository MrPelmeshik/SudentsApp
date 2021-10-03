using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsApp.Models;
using StudentsApp.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace StudentsApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRepository StudentRepository;

        public StudentController(IConfiguration configuration)
        {
            StudentRepository = new StudentRepository(configuration);
        }

        //[Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            //return new JsonResult(StudentRepository.FindAll());
            return View(StudentRepository.FindAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public IActionResult Create(Student cust)
        {
            if (ModelState.IsValid)
            {
                StudentRepository.Add(cust);
                return RedirectToAction("Index");
            }
            return View(cust);

        }

        // GET: /Student/Edit/1
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Student obj = StudentRepository.FindByID(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        // POST: /Student/Edit   
        [HttpPost]
        public IActionResult Edit(Student obj)
        {

            if (ModelState.IsValid)
            {
                StudentRepository.Update(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET:/Student/Delete/1
        public IActionResult Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            StudentRepository.Remove(id.Value);
            return RedirectToAction("Index");
        }
    }
}
