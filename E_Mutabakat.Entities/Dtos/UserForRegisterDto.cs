using E_Mutabakat.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Entities.Dtos
{
    public class UserForRegisterDto
    {
       
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
