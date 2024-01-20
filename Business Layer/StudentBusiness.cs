using Data_Layer.Repository;
using Shared.Models;

namespace Business_Layer
{
    public class StudentBusiness
    {
        StudentRepository StudentRepo;
        public StudentBusiness()
        {
            StudentRepo = new StudentRepository();
        }

        public List<Student> GetStudents()
        {
            return StudentRepo.GetStudents();
        }
        public int AddStudent(Student student)
        {
            return StudentRepo.CreateStudent(student);
        }
        public int DeleteStudent(Student student)
        {  return StudentRepo.DeleteStudent(student);}

        public int UpdateStudent(Student student)
        {
            return StudentRepo.UpdateStudent(student);
        }
    }
}
