using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItlaTaks.Infraestructure.Exceptions
{
    public class MateriaException : Exception
    {
        public MateriaException()
        {
        }
        public MateriaException(string message)
            : base(message)
        {
        }
    }
}
