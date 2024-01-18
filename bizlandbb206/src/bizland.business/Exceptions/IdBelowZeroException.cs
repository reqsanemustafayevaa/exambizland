using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bizland.business.Exceptions
{
    public class IdBelowZeroException:Exception
    {
        public string PropertyName { get; set; }
        public IdBelowZeroException()
        {

        }
        public IdBelowZeroException(string? message) : base(message)
        {

        }
        public IdBelowZeroException(string propertyname, string? message) : base(message)
        {
            PropertyName = propertyname;
        }
    }
}
