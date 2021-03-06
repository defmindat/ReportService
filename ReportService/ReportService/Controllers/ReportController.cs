﻿using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ReportService.Controllers
{
    [Route("api/[controller]")]
    public class ReportController : Controller
    {
        private IReportGenerator _reportGenerator;
        public ReportController(IReportGenerator reportGenerator)
        {
            _reportGenerator = reportGenerator;
        }

        [HttpGet]
        [Route("{year}/{month}")]
        public IActionResult Download(int year, int month)
        {
            var report = _reportGenerator.Generate(year, month);
            if (report == null)
            {
                return Content("Неверные входные данные");
            }

            var file = System.IO.File.ReadAllBytes(report.Name);
            var response = File(file, "application/octet-stream", "report.txt");
            return response;
        }
    }
}
