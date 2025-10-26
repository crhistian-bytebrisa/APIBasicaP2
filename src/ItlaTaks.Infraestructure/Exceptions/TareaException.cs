using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItlaTaks.Infraestructure.Exceptions
{
    public class TareaException : Exception
    {
        public TareaException()
        {
        }
        public TareaException(string message)
            : base(message)
        {
        }
    }
}
