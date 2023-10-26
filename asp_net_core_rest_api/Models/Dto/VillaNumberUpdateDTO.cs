using System;
using System.ComponentModel.DataAnnotations;

namespace asp_net_core_rest_api.Models.Dto
{//in dto, cn skip feild that should be exposed
	public class VillaNumberUpdateDTO
	{
        [Required]
        public int VillaNo { get; set; }
        public string SpecialDetails { get; set; }
    }
}

