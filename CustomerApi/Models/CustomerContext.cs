using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Models
{
    public class CustomerContext : DbContext, ICustomerContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public void MarkAsModified(Customer customer)
        {
            Entry(customer).State = EntityState.Modified;
        }
    }
}
