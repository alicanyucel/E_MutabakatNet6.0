using E_Mutabakat.Business.Abstract;
using E_Mutabakat.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Business.Concrete
{
    public class BabsReconciliationManager:IBabsReconciliationService
    {
        private readonly IBabsReconciliaitonsDal _babsReconciliaitonsDal;
        public BabsReconciliationManager(IBabsReconciliaitonsDal babsReconciliaitonsDal)
        {
            _babsReconciliaitonsDal = babsReconciliaitonsDal;
        }
    }
  
}
