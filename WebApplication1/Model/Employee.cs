using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAO;

namespace WebApplication1.Model
{
	public class Employee
	{		
		public DBOperation _dBOperation = new DBOperation();
		public int SaveEmployee(string connection, EmployeeDto employeeDto)
		{
			
			string query = "Insert into  Employee values('"+employeeDto.EmployeeName+"',"+employeeDto.EmployeeAge+","+employeeDto.EmployeeSalary+",'"+employeeDto.Email+"',"+employeeDto.DeptId+")";
			int result = _dBOperation.InsertEmployee(connection, query);
			return result;
		}
		public List<EmployeeDto> GetEmployees(string connection)
		{
			List<EmployeeDto> res = new List<EmployeeDto>();
		   string query = "select * from Employee";
			DataSet  result=_dBOperation.GetEmployees(connection, query);
			res = result.Tables[0].AsEnumerable().Select(dt => new EmployeeDto
			{
				EmployeeId = dt.Field<int>("EmployeeID"),
				EmployeeName = dt.Field<string>("EmployeeName"),
				EmployeeAge = dt.Field<int>("EmployeeAge"),
				EmployeeSalary = dt.Field<int>("EmployeeSalary"),
				Email = dt.Field<string>("Email"),
				DeptId = dt.Field<int>("DeptId")
			}).ToList();
			return res;
		}
		public int DeleteEmployee(string connection,int EmployeeId)
		{
			
			string query = "DELETE FROM  Employee where EmployeeId=" + EmployeeId.ToString()+"";
			int result = _dBOperation.DeleteEmployee(connection, query);
			return result;
		}

		public int UpdateEmployee(string connection, EmployeeDto empdto)
		{
			string query = "UPDATE Employee SET EmployeeName = '" + empdto.EmployeeName + "',EmployeeAge = " + empdto.EmployeeAge + " WHERE EmployeeId = " + empdto.EmployeeId.ToString()+"";
			int result = _dBOperation.UpdateEmployee(connection, query);
			return result;
		}

	}
}
