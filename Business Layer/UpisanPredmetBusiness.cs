﻿using Data_Layer.Repository;
using Shared.Interfaces;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class UpisanPredmetBusiness: IBiznisUpisani
    {
        private readonly IUpisaniPredmetiRepository upisaniPredmet;
        public UpisanPredmetBusiness(IUpisaniPredmetiRepository upisanipredmet)
        {
            this.upisaniPredmet = upisanipredmet ?? throw new ArgumentNullException(nameof(upisanipredmet));
        }

        public List<UpisanPredmet> GetUpisanPredmets()
        {
            List<UpisanPredmet> upisani = this.upisaniPredmet.GetUpisanPredmets();
            return upisani;
        }
        public List<UpisanPredmet>GetUpisane(String a)
        {
            List<UpisanPredmet> upisani = this.upisaniPredmet.GetUpisane(a);
            return upisani;
        }

        public List<UpisanPredmet> WHERE(int a)
        {
            return upisaniPredmet.GetUpisanPredmets().Where(u => u.PREDMET_ID == a).ToList();
        }

        public int Upis(Shared.Models.UpisanPredmet upisani)
        {
            return upisaniPredmet.CreateUpisaniPredmet(upisani);
        }

        public int DeleteUpisaniPredmet(Shared.Models.UpisanPredmet upisani)
        {
            return upisaniPredmet.DeleteUpisaniPredmet(upisani);
        }
    }
}
