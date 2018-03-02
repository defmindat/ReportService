using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace Business.Model
{
    public class Report
    {
        static object sync = new object();
        public string S { get; set; }
        public void Save()
        {
            lock (sync)
            {
                System.IO.File.WriteAllText(Config.ReportDirectory, S);
            }
        }
    }
}
