using System;
using System.Collections.Generic;
using System.Text;
using Database;
using Entities;

namespace DataAccess
{
    public static class DADepartment
    {
        public static List<Department> GetDepartments()
        {
            // Тут по хорошему надо отдельно создавать отдельный проджект куда писать хранимки, но ограничимся так
            return DBHelper.List<Department>("SELECT ID, Name from deps d where d.active = true");
        }
    }
}
