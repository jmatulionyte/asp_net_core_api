using System;
namespace asp_net_core_rest_api.Logging
{
	public interface ILogging
	{
		public void Log(string message, string type);
	}
}

