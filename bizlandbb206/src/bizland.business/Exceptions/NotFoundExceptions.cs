using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bizland.business.Exceptions
{
    public class NotFoundExceptions:Exception
    {
        public string PropertyName {  get; set; }
        public NotFoundExceptions()
        {
            
        }
        public NotFoundExceptions(string? message):base(message)
        {
            
        }
        public NotFoundExceptions(string propertyname,string? message):base(message) 
        {
            PropertyName = propertyname;
        }
    }
}
