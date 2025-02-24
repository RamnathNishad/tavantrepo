using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRelationShipsDemo
{
    public  class Customer
    {
        public int Id { get; set; }
        public string CustName { get; set; }

        public List<Order> Orders { get; set; }
    }

}
