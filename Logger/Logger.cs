namespace GameDataParser.Logger
{
    public class Logger : ILogger
    {
        public void LogErrorMessage(Exception exception)
        {
            string filePath = "logs.txt";
            string message = exception.Message;
            string logMessage = $"[{DateTime.Now}] Exception Message:{message}, Strack trace:{new System.Diagnostics.StackTrace(exception)}{Environment.NewLine}";

            if (!File.Exists(filePath))
            {
                using StreamWriter sw = File.CreateText(filePath);
                sw.WriteLine(logMessage);
            }
            else
            {
                using StreamWriter sw = File.AppendText(filePath);
                sw.WriteLine(logMessage);
            }
        }
    }
}
