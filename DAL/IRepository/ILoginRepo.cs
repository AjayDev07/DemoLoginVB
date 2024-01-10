using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    public interface ILoginRepo
    {
        bool UserLogin(string email);
        bool AddPerson(string fname, string lname, string email);
        List<Student> GetAllStudent();

	}
}
