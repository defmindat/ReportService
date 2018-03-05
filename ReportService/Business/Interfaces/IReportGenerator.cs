using Business.Model;

namespace Business.Interfaces
{
    public interface IReportGenerator
    {
        Report Generate(int year, int month);
    }
}
