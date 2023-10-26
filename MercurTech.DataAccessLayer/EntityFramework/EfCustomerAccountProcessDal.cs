using MercurTech.DataAccessLayer.Abstract;
using MercurTech.DataAccessLayer.Concrete;
using MercurTech.DataAccessLayer.Repositories;
using MercurTech.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercurTech.DataAccessLayer.EntityFramework
{
    public class EfCustomerAccountProcessDal : GenericRepository<CustomerAccountProcess>, ICustomerAccountProcessDal
    {
        public List<CustomerAccountProcess> MyLastProcess(int id)
        {
            using var context = new Context();
            var values = context.CustomerAccountProcesses.Include(y=> y.SenderCustomer).ThenInclude(z=>z.AppUser).Where(x => x.ReceiverID == id || x.SenderID == id) .ToList();
            return values;
        }
    }
}
