using Data_Layer.Repository;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class PredmetBusiness
    {
        Data_Layer.Repository.Predmet predmet;
        public PredmetBusiness()
        {
            predmet = new Data_Layer.Repository.Predmet();
        }

        public List<Shared.Models.Predmet> GetPredmets()
        {
            return predmet.GetPredmets();
        }
        public int Ukupno(String a)
        {
            return predmet.GetUkupno(a);
        }
    }
}

