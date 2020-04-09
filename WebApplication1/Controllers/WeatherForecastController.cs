using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly ILogger<WeatherForecastController> _logger;
		private IConfiguration _iConfig;
		public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration iConfig)
		{
			_logger = logger;
			_iConfig = iConfig;
		}
		[HttpPost("EmployeeNew")]
		public int SaveEmployee(EmployeeDto employeeDto)
		{
			Employee employee = new Employee();
			string connectionString = _iConfig["Database:DbConnection"]; ;
			int result = employee.SaveEmployee(connectionString, employeeDto);
			return result;
		}
		
		//Attribute Routing
		[HttpGet("EmployeeList")]
		public IEnumerable<EmployeeDto> GetEmployee()
		{
			Employee employee = new Employee();
			string connectionString= _iConfig.GetValue<string>("Database:DbConnection"); 
			List<EmployeeDto> result = employee.GetEmployees(connectionString);
			return result;
		}
		[HttpDelete("EmployeeRemove/{employeeId}")]
		public int DeleteEmployee(string employeeId)
		{
			Employee employee = new Employee();
			string connectionString = _iConfig.GetValue<string>("Database:DbConnection"); ;
			int result = employee.DeleteEmployee(connectionString, Convert.ToInt32(employeeId));
			return result;
		}
		[HttpPut("UpdateEMPDetails")]
		public int UpdateEmp(EmployeeDto employeeDto,string empid)
		{
			Employee emp = new Employee();
			string connectionString = _iConfig.GetValue<string>("Database:DbConnection");
			int result = emp.UpdateEmployee(connectionString, employeeDto);
			return result;
		}
	}
}
