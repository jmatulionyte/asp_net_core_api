using System;
using System.Net;

namespace asp_net_core_rest_api.Models
{
	public class APIResponse
	{
		public HttpStatusCode StatusCode { get; set; }

		public bool IsSuccess { get; set; } = true;

		public List<string> ErrorMessages { get; set; }

		public object Result { get; set; }

	}
}

