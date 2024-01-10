using DAL.Context;
using DAL.Entity;
using DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
	public class LoginRepo : ILoginRepo
	{
		private TestContext _context;
		public LoginRepo(TestContext testContext)
		{
			_context = testContext;
		}

		public bool UserLogin(string email)
		{
			try
			{
				var usrData = _context.Users.Where(x => x.Email == email).FirstOrDefault();
				if (usrData != null)
				{
					return true;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return false;
		}


		public bool AddPerson(string fname, string lname, string email)
		{
			try
			{
				Student student = new Student();
				student.FirstName = fname;
				student.LastName = lname;
				student.Email = email;

				var stu = _context.Add(student);
				if (stu != null)
				{
					_context.SaveChanges();
					return true;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return false;
		}


		public List<Student> GetAllStudent()
		{
			var stu = _context.Students.ToList();
			return stu;
		}
	}
}
