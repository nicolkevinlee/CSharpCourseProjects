using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDataParser.Objects;

public static class Logger
{
    private static string _fileNameLogs = "log.txt";

    public static void LogException(Exception ex)
    {
        string currentTime = DateTime.Now.ToString("[M/d/yyyy h:mm:ss tt]");
        string logText = $"{currentTime}" + Environment.NewLine +
            $"Exception message: {ex.Message}" + Environment.NewLine +
            $"Stack trace: {ex.StackTrace}" + Environment.NewLine + Environment.NewLine;

        File.AppendAllText(_fileNameLogs, logText);
    }
}
