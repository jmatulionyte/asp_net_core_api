using System;
namespace asp_net_core_rest_api.Logging
{
	public class LoggingV2 : ILogging
	{
        public void Log(string message, string type)
        {
            if (type == "error")
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR - " + message);
                Console.BackgroundColor = ConsoleColor.White;
            }
            else
            {
                if (type == "warning")
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("WARNING - " + message);
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine(message);
                }
                    
            }
        }
    }
}

