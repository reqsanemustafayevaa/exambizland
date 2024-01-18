using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bizland.business.Exceptions
{
    public class ImageContentException:Exception
    {
        public string PropertyName { get; set; }
        public ImageContentException()
        {

        }
        public ImageContentException(string? message) : base(message)
        {

        }
        public ImageContentException(string propertyname, string? message) : base(message)
        {
            PropertyName = propertyname;
        }
    }
}
