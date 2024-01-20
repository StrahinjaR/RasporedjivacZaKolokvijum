using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface IBiznisPredmet
    {
        List<Shared.Models.Predmet> GetPredmets();

        int Ukupno(String a);


        int CreatePredmet(Shared.Models.Predmet predmet);

        int DeletePredmet(Shared.Models.Predmet predmet);


        int UpdatePredmet(Shared.Models.Predmet predmet);
    }
}
