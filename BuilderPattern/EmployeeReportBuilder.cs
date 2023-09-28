using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class EmployeeReportBuilder : IEmployeeReportBuilder
    {
        private EmployeeReport _employeeReport;
        private readonly IEnumerable<Employee> _employees;
        
        string underlines;

        public EmployeeReportBuilder(IEnumerable<Employee> employees)
        {
            _employees = employees;
            _employeeReport = new();

            // underlines init
            StringBuilder underlinesBuilder = new StringBuilder();
            for (int i = 0; i < 100; i++)
            {
                underlinesBuilder.Append("_");
            }
            underlines = underlinesBuilder.ToString();

        }
        public void BuildBody()
        {
            _employeeReport.Body =
                string.Join(Environment.NewLine, _employees.Select(e => $"Employee: {e.Name}\t\tSalary: {e.Salary}$"));
        }

        public void BuildFooter()
        {
            _employeeReport.Footer = $"\n{underlines}\n Total employees: {_employees.Count()}\n ";
            _employeeReport.Footer += $"Total salary {_employees.Sum(e => e.Salary)}$";
        }

        public void BuildHeader()
        {
            _employeeReport.Header = $"EMPLOYEES REPORT ON DATE: {DateTime.Now}\n";
           
            _employeeReport.Header += $"\n{underlines}\n";
        }

        public EmployeeReport GetReport()
        {
          EmployeeReport employeeReport = _employeeReport;
            _employeeReport = new();
            return employeeReport;
        }
    }
}
