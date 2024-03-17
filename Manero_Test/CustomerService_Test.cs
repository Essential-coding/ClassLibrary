
using Manero.Shared.Interfaces;
using Manero.Shared.Models;
using Manero.Shared.Services;


namespace Manero_Test
{
    public class CustomerService_Test
    {
        private readonly CustomerService _customerService;

        public CustomerService_Test()
        {
           
            _customerService = new CustomerService(new object());
        }

        [Fact]
        public void AddCustomerToList_Test()
        {
            // Arrange
            ICustomer customer = new Customer
            {
                Email = "test@test.com",
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "1234567890"
            };

            // Act
            bool result = _customerService.AddCustomerToList(customer);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void GetCustomerFromList_Test()
        {
            // Arrange
            string email = "test@test.com";
            ICustomer customerToAdd = new Customer
            {
                Email = email,
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "1234567890"
            };
            _customerService.AddCustomerToList(customerToAdd);

            // Act
            ICustomer customer = _customerService.GetCustomerFromList(email);

            // Assert
            Assert.NotNull(customer);
            Assert.Equal(email, customer.Email);

            // Cleanup
            _customerService.DeleteCustomer(customer);
        }

        [Fact]
        public void GetCustomersFromList_Test()
        {
            // Act
            IEnumerable<ICustomer> customers = _customerService.GetCustomersFromList();

            // Assert
            Assert.NotNull(customers);
            // No specific assertions here, as we're not sure about the contents of the list
        }

        [Fact]
        public void DeleteCustomer_Test()
        {
            // Arrange
            string email = "test@test.com";
            ICustomer customer = new Customer
            {
                Email = email,
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "1234567890"
            };
            _customerService.AddCustomerToList(customer);

            // Act
            bool result = _customerService.DeleteCustomer(customer);

            // Assert
            Assert.True(result);
        }
    }
}
