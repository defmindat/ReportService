using Common;

namespace Business.Model
{
    public class Report
    {
        public string Name { get; }
        public Report(int year, int month)
        {
            Name = string.Format(Config.ReportDirectory, year + "-" + month);
        }

        static object sync = new object();
        public string S { get; set; }
        public void Save()
        {
            lock (sync)
            {
                System.IO.File.WriteAllText(Name, S);
            }
        }
    }
}
