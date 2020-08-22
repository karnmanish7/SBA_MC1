using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchCart.ConsoleApp.CustomException
{
    public class InvalidCatalogTypeException : Exception
    {
        public InvalidCatalogTypeException()
        {

        }

        public InvalidCatalogTypeException(string name)
            : base(String.Format("Invalid Catalog Type: {0}", name))
        {

        }
    }
}
