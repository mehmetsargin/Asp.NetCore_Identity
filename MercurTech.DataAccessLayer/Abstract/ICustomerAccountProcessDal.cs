﻿using MercurTech.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercurTech.DataAccessLayer.Abstract
{
    public interface ICustomerAccountProcessDal:IGenericDal<CustomerAccountProcess>
    {
        List<CustomerAccountProcess> MyLastProcess(int id);
    }
}
