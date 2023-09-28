/***
 * Builder is CREATIONAL Design Pattern
 *
 *Create Interface
 *Create Builder
 *Create Director (if it is only 1 object to build you can not you director)
 *
 ***/

using BuilderPattern;

List<Employee> employees = new List<Employee>()
{
    new Employee { Name = "Ivan", Salary = 100},
    new Employee { Name = "Vladlen", Salary = 111},
    new Employee { Name = "Boris", Salary = 222},
    new Employee { Name = "Mahmoud", Salary = 333},
    new Employee { Name = "Salem", Salary = 444}
};

EmployeeReportBuilder employeeReportBuilder = new EmployeeReportBuilder(employees);

EmployeeDirector employeeDirector = new EmployeeDirector(employeeReportBuilder);
employeeDirector.Build();
var report = employeeReportBuilder.GetReport();
Console.WriteLine(report.ToString());





