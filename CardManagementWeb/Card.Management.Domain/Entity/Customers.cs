﻿using Card.Management.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;


namespace Card.Management.Application.Entity
{
    public class Customers
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }

        public string Email { get; set; }


        public string? PhoneNumber { get; set; }
        public List<Accounts> accounts { get; set; }

    }
}