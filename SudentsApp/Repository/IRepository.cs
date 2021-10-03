using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsApp.Models;

namespace StudentsApp.Repository
{
    interface IRepository 
    {
        void Add(Student item);
        void Remove(int id);
        void Update(Student item);
        Student FindByID(int id);
        IEnumerable<Student> FindAll();
    }
}
