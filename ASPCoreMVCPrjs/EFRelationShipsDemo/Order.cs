using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRelationShipsDemo
{
    public class Order
    {
        public int Id { get; set; }
        public int Amount { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
    }
}
