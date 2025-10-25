using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItlaTaks.Infraestructure.Exceptions
{
    public class ProfesorException : Exception
    {
        public ProfesorException()
        {
        }
        public ProfesorException(string message)
            : base(message)
        {
        }
    }
}
