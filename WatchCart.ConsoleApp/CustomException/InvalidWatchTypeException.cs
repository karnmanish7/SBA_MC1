using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchCart.ConsoleApp.CustomException
{
    public class InvalidWatchTypeException : Exception
    {
        public InvalidWatchTypeException()
        {

        }

        public InvalidWatchTypeException(string name)
            : base(String.Format("Invalid Watch Type: {0}", name))
        {

        }
    }
}
