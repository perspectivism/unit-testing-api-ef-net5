using CustomerApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerApi.Tests.Mocks
{
    public class TestCustomerContext : ICustomerContext
    {
        public TestCustomerContext()
        {
            Customers = new TestCustomerDbSet();
        }

        public DbSet<Customer> Customers { get; set; }

        public void Dispose() { }

        public void MarkAsModified(Customer customer) { }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(0);
        }
    }
}
