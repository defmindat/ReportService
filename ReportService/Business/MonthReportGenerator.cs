using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Model;
using DataAccess;
using Entities;
using MonthNameResolver;
using ReportService.Domain;

namespace Business
{
    public class MonthReportGenerator : IReportGenerator
    {
        private readonly List<(Action<Employee, Report>, Employee)> actions =
            new List<(Action<Employee, Report>, Employee)>();

        public Report Generate(int year, int month)
        {
            if (year < 1900 || year > DateTime.UtcNow.Year || month < 1 || month > 12) return null;
            var report = new Report {S = MonthName.GetName(year, month) + " " + year};

            var employees = DAEmployee.GetEmployees();
            //var departments = DADepartment.GetDepartments();

            Parallel.ForEach(employees, (emp) =>
            {
                emp.BuhCode = EmpCodeResolver.GetCode(emp.Inn).Result;
                emp.Salary = emp.Salary();
            });


            var groupByDep = employees.GroupBy(x => x.Department);

            foreach (var grouping in groupByDep)
            {
                AddLine(grouping.Key);

                foreach (var emp in grouping) AddEmployeeLine(emp);

                AddEmployeeLine(new Employee {Name = "Всего по отделу ", Salary = grouping.Sum(x => x.Salary)});
            }

            AddLine(null);
            AddEmployeeLine(new Employee {Name = "Всего по предприятию ", Salary = employees.Sum(x => x.Salary)});

            foreach (var act in actions) act.Item1(act.Item2, report);
            report.Save();
            return report;
        }

        public void AddLine(string departmentName)
        {
            actions.Add((new ReportFormatter(null).NL, new Employee()));
            actions.Add((new ReportFormatter(null).WL, new Employee()));
            actions.Add((new ReportFormatter(null).NL, new Employee()));
            actions.Add((new ReportFormatter(null).WD, new Employee {Department = departmentName}));
        }

        public void AddEmployeeLine(Employee emp)
        {
            actions.Add((new ReportFormatter(emp).NL, emp));
            actions.Add((new ReportFormatter(emp).WE, emp));
            actions.Add((new ReportFormatter(emp).WT, emp));
            actions.Add((new ReportFormatter(emp).WS, emp));
        }
    }
}