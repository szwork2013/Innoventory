using Innoventory.Lotus.Repository.Abstract;
using Innoventory.Lotus.Core.Common;
using Innoventory.Lotus.Database.DataEntities;
using Innoventory.Lotus.ViewModels;

using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.Composition;



namespace Innoventory.Lotus.Repository.Concrete
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


        public FindResult<CustomerViewModel> SearchCustomer(string searchString)
        {
            FindResult<CustomerViewModel> result = new FindResult<CustomerViewModel>()
            {
                Success = false,
            };

            using (InnoventoryDBContext dbContext = new InnoventoryDBContext())
            {

                List<Customer> customers = null;

                if (!string.IsNullOrEmpty(searchString) && searchString.Trim() != string.Empty)
                {
                    customers = dbContext.CustomerSet.Where(x => x.CustomerName.Contains(searchString)).OrderBy(x => x.CustomerName).ToList();
                }
                else
                {
                    customers = dbContext.CustomerSet.OrderBy(x => x.CustomerName).ToList();
                }

                List<CustomerViewModel> customerVMs = new List<CustomerViewModel>();

                result.Entities = customerVMs;

                if (customers != null && customers.Count > 0)
                {

                    foreach (Customer customer in customers)
                    {

                        CustomerViewModel customerVM = ObjectMapper.PropertyMap(customer, new CustomerViewModel());

                        if (customerVM != null)
                        {
                            customerVMs.Add(customerVM);
                        }

                    }

                }

            }

            result.Success = true;

            return result;
        }
    }
}
