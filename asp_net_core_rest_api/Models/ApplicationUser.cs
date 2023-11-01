using System;
using Microsoft.AspNetCore.Identity;

namespace asp_net_core_rest_api.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string Name { get; set; }
	}
}

