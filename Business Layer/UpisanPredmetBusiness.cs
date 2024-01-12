using Data_Layer.Repository;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class UpisanPredmetBusiness
    {
        UpisaniPredmeti upisaniPredmet;
        public UpisanPredmetBusiness()
        {
            upisaniPredmet = new UpisaniPredmeti();
        }

        public List<UpisanPredmet> GetUpisanPredmets()
        {
            return upisaniPredmet.GetUpisanPredmets();
        }
        public List<UpisanPredmet>GetUpisane(String a)
        {
            return upisaniPredmet.GetUpisane(a);
        }
    }
}
