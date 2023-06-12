
using Employee.EmployeeCardRef;
using Employee.EmployeesRef;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;

namespace Employee.Functions
{
    public class Helpers
    {
       public static List<Employees> GetEmployees()
        {
            List<Employees> employees = new List<Employees>();
            employees = Webservices.employees_Service().ReadMultiple(null, null, 0).ToList();

            return employees;   
        }
        public static EmployeeCard CreateEmployee(EmployeeCard employee)
        {
             Webservices.employeeCard_Service().Create(ref employee);  
            return employee;
        }
        public static EmployeeCard UpdateEmployee(EmployeeCard employee)
        {
             Webservices.employeeCard_Service().Update(ref employee);  
            return employee;                       
        }
        public static void DeleteEmployee( string key)
        {
            Webservices.employeeCard_Service().Delete(key);
            
        }
        public static EmployeeCard GetEmployee(string EmployeeNo)
        {
            var employee =Webservices.employeeCard_Service().Read(EmployeeNo);

            return employee;
        }
    }

    public class Webservices
    {
        public static Employees_Service employees_Service()
        {
            Employees_Service service = new Employees_Service();
            service.Url = ConfigurationManager.AppSettings["Path"]+ "Page/Employees";
            service.UseDefaultCredentials = false;
            service.Credentials = credentials;
            return service;
        }
        public static EmployeeCard_Service employeeCard_Service()
        {
            EmployeeCard_Service service = new EmployeeCard_Service();
            service.Url = ConfigurationManager.AppSettings["Path"]+ "Page/EmployeeCard";
            service.UseDefaultCredentials = false;
            service.Credentials = credentials;
            return service;
        }
        private static NetworkCredential credentials = new NetworkCredential(ConfigurationManager.AppSettings["SoapUsername"], ConfigurationManager.AppSettings["SoapPassword"]);
    }
}