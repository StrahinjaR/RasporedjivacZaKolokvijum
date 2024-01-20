using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface IBiznisStudent
    {
        List<Student> GetStudents();

        int AddStudent(Student student);

        int DeleteStudent(Student student);

        int UpdateStudent(Student student);
    }

}



