﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Common.Exceptions
{
    public class DuplicationException : Exception
    {
        public DuplicationException(string message) : base(message)
        {
        }
    }
}
