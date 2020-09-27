using ChallengeBank.Domain.Entities;
using ChallengeBank.Infra.Interfaces;
using System.Collections.Generic;

namespace ChallengeBank.Service.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer Create(Customer customer)
        {
            _customerRepository.Add(customer);

            return customer;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _customerRepository.GetAll();
        }
    }
}
