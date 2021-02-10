﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Order:IEntity
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public string EmployeeId { get; set; }

        public DateTime OrderDate { get; set; }
        public  string ShipCity { get; set; }

    }
}
