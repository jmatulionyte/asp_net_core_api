using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp_net_core_rest_api.Models
{
	public class VillaNumber
    {   //like 101, 102, key - it is uniqe, db not generates it, user provides it
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)] 
		public int VillaNo { get; set; }

        [ForeignKey("Villa")]
        public int VillaID { get; set; }

        //foreign key mapper
        public Villa Villa { get; set; }

        public string SpecialDetails { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

    }
}

