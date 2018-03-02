using System;
using Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReportService.Controllers;

namespace UnitTestProject
{
    [TestClass]
    public class ReportControllerTest
    {
        [TestMethod]
        public void Unvalid_Input_Data()
        {
            ReportController controller = new ReportController(new MonthReportGenerator());
            int year1 = -1;
            int month1 = -1;

            IActionResult result1 = controller.Download(year1, month1);

            int year2 = DateTime.UtcNow.Year + 1;
            int month2 = 13;

            IActionResult result2 = controller.Download(year2, month2);

            Assert.IsTrue(result1 is ContentResult);
            Assert.IsTrue(((ContentResult)result1).Content == "Неверные входные данные");

            Assert.IsTrue(result2 is ContentResult);
            Assert.IsTrue(((ContentResult)result2).Content == "Неверные входные данные");
        }

        [TestMethod]
        public void Valid_Input_Data()
        {
            ReportController controller = new ReportController(new MonthReportGenerator());
            int year = 2017;
            int month = 1;

            IActionResult result = controller.Download(year, month);

            Assert.IsTrue(result is FileContentResult);
        }
    }
}
