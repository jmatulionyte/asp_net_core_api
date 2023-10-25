using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp_net_core_rest_api.Models
{
	public class Player
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EnrolledToTournament { get; set; }

        public int Points { get; set; }

        public string GroupName { get; set; }
    }
}

