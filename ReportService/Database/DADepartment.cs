using System.Collections.Generic;
using Database;
using Entities;

namespace DataAccess
{
    public static class DADepartment
    {
        public static List<Department> GetDepartments()
        {
            // Тут по хорошему надо отдельно создавать отдельный проджект куда писать хранимки, но ограничимся так
            return DBHelper.List<Department>("SELECT ID, Name, Active from deps d where d.active = true");
        }
    }
}
