using Data_Layer.Repository;
using Shared.Interfaces;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class PredmetBusiness: IBiznisPredmet
    {
        private readonly IPredmetRepository predmetRepo;
        public PredmetBusiness(IPredmetRepository predmetRepository)
        {
            this.predmetRepo = predmetRepository ?? throw new ArgumentNullException(nameof(predmetRepository));
        }

        public List<Shared.Models.Predmet> GetPredmets()
        {
            List<Shared.Models.Predmet> predmets = this.predmetRepo.GetPredmets();
            return predmets;
        }

        public int Ukupno(String a)
        {
             int rowsaffected=this.predmetRepo.GetUkupno(a);
            if (rowsaffected > 0)
            {
                return rowsaffected;
            }
            else { return 0; }
        }

        public int CreatePredmet(Shared.Models.Predmet predmet)
        {
            int rowsaffected = this.predmetRepo.CreatePredmet(predmet);
            if (rowsaffected > 0)
            {
                return 5;
            }
            else { return 6; }
        }
        public int DeletePredmet(Shared.Models.Predmet predmet)
        {
            int rowsaffected = this.predmetRepo.DeletePredmet(predmet);
            if (rowsaffected > 0)
            {
                return 5;
            }
            else { return 6; }
        }

        public int UpdatePredmet(Shared.Models.Predmet predmet)
        {
            int rowsaffected = this.predmetRepo.UpdatePredmet(predmet);
            if (rowsaffected > 0)
            {
                return 5;
            }
            else { return 6; }
        }
    }
}

