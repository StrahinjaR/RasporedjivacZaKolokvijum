using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface IPredmetRepository
    {
        List<Predmet> GetPredmets();
        int GetUkupno(String predmet);
        int DeletePredmet(Predmet predmet);
        int UpdatePredmet(Predmet predmet);
        int CreatePredmet(Predmet predmet);

        void UpdateBrojUpisanih();
    }
}
