using System;
using System.Collections.Generic;
using System.Text;

namespace AirTickets.Core.Encrypt
{
    internal struct HashSalt
    {
        internal string Hash
        {
            get; set;
        }
        internal string Salt
        {
            get; set;
        }
    }
}
