using Data_Layer.Repository;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class UcionicaBusiness
    {
        UcionicaRepository ucionica;
        public UcionicaBusiness()
        {
            ucionica = new UcionicaRepository();
        }

        public List<Ucionica> GetUcionicas()
        {
            return ucionica.GetUcionicas();

        }
        public List<Ucionica> GetTips(String a)
        {
            return ucionica.GetTips(a);
        }
    }
}
    