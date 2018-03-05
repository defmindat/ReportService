namespace Common
{
    public static class Config
    {
        public static string ConnectionString =
            "Host=127.0.0.1;Username=postgres;Password=fuckinglife;Database=Enterprise"; // вообще надо бы брать из веб конфига

        public static string ReportDirectory = "C:\\Users\\User\\report_{0}.txt";
    }
}
