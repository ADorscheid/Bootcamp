using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TenmoServer.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public int UserId { get; set; }


        //could be lower case d for double?
        [Range (0, Double.PositiveInfinity, ErrorMessage = "Balance must be greater than 0")]
        public decimal Balance { get; set; }
    }
}
