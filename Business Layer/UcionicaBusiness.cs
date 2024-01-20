using Data_Layer.Repository;
using Shared.Interfaces;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shared.Interfaces;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class UcionicaBusiness: IBiznisUcionica
    {
        private readonly  IUcionicaRepository ucionica;
        public UcionicaBusiness(IUcionicaRepository ucionica1)
        {
            this.ucionica = ucionica1 ?? throw new ArgumentNullException(nameof(ucionica1));
        }

        public List<Ucionica> GetUcionicas()
        {
            List<Ucionica> ucionice = this.ucionica.GetUcionicas();
            return ucionice;

        }
        public List<Ucionica> GetTips(String a)
        {
            List<Ucionica> ucionice = this.ucionica.GetTips(a);
            return ucionice;
        }
    }
}
    