﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer
{
    public class TestValueObject
    {
        [Key]
        public int Key { get; set; }   
        public string Message { get; set; }
    }
}
