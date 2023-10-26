using MercurTech.DataAccessLayer.Abstract;
using MercurTech.DataAccessLayer.Repositories;
using MercurTech.DataAccessLayer.Concrete;
using MercurTech.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercurTech.DataAccessLayer.EntityFramework
{
    public class EfCustomerAccountDal : GenericRepository<CustomerAccount>, ICustomerAccountDal
    {
        public List<CustomerAccount> GetCustomerAccountList(int id)
        {
            using var context = new Context();
            var values= context.CustomerAccounts.Where(x=> x.AppUserID == id).ToList();
            return values;
        }
    }
}
