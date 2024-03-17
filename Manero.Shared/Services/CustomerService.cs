using Manero.Shared.Interfaces;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Manero.Shared.Services;

public class CustomerService : ICustomerService
{
    private readonly FileService _fileService = new FileService();

    private List<ICustomer> _customers = new List<ICustomer>();
    private object @object;
    private readonly string _filePath = @"c:\projects\contacts.json";

    public CustomerService(object @object)
    {
        this.@object = @object;
    }

    public CustomerService()
    {
    }

    /// <summary>
    /// Add a customer to a customer list
    /// </summary>
    /// <param name="customer">a customer of type ICustomer</param>
    /// <returns>Returns true if successful, or false if it fails or customer already exists</returns>
    public bool AddCustomerToList(ICustomer customer)
    {
        try
        {
            // Om kundens email inte finns i listan adda kunden
            if (!_customers.Any(x => x.Email == customer.Email))
            {
                _customers.Add(customer);

                string json = JsonConvert.SerializeObject(_customers, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

                var result = _fileService.SaveContentToFile(_filePath, json);
                return result;

            }


        }
        catch (Exception ex) { Debug.WriteLine("CustomerService - AddCustomerToList:: " + ex.Message); }
        return false;
    }



    //Returns specific customer 
    public ICustomer GetCustomerFromList(string email)
    {
        try
        {
            GetCustomersFromList();

            var customer = _customers.FirstOrDefault(x => x.Email == email);

            return customer;
        }
        catch (Exception ex)
        {
            Debug.WriteLine("CustomerService - GetCustomerFrom:: " + ex.Message);
            return null; // Error occurred during retrieval
        }
    }

    //Returns all customers
    public IEnumerable<ICustomer> GetCustomersFromList()
    {
        try
        {
            var content = _fileService.GetContentFromFile(_filePath);

            if (!string.IsNullOrEmpty(content))
            {
                _customers = JsonConvert.DeserializeObject<List<ICustomer>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })!;
                return _customers;
            }
        }
        catch (Exception ex) { Debug.WriteLine("CustomerService - GetCustomersFromList:: " + ex.Message); }
        return null!;
    }

    public bool DeleteCustomer(ICustomer customer)
    {
        try
        {
            var customerToRemove = _customers.FirstOrDefault(c => c.Email == customer.Email);
            if (customerToRemove != null)
            {
                _customers.Remove(customerToRemove);

                string json = JsonConvert.SerializeObject(_customers, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                _fileService.SaveContentToFile(_filePath, json);

                return true; // Customer deleted successfully
            }
            else
            {
                return false; // Customer with the specified email not found
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("CustomerService - DeleteCustomer:: " + ex.Message);
            return false; // Error occurred during deletion
        }
    }
}
