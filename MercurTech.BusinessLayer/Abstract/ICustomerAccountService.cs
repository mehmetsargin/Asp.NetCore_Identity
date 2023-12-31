﻿using MercurTech.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercurTech.BusinessLayer.Abstract
{
    public interface ICustomerAccountService: IGenericService<CustomerAccount>
    {
        public List<CustomerAccount> TGetCustomerAccountList(int id);
    }
}
