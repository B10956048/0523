using System.Collections.Generic; //list
using WebApplication1.Models;
namespace WebApplication1.Service
{
    public interface IStudentService
    {
        public List<Student> GetStudents();

        public (int total, List<Student>) GetStudents(int offset , int count);

        public (int total, List<Student>) GetStudents(int offset, int count,Dictionary<string,string> queryDic);

        public Student GetStudentByNo(string studentNo);

        public bool UpdateStudent(Student  student);

        public bool DeleteStudent(string studentNo);

        public bool CreateStudent(Student student);
    }
}
