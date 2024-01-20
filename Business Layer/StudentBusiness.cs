using Data_Layer.Repository;
using Shared.Models;
using Shared.Interfaces;

namespace Business_Layer
{
    public class StudentBusiness: IBiznisStudent
    {
        private readonly IStudentRepository StudentRepo;
        public StudentBusiness(IStudentRepository studentRepository)
        {
            this.StudentRepo = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
        }

        public List<Student> GetStudents()
        {
            return StudentRepo.GetStudents();
            
        }
        public int AddStudent(Student student)
        {
            int rowsaffected= this.StudentRepo.CreateStudent(student);
            if(rowsaffected>0)
            {
                return 5;
            }
            else { return 6; }

        }
        public int DeleteStudent(Student student)
        {  int rowsaffected= this.StudentRepo.DeleteStudent(student);
            if (rowsaffected > 0)
            {
                return 5;
            }
            else { return 6; }
        }

        public int UpdateStudent(Student student)
        {
            int rowsaffected= this.StudentRepo.UpdateStudent(student);
            if (rowsaffected > 0)
            {
                return 5;
            }
            else { return 6; }
        }
    }
}
