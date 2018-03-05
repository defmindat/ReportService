using System.Collections.Generic;
using System.Threading.Tasks;
using Business;
using Business.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class MonthlyReportTest
    {
        [TestMethod]
        public void Report_Multiply_Threads()
        {
            MonthReportGenerator generator = new MonthReportGenerator();

            List<Report> listReport = new List<Report>();

            Parallel.For(1, 5, (i) =>
            {
                listReport.Add(generator.Generate(2000 + i, i));
            });

            Assert.IsTrue(listReport.Count == 4);
        }
    }
}
