namespace Manero.Shared.Interfaces
{
    /// <summary>
    /// Represents a service for managing customers.
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Adds a customer to the list.
        /// </summary>
        /// <param name="customer">The customer to add.</param>
        /// <returns>True if the customer was successfully added; otherwise, false.</returns>
        bool AddCustomerToList(ICustomer customer);

        /// <summary>
        /// Retrieves a readable list of customers.
        /// </summary>
        /// <returns>An enumerable collection of customers.</returns>
        IEnumerable<ICustomer> GetCustomersFromList();

        /// <summary>
        /// Retrieves a customer from the list using their email.
        /// </summary>
        /// <param name="email">The email of the customer to retrieve.</param>
        /// <returns>The customer with the specified email, or null if not found.</returns>
        ICustomer GetCustomerFromList(string email);

        /// <summary>
        /// Deletes a customer from the list.
        /// </summary>
        /// <param name="customer">The customer to delete.</param>
        /// <returns>True if the customer was successfully deleted; otherwise, false.</returns>
        bool DeleteCustomer(ICustomer customer);
    }
}
// Källa jag tog hjälp från ChatGPT :) 