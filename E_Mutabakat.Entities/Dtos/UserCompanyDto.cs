﻿using E_Mutabakat.Core.Entities;
using E_Mutabakat.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Entities.Dtos
{
    public class UserCompanyDto:User,IDto
    {
       public int companyid { get; set; }   



    }
}
