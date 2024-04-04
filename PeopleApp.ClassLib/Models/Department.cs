﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleApp.ClassLib.Models
{
    public class Department
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Person>? People { get; set; } = new List<Person>();
    }
}