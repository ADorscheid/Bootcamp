using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TenmoServer.Models
{
    public class Transfer
    {
        public int TransferId { get; set; }
        public int TransferTypeId { get; set; }
        public int TransferStatusId { get; set; }
        public int AccountFrom { get; set; }
        public int AccountTo { get; set; }

        //could be lower case d for double?
        [Range(0, Double.PositiveInfinity, ErrorMessage = "Transfer amount must be greater than 0")]
        public decimal Amount { get; set; }
    }
}
