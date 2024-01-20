using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface IBiznisUpisani
    {
        List<UpisanPredmet> GetUpisane(String Upisani);
        List<UpisanPredmet> GetUpisanPredmets();
    }
}
