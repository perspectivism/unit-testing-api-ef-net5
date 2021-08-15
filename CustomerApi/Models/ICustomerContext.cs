using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerApi.Models
{
    public interface ICustomerContext : IDisposable
    {
        DbSet<Customer> Customers { get; }
        void MarkAsModified(Customer customer);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
