using E_Mutabakat.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Entities.Dtos
{
    public interface IAutDto
    {
        public User user { get; set; }
        public List<OperationClaim> operationClaims { get; set; }
    }
}
