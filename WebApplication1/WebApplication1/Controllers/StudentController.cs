using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.Models;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public IActionResult Index(int nowPage =  1)
        {
            int count = 10;
            int offset = (nowPage - 1) * count;

            var (total,list) = _studentService.GetStudents(offset,count);

            //var list = _studentService.GetStudents();
            ViewData["total"] = total;
            ViewData["nowPage"] = nowPage;

            return View(list);
        }

        [HttpPost]
        public IActionResult Index(Dictionary<string,string> queryDic,int nowPage = 1)
        {
            int count = 10;
            int offset = (nowPage - 1) * count;

            var (total, list) = _studentService.GetStudents(offset, count,queryDic);

            //var list = _studentService.GetStudents();
            ViewData["total"] = total;
            ViewData["nowPage"] = nowPage;

            ViewData["query_studentName"] = queryDic["studentName"];
            ViewData["query_studentNo"] = queryDic["studentNo"];
            ViewData["query_githubLink"] = queryDic["githubLink"];

            return View(list);
        }

        public IActionResult Update(string studentNo)
        {
            var student = _studentService.GetStudentByNo(studentNo);
            if(student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost] 
        public IActionResult Update(Student student)
        {
            _studentService.UpdateStudent(student); //_studentService.UpdateStudent 用介面的方法


            return RedirectToAction("Index"); //save後回Index
        }

        [HttpPost]//post傳法
        [ValidateAntiForgeryToken]//request判斷
        public IActionResult DeletePost(string studentNo)
        {
            _studentService.DeleteStudent(studentNo); 
            return RedirectToAction("Index");
        }
        public IActionResult Delete(string studentNo)
        {
           var student =  _studentService.GetStudentByNo(studentNo);

            return View(student);
         }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            _studentService.CreateStudent(student);

            return RedirectToAction("Index");
        }

        public IActionResult Detail(string studentNo)
        {
            var student = _studentService.GetStudentByNo(studentNo);
            if(student == null)
            {
                return NotFound();
            }
            return View(student);
        }

    }
}
