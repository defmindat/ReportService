using System;
using System.Collections.Generic;
using System.Text;
using Database;
using Entities;

namespace DataAccess
{
    public static class DAEmployee
    {
        public static List<Employee> GetEmployees()
        {
            // Тут по хорошему надо отдельно создавать отдельный проджект куда писать хранимки, но ограничимся так
            return DBHelper.List<Employee>("SELECT e.name as Name, e.inn as Inn, d.name as Department from emps e left join deps d on e.departmentid = d.id and d.active = true");
        }
    }
}
