using MercurTech.DataAccessLayer.Abstract;
using MercurTech.DataAccessLayer.Repositories;
using MercurTech.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercurTech.DataAccessLayer.EntityFramework
{
    public class EfCustomerAccountProcessDal : GenericRepository<CustomerAccountProcess>, ICustomerAccountProcessDal
    {
    }
}
