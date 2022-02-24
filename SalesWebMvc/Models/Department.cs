using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
    {
    public class Department
        {
        public int Id { get; set; }
        public String Name { get; set; }

        public Department(int id, string name)
            {
            Id = id;
            Name = name;
            }

        public override string ToString()
            {
            return base.ToString();
            }
        }
    }
