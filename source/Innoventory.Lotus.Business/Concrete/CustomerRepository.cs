using Innoventory.Lotus.Business.Abstract;
using Innoventory.Lotus.Core.Common;
using Innoventory.Lotus.Database.DataEntities;
using Innoventory.Lotus.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Innoventory.Lotus.Business.Concrete
{
    [Export(typeof(ICustomerRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CustomerRepository : GenericRepository<Customer, CustomerViewModel>, ICustomerRepository
    {

        protected Customer GetDomainEntity(CustomerViewModel viewModel)
        {
            Customer customer = ObjectMapper.PropertyMap(viewModel, new Customer());

            return customer;
        }



        protected override CustomerViewModel GetEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<Customer> entitySet = dbContext.CustomerSet;

            Customer dmCustomer = entitySet.FirstOrDefault(x => x.CustomerId == id);

            CustomerViewModel custVM = new CustomerViewModel();

            CustomerViewModel customerVM = ObjectMapper.PropertyMap(dmCustomer, custVM);

            return customerVM;

        }

        protected override List<CustomerViewModel> GetEntities(InnoventoryDBContext dbContext)
        {
            DbSet<Customer> entitySet = dbContext.CustomerSet;

            List<Customer> customers = entitySet.ToList();

            List<CustomerViewModel> retList = new List<CustomerViewModel>();

            foreach (Customer customer in customers)
            {
                CustomerViewModel custVM = new CustomerViewModel();


                retList.Add(ObjectMapper.PropertyMap(customer, custVM));

            }

            return retList;
        }

        protected override List<CustomerViewModel> Find(InnoventoryDBContext dbContext, Func<CustomerViewModel, bool> predicate)
        {

            List<CustomerViewModel> customers = (GetEntities(dbContext)).Where(predicate).ToList();

            return customers;
        }

        protected override bool DeleteEntity(InnoventoryDBContext dbContext, Guid id)
        {
            DbSet<Customer> entitySet = dbContext.CustomerSet;

            //CustomerViewModel customerVM = GetEntity(dbContext, id);


            Customer customer = entitySet.FirstOrDefault(x => x.CustomerId == id);

            if (customer != null)
            {
                entitySet.Remove(customer);
                dbContext.SaveChanges();
            }
            return true;
        }

        protected override bool AddEntity(InnoventoryDBContext dbContext, CustomerViewModel viewModel)
        {
            Customer customer = GetDomainEntity(viewModel);
            dbContext.CustomerSet.Add(customer);

            dbContext.SaveChanges();
            return true;
        }

        protected override bool EditEntity(InnoventoryDBContext dbContext, CustomerViewModel viewModel)
        {
            DbSet<Customer> entitySet = dbContext.CustomerSet;

            Customer customer = GetDomainEntity(viewModel);

            entitySet.Attach(customer);

            dbContext.Entry(customer).State = EntityState.Modified;

            dbContext.SaveChanges();

            return true;

        }

    }
}
