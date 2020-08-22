using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchCart.Models;

namespace WatchCart.Repository.Order
{
    public interface IWatchCatalog
    {
        List<AnalogWatch> AnalogCatalog();
        List<DigitalWatch> DigitalCatalog();
        AnalogWatch GetAnalogWatchById(int Id);
        DigitalWatch GetDigitalWatchById(int Id);
    }
}
