using System;
using Business.Model;

namespace ReportService.Domain
{
    public class ReportFormatter
    {
        public ReportFormatter(Entities.Employee e)
        {
            Employee = e;
        }

        public Action<Entities.Employee, Report> NL = (e, s) => s.S = s.S + Environment.NewLine;
        public Action<Entities.Employee, Report> WL = (e, s) => s.S = s.S + "--------------------------------------------";
        public Action<Entities.Employee, Report> WT = (e, s) => s.S = s.S + "         ";
        public Action<Entities.Employee, Report> WE = (e, s) => s.S = s.S + e.Name;
        public Action<Entities.Employee, Report> WS = (e, s) => s.S = s.S + e.Salary + "р";
        public Action<Entities.Employee, Report> WD = (e, s) => s.S = s.S + e.Department;
        public Entities.Employee Employee { get; }
    }
}
