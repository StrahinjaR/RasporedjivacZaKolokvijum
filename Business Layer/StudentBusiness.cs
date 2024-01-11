using Data_Layer.Repository;
using Shared.Models;

namespace Business_Layer
{
    public class StudentBusiness
    {
        StudentRepository student;
        public StudentBusiness()
        {
            student = new StudentRepository();
        }

        public List<Student> GetStudents()
        {
            return student.GetStudents();
        }
    }
}
