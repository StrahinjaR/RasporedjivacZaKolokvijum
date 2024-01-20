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
        Data_Layer.Repository.Predmet predmetRepo;
        public PredmetBusiness()
        {
            predmetRepo = new Data_Layer.Repository.Predmet();
        }

        public List<Shared.Models.Predmet> GetPredmets()
        {
            return predmetRepo.GetPredmets();
        }
        public int Ukupno(String a)
        {
            return predmetRepo.GetUkupno(a);
        }

        public int CreatePredmet(Shared.Models.Predmet predmet)
        {
            return predmetRepo.CreatePredmet(predmet);
        }
        public int DeletePredmet(Shared.Models.Predmet predmet)
        { return predmetRepo.DeletePredmet(predmet); }

        public int UpdatePredmet(Shared.Models.Predmet predmet)
        {
            return predmetRepo.UpdatePredmet(predmet);
        }
    }
}

