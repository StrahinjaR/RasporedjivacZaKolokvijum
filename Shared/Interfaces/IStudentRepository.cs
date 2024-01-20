using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface IStudentRepository
    {
        List<Student> GetStudents();
        int CreateStudent(Student student);
        int DeleteStudent(Student student);
        int UpdateStudent(Student student);
    }
}
